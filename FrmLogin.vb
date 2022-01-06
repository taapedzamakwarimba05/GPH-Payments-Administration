Imports System.Data.OleDb
Public Class FrmLogin
    Private db As New OleDbConnection(Connect)
    'Login
    Private Sub Login()
        Dim Dgv As New OleDbDataAdapter("Select * From Users Where Username = '" & Tb_UserName.Text & "' And Password = '" & Tb_Pass.Text & "';", db)
        Dim Dtset As New DataSet
        Dgv.Fill(Dtset)
        If Dtset.Tables(0).DefaultView.Count > 0 Then
            Switchboard.Show()
            Me.Hide()

        ElseIf Tb_UserName.Text = "" Then
            ErrorProvider1.SetError(Tb_UserName, "Username Field Cannot Be Left Empty")
        Else
            MessageBox.Show("Username And/Or Password Are Invalid", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Tb_UserName.Focus()
        End If
    End Sub
    'Enter keys
    Private Sub Tb_Pass_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Tb_Pass.KeyDown
        If e.KeyCode = Keys.Enter Then
            Login()
        End If
    End Sub
    'login button
    Private Sub Bttn_Login_Click(sender As Object, e As EventArgs) Handles Bttn_Login.Click
        Login()
        Tb_UserName.ResetText()
        Tb_Pass.ResetText()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

    End Sub
End Class