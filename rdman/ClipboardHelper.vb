Imports System.Diagnostics

Public Class ClipboardHelper
    Public Shared Sub CopyTextToClipboard(ByVal text As String)
        Try
            ' Vytvořte nový proces pro spuštění příkazu "clip" a předáme mu vstupní text
            Using process As New Process()
                process.StartInfo.FileName = "clip"
                process.StartInfo.RedirectStandardInput = True
                process.StartInfo.UseShellExecute = False

                process.Start()

                ' Zapišeme text do standardního vstupu procesu
                process.StandardInput.Write(text)
                process.StandardInput.Close()

                process.WaitForExit()
            End Using
        Catch ex As Exception
            ' Zpracování chyb, pokud se při spuštění procesu "clip" vyskytne problém
            Console.WriteLine("Došlo k chybě: " & ex.Message)
        End Try
    End Sub
End Class