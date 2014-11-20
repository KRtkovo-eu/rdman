Imports System.Runtime.InteropServices

Public Class processAPI
    Private Declare Function apiGetTopWindow Lib "user32" Alias "GetTopWindow" (ByVal hwnd As Integer) As Integer
    Private Declare Function apiGetDesktopWindow Lib "user32" Alias "GetDesktopWindow" () As Integer
    Private Declare Function apiGetWindow Lib "user32" Alias "GetWindow" (ByVal hwnd As Integer, ByVal wCmd As Integer) As Integer
    Private Declare Function apiGetWindowTextLength Lib "user32" Alias "GetWindowTextLengthA" (ByVal hwnd As Integer) As Integer
    Private Declare Function apiGetWindowText Lib "user32" Alias "GetWindowTextA" (ByVal hwnd As Integer, ByVal lpString As String, ByVal cch As Integer) As Integer
    Private Declare Function apiShowWindow Lib "user32" Alias "ShowWindow" (ByVal hwnd As IntPtr, ByVal nCmdShow As Integer) As Integer
    Private Declare Function apiIsIconic Lib "user32" Alias "IsIconic" (ByVal hwnd As IntPtr) As Boolean

    Private Const GW_HWNDNEXT As Integer = 2
    Private Const SW_NORMAL As Integer = 1

    Public Shared Function GetFirstWindowHandle(ByVal sStartingWith As String) As Integer

        Dim hwnd As Integer
        Dim sWindowName As String

        Dim iHandle As Integer = 0

        hwnd = apiGetTopWindow(apiGetDesktopWindow)

        Do While hwnd <> 0
            sWindowName = zGetWindowName(hwnd)
            If sWindowName.StartsWith(sStartingWith) Then
                iHandle = hwnd
                Exit Do
            End If
            hwnd = apiGetWindow(hwnd, GW_HWNDNEXT)
        Loop

        Return iHandle

    End Function

    Public Shared Function IsMinimized(ByVal hwnd As Integer) As Boolean

        Dim ip As New IntPtr(hwnd)

        Return apiIsIconic(ip)

    End Function

    Public Shared Sub ShowWindow(ByVal hwnd As Integer)

        Dim ip As New IntPtr(hwnd)

        apiShowWindow(ip, SW_NORMAL)

    End Sub

    Private Shared Function zGetWindowName(ByVal hWnd As Integer) As String

        Dim nBufferLength As Integer
        Dim nTextLength As Integer
        Dim sName As String

        nBufferLength = apiGetWindowTextLength(hWnd) + 4
        sName = New String(" "c, nBufferLength)

        nTextLength = apiGetWindowText(hWnd, sName, nBufferLength)
        sName = sName.Substring(0, nTextLength)

        Return sName

    End Function
End Class
