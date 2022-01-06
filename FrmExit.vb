Public Class FrmExit

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        ProgressBar1.Increment(5)
        Label2.Text = ProgressBar1.Value.ToString() & "% Exiting the system.Thank you"
        If ProgressBar1.Value = ProgressBar1.Maximum = True Then
            Timer1.Stop()
            Application.Exit()

        End If
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub
End Class