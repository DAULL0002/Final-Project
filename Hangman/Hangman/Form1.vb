Public Class frmStartScreen

    Public twoPlayer As Boolean

    Private Sub btnOnePlayer_Click(sender As Object, e As EventArgs) Handles btnOnePlayer.Click
        Me.Hide()
        frmGame.Show()
    End Sub

    Private Sub btnTwoPlayers_Click(sender As Object, e As EventArgs) Handles btnTwoPlayers.Click
        Dim category As String
        twoPlayer = True
        frmGame.phrase = InputBox("Type in the phrase that you want the other player to guess.")
        category = InputBox("Type in the category of your phrase (e.g. movie titles).")
        frmGame.lblCategory.Text = category
        Me.Hide()
        frmGame.Show()
    End Sub

    Public series As Boolean
    Private Sub btnSeries_Click(sender As Object, e As EventArgs) Handles btnSeries.Click
        series = True
        Me.Hide()
        frmGame.Show()

    End Sub

    Private Sub btnHighScore_Click(sender As Object, e As EventArgs) Handles btnHighScore.Click
        If IO.File.Exists("High_Score.txt") Then
            Dim sr As IO.StreamReader = IO.File.OpenText("High_Score.txt")
            Dim player, score, dateTime As String
            player = sr.ReadLine
            score = sr.ReadLine
            dateTime = sr.ReadLine
            dateTime = dateTime.Substring(0, dateTime.IndexOf(" "))
            MsgBox(player & " scored " & score & " on " & dateTime & ".")
        Else
            MsgBox("There is no high score currently on record.")
        End If

    End Sub
End Class
