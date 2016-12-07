Public Class frmGame
    Public phrases() As String = IO.File.ReadAllLines("hangman.txt")
    Public phrase As String
    Dim phraseLength As Integer
    Dim incorrectGuesses As Integer
    Dim disposeLabels As Boolean
    Dim gamesWon As Integer

    Private Sub frmGame_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        Dim letterTyped As String
        Dim completedWord As Boolean = True
        Dim strikeout As Font = New Font("Times New Roman", 14, FontStyle.Strikeout Or FontStyle.Bold)
        letterTyped = e.KeyChar
        If Asc(letterTyped.ToUpper) > 64 And Asc(letterTyped.ToUpper) < 91 Then
            lblRemainingLetters(Asc(letterTyped.ToUpper) - 64).Font = strikeout

            If phrase.IndexOf(letterTyped.ToUpper) <> -1 Or phrase.IndexOf(letterTyped.ToLower) <> -1 Then
                For x = 1 To phraseLength
                    If phrase.Substring(x - 1, 1).ToUpper = letterTyped.ToUpper Then
                        lblLetter(x).Text = phrase.Substring(x - 1, 1)
                    End If
                    If lblLetter(x).Text = "_" Then
                        completedWord = False
                    End If
                Next
                If completedWord = True And frmStartScreen.series = False Then
                    MsgBox("You win.")
                    If MsgBox("Would you like to play again?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                        If frmStartScreen.twoPlayer = True Then
                            Dim category As String
                            phrase = InputBox("Type in the phrase that you want the other player to guess.")
                            category = InputBox("Type in the category of your phrase (e.g. movie titles).")
                            lblCategory.Text = category
                        End If
                        newGame()
                    Else
                        Me.Close()
                        frmStartScreen.Show()
                        frmStartScreen.twoPlayer = False
                        frmStartScreen.series = False
                    End If
                ElseIf completedWord = True Then
                    gamesWon += 1
                    newGame()
                End If

            Else
                incorrectGuesses += 1
                drawStickMan()
            End If

        End If
    End Sub

    Private Sub frmGame_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        newGame()
    End Sub

    Dim lblLetter() As Label
    Dim lblRemainingLetters(26) As Label
    Sub newGame()
        If frmStartScreen.twoPlayer = False Then
            Dim randomNum As New Random
            Dim num As Integer
            num = randomNum.Next(0, phrases.Count)
            Select Case num
                Case 0 To 522
                    lblCategory.Text = "Around the House"
                Case 523 To 1116
                    lblCategory.Text = "Before and After"
                Case 1117 To 1146
                    lblCategory.Text = "Book Title"
                Case 1147 To 1212
                    lblCategory.Text = "Classic Movie"
                Case 1213 To 1367
                    lblCategory.Text = "Classic TV"
                Case 1368 To 2398
                    lblCategory.Text = "Event"
                Case 2399 To 2418
                    lblCategory.Text = "Family"
                Case 2419 To 2777
                    lblCategory.Text = "Fictional Character"
                Case 2778 To 2785
                    lblCategory.Text = "Fictional Place"
                Case 2786 To 3485
                    lblCategory.Text = "Food"
                Case 3486 To 3772
                    lblCategory.Text = "Fun and Games"
                Case 3773 To 4010
                    lblCategory.Text = "In the Kitchen"
                Case 4011 To 4297
                    lblCategory.Text = "Landmark"
                Case 4298 To 4529
                    lblCategory.Text = "Movie Title"
                Case 4530 To 4728
                    lblCategory.Text = "Occupations"
                Case 4729 To 4927
                    lblCategory.Text = "Places"
                Case 4928 To 5127
                    lblCategory.Text = "People"
                Case 5128 To 5325
                    lblCategory.Text = "Phrases"
                Case 5326 To 5525
                    lblCategory.Text = "Proper Name"
                Case 5526 To 5556
                    lblCategory.Text = "Quotations"
                Case 5557 To 5690
                    lblCategory.Text = "Rhyme Time"
                Case 5691 To 5739
                    lblCategory.Text = "Same Letter"
                Case 5740 To 5939
                    lblCategory.Text = "Same Name"
                Case 5940 To 6139
                    lblCategory.Text = "Show Biz"
                Case 6140 To 6142
                    lblCategory.Text = "Slogans"
                Case 6143 To 6193
                    lblCategory.Text = "Song/Artist"
                Case 6194 To 6292
                    lblCategory.Text = "Song Lyrics"
                Case 6293 To 6324
                    lblCategory.Text = "Star and Role"
                Case Else
                    lblCategory.Text = "Title/Author"

            End Select
            phrase = phrases(num).Trim
        End If

        If frmStartScreen.series = False Or gamesWon = 0 Then
            incorrectGuesses = 0
            PictureBox1.Image = Image.FromFile("Gallows.png")
        End If


        If disposeLabels = False Then
            For x = 65 To 90
                If x = 65 Then
                    lblRemainingLetters(1) = New Label
                    lblRemainingLetters(1).Font = New Font("Times New Roman", 14, FontStyle.Bold)
                    lblRemainingLetters(1).AutoSize = True
                    lblRemainingLetters(1).Left = 39
                    lblRemainingLetters(1).Top = 60
                    lblRemainingLetters(1).Text = Chr(65)
                Else
                    lblRemainingLetters(x - 64) = New Label
                    lblRemainingLetters(x - 64).Font = New Font("Times New Roman", 14, FontStyle.Bold)
                    lblRemainingLetters(x - 64).AutoSize = True
                    lblRemainingLetters(x - 64).Left = lblRemainingLetters(x - 65).Left + 24
                    lblRemainingLetters(x - 64).Top = 60
                    lblRemainingLetters(x - 64).Text = Chr(x)

                End If
                Me.Controls.Add(lblRemainingLetters(x - 64))
            Next
        Else
            'removes strikeouts
            For x = 1 To 26
                lblRemainingLetters(x).Font = New Font("Times New Roman", 14, FontStyle.Bold)
            Next

            'ensures there are labels to dispose of
            For x = 1 To phraseLength
                lblLetter(x).Dispose()
            Next
        End If



        phraseLength = phrase.Length
        Dim numberOfWords, wordCount As Integer

        'Used if words are too long to fit in a single line
        Dim secondLine As Integer
        numberOfWords = phrase.Split(" ").Length
        Dim words(numberOfWords - 1) As String
        words = phrase.Split(" "c)
        ReDim lblLetter(phraseLength)


        disposeLabels = True
        For x = 1 To phraseLength
            Dim letter As String
            letter = phrase.Substring(x - 1, 1)
            lblLetter(x) = New Label()

            lblLetter(x).Font = New Font("Times New Roman", 14, FontStyle.Bold)
            lblLetter(x).AutoSize = True

            If ((Asc(letter) < 65 Or Asc(letter) > 122) Or (Asc(letter) < 97 And Asc(letter) > 90)) And Asc(letter) <> 38 Then
                lblLetter(x).Text = letter
            ElseIf Asc(letter) = 38 Then
                lblLetter(x).Text = "&&"
            Else
                lblLetter(x).Text = "_"
            End If
            If Asc(letter) = 32 Then
                wordCount += 1
                If (words(wordCount).Length * 20) + (words(wordCount).Length * 1.5) + lblLetter(x - 1).Left > 644 Then
                    secondLine = True
                End If
            End If

            If x = 1 Then
                lblLetter(x).Left = 12
                lblLetter(x).Top = 205

            Else

                If secondLine = False Then
                    lblLetter(x).Top = lblLetter(x - 1).Top
                    lblLetter(x).Left = lblLetter(x - 1).Left + lblLetter(x - 1).Width + 1.5
                Else
                    lblLetter(x).Top = 235
                    lblLetter(x).Left = 12
                    secondLine = False
                End If
            End If


            Me.Controls.Add(lblLetter(x))
        Next

        'Test to make sure program works correctly (to be removed before final program)
        MsgBox(phrase)
    End Sub

    Sub drawStickMan()
        PictureBox1.Image = Image.FromFile("Wrong_Guess_" & incorrectGuesses & ".png")
        If incorrectGuesses = 6 Then
            MsgBox("You lost.")
            If frmStartScreen.series = True Then
                If IO.File.Exists("High_Score.txt") Then
                    Dim sr As IO.StreamReader = IO.File.OpenText("High_Score.txt")
                    Dim player, score, dateTime As String
                    player = sr.ReadLine
                    score = sr.ReadLine
                    dateTime = sr.ReadLine
                    sr.Close()
                    If gamesWon > score Then
                        player = InputBox(gamesWon & " games won is the new high score. Please type in your name.")
                        score = gamesWon
                        dateTime = Now.ToString
                        Dim sw As IO.StreamWriter = IO.File.CreateText("High_Score.txt")
                        sw.WriteLine(player)
                        sw.WriteLine(score)
                        sw.WriteLine(dateTime)
                        sw.Close()
                    End If

                Else
                    Dim sw As IO.StreamWriter = IO.File.CreateText("High_Score.txt")
                    Dim player, score, dateTime As String
                    player = InputBox(gamesWon & " games won is the new high score. Please type in your name.")
                    score = gamesWon
                    dateTime = Now.ToString
                    sw.WriteLine(player)
                    sw.WriteLine(score)
                    sw.WriteLine(DateTime)
                    sw.Close()
                End If
            End If
            PictureBox1.Image = Image.FromFile("Hanged_Man.png")
            If MsgBox("Would you like to play again?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                If frmStartScreen.twoPlayer = True Then
                    Dim category As String
                    phrase = InputBox("Type in the phrase that you want the other player to guess.")
                    category = InputBox("Type in the category of your phrase (e.g. movie titles).")
                    lblCategory.Text = category
                End If
                gamesWon = 0
                incorrectGuesses = 0
                PictureBox1.Image = Image.FromFile("Gallows.png")
                newGame()
            Else
                Me.Close()

                frmStartScreen.Show()
                frmStartScreen.twoPlayer = False
                frmStartScreen.series = False
            End If
        End If
    End Sub
End Class