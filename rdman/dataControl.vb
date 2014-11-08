Imports System.Xml

Module dataControl
    Dim windir As String = System.Environment.ExpandEnvironmentVariables("%windir%")
    Dim mstscPath As String = windir + "\system32\mstsc.exe"
    Public mstsc As Process
    Dim ProcessProperties As New ProcessStartInfo

    Public Sub saveSource(ByVal nodeIP As String, ByVal nodePort As String, ByVal nodeName As String, ByVal nodeWidth As String, ByVal nodeHeight As String, ByVal nodeSystem As String, ByVal nodeVersion As String, ByVal nodeDescription As String, ByVal nodeFullscreen As Boolean)

    End Sub

    Public Sub LoadSources(ByVal sources As String)
        mainForm.statistics("Loading Sources Database file from " + sources)
        'Dim reader As IO.StreamReader = New IO.StreamReader(sourcesDb)
        'Do While reader.EndOfStream = False
        '    mainForm.sourcesList.Items.Add(reader.ReadLine)
        'Loop
        'reader.Close()
    End Sub

    Public Sub loadSourceData(ByVal nodeName As String)
        'mainForm.boxName.Text = nodeName
        'mainForm.boxIP.Text = nodeIP
        'mainForm.boxPort.Text = nodePort
        'mainForm.boxSystem.Text = nodeSystem
        'mainForm.boxSystemVersion.Text = nodeVersion
        'mainForm.boxDescription.Text = nodeDescription
        'mainForm.boxFullscreen.Checked = nodeFullscreen
        'mainForm.boxWidth.Text = nodeWidth
        'mainForm.boxHeight.Text = nodeHeight
        'mainForm.boxPicture.Image = mainForm.operatingSystemsImages.Images.Item(mainForm.boxSystem.SelectedIndex)
    End Sub

    Public Sub deleteSource(ByVal nodeName As String)

    End Sub

    Public Function runRemote(ByVal nodeIP As String, ByVal nodePort As String, ByVal nodeFullscreen As Boolean, ByVal nodeWidth As String, ByVal nodeHeight As String) As Integer
        If nodeIP <> "" Then
            If nodePort = "" Then
                nodePort = "3389"
            End If

            ProcessProperties.FileName = mstscPath

            If nodeFullscreen = True Then
                ProcessProperties.Arguments = "/v:" + nodeIP + ":" + nodePort + " /f"
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
                mainForm.statistics("Execution > " + mstscPath + " " + ProcessProperties.Arguments)
                Return mstsc.Id
            Else
                mainForm.statistics("Execution ends with error.")
                Return 0
            End If

        Else
            MessageBox.Show("IP Address cannot be empty.", "IP Address null", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return 0
        End If
    End Function

    Public Function runRemote(ByVal nodeIP As String, ByVal nodePort As String, ByVal nodeFullscreen As Boolean)
        Return runRemote(nodeIP, nodePort, nodeFullscreen, "1024", "768")
    End Function
End Module
