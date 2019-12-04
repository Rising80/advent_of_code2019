Option Strict On
Option Explicit On

Imports System.IO

Module Module1

    Sub Main()
        Dim lstNums As New List(Of Integer)
        Dim result As String = String.Empty
        Try
            Using sr As StreamReader = New StreamReader("Input.txt")
                Dim input() As String = sr.ReadToEnd.Split(","c)
                For cnt As Integer = 0 To input.Length - 1
                    lstNums.Add(CInt(input(cnt)))
                Next
            End Using
            For i As Integer = 0 To 99
                For j As Integer = 0 To 99
                    'Console.WriteLine("i=" & i.ToString & ", j=" & j.ToString)
                    ProcessData(lstNums, i, j)
                Next
            Next
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try

        Console.WriteLine("Program executed successfully. Press any key to exit...")
        Console.ReadKey()

    End Sub

    Private Sub ProcessData(ByVal lstNumbers As List(Of Integer), cnt1 As Integer, cnt2 As Integer)
        Dim retval As Integer = 0

        Dim dataCopy(lstNumbers.Count) As Integer
        lstNumbers.CopyTo(dataCopy, 0)
        'replace position 1 with the value of i and replace position 2 with the value of j.
        dataCopy(1) = cnt1
        dataCopy(2) = cnt2

        Dim action As Integer = 0
        Dim result As Integer = 0
        Try
            For i As Integer = 0 To lstNumbers.Count - 1
                'every 4 positions is the action
                If i Mod 4 = 0 Then
                    action = lstNumbers(i)

                    Dim idx1 As Integer = 0
                    Dim idx2 As Integer = 0
                    Dim pos As Integer = 0

                    idx1 = lstNumbers(i + 1)
                    idx2 = lstNumbers(i + 2)
                    pos = lstNumbers(i + 3)

                    Select Case action
                        Case 1
                            result = dataCopy(idx1) + dataCopy(idx2)
                            dataCopy(pos) = result
                        Case 2
                            result = dataCopy(idx1) * dataCopy(idx2)
                            dataCopy(pos) = result
                        Case 99
                            retval = dataCopy(0)
                            'Return retval
                            'Exit Function
                            'Exit Sub
                            Exit For
                        Case Else
                            Throw New Exception("Error! Action code " & action.ToString & " not recognized!")
                    End Select
                End If
            Next
            retval = dataCopy(0)
            If retval = 19690720 Then
                Console.WriteLine("DataCopy(0): " & retval.ToString)
                Console.WriteLine("Noun: " & cnt1.ToString)
                Console.WriteLine("Verb: " & cnt2.ToString)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Module
