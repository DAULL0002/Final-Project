Public Class frmStartScreen

    

    Private Sub btnOnePlayer_Click(sender As Object, e As EventArgs) Handles btnOnePlayer.Click
        
        frmGame.ShowDialog()
    End Sub

    Private Sub btnTwoPlayers_Click(sender As Object, e As EventArgs) Handles btnTwoPlayers.Click
        Me.Hide()
        frmGame.ShowDialog()
    End Sub
    
End Class
