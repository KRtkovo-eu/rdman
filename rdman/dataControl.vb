Imports System.Xml
Imports System.IO

Module dataControl
    Dim windir As String = System.Environment.ExpandEnvironmentVariables("%windir%")
    Dim mstscPath As String = windir + "\system32\mstsc.exe"
    Public mstsc As Process
    Dim ProcessProperties As New ProcessStartInfo
    Dim nodes As List(Of String())
    Dim monitorNodes As List(Of String()) = New List(Of String())

    Function csvArray(ByVal sources As String) As List(Of String())
        Dim afile As FileIO.TextFieldParser = New FileIO.TextFieldParser(sources)
        Dim csvLine As String()

        afile.TextFieldType = FileIO.FieldType.Delimited
        afile.Delimiters = New String() {";"}
        afile.HasFieldsEnclosedInQuotes = False

        nodes = New List(Of String())

        ' parse the actual file
        Do While Not afile.EndOfData
            csvLine = afile.ReadFields
            nodes.Add(csvLine)
        Loop

        Return nodes
    End Function

    Public Function IsPathWritable(ByVal strPath As String) As Boolean
        IsPathWritable = True
        If Not Directory.Exists(strPath) Then
            IsPathWritable = False
        Else
            Try
                Dim fs As FileStream = File.Create(strPath & "\WriteTest.txt")
                fs.Close()
            Catch ex As IOException
                IsPathWritable = False
            Finally
                If File.Exists(strPath & "\WriteTest.txt") And IsPathWritable Then File.Delete(strPath & "\WriteTest.txt")
            End Try
        End If
    End Function

    Public Sub statistics(ByVal newLine As String, ByVal command As Boolean)
        If command = True Then
            mainForm.boxStatistics.AppendText(DateTime.Now.ToString("<HH:mm:ss>#:") + newLine + vbNewLine)
        Else
            mainForm.boxStatistics.AppendText(DateTime.Now.ToString("<HH:mm:ss>$:") + newLine + vbNewLine)
        End If
    End Sub

    Public Sub statistics(ByVal newLine As String)
        statistics(newLine, False)
    End Sub

    Public Sub statisticsEnvironment()
        Dim compTitle As String = ""

        'Line
        Dim username As String = My.User.Name
        username = username.Substring(username.LastIndexOf("\") + 1)

        compTitle = "Hello " + username + "!"
        compTitle += " Today is nice " + Today.ToString("dddd, yyyy/MM/dd.")

        statistics(compTitle)

        'Line

        compTitle = "Environment: "
        compTitle += My.Computer.Name
        compTitle += " (system: "
        compTitle += My.Computer.Info.OSFullName
        compTitle += "| locale: "
        compTitle += My.Computer.Info.InstalledUICulture.EnglishName
        compTitle += "| memory free: "
        compTitle += SetBytes(My.Computer.Info.AvailablePhysicalMemory)
        compTitle += "/total: "
        compTitle += SetBytes(My.Computer.Info.TotalPhysicalMemory)
        compTitle += ")"

        If My.Computer.Network.IsAvailable = True Then
            compTitle += " is connected to network. Ready to work!"

        Else
            compTitle += "is not connected to network."
        End If

        statistics(compTitle)

        statistics("Check the news on our GitHub page! [http://github.com/KRtkovo-eu/rdman/]")
    End Sub

    Public Sub saveSource(ByVal nodeName As String, ByVal sourcesDb As String)
        Dim db As List(Of String())

        db = deleteSource(nodeName, sourcesDb)

        Dim sourceData As String() = {nodeName, mainForm.boxIP.Text, mainForm.boxPort.Text, mainForm.boxFullscreen.Checked.ToString, mainForm.boxMultimon.Checked.ToString, mainForm.boxWidth.Text, mainForm.boxHeight.Text, mainForm.boxSystem.Text, mainForm.boxSystemVersion.Text, mainForm.boxDescription.Text, mainForm.boxConnectOver.Checked, mainForm.boxViewerPath.Text}

        db.Add(sourceData)

        If IsPathWritable(sourcesDb.Replace(sourcesDb.Substring(sourcesDb.LastIndexOf("\") + 1), "")) = False Then
            MessageBox.Show(sourcesDb + vbNewLine + "is not writable.", "Cannot write to database", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            mainForm.NewEmptySourcesDatabaseToolStripMenuItem_Click(Nothing, New System.EventArgs)
        End If

        Dim objWriter As New System.IO.StreamWriter(sourcesDb)

        For Each element In db
            Dim line As String = ""
            For Each field In element
                line += field + ";"
            Next
            line = line.Substring(0, line.Length - 1)

            'line = element(0) + ";"
            'line += element(1) + ";"
            'line += element(2) + ";"
            'line += element(3) + ";"
            'line += element(4) + ";"
            'line += element(5) + ";"
            'line += element(6) + ";"
            'line += element(7) + ";"
            'line += element(8) + ";"
            'line += element(9) + ";"
            'line += element(10) + ";"
            'line += element(11)

            objWriter.WriteLine(line)
        Next

        objWriter.Close()
        statistics("Node ~" + nodeName + "~ successfully saved.")

        LoadSources(sourcesDb)
    End Sub

    Public Sub LoadSources(ByVal sources As String)
        mainForm.sourcesList.Clear()
        mainForm.sourcesList.Items.Add("Add New Node", 5)

        For Each element In csvArray(sources)
            mainForm.sourcesList.Items.Add(element(0), systemToIndexNum(element(7)))
        Next

        mainForm.boxSourcesPath.Text = "Loaded: " + sources.Substring(sources.LastIndexOf("\") + 1)
        statistics("Loaded sources database file from " + sources)
    End Sub

    Public Sub loadSourceData(ByVal nodeName As String)
        Dim nodeIP As String = ""
        Dim nodePort As String = ""
        Dim nodeSystem As String = ""
        Dim nodeVersion As String = ""
        Dim nodeDescription As String = ""
        Dim nodeWidth As String = ""
        Dim nodeHeight As String = ""
        Dim nodeFullscreen As Boolean = False
        Dim nodeMultimon As Boolean = False
        Dim nodeSystemNum As Integer
        Dim nodeConnectOver As Boolean = False
        Dim nodeViewerPath As String = ""

        If nodeName = "EMPTY" Then
            nodeName = "New node"
            nodeIP = "127.0.0.1"
            nodePort = "3389"
            nodeSystem = "other"
            nodeVersion = "unknown system"
            nodeDescription = "Node description"
            nodeFullscreen = False
            nodeWidth = "1024"
            nodeHeight = "768"
            nodeSystemNum = 4
            nodeMultimon = False
            nodeConnectOver = False
            nodeViewerPath = ""
        Else
            For Each element In nodes
                If element(0) = nodeName Then
                    nodeName = element(0)
                    nodeIP = element(1)
                    nodePort = element(2)
                    nodeSystem = element(7)
                    nodeVersion = element(8)
                    nodeDescription = element(9)
                    nodeFullscreen = element(3)
                    nodeWidth = element(5)
                    nodeHeight = element(6)
                    nodeSystemNum = systemToIndexNum(element(7))
                    nodeMultimon = element(4)
                    nodeConnectOver = element(10)
                    nodeViewerPath = element(11)
                End If
            Next
        End If

        mainForm.boxName.Text = nodeName
        mainForm.boxIP.Text = nodeIP
        mainForm.boxPort.Text = nodePort
        mainForm.boxSystem.Text = nodeSystem
        mainForm.boxSystemVersion.Text = nodeVersion
        mainForm.boxDescription.Text = nodeDescription
        mainForm.boxFullscreen.Checked = nodeFullscreen
        mainForm.boxWidth.Text = nodeWidth
        mainForm.boxHeight.Text = nodeHeight
        mainForm.boxPicture.Image = mainForm.operatingSystemsImages.Images.Item(nodeSystemNum)
        mainForm.boxMultimon.Checked = nodeMultimon
        mainForm.boxConnectOver.Checked = nodeConnectOver
        mainForm.boxViewerPath.Text = nodeViewerPath

        statistics("Loaded source ~" + nodeName + "~ (system: " + nodeSystem + "| IP or hostname: " + nodeIP + ":" + nodePort + ")")
    End Sub

    Public Function deleteSource(ByVal nodeName As String, ByVal sourcesDb As String) As List(Of String())
        Dim db As List(Of String())

        db = csvArray(sourcesDb)

        Try
            Dim marker As Integer = 0

            For Each element In nodes
                If element(0) = nodeName Then
                    db.RemoveAt(db.IndexOf(element))
                    Exit For
                End If
                marker = marker + 1
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

        Return db
    End Function

    Public Function runRemote(ByVal nodeIP As String, ByVal nodePort As String, ByVal nodeFullscreen As Boolean, ByVal nodeWidth As String, ByVal nodeHeight As String, ByVal nodeMultimon As Boolean, ByVal nodeConnectOver As Boolean, ByVal nodeViewer As String, ByVal nodeName As String) As Integer
        If nodeIP <> "" Then
            statistics("Connecting to " + nodeName)

            If My.Computer.Network.Ping(nodeIP) = False Then
                statistics("Ping on " + nodeIP + " > Connection timed out or host is unavailable.")
            Else
                statistics("Ping on " + nodeIP + " > Host is available.")
            End If

            If nodePort = "" Then
                nodePort = "3389"
            End If

            If nodeConnectOver = False Then
                ProcessProperties.FileName = mstscPath

                If nodeFullscreen = True Then
                    If nodeMultimon = True Then
                        ProcessProperties.Arguments = "/v:" + nodeIP + ":" + nodePort + " /multimon"
                    Else
                        ProcessProperties.Arguments = "/v:" + nodeIP + ":" + nodePort + " /f"
                    End If
                Else
                    If nodeWidth = "" Then
                        nodeWidth = "1024"
                    End If

                    If nodeHeight = "" Then
                        nodeHeight = "768"
                    End If

                    ProcessProperties.Arguments = "/v:" + nodeIP + ":" + nodePort + " /w:" + nodeWidth + " /h:" + nodeHeight
                End If

            Else
                If nodeViewer <> "" And My.Computer.FileSystem.FileExists(nodeViewer) = True Then
                    ProcessProperties.FileName = nodeViewer
                    ProcessProperties.Arguments = nodeIP + ":" + nodePort
                Else
                    MessageBox.Show("Viewer is not found or path is empty!", "Viewer not found", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return 0
                    Exit Function
                End If
            End If

            mstsc = Process.Start(ProcessProperties)

            Dim monitorNodeDetails As String()

            If mstsc.HasExited = False Then
                monitorNodeDetails = {nodeName, nodeIP + ":" + nodePort, "(connected)", mstsc.Id.ToString, ProcessProperties.FileName.Substring(ProcessProperties.FileName.LastIndexOf("\") + 1) + " " + ProcessProperties.Arguments, DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")}
                setMonitor(monitorNodeDetails, True)
                statistics("Execution > " + ProcessProperties.FileName + " " + ProcessProperties.Arguments)
                Return mstsc.Id
            Else
                monitorNodeDetails = {nodeName, nodeIP + ":" + nodePort, "(failed)", "0", ProcessProperties.FileName.Substring(ProcessProperties.FileName.LastIndexOf("\") + 1) + " " + ProcessProperties.Arguments, DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")}
                setMonitor(monitorNodeDetails, False)
                statistics("Execution > " + ProcessProperties.FileName + " " + ProcessProperties.Arguments)
                statistics("Unexpectedly ended...")
                Return 0
            End If
        Else
            MessageBox.Show("IP Address cannot be empty!", "IP Address null", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return 0
        End If
    End Function

    Public Function SetBytes(ByVal number As ULong) As String
        Select Case number
            Case Is >= 1073741824
                Return (number / 1024 / 1024 / 1024).ToString("F2") + " GB"
            Case Is >= 1048576
                Return (number / 1024 / 1024).ToString("F2") + " MB"
            Case Is >= 1024
                Return (number / 1024).ToString("F2") + " KB"
            Case Else
                Return number.ToString + " Bytes"
        End Select
    End Function

    Public Function systemToIndexNum(ByVal system As String) As Integer
        Select Case system
            Case "Windows"
                Return 0
            Case "Linux"
                Return 1
            Case "Android"
                Return 2
            Case "MacOS"
                Return 3
            Case Else
                Return 4
        End Select
    End Function

    Private Sub setMonitor(ByVal node As String(), ByVal success As Boolean)
        If node IsNot Nothing Then
            monitorNodes.Add(node)

            Dim listViewItem As ListViewItem = mainForm.monitor.Items.Add(node(0))

            If success = True Then
                listViewItem.StateImageIndex = 0
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

        For Each node In monitorNodes
            If node(2) = "(connected)" Then
                Try
                    remoteSession = Process.GetProcessById(Convert.ToInt32(node(3)))

                    If remoteSession.HasExited = True Then
                        node(2) = "(disconnected)"
                        mainForm.monitor.Items(nodeId).SubItems(2).Text = "(disconnected)"
                        mainForm.monitor.Items(nodeId).StateImageIndex = 1
                        mainForm.monitor.Items(nodeId).Font = New Font("Segoe UI", 8, FontStyle.Italic, GraphicsUnit.Point)
                        mainForm.monitor.Items(nodeId).ForeColor = Color.Gray
                    End If
                Catch
                    node(2) = "(disconnected)"
                    mainForm.monitor.Items(nodeId).SubItems(2).Text = "(disconnected)"
                    mainForm.monitor.Items(nodeId).StateImageIndex = 1
                    mainForm.monitor.Items(nodeId).Font = New Font("Segoe UI", 8, FontStyle.Italic, GraphicsUnit.Point)
                    mainForm.monitor.Items(nodeId).ForeColor = Color.Gray
                End Try
            End If
            nodeId = nodeId + 1
        Next
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
End Module
