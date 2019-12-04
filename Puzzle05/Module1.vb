Imports System.IO
Module Module1

    Sub Main()
        Dim input As String = String.Empty
        Try
            Using sr As StreamReader = New StreamReader("Input.txt")
                input = sr.ReadToEnd
            End Using
            Solve(input)
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try

        Console.WriteLine("Program executed successfully. Press any key to exit...")
        Console.ReadKey()
    End Sub


    Private Function GetPath(ByVal input As String) As Dictionary(Of Tuple(Of Integer, Integer), Integer)

        Dim r As New Dictionary(Of Tuple(Of Integer, Integer), Integer)
        Dim x As Integer, y As Integer, c As Integer = 0
        For Each p In input.Split(",")
            Dim dist = Integer.Parse(p.Substring(1, p.Length - 1))
            Select Case p(0)
                Case "U"
                    For s As Integer = 0 To dist - 1
                        y += 1
                        c += 1
                        Dim newPoint As Tuple(Of Integer, Integer) = New Tuple(Of Integer, Integer)(x, y)
                        If Not r.ContainsKey(newPoint) Then
                            'Throw New Exception("Key " & newPoint.Item1.ToString & ", " & newPoint.Item2.ToString & " already added. Distance= " & dist)
                            'Else
                            r.Add(newPoint, c)
                        End If
                    Next
                    Exit Select
                Case "D"
                    For s As Integer = 0 To dist - 1
                        y -= 1
                        c += 1
                        Dim newPoint As Tuple(Of Integer, Integer) = New Tuple(Of Integer, Integer)(x, y)
                        If Not r.ContainsKey(newPoint) Then
                            'Throw New Exception("Key " & newPoint.Item1.ToString & ", " & newPoint.Item2.ToString & " already added. Distance= " & dist)
                            'Else
                            r.Add(newPoint, c)
                        End If
                    Next
                    Exit Select
                Case "L"
                    For s As Integer = 0 To dist - 1
                        x -= 1
                        c += 1
                        Dim newPoint As Tuple(Of Integer, Integer) = New Tuple(Of Integer, Integer)(x, y)
                        If Not r.ContainsKey(newPoint) Then
                            'Throw New Exception("Key " & newPoint.Item1.ToString & ", " & newPoint.Item2.ToString & " already added. Distance= " & dist)
                            'Else
                            r.Add(newPoint, c)
                        End If
                    Next
                    Exit Select
                Case "R"
                    For s As Integer = 0 To dist - 1
                        x += 1
                        c += 1
                        Dim newPoint As Tuple(Of Integer, Integer) = New Tuple(Of Integer, Integer)(x, y)
                        If Not r.ContainsKey(newPoint) Then
                            'Throw New Exception("Key " & newPoint.Item1.ToString & ", " & newPoint.Item2.ToString & " already added. Distance= " & dist)
                            'Else
                            r.Add(newPoint, c)
                        End If
                    Next
                    Exit Select
                Case Else
                    Throw New Exception("Direction code not recognized.")
            End Select
        Next


        'x = 0
        'y = 0
        'Dim dir = p(0).ToString()
        'Dim dist = Integer.Parse(p.Substring(1, p.Length - 1))
        'For d As Integer = 0 To dist - 1
        '    Dim newPoint As Tuple(Of Integer, Integer)
        '    Select Case dir
        '        Case "R"
        '            x += 1
        '            newPoint = New Tuple(Of Integer, Integer)(x, y)
        '        Case "D"
        '            y -= 1
        '            newPoint = New Tuple(Of Integer, Integer)(x, y)
        '        Case "L"
        '            x -= 1
        '            newPoint = New Tuple(Of Integer, Integer)(x, y)
        '        Case "U"
        '            y += 1
        '            newPoint = New Tuple(Of Integer, Integer)(x, y)
        '        Case Else
        '            Throw New Exception("Direction code not recognized.")
        '    End Select
        '    'r.TryAdd(newPoint, ++pathLength);
        '    If r.ContainsKey(newPoint) Then
        '        Throw New Exception("Key " & newPoint.Item1.ToString & ", " & newPoint.Item2.ToString & " already added.")
        '    End If
        '    r.Add(newPoint, pathLength + 1)
        'Next
        'Next
        Return r
    End Function

    Public Sub Solve(ByVal Input As String)
        Dim paths() = Input.Split(vbLf)
        Dim path1 = GetPath(paths(0))
        Dim path2 = GetPath(paths(1))
        Dim intersections = path1.Keys.Intersect(path2.Keys).ToArray()
        Console.WriteLine(intersections.Min(Function(p) Math.Abs(p.Item1) + Math.Abs(p.Item2)))
        Console.WriteLine(intersections.Min(Function(x) path1(x) + path2(x)))
    End Sub

End Module
