Public Class frmStartScreen

    Public phrases() As String = IO.File.ReadAllLines("hangman.txt")
    Public phrase As String

    Private Sub btnOnePlayer_Click(sender As Object, e As EventArgs) Handles btnOnePlayer.Click
        Dim randomNum As New Random
        phrase = phrases(randomNum.Next(1, phrases.Count))
        frmGame.ShowDialog()
    End Sub

    Private Sub btnTwoPlayers_Click(sender As Object, e As EventArgs) Handles btnTwoPlayers.Click
        Me.Hide()
        frmGame.ShowDialog()
    End Sub
    
End Class
