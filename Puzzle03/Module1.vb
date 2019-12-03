Option Strict On
Option Explicit On

Imports System.IO

Module Module1

    Sub Main()
        Dim lstNums As New List(Of Integer)
        Dim result As Integer = 0
        Try
            Using sr As StreamReader = New StreamReader("Input.txt")
                Dim input() As String = sr.ReadToEnd.Split(","c)
                For i As Integer = 0 To input.Length - 1
                    lstNums.Add(CInt(input(i)))
                Next
                result = ProcessData(lstNums)
            End Using
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
        Console.WriteLine("Value needed: " & result.ToString)
        Console.ReadKey()
    End Sub

    Private Function ProcessData(ByVal lstNumbers As List(Of Integer)) As Integer
        Dim retval As Integer = 0

        Dim dataCopy(lstNumbers.Count) As Integer
        lstNumbers.CopyTo(dataCopy, 0)
        'replace position 1 with the value 12 and replace position 2 with the value 2.
        dataCopy(1) = 12
        dataCopy(2) = 2

        Dim action As Integer = 0
        Dim result As Integer = 0
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
                        Return retval
                        Exit Function
                    Case Else
                        Throw New Exception("Error! Action code " & action.ToString & " not recognized!")
                End Select
            End If
        Next
        retval = dataCopy(0)
        Return retval
    End Function
End Module
