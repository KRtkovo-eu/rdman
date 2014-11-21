Imports rdman.processWindowState

Module monitorFunctions
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
                        If DateDiff(DateInterval.Second, Convert.ToDateTime(node(5)), Now) > 15 Then
                            mainForm.monitor.Items(nodeId).StateImageIndex = 0
                            Try
                                remoteSession = Process.GetProcessById(Convert.ToInt32(node(3)))
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
                        End If
                    Case "(module)", "(running)"
                        If DateDiff(DateInterval.Second, Convert.ToDateTime(node(5)), Now) > 15 Then
                            mainForm.monitor.Items(nodeId).StateImageIndex = 0
                            Try
                                remoteSession = Process.GetProcessById(Convert.ToInt32(node(3)))
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
                        End If
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
    Dim lastLoad As Date = Now

    Public Function getWindowScreenshot(ByVal PID As Integer, ByVal delay As Integer) As Image
        lastPid = 0
        Try
            If (PID <> lastPid Or DateDiff(DateInterval.Second, lastLoad, Now) >= delay) And Process.GetProcessById(PID).HasExited = False Then
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
            ElseIf PID = lastPid Then
                Return MyWindow
            Else
                Return Nothing
            End If
        Catch
            Return Nothing
        End Try
    End Function

    Public Function getWindowScreenshot(ByVal PID As String, ByVal delay As Integer) As Image
        Return getWindowScreenshot(Convert.ToInt32(PID), delay)
    End Function
End Module
