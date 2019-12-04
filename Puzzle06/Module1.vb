Module Module1

    Sub Main()
        Const downLimit As Integer = 236491
        Const upLimit As Integer = 713787
        Dim satisfies_condition As Boolean = False
        Dim foundPair As Boolean = False
        Dim cnt As Integer = 0
        Dim part2_cnt As Integer = 0

        For i As Integer = downLimit To upLimit
            Dim numToCheck As String = i.ToString
            foundPair = False
            Dim dict As New Dictionary(Of Integer, Integer)
            'check number for at least 1 pair of same digits
            For k As Integer = 0 To numToCheck.Length - 2
                If CInt(numToCheck.Substring(k + 1, 1)) = CInt(numToCheck.Substring(k, 1)) Then
                    foundPair = True
                    If Not dict.ContainsKey(k) Then
                        dict.Add(k, CInt(numToCheck.Substring(k, 1)))
                    End If
                    If Not dict.ContainsKey(k + 1) Then
                        dict.Add(k + 1, CInt(numToCheck.Substring(k + 1, 1)))
                    End If
                End If
            Next

            If foundPair Then
                For j As Integer = 0 To numToCheck.Length - 2
                    'check from left to right that no digit is bigger than its previous
                    If CInt(numToCheck.Substring(j + 1, 1)) >= CInt(numToCheck.Substring(j, 1)) Then
                        satisfies_condition = True
                    Else
                        satisfies_condition = False
                        Exit For
                    End If
                Next
                If satisfies_condition Then
                    cnt += 1
                    'part 2
                    'Same digit occurence must be 2 only. More than that and the password does not satisfy the criteria.
                    If dict.Values.Count > 1 Then
                        Dim dictCount As New Dictionary(Of Integer, Integer)
                        For Each v As Integer In dict.Values
                            If dictCount.ContainsKey(v) Then
                                dictCount(v) += 1
                            Else
                                dictCount(v) = 1
                            End If
                        Next
                        If dictCount.ContainsValue(2) Then
                            part2_cnt += 1
                        End If
                    End If
                End If
            End If
        Next
        Console.WriteLine("Number of passwords satisfying the criteria: " & cnt.ToString)
        Console.WriteLine("Number of passwords with at least 1 pair of length 2: " & part2_cnt.ToString)
        Console.ReadKey()

    End Sub

End Module
