Module Module1

    Sub Main()
        Dim CostOfEachSung As Integer() = {
            321000, 641000, 961000, 1281000, 1601000,
            1921000, 2241000, 2561000, 2881000, 3201000, '1~10성
            12966500, 16400100, 20356300, 24865300, 29956500,
            71316500, 83999600, 98016700, 113422300, 130270000, '11~20성
            148612400, 168501500,
            189988600, 213124100, 237957700
            }
        Dim SuccessRateOfEachSung As Integer() = {
        95, 90, 85, 85, 80,
        75, 70, 65, 60, 55,
        45, 35, 30, 30, 30,
        30, 30, 30, 30, 30,
        30, 30,
        3, 2, 1
        }
        Dim DistroyRateOfEachSung As Integer() = {
            0, 0, 0, 0, 0,
            0, 0, 0, 0, 0,
            0, 0, 1, 2, 2,
            3, 3, 3, 4, 4,
            10, 10,
            20, 30, 40
        }

        Dim RepeatCount As Integer = 100000
        Dim Goal As Integer = 22
        Dim StarCatch As Boolean = False
        Dim AntiDestroy As Boolean = True '0~16

        Dim NowFailCnt As Integer = 0
        Dim NowKeepCnt As Integer = 0
        Dim NowSuccessCnt As Integer = 0
        Dim NowCost As ULong = 0
        Dim NowDistroyCnt As Integer = 0

        Dim TotlDistroyCnt As Integer = 0
        Dim TotlKeepCnt As Integer = 0
        Dim TotlFailCnt As Integer = 0
        Dim TotlSuccessCnt As Integer = 0
        Dim TotlCost As ULong = 0

        Dim NowSung As Integer = 0

        Dim isChanceTime As Integer = 0

        Dim rd As New Random
        Dim Percent As Integer = 0
        Dim DistroyP As Integer = 0
        For i = 1 To RepeatCount
            While True
                If (NowSung < 17) And (AntiDestroy = True) Then
                    NowCost = NowCost + CostOfEachSung(NowSung) + CostOfEachSung(NowSung)
                    DistroyP = 99
                Else
                    NowCost = NowCost + CostOfEachSung(NowSung)
                    DistroyP = rd.Next(0, 99)
                End If

                If isChanceTIme >= 2 Then
                    Percent = 0
                    isChanceTIme = 0
                Else
                    Percent = rd.Next(0, 99)
                End If

                If Percent < SuccessRateOfEachSung(NowSung) Then
                    NowSuccessCnt = NowSuccessCnt + 1
                    NowSung = NowSung + 1
                Else
                    If DistroyP < DistroyRateOfEachSung(NowSung) Then

                        NowDistroyCnt = NowDistroyCnt + 1
                        NowSung = 12
                        isChanceTime = 0
                    Else
                        NowFailCnt = NowFailCnt + 1
                        If (NowSung <= 5) OrElse (NowSung = 10) OrElse (NowSung = 15) OrElse (NowSung = 20) Then
                            NowKeepCnt = NowKeepCnt + 1
                        Else
                            NowSung = NowSung - 1
                            isChanceTIme = isChanceTIme + 1
                        End If
                    End If
                End If
                If NowSung >= Goal Then Exit While
            End While

            TotlCost = TotlCost + NowCost
            TotlSuccessCnt = TotlSuccessCnt + NowSuccessCnt
            TotlFailCnt = TotlFailCnt + NowFailCnt
            TotlKeepCnt = TotlKeepCnt + NowKeepCnt
            TotlDistroyCnt = TotlDistroyCnt + NowDistroyCnt

            NowSung = 0
            NowCost = 0
            NowSuccessCnt = 0
            NowFailCnt = 0
            NowKeepCnt = 0
            NowDistroyCnt = 0
        Next

        Console.WriteLine()
        Console.WriteLine("평균 강화 비용: " & (TotlCost / RepeatCount))
        Console.WriteLine("평균 성공 횟수: " & (TotlSuccessCnt / RepeatCount))
        Console.WriteLine("평균 실패 횟수: " & (TotlFailCnt / RepeatCount))
        Console.WriteLine("평균 유지 횟수: " & (TotlKeepCnt / RepeatCount))
        Console.WriteLine("평균 파괴 횟수: " & (TotlDistroyCnt / RepeatCount))

        Console.ReadLine()
    End Sub

End Module
