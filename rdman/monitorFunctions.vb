Imports rdman.processWindowState

Class MonitorFunctions
    Public Event MonitorRedraw(ByVal MonitorItems As ListView)
    Public monitorNodes As List(Of String()) = New List(Of String())

    Public Sub setMonitor(ByVal node As String(), ByVal success As Boolean)
        setMonitor(node, success, False)
    End Sub

    Public Sub setMonitor(ByVal node As String(), ByVal success As Boolean, ByVal moduleRun As Boolean)
        If node IsNot Nothing Then
            monitorNodes.Add(node)

            Dim listViewItem As ListViewItem = mainForm.monitor.Items.Add(node(0))

            If success = True Then
                listViewItem.StateImageIndex = 3

                If moduleRun = True Then
                    listViewItem.ForeColor = Color.SteelBlue
                End If
            Else
                listViewItem.StateImageIndex = 2
                listViewItem.Font = New Font("Segoe UI", 8, FontStyle.Italic, GraphicsUnit.Point)
                listViewItem.ForeColor = Color.Red
            End If

            For x = 1 To node.Length - 1
                listViewItem.SubItems.Add(node(x))
            Next
        End If

        RaiseEvent MonitorRedraw(mainForm.monitor)
    End Sub

    Public Sub monitorCheckStates()
        Dim remoteSession As Process = New Process
        Dim nodeId As Integer = 0

        If monitorNodes IsNot Nothing Then
            For Each node In monitorNodes
                Select Case node(2)
                    Case "(connected)"
                        Try
                            remoteSession = Process.GetProcessById(Convert.ToInt32(node(3)))
                            If remoteSession.MainWindowHandle <> IntPtr.Zero And Not remoteSession.HasExited Then
                                mainForm.monitor.Items(nodeId).StateImageIndex = 0
                            End If

                            'Ask for some process data to catch ghost dead processes
                            Dim x = remoteSession.PrivateMemorySize64

                            If remoteSession.ProcessName.Contains("mstsc") And (DateTime.Now - remoteSession.StartTime).TotalSeconds >= 60 And remoteSession.MainWindowHandle = IntPtr.Zero And Not remoteSession.HasExited Then
                                remoteSession.Kill()
                            End If
                        Catch
                            node(2) = "(disconnected)"
                            mainForm.monitor.Items(nodeId).SubItems(2).Text = "(disconnected)"
                            mainForm.monitor.Items(nodeId).StateImageIndex = 1
                            mainForm.monitor.Items(nodeId).Font = New Font("Segoe UI", 8, FontStyle.Italic, GraphicsUnit.Point)
                            mainForm.monitor.Items(nodeId).ForeColor = Color.Gray

                            Dim started As Date = Convert.ToDateTime(node(5))
                            Dim elapsed As String = DateDiff(DateInterval.Second, started, Now)

                            statistics("Remote session on " + node(0) + " (pid: " + node(3) + ") has terminated after " + elapsed + " seconds long run.")

                            'Write statistics about how long you have opened session in CSV file.
                            'Format is: Day of start; Time of start; Date of end; Time of end; Elapsed time; Process arguments
                            Try
                                Dim statsNode As String = ""
                                Dim statsFolderPath As String = My.Application.Info.DirectoryPath + "\statistics\"

                                If System.IO.Directory.Exists(statsFolderPath) = False Then
                                    System.IO.Directory.CreateDirectory(statsFolderPath)
                                End If

                                Dim exportedNodeFilePath As String = statsFolderPath + node(0) + ".csv"
                                Dim objWriter As New System.IO.StreamWriter(exportedNodeFilePath, True)

                                objWriter.Write(DateTime.Parse(node(5)).ToString("yyyy-MM-dd;HH:mm:ss") + ";" + DateTime.Now.ToString("yyyy-MM-dd;HH:mm:ss") + ";" + elapsed + ";" + node(4) + vbNewLine)
                                objWriter.Close()
                            Catch
                            End Try
                        End Try
                    Case "(module)", "(running)"
                        Try
                            remoteSession = Process.GetProcessById(Convert.ToInt32(node(3)))
                            If remoteSession.MainWindowHandle <> IntPtr.Zero Then
                                mainForm.monitor.Items(nodeId).StateImageIndex = 4
                            End If

                        Catch
                            node(2) = "(closed)"
                            mainForm.monitor.Items(nodeId).SubItems(2).Text = "(closed)"
                            mainForm.monitor.Items(nodeId).StateImageIndex = 1
                            mainForm.monitor.Items(nodeId).Font = New Font("Segoe UI", 8, FontStyle.Italic, GraphicsUnit.Point)
                            mainForm.monitor.Items(nodeId).ForeColor = Color.Gray

                            Dim started As Date = Convert.ToDateTime(node(5))
                            Dim elapsed As String = DateDiff(DateInterval.Second, started, Now)

                            statistics("Process " + node(0) + " (pid: " + node(3) + ") has terminated after " + elapsed + " seconds long run.")
                        End Try
                End Select
                nodeId = nodeId + 1
            Next
        End If

        RaiseEvent MonitorRedraw(mainForm.monitor)
    End Sub

    Public Sub monitorDelNode(ByVal nodeName As String, ByVal PID As String)
        Dim nodeId As Integer = 0

        For Each node In monitorNodes
            If node(0) = nodeName And node(3) = PID Then
                monitorNodes.RemoveAt(nodeId)
                mainForm.monitor.Items(nodeId).Remove()
                Exit Sub
            End If
            nodeId = nodeId + 1
        Next

        RaiseEvent MonitorRedraw(mainForm.monitor)
    End Sub

    Public lastPid As Integer
    Dim MyWindow As Image

    Public Function getWindowScreenshot(ByVal PID As Integer) As Image
        lastPid = 0
        Try
            If Process.GetProcessById(PID).HasExited = False Then
                lastPid = PID

                Dim window As IntPtr = Process.GetProcessById(PID).MainWindowHandle
                Dim SC As New ScreenShot.ScreenCapture

                MyWindow = SC.CaptureWindow(window)

                If (MyWindow IsNot Nothing) And (GetProcessWindowState(window) <> FormWindowState.Minimized) Then
                    Select Case MyWindow.Width
                        Case Is >= 1280
                            MyWindow = MyWindow.GetThumbnailImage(MyWindow.Width / 7, MyWindow.Height / 7, Nothing, System.IntPtr.Zero)
                        Case 800 To 1279
                            MyWindow = MyWindow.GetThumbnailImage(MyWindow.Width / 5, MyWindow.Height / 5, Nothing, System.IntPtr.Zero)
                        Case 400 To 799
                            MyWindow = MyWindow.GetThumbnailImage(MyWindow.Width / 3, MyWindow.Height / 3, Nothing, System.IntPtr.Zero)
                        Case Is < 400
                            MyWindow = MyWindow.GetThumbnailImage(MyWindow.Width / 2, MyWindow.Height / 2, Nothing, System.IntPtr.Zero)
                    End Select
                End If
                Return MyWindow
            Else
                Return Nothing
            End If
        Catch
            Return Nothing
        End Try
    End Function

    Public Function getWindowScreenshot(ByVal PID As String) As Image
        Return getWindowScreenshot(Convert.ToInt32(PID))
    End Function

    Public Sub pingNodes()
        Dim nodeName As String = ""

        mainForm.pingProgressBar.Visible = True
        mainForm.pingProgressBar.Maximum = mainForm.sourcesList.CheckedItems.Count
        mainForm.pingProgressBar.Value = 0
        mainForm.Cursor = Cursors.WaitCursor

        For Each node In mainForm.sourcesList.CheckedItems

            If node.Text.Contains("[") And node.Text.Contains("]") Then
                nodeName = node.Text.Remove(0, node.Text.LastIndexOf("["))
                nodeName = nodeName.Replace("[", "")
                nodeName = nodeName.Replace("]", "")
                If nodeName.Contains(":") Then
                    nodeName = nodeName.Substring(0, nodeName.LastIndexOf(":"))
                End If

                Try
                    If My.Computer.Network.Ping(nodeName) = True Then
                        'node.StateImageIndex = 0
                        node.ForeColor = Color.Green
                        statistics("Ping on " + nodeName + " > successful.")
                    Else
                        'node.StateImageIndex = 2
                        node.ForeColor = Color.Red
                        statistics("Ping on " + nodeName + " > host unreachable.")
                    End If

                    'If checkAddress("http://" + nodeName) = True Then
                    '    statistics("Webserver is available on http://" + nodeName)
                    'End If
                Catch ex As Exception
                    node.ForeColor = Color.Red
                    statistics("Ping on " + nodeName + " > " + ex.Message)
                End Try
            End If

            mainForm.pingProgressBar.Value = mainForm.pingProgressBar.Value + 1
        Next

        mainForm.pingProgressBar.Visible = False
        mainForm.Cursor = Cursors.Default
    End Sub

#Region "ProcessFunctions"
    Public Function ReturnSelectedProcess() As ListViewItem
        If mainForm.monitor.SelectedItems.Count > 0 Then
            Return mainForm.monitor.SelectedItems.Item(0)
        Else
            Return Nothing
        End If
    End Function

    Public Function ReturnProcessPID(ByVal processItem As ListViewItem) As Integer
        If processItem IsNot Nothing Then
            Return Convert.ToInt32(processItem.SubItems(3).Text)
        Else
            Return 0
        End If
    End Function

    Public Function ReturnProcessState(ByVal processItem As ListViewItem) As String
        If processItem IsNot Nothing Then
            Dim processStateString As String = processItem.SubItems(2).Text

            Select Case processStateString
                Case "(connected)"
                    Return ProcessState.connected
                Case "(disconnected)"
                    Return ProcessState.disconnected
                Case "(running)", "(module)"
                    Return ProcessState.running
                Case "(failed)"
                    Return ProcessState.failed
                Case "(closed)"
                    Return ProcessState.closed
            End Select
        End If
        Return Nothing
    End Function

    Public Function IsSelectedProcessDead(ByVal processItem As ListViewItem) As Boolean
        If processItem IsNot Nothing Then
            Select Case ReturnProcessState(processItem)
                Case ProcessState.closed, ProcessState.disconnected, ProcessState.failed
                    Return True
                Case ProcessState.connected, ProcessState.running
                    Return False
            End Select
        End If
        Return True
    End Function

    Public Enum ProcessState
        connected
        disconnected
        running
        closed
        failed
    End Enum
#End Region
End Class
