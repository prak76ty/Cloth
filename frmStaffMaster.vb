Imports System.Data.OleDb

Public Class frmStaffMaster

    Public Con As OleDbConnection
    Public Cmd As OleDbCommand
    Public Dr As OleDbDataReader
    Public Gender As String
    Public t As Integer
    Public f As Integer

    Private Sub frmStaffMaster_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        btnSave.Enabled = False
        btnUpdate.Enabled = False
        btnDelete.Enabled = False
        rdbMale.Enabled = False
        rdbFemale.Enabled = False
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        txtID.Enabled = True
        txtName.Enabled = True
        rdbMale.Enabled = True
        rdbFemale.Enabled = True
        txtAddress.Enabled = True
        txtContact.Enabled = True

        Con = New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\Bhaiyya\Lalsai.accdb")
        Con.Open()

        Cmd = New OleDbCommand("Select max(ID) From tblStaffMast", Con)

        Dr = Cmd.ExecuteReader

        Dr.Read()

        If (Dr.Item(0) IsNot DBNull.Value) Then
            t = Dr.Item(0) + 1
        Else
            t = 1
        End If
        txtID.Text = t.ToString
        txtName.Focus()
        btnAdd.Enabled = False
        btnSave.Enabled = True
        btnFind.Enabled = False
        Dr.Close()

        Con.Close()

        f = 0

    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If f = 0 Then
            Con = New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\Bhaiyya\Lalsai.accdb")
            Con.Open()

            If rdbMale.Checked = True Then
                Gender = rdbMale.Text
            Else
                Gender = rdbFemale.Text
            End If

            ' If rdbMale.Checked = True Then
            Cmd = New OleDbCommand("Insert Into tblStaffMast Values(" & txtID.Text & ",'" & txtName.Text & "','" & Gender & "','" & txtAddress.Text & "','" & txtContact.Text & "' )", Con)
            'Else
            'Cmd = New OleDbCommand("Insert Into tblStaffMast Values(" & txtID.Text & ",'" & txtName.Text & "','" & rdbFemale.Text & "','" & txtAddress.Text & "','" & txtContact.Text & "' )", Con)
            ' End If

            Cmd.ExecuteNonQuery()

            MsgBox("Record Inserted !")

            txtID.Clear()
            txtName.Clear()
            txtName.Enabled = False
            txtAddress.Clear()
            txtAddress.Enabled = False
            txtContact.Clear()
            txtContact.Enabled = False
            btnSave.Enabled = False
            btnAdd.Enabled = True
            btnFind.Enabled = True
            rdbMale.Enabled = False
            rdbFemale.Enabled = False

            Con.Close()

        Else
            Con = New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\Bhaiyya\Lalsai.accdb")
            Con.Open()

            If rdbMale.Checked = True Then
                Gender = rdbMale.Text
            Else
                Gender = rdbFemale.Text
            End If


            Cmd = New OleDbCommand("Update tblStaffMast Set Name='" & txtName.Text & "',Gender='" & Gender & "',Address='" & txtAddress.Text & "',Contact=" & txtContact.Text & " Where ID=" & txtID.Text & "", Con)


            Cmd.ExecuteNonQuery()

            MsgBox("Record is Updated !")

            txtID.Clear()
            txtName.Clear()
            txtName.Enabled = False
            txtAddress.Clear()
            txtAddress.Enabled = False

            txtContact.Clear()
            txtContact.Enabled = False
           
            btnSave.Enabled = False
            btnAdd.Enabled = True
            btnFind.Enabled = True
            Con.Close()
        End If
    End Sub

    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        Dim res As DialogResult = MessageBox.Show("Do U Want To Update Record?", "UPdate Record?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

        If res = DialogResult.Yes Then
            txtID.ReadOnly = True
            txtName.Enabled = True
            rdbMale.Enabled = True
            rdbFemale.Enabled = True
            txtAddress.Enabled = True
            txtContact.Enabled = True

            btnSave.Enabled = True
            btnAdd.Enabled = False
            btnDelete.Enabled = False
            btnUpdate.Enabled = False
            btnFind.Enabled = False
            f = 1
        End If
    End Sub

    Private Sub txtContact_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtContact.KeyPress
        If Asc(e.KeyChar) <> 13 AndAlso Asc(e.KeyChar) <> 8 AndAlso Not IsNumeric(e.KeyChar) Then
            'MsgBox("Plz Enter Number Only")
            e.Handled = True
        End If
    End Sub


    Private Sub txtName_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtName.KeyPress
        If Not Char.IsLetter(e.KeyChar) And Not e.KeyChar = Chr(Keys.Delete) And Not e.KeyChar = Chr(Keys.Back) And Not e.KeyChar = Chr(Keys.Space) Then
            e.Handled = True
        End If
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Dim res As DialogResult = MessageBox.Show("Do U Want To Delete Record?", "Delete Record?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

        If res = DialogResult.Yes Then
            Con = New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\Bhaiyya\Lalsai.accdb")
            Con.Open()


            Cmd = New OleDbCommand("Delete From tblStaffMast Where ID=" & txtID.Text & "", Con)


            Cmd.ExecuteNonQuery()

            MsgBox("Record Deleted !")

            txtID.Clear()
            txtName.Clear()
            txtName.Enabled = False
            txtAddress.Clear()
            txtAddress.Enabled = False

            txtContact.Clear()
            txtContact.Enabled = False
            btnSave.Enabled = False
            btnAdd.Enabled = True
            btnFind.Enabled = True
            btnDelete.Enabled = False
            btnUpdate.Enabled = False
            Con.Close()

        End If

    End Sub


    Private Sub btnFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFind.Click

        Try

            Dim id As Integer
            id = InputBox("Plz Enter Customer ID:")

            Con = New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\Bhaiyya\Lalsai.accdb")
            Con.Open()

            Cmd = New OleDbCommand("Select * From tblStaffMast Where ID=" & id & "", Con)


            Dr = Cmd.ExecuteReader

            Dr.Read()

            txtID.Text = Dr.GetValue(0)
            txtName.Text = Dr.GetValue(1)

            If rdbMale.Text = Dr.GetValue(2) Then
                rdbMale.Checked = True
            Else
                rdbFemale.Checked = True
            End If

            txtAddress.Text = Dr.GetValue(3)
            txtContact.Text = Dr.GetValue(4)

            Dr.Close()
            Con.Close()

            btnUpdate.Enabled = True
            btnDelete.Enabled = True
            btnAdd.Enabled = False
            rdbMale.Enabled = False
            rdbFemale.Enabled = False

        Catch ex As Exception
            MsgBox("Record Does Not Found????")
        End Try


    End Sub
End Class