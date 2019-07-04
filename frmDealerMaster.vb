Imports System.Data.OleDb

Public Class frmSupplierMaster
    Public Con As OleDbConnection
    Public Cmd As OleDbCommand
    Public Dr As OleDbDataReader
    Dim t As Integer
    Dim f As Integer


    Private Sub frmSupplierMaster_load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        btnSave.Enabled = False
        btnUpdate.Enabled = False
        btnDelete.Enabled = False
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        txtSID.Enabled = True
        txtSName.Enabled = True
        txtSAddress.Enabled = True
        txtSCity.Enabled = True
        txtSContact.Enabled = True

        Con = New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\Bhaiyya\Lalsai.accdb")
        Con.Open()

        Cmd = New OleDbCommand("Select max(SID) From tblSupplierMast", Con)

        Dr = Cmd.ExecuteReader

        Dr.Read()

        If (Dr.Item(0) IsNot DBNull.Value) Then
            t = Dr.Item(0) + 1
        Else
            t = 1
        End If
        txtSID.Text = t.ToString
        txtSName.Focus()
        btnAdd.Enabled = False
        btnSave.Enabled = True
        btnFind.Enabled = False

        Dr.Close()
        Con.Close()

        f = 0
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        'To Insert The New Record
        If f = 0 Then
            Con = New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\Bhaiyya\Lalsai.accdb")
            Con.Open()


            Cmd = New OleDbCommand("Insert Into tblSupplierMast Values(" & txtSID.Text & ",'" & txtSName.Text & "','" & txtSAddress.Text & "','" & txtSCity.Text & "'," & txtSContact.Text & ")", Con)


            Cmd.ExecuteNonQuery()

            MsgBox("Record Inserted !")

            txtSID.Clear()
            txtSName.Clear()
            txtSName.Enabled = False
            txtSAddress.Clear()
            txtSAddress.Enabled = False
            txtSCity.Clear()
            txtSCity.Enabled = False
            txtSContact.Clear()
            txtSContact.Enabled = False
            btnSave.Enabled = False
            btnAdd.Enabled = True
            btnFind.Enabled = True
            Con.Close()

        Else
            Con = New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\Bhaiyya\Lalsai.accdb")
            Con.Open()


            Cmd = New OleDbCommand("Update tblSupplierMast Set SName='" & txtSName.Text & "',SAddress='" & txtSAddress.Text & "',SCity='" & txtSCity.Text & "',SNumber=" & txtSContact.Text & " Where SID=" & txtSID.Text & "", Con)


            Cmd.ExecuteNonQuery()

            MsgBox("Record is Updated !")

            txtSID.Clear()
            txtSName.Clear()
            txtSName.Enabled = False
            txtSAddress.Clear()
            txtSAddress.Enabled = False
            txtSCity.Clear()
            txtSCity.Enabled = False
            txtSContact.Clear()
            txtSContact.Enabled = False
            btnSave.Enabled = False
            btnAdd.Enabled = True
            btnFind.Enabled = True
            Con.Close()
        End If
    End Sub

    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        Dim res As DialogResult = MessageBox.Show("Do U Want To Update Record?", "UPdate Record?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

        If res = DialogResult.Yes Then
            txtSID.ReadOnly = True
            txtSName.Enabled = True
            txtSAddress.Enabled = True
            txtSCity.Enabled = True
            txtSContact.Enabled = True
            btnSave.Enabled = True
            btnAdd.Enabled = False
            btnDelete.Enabled = False
            btnUpdate.Enabled = False
            btnFind.Enabled = False
            f = 1
        End If
    End Sub

    Private Sub btnFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFind.Click
        Try
            Dim id As Integer
            id = InputBox("Plz Enter Supplier ID:")

            Con = New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\Bhaiyya\Lalsai.accdb")
            Con.Open()

            Cmd = New OleDbCommand("Select * From tblSupplierMast Where SID=" & id & "", Con)


            Dr = Cmd.ExecuteReader

            Dr.Read()

            txtSID.Text = Dr.GetValue(0)
            txtSName.Text = Dr.GetValue(1)
            txtSAddress.Text = Dr.GetValue(2)
            txtSCity.Text = Dr.GetValue(3)
            txtSContact.Text = Dr.GetValue(4)

            Dr.Close()
            Con.Close()

            btnUpdate.Enabled = True
            btnDelete.Enabled = True
            btnAdd.Enabled = False

        Catch ex As Exception
            MsgBox("Record Does Not Found????")
        End Try
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Dim res As DialogResult = MessageBox.Show("Do U Want To Delete Record?", "Delete Record?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

        If res = DialogResult.Yes Then
            Con = New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\Bhaiyya\Lalsai.accdb")
            Con.Open()


            Cmd = New OleDbCommand("Delete From tblSupplierMast Where SID=" & txtSID.Text & "", Con)


            Cmd.ExecuteNonQuery()

            MsgBox("Record Deleted !")

            txtSID.Clear()
            txtSName.Clear()
            txtSName.Enabled = False
            txtSAddress.Clear()
            txtSAddress.Enabled = False
            txtSCity.Clear()
            txtSCity.Enabled = False
            txtSContact.Clear()
            txtSContact.Enabled = False
            btnSave.Enabled = False
            btnAdd.Enabled = True
            btnFind.Enabled = True
            btnDelete.Enabled = False
            btnUpdate.Enabled = False
            Con.Close()

        End If

    End Sub
    Private Sub txtSContact_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSContact.KeyPress

        If Asc(e.KeyChar) <> 13 AndAlso Asc(e.KeyChar) <> 8 AndAlso Not IsNumeric(e.KeyChar) Then
            'MsgBox("Plz Enter Number Only")
            e.Handled = True
        End If
        If txtSContact.Text.Length = 10 Then
            e.Handled = True
        Else

        End If
    End Sub


    Private Sub txtSName_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSName.KeyPress
        If Not Char.IsLetter(e.KeyChar) And Not e.KeyChar = Chr(Keys.Delete) And Not e.KeyChar = Chr(Keys.Back) And Not e.KeyChar = Chr(Keys.Space) Then
            e.Handled = True
        End If
    End Sub
   
    Private Sub txtSCity_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSCity.KeyPress
        If Not Char.IsLetter(e.KeyChar) And Not e.KeyChar = Chr(Keys.Delete) And Not e.KeyChar = Chr(Keys.Back) Then
            e.Handled = True
        End If
    End Sub
End Class