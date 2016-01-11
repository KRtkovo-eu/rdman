Imports System
Imports System.Runtime.InteropServices
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.IO
Imports System.Net

Module dataControl
#Region "Global variables"
    Dim windir As String = System.Environment.ExpandEnvironmentVariables("%windir%")
    Dim mstscPath As String = windir + "\system32\mstsc.exe"
    Public mstsc As Process
    Dim ProcessProperties As New ProcessStartInfo
    Dim nodes As List(Of String())
    Const csvLineNumOfFields As Integer = 14
#End Region

#Region "Function for fillig nodes array"
    Function csvArray(ByVal sources As String) As List(Of String())
        Dim afile As FileIO.TextFieldParser = New FileIO.TextFieldParser(sources)
        Dim csvLine As String()
        Dim csvNodes As List(Of String())

        afile.TextFieldType = FileIO.FieldType.Delimited
        afile.Delimiters = New String() {";"}
        afile.HasFieldsEnclosedInQuotes = False

        csvNodes = New List(Of String())

        ' parse the actual file
        Do While Not afile.EndOfData
            csvLine = afile.ReadFields
            csvNodes.Add(csvLine)
        Loop

        'Check if the database file contains all fields.
        If csvNodes.Item(0).Length < csvLineNumOfFields Then
            MessageBox.Show("Sources database file was created by previous version of Remote Desktop Manager.", "Database file cannot be used.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            statistics("Sources database file " + sources + " was created by previous version of Remote Desktop Manager and must be resolved manually before it can be loaded.")
        End If

        Return csvNodes
    End Function
#End Region

#Region "Misc"
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
            Case "Application"
                Return 5
            Case Else
                Return 4
        End Select
    End Function

    Public Function checkAddress(ByVal URL As String) As Boolean
        Try
            Dim request As WebRequest = WebRequest.Create(URL)
            Dim response As WebResponse = request.GetResponse()
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function
#End Region

#Region "Statistics functions"
    Public Sub statistics(ByVal lineStatistics As String, ByVal command As Boolean)
        Dim nowInFormat As String = DateTime.Now.ToString("<HH:mm:ss>")
        Dim toConsole As String

        mainForm.boxStatistics.AppendText(nowInFormat)
        toConsole = nowInFormat

        If command = True Then
            mainForm.boxStatistics.AppendText("#:")
            toConsole += "#:"
        Else
            mainForm.boxStatistics.AppendText("$:")
            toConsole += "$:"
        End If
        mainForm.boxStatistics.AppendText(" " + lineStatistics + vbNewLine)
        toConsole += " " + lineStatistics

        Console.WriteLine(toConsole)
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
        compTitle += " | locale: "
        compTitle += My.Computer.Info.InstalledUICulture.EnglishName
        compTitle += " | memory free: "
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

        statisticsModules()

        statistics("Check the news on our GitHub page! [http://github.com/KRtkovo-eu/rdman/]")
    End Sub

    Public Sub statisticsModules()
        Dim modulesPath As String = My.Application.Info.DirectoryPath + "\modules"
        Dim line As String = ""

        If IO.Directory.Exists(modulesPath) = True Then
            Dim modulesCount As Integer = 0
            line += vbNewLine + "Found these modules:" + vbNewLine

            For Each rdmanModule In IO.Directory.GetDirectories(modulesPath)
                line += vbTab + rdmanModule.Substring(rdmanModule.LastIndexOf("\") + 1) + vbNewLine
                modulesCount = modulesCount + 1
            Next
            line += "--- Total count: " + modulesCount.ToString
            line += vbNewLine

            statistics(line)
        End If
    End Sub
#End Region

#Region "Node details functions"
    Public Sub saveSource(ByVal nodeName As String, ByVal sourcesDb As String)
        saveSource(nodeName, sourcesDb, False)
    End Sub

    Public Sub saveSource(ByVal nodeName As String, ByVal sourcesDb As String, ByVal onlyDelete As Boolean)
        If nodeName <> "" And mainForm.boxIP.Text <> "" Then
            Dim db As List(Of String())

            db = deleteSource(nodeName, sourcesDb)

            If onlyDelete = False Then
                Dim autoconnect As Boolean = False
                If mainForm.btnAutoconnect.BackColor = Color.GreenYellow Then
                    autoconnect = True
                End If

                Dim sourceData As String() = {
                    nodeName,
                    mainForm.boxIP.Text,
                    mainForm.boxPort.Text,
                    mainForm.boxFullscreen.Checked.ToString,
                    mainForm.boxMultimon.Checked.ToString,
                    mainForm.boxWidth.Text,
                    mainForm.boxHeight.Text,
                    mainForm.boxSystem.Text,
                    mainForm.boxSystemVersion.Text,
                    mainForm.boxDescription.Text,
                    mainForm.boxConnectOver.Checked,
                    mainForm.boxViewerPath.Text,
                    autoconnect.ToString,
                    mainForm.textboxUsername.Text,
                    mainForm.textboxPassword.Text}

                db.Add(sourceData)
            End If

            Try
                Dim objWriter As New System.IO.StreamWriter(sourcesDb)

                For Each element In db
                    Dim line As String = ""
                    Dim fieldNum As Integer = 0

                    For Each field In element
                        If fieldNum = 14 Then
                            line += field.Replace(Environment.NewLine, "\n") + ";"
                        Else
                            line += field + ";"
                        End If

                        fieldNum = fieldNum + 1
                    Next
                    line = line.Substring(0, line.Length - 1)

                    objWriter.WriteLine(line)
                Next

                objWriter.Close()
                If onlyDelete = False Then
                    statistics("Source [" + nodeName + "] successfully saved.")
                Else
                    statistics("Source [" + nodeName + "] successfully deleted.")
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

            LoadSources(sourcesDb)
        End If
    End Sub

    Public Sub LoadSources(ByVal sources As String)
        mainForm.sourcesList.Clear()

        mainForm.sourcesList.Items.Add("(Add New Node)", 6)

        nodes = csvArray(sources)

        For Each element In nodes
            If element(2) <> "" Then
                mainForm.sourcesList.Items.Add(element(0) + " [" + element(1) + ":" + element(2) + "]", systemToIndexNum(element(7)))
            Else
                mainForm.sourcesList.Items.Add(element(0) + " [" + element(1) + "]", systemToIndexNum(element(7)))
            End If
        Next

        mainForm.boxSourcesPath.Text = "Loaded: " + sources.Substring(sources.LastIndexOf("\") + 1)
        statistics("Loaded sources database file from " + sources)
    End Sub

    Public Sub loadSourceData(ByVal nodeName As String, nodeIP As String, nodePort As String, nodeSystem As String, nodeVersion As String, nodeDescription As String, nodeWidth As String, nodeHeight As String, nodeFullscreen As Boolean, nodeMultimon As Boolean, nodeSystemNum As Integer, nodeConnectOver As Boolean, nodeViewerPath As String)
        Dim nodeAutoconnect As Boolean
        Dim username, password As String

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
            nodeAutoconnect = False
            username = ""
            password = ""
        ElseIf nodeIP = "" And nodePort = "" And nodeSystem = "" And nodeVersion = "" And nodeDescription = "" And nodeWidth = "" And nodeHeight = "" Then
            For Each element In nodes
                If element(0) = nodeName Then
                    nodeName = element(0)
                    nodeIP = element(1)
                    nodePort = element(2)
                    nodeSystem = element(7)
                    nodeVersion = element(8)
                    nodeDescription = element(9).Replace("\n", Environment.NewLine)
                    nodeFullscreen = Convert.ToBoolean(element(3))
                    nodeWidth = element(5)
                    nodeHeight = element(6)
                    nodeSystemNum = systemToIndexNum(element(7))
                    nodeMultimon = Convert.ToBoolean(element(4))
                    nodeConnectOver = Convert.ToBoolean(element(10))
                    nodeViewerPath = element(11)
                    nodeAutoconnect = Convert.ToBoolean(element(12))
                    username = element(13)
                    password = element(14)
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
        mainForm.textboxUsername.Text = username
        mainForm.textboxPassword.Text = password

        If nodeAutoconnect Then
            mainForm.btnAutoconnect.BackColor = Color.GreenYellow
        Else
            mainForm.btnAutoconnect.BackColor = SystemColors.Control
        End If

        If nodePort <> "" Then
            statistics("Loaded source [" + nodeName + "] (system: " + nodeSystem + " | IP or hostname: " + nodeIP + ":" + nodePort + ")")
        Else
            statistics("Loaded source [" + nodeName + "] (system: " + nodeSystem + " | IP or hostname: " + nodeIP + ")")
        End If
    End Sub

    Public Sub loadSourceData(ByVal nodeName As String)
        loadSourceData(nodeName, "", "", "", "", "", "", "", False, False, 0, False, "")
    End Sub

    Public Function deleteSource(ByVal nodeName As String, ByVal sourcesDb As String) As List(Of String())
        Dim db As List(Of String())

        db = csvArray(sourcesDb)

        Try
            Dim marker As Integer = 0

            For Each element In db
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
#End Region

#Region "Run functions"
    Public Function runRemote(ByVal nodeIP As String, ByVal nodePort As String, ByVal nodeFullscreen As Boolean, ByVal nodeWidth As String, ByVal nodeHeight As String, ByVal nodeMultimon As Boolean, ByVal nodeConnectOver As Boolean, ByVal nodeViewer As String, ByVal nodeName As String, ByVal application As Boolean, ByVal username As String, ByVal password As String) As Integer
        If nodeIP <> "" Then
            For Each monitorItem As ListViewItem In mainForm.monitor.Items
                If monitorItem.SubItems.Item(1).Text.Contains(nodeIP) And (monitorItem.SubItems.Item(2).Text = "(connected)" Or monitorItem.SubItems.Item(2).Text = "(running)") Then
                    Dim startNewSessionDialog As DialogResult = MessageBox.Show("You are already connected to source [" + nodeName + "]. Do you want to open this session?", "Session on " + nodeIP + " already running", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)

                    Select Case startNewSessionDialog
                        Case DialogResult.Yes
                            mainForm.monitorFocusApplication(monitorItem)
                            Return 2
                            Exit Function
                        Case DialogResult.No
                            Exit For
                        Case DialogResult.Cancel
                            Return 2
                            Exit Function
                    End Select
                End If
            Next

            statistics("Connecting to " + nodeName)

            Dim nodeAddressToConnect As String

            If nodePort <> "" Then
                nodeAddressToConnect = nodeIP + ":" + nodePort
            Else
                nodeAddressToConnect = nodeIP
            End If

            Try
                If My.Computer.Network.Ping(nodeIP) = False Then
                    statistics("Ping on " + nodeIP + " > Connection timed out or host is unavailable.")
                Else
                    statistics("Ping on " + nodeIP + " > Host is available.")
                End If
            Catch
                statistics("Ping on " + nodeIP + " failed.")
            End Try

            If nodePort = "" Then
                nodePort = "3389"
            End If

            If nodeConnectOver = False Then
                ProcessProperties.FileName = mstscPath

                If nodeFullscreen = True Then
                    If nodeMultimon = True Then
                        ProcessProperties.Arguments = "/v:" + nodeAddressToConnect + " /multimon"
                    Else
                        ProcessProperties.Arguments = "/v:" + nodeAddressToConnect + " /f"
                    End If
                Else
                    If nodeWidth = "" Then
                        nodeWidth = "1024"
                    End If

                    If nodeHeight = "" Then
                        nodeHeight = "768"
                    End If

                    ProcessProperties.Arguments = "/v:" + nodeAddressToConnect + " /w:" + nodeWidth + " /h:" + nodeHeight
                End If
            Else
                If nodeViewer <> "" And My.Computer.FileSystem.FileExists(nodeViewer) = True Then
                    ProcessProperties.FileName = nodeViewer
                    ProcessProperties.Arguments = nodeAddressToConnect
                Else
                    MessageBox.Show("Viewer is not found or path is empty!", "Viewer not found", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return 0
                    Exit Function
                End If
            End If

            Dim monitorNodeDetails As String()
            Try
                'If MSTSC is used and username is filled, try to use stored credentials.
                Dim launchRdp As String = My.Application.Info.DirectoryPath + "\modules\launchrdp\launchrdp.exe"

                If username <> "" And nodeConnectOver = False And My.Computer.FileSystem.FileExists(launchRdp) Then
                    Dim usernameDomain As String = ""

                    'Parse username (get domain)
                    If username.Contains("\") Then
                        usernameDomain = username.Substring(0, username.LastIndexOf("\"))
                        username = username.Substring(username.LastIndexOf("\") + 1)
                    End If
                    If username.Contains(" ") Then
                        username = ControlChars.Quote + username + ControlChars.Quote
                    End If

                    'Set LaunchRdp path and args

                    Dim launchRdpArgs As String = nodeIP + " " + nodePort + " " + username + " " + usernameDomain + " " + password + " 0 1 0"

                    Try
                        Process.Start(launchRdp, launchRdpArgs).WaitForExit()
                        Threading.Thread.Sleep(2000)

                        Dim listOfProcesses As Process() = Process.GetProcesses()

                        For Each runningProcess As Process In listOfProcesses
                            If runningProcess.MainWindowTitle = "LaunchRDP - " + nodeIP + " - Remote Desktop Connection" Then
                                mstsc = runningProcess
                            End If
                        Next
                    Catch ex As Exception
                        statistics("Applying saved credentials failed. > " + ex.Message)
                    End Try
                Else
                    mstsc = Process.Start(ProcessProperties)
                End If


                Dim state As String = "(connected)"

                If application = True Then
                    state = "(running)"
                End If

                monitorNodeDetails = {nodeName, nodeAddressToConnect, state, mstsc.Id.ToString, ProcessProperties.FileName.Substring(ProcessProperties.FileName.LastIndexOf("\") + 1) + " " + ProcessProperties.Arguments, DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")}
                setMonitor(monitorNodeDetails, True, application)
                statistics("Execution > " + ProcessProperties.FileName + " " + ProcessProperties.Arguments)

                Return mstsc.Id
            Catch ex As Exception
                monitorNodeDetails = {nodeName, nodeAddressToConnect, "(failed)", "0", ProcessProperties.FileName.Substring(ProcessProperties.FileName.LastIndexOf("\") + 1) + " " + ProcessProperties.Arguments, DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")}
                setMonitor(monitorNodeDetails, False)
                statistics("Execution > " + ProcessProperties.FileName + " " + ProcessProperties.Arguments)
                statistics("Unexpectedly ended with error: " + ex.Message)
                Return 0
            End Try
        Else
            MessageBox.Show("IP Address cannot be empty!", "IP Address null", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return 0
        End If
    End Function

    Public Sub runModule(ByVal moduleProperties As ProcessStartInfo, ByVal isModule As Boolean)
        Try
            Dim moduleProcess As Process
            moduleProcess = Process.Start(moduleProperties)

            Dim status As String

            If isModule = True Then
                status = "(module)"
            Else
                status = "(running)"
            End If

            setMonitor({moduleProperties.FileName.Substring(moduleProperties.FileName.LastIndexOf("\") + 1), "localhost", status, moduleProcess.Id.ToString, moduleProperties.FileName + " " + moduleProperties.Arguments, DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")}, True, True)
            statistics("Execution > " + moduleProperties.FileName + " " + moduleProperties.Arguments)
        Catch ex As Exception
            setMonitor({moduleProperties.FileName.Substring(moduleProperties.FileName.LastIndexOf("\") + 1), "localhost", "(closed)", "0", moduleProperties.FileName + " " + moduleProperties.Arguments, DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")}, False, True)
            statistics("Execution > " + moduleProperties.FileName + " " + moduleProperties.Arguments)
            statistics("Unexpectedly ended... with error: " + ex.Message)
        End Try
    End Sub

    Public Sub addProcessToMonitorByPid(ByVal PID As String)
        Try
            Dim moduleProcess As Process

            moduleProcess = Process.GetProcessById(Convert.ToInt32(PID))

            setMonitor({moduleProcess.ProcessName, "localhost", "(running)", PID, moduleProcess.ProcessName, moduleProcess.StartTime.ToString("yyyy/MM/dd HH:mm:ss")}, True, True)
            statistics("Process " + PID + " [" + moduleProcess.ProcessName + "] added to monitor.")
        Catch ex As Exception
            statistics(ex.Message)
        End Try
    End Sub

    Public Sub autoconnect()
        Try
            For Each node In nodes
                If Convert.ToBoolean(node(12)) Then
                    loadSourceData(node(0))
                    mainForm.buttonConnect_Click(Nothing, Nothing)
                End If
            Next
        Catch
        End Try
    End Sub

    Public Sub SendString(ByVal text As String, ByVal process As Process)
        AppActivate(process.Id)
        SendKeys.SendWait(text)
        Threading.Thread.Sleep(250)
    End Sub
#End Region
End Module
