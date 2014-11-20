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
                listViewItem.StateImageIndex = 0

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

    Dim lastPid As Integer
    Dim MyWindow As Image

    Public Function getWindowScreenshot(ByVal PID As Integer) As Image
        If PID <> lastPid Then
            lastPid = PID

            Dim window As IntPtr = Process.GetProcessById(PID).MainWindowHandle
            Dim SC As New ScreenShot.ScreenCapture

            MyWindow = SC.CaptureWindow(window)

            If GetProcessWindowState(window) <> FormWindowState.Minimized Then
                MyWindow = MyWindow.GetThumbnailImage(MyWindow.Width / 4, MyWindow.Height / 4, Nothing, System.IntPtr.Zero)
            End If

            Return MyWindow
        ElseIf PID = lastPid Then
            Return MyWindow
        Else
            Return Nothing
        End If
    End Function

    Public Function getWindowScreenshot(ByVal PID As String) As Image
        Return getWindowScreenshot(Convert.ToInt32(PID))
    End Function
End Module
