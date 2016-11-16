Public Class frmStartScreen

    Private Sub btnOnePlayer_Click(sender As Object, e As EventArgs) Handles btnOnePlayer.Click
        Me.Hide()
        frmGame.ShowDialog()
    End Sub

    Private Sub btnTwoPlayers_Click(sender As Object, e As EventArgs) Handles btnTwoPlayers.Click
        Me.Hide()
        frmGame.ShowDialog()
    End Sub

    Private Sub frmStartScreen_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MsgBox("The screen is loading")
        Dim words() As String = IO.File.ReadAllLines("words.txt")
        Dim newWords(words.Count - 1) As String
        Dim phrase As String
        For x = 0 To words.Count - 1
            phrase = words(x)
            
            newWords(x) = phrase.Trim
        Next

        IO.File.WriteAllLines("hangman.txt", newWords)

    End Sub
End Class
