Imports System.ComponentModel
Imports System.Runtime.InteropServices
Imports System.Text

Public Module RdpEncrypt

    Public Class DPAPI
        <DllImport("crypt32.dll", SetLastError:=True, CharSet:=CharSet.Auto)>
        Private Shared Function CryptProtectData(
            ByRef pPlainText As DATA_BLOB,
            ByVal szDescription As String,
            ByRef pEntropy As DATA_BLOB,
            ByVal pReserved As IntPtr,
            ByRef pPrompt As CRYPTPROTECT_PROMPTSTRUCT,
            ByVal dwFlags As Integer,
            ByRef pCipherText As DATA_BLOB
        ) As Boolean
        End Function

        <DllImport("crypt32.dll", SetLastError:=True, CharSet:=CharSet.Auto)>
        Private Shared Function CryptUnprotectData(
            ByRef pCipherText As DATA_BLOB,
            ByRef pszDescription As String,
            ByRef pEntropy As DATA_BLOB,
            ByVal pReserved As IntPtr,
            ByRef pPrompt As CRYPTPROTECT_PROMPTSTRUCT,
            ByVal dwFlags As Integer,
            ByRef pPlainText As DATA_BLOB
        ) As Boolean
        End Function

        <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Unicode)>
        Friend Structure DATA_BLOB
            Public cbData As Integer
            Public pbData As IntPtr
        End Structure

        <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Unicode)>
        Friend Structure CRYPTPROTECT_PROMPTSTRUCT
            Public cbSize As Integer
            Public dwPromptFlags As Integer
            Public hwndApp As IntPtr
            Public szPrompt As String
        End Structure

        Private Const CRYPTPROTECT_UI_FORBIDDEN As Integer = 1
        Private Const CRYPTPROTECT_LOCAL_MACHINE As Integer = 4

        Private Shared Sub InitPrompt _
        (
            ByRef ps As CRYPTPROTECT_PROMPTSTRUCT
        )
            ps.cbSize = Marshal.SizeOf(GetType(CRYPTPROTECT_PROMPTSTRUCT))
            ps.dwPromptFlags = 0
            ps.hwndApp = IntPtr.Zero
            ps.szPrompt = Nothing
        End Sub

        Private Shared Sub InitBLOB _
        (
            ByVal data As Byte(),
            ByRef blob As DATA_BLOB
        )
            ' Use empty array for null parameter.
            If data Is Nothing Then
                data = New Byte(0) {}
            End If

            ' Allocate memory for the BLOB data.
            blob.pbData = Marshal.AllocHGlobal(data.Length)

            ' Make sure that memory allocation was successful.
            If blob.pbData.Equals(IntPtr.Zero) Then
                Throw New Exception(
                        "Unable to allocate data buffer for BLOB structure.")
            End If

            ' Specify number of bytes in the BLOB.
            blob.cbData = data.Length
            Marshal.Copy(data, 0, blob.pbData, data.Length)
        End Sub

        Public Enum KeyType
            UserKey = 1
            MachineKey
        End Enum

        Private Shared defaultKeyType As KeyType = KeyType.UserKey

        Public Shared Function Encrypt _
        (
            ByVal keyType As KeyType,
            ByVal plainText As String,
            ByVal entropy As String,
            ByVal description As String
        ) As String
            If plainText Is Nothing Then
                plainText = String.Empty
            End If
            If entropy Is Nothing Then
                entropy = String.Empty
            End If

            Dim result As Byte()
            Dim encrypted As String = ""
            Dim i As Integer
            result = Encrypt(keyType,
                             Encoding.Unicode.GetBytes(plainText),
                             Encoding.Unicode.GetBytes(entropy),
                             description)
            For i = 0 To result.Length - 1
                encrypted = encrypted & Convert.ToString(result(i), 16).PadLeft(2, "0").ToUpper()
            Next
            Return encrypted.ToString()
        End Function

        Public Shared Function Encrypt _
        (
            ByVal keyType As KeyType,
            ByVal plainTextBytes As Byte(),
            ByVal entropyBytes As Byte(),
            ByVal description As String
        ) As Byte()
            If plainTextBytes Is Nothing Then
                plainTextBytes = New Byte(0) {}
            End If

            If entropyBytes Is Nothing Then
                entropyBytes = New Byte(0) {}
            End If

            If description Is Nothing Then
                description = String.Empty
            End If

            Dim plainTextBlob As DATA_BLOB = New DATA_BLOB
            Dim cipherTextBlob As DATA_BLOB = New DATA_BLOB
            Dim entropyBlob As DATA_BLOB = New DATA_BLOB

            Dim prompt As _
                    CRYPTPROTECT_PROMPTSTRUCT = New CRYPTPROTECT_PROMPTSTRUCT
            InitPrompt(prompt)

            Try
                Try
                    InitBLOB(plainTextBytes, plainTextBlob)
                Catch ex As Exception
                    Throw New Exception("Cannot initialize plaintext BLOB.", ex)
                End Try

                Try
                    InitBLOB(entropyBytes, entropyBlob)
                Catch ex As Exception
                    Throw New Exception("Cannot initialize entropy BLOB.", ex)
                End Try

                Dim flags As Integer = CRYPTPROTECT_UI_FORBIDDEN

                If keyType = KeyType.MachineKey Then
                    flags = flags Or (CRYPTPROTECT_LOCAL_MACHINE)
                End If

                Dim success As Boolean = CryptProtectData(
                                                plainTextBlob,
                                                description,
                                                entropyBlob,
                                                IntPtr.Zero,
                                                prompt,
                                                flags,
                                                cipherTextBlob)

                If Not success Then
                    Dim errCode As Integer = Marshal.GetLastWin32Error()

                    Throw New Exception("CryptProtectData failed.",
                                    New Win32Exception(errCode))
                End If

                Dim cipherTextBytes(cipherTextBlob.cbData) As Byte

                Marshal.Copy(cipherTextBlob.pbData, cipherTextBytes, 0,
                                cipherTextBlob.cbData)

                Return cipherTextBytes
            Catch ex As Exception
                Throw New Exception("DPAPI was unable to encrypt data.", ex)
            Finally
                If Not (plainTextBlob.pbData.Equals(IntPtr.Zero)) Then
                    Marshal.FreeHGlobal(plainTextBlob.pbData)
                End If

                If Not (cipherTextBlob.pbData.Equals(IntPtr.Zero)) Then
                    Marshal.FreeHGlobal(cipherTextBlob.pbData)
                End If

                If Not (entropyBlob.pbData.Equals(IntPtr.Zero)) Then
                    Marshal.FreeHGlobal(entropyBlob.pbData)
                End If
            End Try
        End Function

    End Class

    Public Function encryptText(ByVal text As String) As String
        Return DPAPI.Encrypt(DPAPI.KeyType.MachineKey, text, Nothing, "psw")
    End Function
End Module

