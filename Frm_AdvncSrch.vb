Imports System.Data.OleDb
Public Class Frm_AdvncSrch
    Private db As New OleDbConnection(Connect)

    Private Sub DgvPatient()
        Dim Dgv As New OleDbDataAdapter("Select PatientID as [Patient ID], ID_Number as [ID Number], [FirstName]+' '+[Surname] as Name ,DOB, Gender , AilmentGrade,TelephoneNumber From Patient Where PatientID Like '%" & Tb_Srch.Text & "%' or LastName Like '%" & Tb_Srch.Text & "%' ", db)
        Dim DtSet As New DataSet
        Dgv.Fill(DtSet)
        Dgv_AdvncSrch.DataSource = DtSet.Tables(0).DefaultView
    End Sub
    Private Sub Frm_AdvncSrch_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class