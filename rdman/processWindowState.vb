Public Class processWindowState
    Private Const SW_SHOWMAXIMIZED As Integer = 3
    Private Const SW_SHOWMINIMIZED As Integer = 2
    Private Const SW_SHOWNORMAL As Integer = 1

    Private Structure POINTAPI
        Public x As Integer
        Public y As Integer
    End Structure

    Private Structure RECT
        Public Left As Integer
        Public Top As Integer
        Public Right As Integer
        Public Bottom As Integer
    End Structure

    Private Structure WINDOWPLACEMENT
        Public Length As Integer
        Public flags As Integer
        Public showCmd As Integer
        Public ptMinPosition As POINTAPI
        Public ptMaxPosition As POINTAPI
        Public rcNormalPosition As RECT
    End Structure

    Private Declare Function GetWindowPlacement Lib "user32" (ByVal hwnd As IntPtr, ByRef lpwndpl As WINDOWPLACEMENT) As Integer

    Public Shared Function GetProcessWindowState(Handle As IntPtr) As FormWindowState
        Dim wp As WINDOWPLACEMENT
        wp.Length = System.Runtime.InteropServices.Marshal.SizeOf(wp)
        GetWindowPlacement(Handle, wp)
        If wp.showCmd = SW_SHOWMAXIMIZED Then ' is window maximized?
            Return FormWindowState.Maximized
        ElseIf wp.showCmd = SW_SHOWMINIMIZED Then
            Return FormWindowState.Minimized
        Else
            Return FormWindowState.Normal
        End If
    End Function
End Class
