<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmStartScreen
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnOnePlayer = New System.Windows.Forms.Button()
        Me.btnTwoPlayers = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 72.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(41, 72)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(542, 108)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "HANGMAN"
        '
        'btnOnePlayer
        '
        Me.btnOnePlayer.Location = New System.Drawing.Point(59, 222)
        Me.btnOnePlayer.Name = "btnOnePlayer"
        Me.btnOnePlayer.Size = New System.Drawing.Size(254, 70)
        Me.btnOnePlayer.TabIndex = 1
        Me.btnOnePlayer.Text = "One Player"
        Me.btnOnePlayer.UseVisualStyleBackColor = True
        '
        'btnTwoPlayers
        '
        Me.btnTwoPlayers.Location = New System.Drawing.Point(319, 222)
        Me.btnTwoPlayers.Name = "btnTwoPlayers"
        Me.btnTwoPlayers.Size = New System.Drawing.Size(254, 70)
        Me.btnTwoPlayers.TabIndex = 2
        Me.btnTwoPlayers.Text = "Two Players"
        Me.btnTwoPlayers.UseVisualStyleBackColor = True
        '
        'frmStartScreen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(629, 380)
        Me.Controls.Add(Me.btnTwoPlayers)
        Me.Controls.Add(Me.btnOnePlayer)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmStartScreen"
        Me.Text = "Hangman"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnOnePlayer As System.Windows.Forms.Button
    Friend WithEvents btnTwoPlayers As System.Windows.Forms.Button

End Class
