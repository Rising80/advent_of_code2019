Option Strict On
Option Explicit On

Imports System.IO

Module Module1

    Sub Main()
        Dim fuel As Long = 0
        Dim mass As Long = 0
        Dim totalFuel As Long = 0
        Dim line As String = String.Empty

        Try
            Using sr As StreamReader = New StreamReader("Input.txt")
                line = sr.ReadLine
                Do While (Not line Is Nothing)
                    mass = CLng(line)
                    fuel = calculateFuel(mass)
                    Console.WriteLine("For mass: " & mass.ToString & ", fuel required= " & fuel.ToString)
                    totalFuel += fuel
                    line = sr.ReadLine
                Loop
            End Using

            Console.WriteLine("Total fuel required: " & totalFuel.ToString)
            Console.ReadKey()

        Catch ex As Exception
            Console.WriteLine(ex.Message)
            Console.ReadKey()
        End Try

    End Sub

    Private Function calculateFuel(ByVal mss As Long) As Long
        Dim totalFuel As Long = 0
        Dim lstFuel As New List(Of Long)
        Dim fuel As Long = CLng(Math.Floor(mss / 3) - 2)
        While (Not fuel <= 0)
            lstFuel.Add(fuel)
            fuel = CLng(Math.Floor(fuel / 3) - 2)
        End While
        For Each element As Long In lstFuel
            totalFuel += element
        Next
        Return totalFuel
    End Function


End Module
