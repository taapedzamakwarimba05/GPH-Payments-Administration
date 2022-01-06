Imports System.Data.OleDb
Public Class Switchboard
    Private db As New OleDbConnection(Connect)
    Public psswrd As String
    Public usr As String


    'Get Username And Password
    Private Sub getUsrPssword()
        Dim Dgv As New OleDbDataAdapter("Select * From Users", db)
        Dim Dtset As New DataSet
        Dgv.Fill(Dtset)
        If Dtset.Tables(0).DefaultView.Count > 0 Then
            usr = Dtset.Tables(0).DefaultView.Item(0).Item(0)
            psswrd = Dtset.Tables(0).DefaultView.Item(0).Item(1)
        End If
    End Sub
    'Disable all Textboxes and buttons when Deleteing records
    Private Sub DisableButtons()
        BtnAddEmployee.Enabled = False
        BtnEditEmployee.Enabled = False
        TxtFname.ReadOnly = True
        TxtSname.ReadOnly = True
        TxtNID.ReadOnly = True
        DateTimePicker1.Enabled = False
        Cbx1.Enabled = False
        Cbx2.Enabled = False
        TxtPnumber.ReadOnly = True
    End Sub
    'fill dataGridView
    Public Sub DgvEmployees()
        'Fill Data GridViews
        Dim Dgv As New OleDbDataAdapter("SELECT EmployeeID as [Employee ID],ID_Number As [National ID] ,Surname As [Surname] , FirstName As [First Name],Gender As [Gender],TelephoneNumber As [Department] FROM Employee Order BY Surname ASC", db)
        Dim DtSet As New DataSet
        Dgv.Fill(DtSet)
        Dgv_Employees.DataSource = DtSet.Tables(0).DefaultView
    End Sub
    Public Sub DgvPatients()
        'Fill Data GridViews
        Dim Dgv As New OleDbDataAdapter("SELECT PatientID as [Patient ID],ID_Number As [National ID] ,Surname As [Surname] , FirstName As [First Name],Gender As [Gender],AilmentGrade As [Ailment Grade],TelephoneNumber As[Phone Number] FROM Patient Order BY Surname ASC", db)
        Dim DtSet As New DataSet
        Dgv.Fill(DtSet)
        Dgv_Patients.DataSource = DtSet.Tables(0).DefaultView
    End Sub
    Public Sub DgvPayments()
        'Fill Data GridViews
        'Dim Dgv As New OleDbDataAdapter("SELECT Reference_Code as [Reference ID],PaymentPurpose As [Payment Purpose] ,PaymentType As [Method Of Payment] , Amount As [Amount Paid],DateOfPayment As [Date Of Payment],PaymentPatient.PatientID As[Patient ID] FROM Payment INNER JOIN PaymentPatient ON Payment.PatientID = PaymentPatient.PatientID Order BY Surname ASC", db)
        Dim Dgv As New OleDbDataAdapter("SELECT Reference_Code as [Reference ID],PaymentPurpose As [Payment Purpose] ,PaymentType As [Method Of Payment] , Amount As [Amount Paid],DateOfPayment As [Date Of Payment] FROM Payments Order BY Reference_Code ASC", db)
        Dim DtSet As New DataSet
        Dgv.Fill(DtSet)
        Dgv_Transactions.DataSource = DtSet.Tables(0).DefaultView
    End Sub
    Public Sub DgvPayments2()
        'Fill Data GridViews
        'Dim Dgv As New OleDbDataAdapter("SELECT Reference_Code as [Reference ID],PaymentPurpose As [Payment Purpose] ,PaymentType As [Method Of Payment] , Amount As [Amount Paid],DateOfPayment As [Date Of Payment],PaymentPatient.PatientID As[Patient ID] FROM Payment INNER JOIN PaymentPatient ON Payment.PatientID = PaymentPatient.PatientID Order BY Surname ASC", db)
        Dim Dgv As New OleDbDataAdapter("SELECT Reference_Code as [Reference ID],PaymentPurpose As [Payment Purpose] ,PaymentType As [Method Of Payment] , Amount As [Amount Paid],DateOfPayment As [Date Of Payment] FROM Payments Order BY DateOfPayment ASC", db)
        Dim DtSet As New DataSet
        Dgv.Fill(DtSet)
        Dgv_PaymentsMade.DataSource = DtSet.Tables(0).DefaultView
    End Sub
    'fill ComboBox
    Public Sub fillCbox()
        'Fill Patient ID combobox
        Dim Dgv1 As New OleDbDataAdapter("SELECT PatientID  FROM Patient;", db)
        Dim Dtset1 As New DataSet
        Dgv1.Fill(Dtset1)
        CbSearchPatient.DataSource = Dtset1.Tables(0).DefaultView
        CbSearchPatient.ValueMember = "PatientID"

    End Sub
    'Load SwitchBoard
    Private Sub Switchboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Make Payments
        fillCbox()

        ' Management accounts
        getUsrPssword()
        Lbl_Usrname.Text = usr
        'Fill Employee gridview
        DgvEmployees()
        'Fill Patients gridwview
        DgvPatients()
        'Fill Payments Gridview
        DgvPayments()
        'Fill payments Made Grid View
        DgvPayments2()
    End Sub
    'Logout from the system
    Private Sub Button5_Click_1(sender As Object, e As EventArgs) Handles Button5.Click
        Me.Close()
        FrmLogin.Show()
        FrmLogin.Tb_Pass.ResetText()
        FrmLogin.Tb_UserName.Focus()
    End Sub
    'Exit the application
    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        'Frm_Login.Hide()
        FrmExit.Show()
        Me.Hide()

    End Sub

    'Add Employee
    Private Sub BtnAddEmployee_Click(sender As Object, e As EventArgs) Handles BtnAddEmployee.Click
        If MessageBox.Show("Do You Want To Add This Employee?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.No Then
            Exit Sub
        ElseIf TxtFname.Text = "" Or TxtSname.Text = "" Then
            MessageBox.Show("Please Enter First Name Or Last Name Of The Employee.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        Try
            If TxtEmplyeeId.Text = "" Then
                MessageBox.Show("Please Enter The Employee ID.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If

            Dim Insrt As New OleDbCommand("INSERT INTO Employee Values('" & TxtEmplyeeId.Text & "','" & TxtNID.Text & "','" & TxtFname.Text & "','" & TxtSname.Text & "','" & DateTimePicker1.Text & "','" & Cbx1.Text & "','" & Cbx2.Text & "','" & TxtPnumber.Text & "');", db)
            db.Open()
            Insrt.ExecuteNonQuery()
            db.Close()
            MessageBox.Show("The Employee Record Has Been Successfully Added!")
            TxtEmplyeeId.Focus()
            TxtFname.ResetText()
            TxtSname.ResetText()
            TxtNID.ResetText()
            TxtPnumber.ResetText()
            Cbx1.ResetText()
            Cbx2.ResetText()
            DateTimePicker1.ResetText()
            DgvEmployees()
        Catch ex As OleDb.OleDbException
            db.Close()
            MessageBox.Show("The Employee Record Already Exist!" & vbNewLine & "Please Check For Employee I.D.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub
    'Add Patient
    Private Sub BtnAddPatient_Click(sender As Object, e As EventArgs) Handles BtnAddPatient.Click
        If MessageBox.Show("Do You Want To Add This Patient?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.No Then
            Exit Sub
        ElseIf TxtName.Text = "" Or TxtSrname.Text = "" Then
            MessageBox.Show("Please Enter First Name Or Last Name Of The Patient.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        Try
            If TxtPatientID.Text = "" Then
                MessageBox.Show("Please Enter The Patient ID.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If

            Dim Insrt As New OleDbCommand("INSERT INTO Patient Values('" & TxtPatientID.Text & "','" & TxtNationalID.Text & "','" & TxtName.Text & "','" & TxtSrname.Text & "','" & Dob.Text & "','" & Cbx4.Text & "','" & Cbx3.Text & "','" & TxtTeleNumber.Text & "');", db)
            db.Open()
            Insrt.ExecuteNonQuery()
            db.Close()
            MessageBox.Show("The Patient Record Has Been Successfully Added!")
            TxtPatientID.Focus()
            TxtName.ResetText()
            TxtSrname.ResetText()
            TxtNationalID.ResetText()
            TxtTeleNumber.ResetText()
            Cbx3.ResetText()
            Cbx4.ResetText()
            Dob.ResetText()
            DgvPatients()
        Catch ex As OleDb.OleDbException
            db.Close()
            MessageBox.Show("The Patient Record Already Exist!" & vbNewLine & "Please Check For Patient I.D.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            TxtPatientID.Focus()
            TxtName.ResetText()
            TxtSrname.ResetText()
            TxtNationalID.ResetText()
            TxtTeleNumber.ResetText()
            Cbx3.ResetText()
            Cbx4.ResetText()
            Dob.ResetText()
        End Try
    End Sub

    Private Sub Bttn_AdvncSrch1_Click(sender As Object, e As EventArgs) Handles BtnSearchPatient.Click
        'Me.Enabled = False
        'rm_AdvncSrch.Visible = True
        Dim Insrt As New OleDbCommand("Update Payments Set PatientID = #" & CbSearchPatient.Text & "# ;", db)
        db.Open()
        Insrt.ExecuteNonQuery()
        db.Close()
        MessageBox.Show("The Patient Id  Has Been Selected!")
        CbSearchPatient.ResetText()
    End Sub
    'Confirm Change User Name
    Private Sub Bttn_Cnfrm1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bttn_Cnfrm1.Click
        If Tb_NewUser.Text = "" Then
            ErrorProvider1.SetError(Tb_NewUser, "The Username Field is Blank.")
            Exit Sub
        End If
        If Tb_CnfrmPass.Text = psswrd Then
            If MessageBox.Show("Do You Want Change The Username?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.No Then
                Exit Sub
            End If
            Dim UsrrName As New OleDbCommand("Update Users Set UserName = '" & Tb_NewUser.Text & "'", db)
            db.Open()
            UsrrName.ExecuteNonQuery()
            db.Close()
            getUsrPssword()
            Lbl_Usrname.Text = usr
            Tb_NewUser.ResetText()
            Tb_CnfrmPass.ResetText()
            ErrorProvider1.Clear()
            MessageBox.Show("The Username Has Been Change.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        ElseIf Tb_CnfrmPass.Text = "" Then
            ErrorProvider1.SetError(Tb_CnfrmPass, "The Password Field is Blank.")
        Else
            ErrorProvider1.SetError(Tb_CnfrmPass, "Please Check Your Password.")
        End If
    End Sub
    'Change Password
    Private Sub Bttn_Cnfrm2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bttn_Cnfrm2.Click
        If Tb_CP.Text = psswrd Then
            If Tb_NP.Text <> Tb_CPP.Text Then
                ErrorProvider1.SetError(Tb_CPP, "The Password Does Not Match.")
                Exit Sub
            End If
            If Tb_NP.Text = "" Or Tb_CPP.Text = "" Then
                ErrorProvider1.SetError(Tb_CPP, "The Field is Blank.")
                Exit Sub
            End If

            If MessageBox.Show("Do You Want Change The Password?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.No Then
                Exit Sub
            End If

            Dim Psswrd As New OleDbCommand("Update Users Set Password = '" & Tb_CPP.Text & "'", db)
            db.Open()
            Psswrd.ExecuteNonQuery()
            db.Close()
            getUsrPssword()
            Lbl_CP.ResetText()
            Tb_CP.ResetText()
            Tb_NP.ResetText()
            Tb_CPP.ResetText()
            ErrorProvider1.Clear()
            MessageBox.Show("The Password Has Been Change.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            ErrorProvider1.SetError(Tb_CP, "Please Check Your Password")
        End If
    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub CbSearchPatient_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CbSearchPatient.SelectedIndexChanged
        Dim Dgv As New OleDbDataAdapter("SELECT [FirstName] + ' ' + [Surname] as Name , AilmentGrade,Gender,TelephoneNumber FROM Patient Where PatientID = '" & CbSearchPatient.Text & "';", db)
        Dim Dtset As New DataSet
        Dgv.Fill(Dtset)
        If Dtset.Tables(0).DefaultView.Count > 0 Then
            Tb_Name.Text = Dtset.Tables(0).DefaultView.Item(0).Item(0)
            Tb_AilGrade.Text = Dtset.Tables(0).DefaultView.Item(0).Item(1)
            Tb_Gender.Text = Dtset.Tables(0).DefaultView.Item(0).Item(2)
            Tb_TN.Text = Dtset.Tables(0).DefaultView.Item(0).Item(3)
        End If
        ErrorProvider1.Clear()
        DgvPayments2()
    End Sub
    'Record Payment
    Private Sub Bttn_RecrdPayment_Click(sender As Object, e As EventArgs) Handles Bttn_RecrdPayment.Click
        If MessageBox.Show("Do You Want To Add This Payment Record?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.No Then
            Exit Sub
        ElseIf CbxPaymentPurpose.Text = "" Or TbAmount.Text = "" Then

            MessageBox.Show("Please Enter Amount Or Purpose Of The Payment.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        Try
            If TxtReferenceCode.Text = "" Then
                MessageBox.Show("Please Enter The Payment Reference Code.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If

            Dim Insrt As New OleDbCommand("INSERT INTO Payments Values('" & TxtReferenceCode.Text & "','" & CbxPaymentPurpose.Text & "','" & CbxPaymentType.Text & "','" & TbAmount.Text & "','" & DateTimePaymentDate.Text & "');", db)
            db.Open()
            Insrt.ExecuteNonQuery()
            db.Close()
            MessageBox.Show("The Payment Record Has Been Successfully Added!")
            TxtReferenceCode.Focus()
            CbxPaymentPurpose.ResetText()
            CbxPaymentType.ResetText()
            TbAmount.ResetText()
            DateTimePaymentDate.ResetText()
            TxtReferenceCode.Focus()
            DgvPayments2()
        Catch ex As OleDb.OleDbException
            db.Close()
            MessageBox.Show("The Payment Record Already Exist!" & vbNewLine & "Please Check For Payment Refence Code.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub
    'Update Employee Records 
    Private Sub BtnEditEmployee_Click(sender As Object, e As EventArgs) Handles BtnEditEmployee.Click
        If TxtEmplyeeId.Text = "" Then
            MessageBox.Show("Please Enter The Employee ID.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            TxtEmplyeeId.Focus()
            Exit Sub
        End If

        If MessageBox.Show("Do You Want To Update This Employee?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.No Then
            Exit Sub
        End If



        Dim Updte As New OleDbCommand("UPDATE Employee Set EmployeeID = '" & TxtEmplyeeId.Text & "' , ID_Number = '" & TxtNID.Text & "',FirstName = '" & TxtFname.Text & "', Surname = '" & TxtSname.Text & "', DOB = '" & DateTimePicker1.Text & "', Gender = '" & Cbx1.Text & "', TelephoneNumber = '" & Cbx2.Text & "', Department = '" & TxtPnumber.Text & "' Where EmployeeID = '" & Dgv_Employees.CurrentRow.Cells(0).Value & "';", db)
        db.Open()
        Updte.ExecuteNonQuery()
        db.Close()
        MessageBox.Show("The Employee Record Has Been Successfully Altered!")
        TxtEmplyeeId.ResetText()
        TxtFname.ResetText()
        TxtSname.ResetText()
        TxtNID.ResetText()
        TxtPnumber.ResetText()
        Cbx1.ResetText()
        Cbx2.ResetText()
        DateTimePicker1.ResetText()
        TxtEmplyeeId.Focus()
    End Sub
    'Update Patient Records 
    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles BtnEditPatient.Click
        If TxtPatientID.Text = "" Then
            MessageBox.Show("Please Enter The Patient ID.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            TxtPatientID.Focus()
            Exit Sub
        End If

        If MessageBox.Show("Do You Want To Update This Patient Record?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.No Then
            Exit Sub
        End If



        Dim Updte As New OleDbCommand("UPDATE Patient Set PatientID = '" & TxtPatientID.Text & "' , ID_Number = '" & TxtNationalID.Text & "',FirstName = '" & TxtName.Text & "', Surname = '" & TxtSrname.Text & "', DOB = '" & Dob.Text & "', Gender = '" & Cbx4.Text & "', AilmentGrade = '" & Cbx4.Text & "', TelephoneNumber = '" & TxtTeleNumber.Text & "' Where PatientID = '" & Dgv_Patients.CurrentRow.Cells(0).Value & "';", db)
        db.Open()
        Updte.ExecuteNonQuery()
        db.Close()
        MessageBox.Show("The Patient Record Has Been Successfully Altered!")
        TxtPatientID.ResetText()
        TxtName.ResetText()
        TxtSrname.ResetText()
        TxtNationalID.ResetText()
        TxtTeleNumber.ResetText()
        Cbx3.ResetText()
        Cbx4.ResetText()
        Dob.ResetText()
        TxtPatientID.Focus()
    End Sub
    'Delete Employee Records
    Private Sub BtnDeleteEmployee_Click(sender As Object, e As EventArgs) Handles BtnDeleteEmployee.Click
        If MessageBox.Show("Do You Want To Delete The Selected Employee Record?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.No Then
            Exit Sub
        End If
        Dim dlte As New OleDbCommand("Delete From Employee Where EmployeeID = '" & Dgv_Employees.CurrentRow.Cells(0).Value & "'", db)
        db.Open()
        dlte.ExecuteNonQuery()
        db.Close()
        DgvEmployees()
        DisableButtons()
        MessageBox.Show("The Employee Record Has Been Deleted From The Database!")

    End Sub
    'Delete Patient Records
    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        DisableButtons()
        If MessageBox.Show("Do You Want To Delete The Selected Patient Record?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.No Then
            Exit Sub
        End If
        Dim dlte As New OleDbCommand("Delete From Patient Where PatientID = '" & Dgv_Patients.CurrentRow.Cells(0).Value & "'", db)
        db.Open()
        dlte.ExecuteNonQuery()
        db.Close()
        DgvPatients()
        DisableButtons()
        MessageBox.Show("The Patient Record Has Been Deleted From The Database!")
    End Sub
End Class