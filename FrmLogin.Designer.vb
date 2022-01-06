<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmLogin
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmLogin))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Lbl_UserName = New System.Windows.Forms.Label()
        Me.Tb_UserName = New System.Windows.Forms.TextBox()
        Me.Lbl_Pass = New System.Windows.Forms.Label()
        Me.Tb_Pass = New System.Windows.Forms.TextBox()
        Me.Bttn_Login = New System.Windows.Forms.Button()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Sitka Subheading", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(24, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(635, 28)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "GWERU PROVINCIAL HOSPITAL PAYMENT ADMINISTRATION SYSTEM"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(57, 74)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(148, 199)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 10
        Me.PictureBox1.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.Lbl_UserName)
        Me.GroupBox1.Controls.Add(Me.Tb_UserName)
        Me.GroupBox1.Controls.Add(Me.Lbl_Pass)
        Me.GroupBox1.Controls.Add(Me.Tb_Pass)
        Me.GroupBox1.Controls.Add(Me.Bttn_Login)
        Me.GroupBox1.Location = New System.Drawing.Point(292, 90)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(356, 183)
        Me.GroupBox1.TabIndex = 9
        Me.GroupBox1.TabStop = False
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Sitka Subheading", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(100, 137)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 31)
        Me.Button1.TabIndex = 5
        Me.Button1.Text = "Cancel"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Lbl_UserName
        '
        Me.Lbl_UserName.AutoSize = True
        Me.Lbl_UserName.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Lbl_UserName.Font = New System.Drawing.Font("Sitka Subheading", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_UserName.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Lbl_UserName.Location = New System.Drawing.Point(6, 27)
        Me.Lbl_UserName.Name = "Lbl_UserName"
        Me.Lbl_UserName.Size = New System.Drawing.Size(74, 19)
        Me.Lbl_UserName.TabIndex = 0
        Me.Lbl_UserName.Text = "Username :"
        '
        'Tb_UserName
        '
        Me.Tb_UserName.Font = New System.Drawing.Font("Sitka Subheading", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Tb_UserName.Location = New System.Drawing.Point(100, 26)
        Me.Tb_UserName.Name = "Tb_UserName"
        Me.Tb_UserName.Size = New System.Drawing.Size(206, 24)
        Me.Tb_UserName.TabIndex = 1
        '
        'Lbl_Pass
        '
        Me.Lbl_Pass.AutoSize = True
        Me.Lbl_Pass.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Lbl_Pass.Font = New System.Drawing.Font("Sitka Subheading", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Pass.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Lbl_Pass.Location = New System.Drawing.Point(11, 78)
        Me.Lbl_Pass.Name = "Lbl_Pass"
        Me.Lbl_Pass.Size = New System.Drawing.Size(72, 19)
        Me.Lbl_Pass.TabIndex = 2
        Me.Lbl_Pass.Text = "Password :"
        '
        'Tb_Pass
        '
        Me.Tb_Pass.Font = New System.Drawing.Font("Sitka Subheading", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Tb_Pass.Location = New System.Drawing.Point(100, 74)
        Me.Tb_Pass.Name = "Tb_Pass"
        Me.Tb_Pass.Size = New System.Drawing.Size(206, 24)
        Me.Tb_Pass.TabIndex = 3
        Me.Tb_Pass.UseSystemPasswordChar = True
        '
        'Bttn_Login
        '
        Me.Bttn_Login.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Bttn_Login.Font = New System.Drawing.Font("Sitka Subheading", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Bttn_Login.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Bttn_Login.Location = New System.Drawing.Point(226, 137)
        Me.Bttn_Login.Name = "Bttn_Login"
        Me.Bttn_Login.Size = New System.Drawing.Size(80, 31)
        Me.Bttn_Login.TabIndex = 4
        Me.Bttn_Login.Text = "Login"
        Me.Bttn_Login.UseVisualStyleBackColor = False
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'FrmLogin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(711, 314)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "FrmLogin"
        Me.Text = "Login Form"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Lbl_UserName As System.Windows.Forms.Label
    Friend WithEvents Tb_UserName As System.Windows.Forms.TextBox
    Friend WithEvents Lbl_Pass As System.Windows.Forms.Label
    Friend WithEvents Tb_Pass As System.Windows.Forms.TextBox
    Friend WithEvents Bttn_Login As System.Windows.Forms.Button
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
End Class
