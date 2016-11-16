Public Class frmGame

    Dim phraseLength As Integer
    Private Sub frmGame_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        

        newGame()
    End Sub

    Dim lblLetter() As Label
    Sub newGame()
        phraseLength = frmStartScreen.phrase.Length
        Dim numberOfWords As Integer
        numberOfWords = frmStartScreen.phrase.Split(" ").Length
        Dim words(numberOfWords) As String
        words = frmStartScreen.phrase.Split(" "c)
        ReDim lblLetter(phraseLength)
        For x = 1 To phraseLength
            Dim letter As String
            letter = frmStartScreen.phrase.Substring(x - 1, 1)
            lblLetter(x) = New Label()

            lblLetter(x).Font = New Font(FontFamily.GenericSansSerif, 14.0F, FontStyle.Bold)
            lblLetter(x).AutoSize = True

            If Asc(letter) < 65 Or Asc(letter) > 122 Or (Asc(letter) < 97 And Asc(letter) > 90) Then
                lblLetter(x).Text = letter
            Else
                lblLetter(x).Text = "_"
            End If

            If x = 1 Then
                lblLetter(x).Left = 12
                lblLetter(x).Top = 205
            Else
                lblLetter(x).Left = lblLetter(x - 1).Left + lblLetter(x - 1).Width + 1.5
                lblLetter(x).Top = 205
            End If


            Me.Controls.Add(lblLetter(x))
        Next
        MsgBox(frmStartScreen.phrase)
    End Sub

    Private Sub frmGame_Shown(sender As Object, e As EventArgs) Handles Me.Shown

    End Sub
End Class