Imports rdman.processWindowState

Module monitorFunctions
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
                            If DateDiff(DateInterval.Second, Convert.ToDateTime(node(5)), Now) > 15 Then
                                mainForm.monitor.Items(nodeId).StateImageIndex = 0
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
                        End Try
                    Case "(module)", "(running)"
                        Try
                            remoteSession = Process.GetProcessById(Convert.ToInt32(node(3)))
                            If DateDiff(DateInterval.Second, Convert.ToDateTime(node(5)), Now) > 15 Then
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

                If MyWindow IsNot Nothing Then
                    If MyWindow.Width > 1280 Then
                        MyWindow = MyWindow.GetThumbnailImage(MyWindow.Width / 7, MyWindow.Height / 7, Nothing, System.IntPtr.Zero)
                    ElseIf GetProcessWindowState(window) <> FormWindowState.Minimized Then
                        MyWindow = MyWindow.GetThumbnailImage(MyWindow.Width / 5, MyWindow.Height / 5, Nothing, System.IntPtr.Zero)
                    End If
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

        For Each node As ListViewItem In mainForm.sourcesList.CheckedItems
            If node.Text.Contains("[") And node.Text.Contains("]") Then
                nodeName = node.Text.Remove(0, node.Text.LastIndexOf("["))
                nodeName = nodeName.Replace("[", "")
                nodeName = nodeName.Replace("]", "")
                nodeName = nodeName.Substring(0, nodeName.LastIndexOf(":"))

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
End Module
