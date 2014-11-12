Imports System.Xml

Module dataControl
    Dim windir As String = System.Environment.ExpandEnvironmentVariables("%windir%")
    Dim mstscPath As String = windir + "\system32\mstsc.exe"
    Public mstsc As Process
    Dim ProcessProperties As New ProcessStartInfo
    Dim nodes As List(Of String())

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

    Public Function statisticsEnvironment() As String
        Dim compTitle As String

        compTitle = "Environment: "
        compTitle += My.Computer.Name
        compTitle += " (system: "
        compTitle += My.Computer.Info.OSFullName
        compTitle += "| locale: "
        compTitle += My.Computer.Info.InstalledUICulture.EnglishName
        compTitle += "| memory: "
        compTitle += SetBytes(My.Computer.Info.AvailablePhysicalMemory)
        compTitle += "/"
        compTitle += SetBytes(My.Computer.Info.TotalPhysicalMemory)
        compTitle += ")"

        If My.Computer.Network.IsAvailable = True Then
            compTitle += " is connected to network. Ready to work!"

        Else
            compTitle += "is not connected to network."
        End If

        Return compTitle
    End Function

    Public Sub saveSource(ByVal nodeName As String, ByVal sourcesDb As String)
        deleteSource(nodeName)

        Dim sourceData As String() = {nodeName, mainForm.boxIP.Text, mainForm.boxPort.Text, mainForm.boxFullscreen.Checked.ToString, mainForm.boxMultimon.Checked.ToString, mainForm.boxWidth.Text, mainForm.boxHeight.Text, mainForm.boxSystem.Text, mainForm.boxSystemVersion.Text, mainForm.boxDescription.Text}

        nodes.Add(sourceData)

        Dim objWriter As New System.IO.StreamWriter(sourcesDb)

        For Each element In nodes
            Dim line As String
            line = element(0) + ";"
            line += element(1) + ";"
            line += element(2) + ";"
            line += element(3) + ";"
            line += element(4) + ";"
            line += element(5) + ";"
            line += element(6) + ";"
            line += element(7) + ";"
            line += element(8) + ";"
            line += element(9)

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
            mainForm.sourcesList.Items.Add(element(0), systemToIndexNum(element(6)))
        Next

        'mainForm.boxSourcesPath.Text = "CSV database: " + sources
        statistics("Loaded Sources Database file from " + sources)
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
        statistics("Loaded source ~" + nodeName + "~ (system: " + nodeSystem + "| IP or hostname: " + nodeIP + ":" + nodePort + ")")
    End Sub

    Public Sub deleteSource(ByVal nodeName As String)
        Try
            Dim marker As Integer

            For Each element In nodes
                If element(0) = nodeName Then
                    nodes.RemoveAt(marker)
                End If
                marker = marker + 1
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Public Function runRemote(ByVal nodeIP As String, ByVal nodePort As String, ByVal nodeFullscreen As Boolean, ByVal nodeWidth As String, ByVal nodeHeight As String, ByVal nodeMultimon As Boolean) As Integer
        If nodeIP <> "" And nodeIP <> "127.0.0.1" Then
            If nodePort = "" Then
                nodePort = "3389"
            End If

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

                mstsc = Process.Start(ProcessProperties)
                If mstsc.HasExited = False Then
                    statistics("Execution > " + mstscPath + " " + ProcessProperties.Arguments)
                    Return mstsc.Id
                Else
                    statistics("Execution ends with error.")
                    Return 0
                End If
            ElseIf nodeIP = "127.0.0.1" Then
                'MessageBox.Show("Connecting to localhost is not allowed.", "Cannot connect to localhost", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return 1
            Else
                MessageBox.Show("IP Address cannot be empty.", "IP Address null", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return 0
            End If
    End Function

    Public Function runRemote(ByVal nodeIP As String, ByVal nodePort As String, ByVal nodeFullscreen As Boolean, ByVal nodeMultimon As Boolean)
        Return runRemote(nodeIP, nodePort, nodeFullscreen, "1024", "768", nodeMultimon)
    End Function

    Public Function runRemote(ByVal nodeIP As String, ByVal nodePort As String, ByVal nodeFullscreen As Boolean)
        Return runRemote(nodeIP, nodePort, nodeFullscreen, "1024", "768", False)
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
End Module
