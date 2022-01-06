Public Class WelcomeFrm

    Private Sub WelcomeFrm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        ProgressBar1.Increment(2)
        Label2.Text = ProgressBar1.Value.ToString() & " % Please Wait!The system is starting....."
        If ProgressBar1.Value = ProgressBar1.Maximum = True Then
            Timer1.Stop()
            FrmLogin.Show()
            Me.Hide()
        End If
    End Sub
End Class
