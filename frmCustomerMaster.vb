Imports System.Data.OleDb

Public Class frmCustomerMaster
    Public Con As OleDbConnection
    Public Cmd As OleDbCommand
    Public Dr As OleDbDataReader
    Dim t As Integer
    Dim f As Integer

    Private Sub frmCustomerMaster_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        btnSave.Enabled = False
        btnUpdate.Enabled = False
        btnDelete.Enabled = False
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        txtCID.Enabled = True
        txtCName.Enabled = True
        txtCAddress.Enabled = True
        txtCCity.Enabled = True
        txtCContact.Enabled = True

        Con = New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\Bhaiyya\Lalsai.accdb")
        Con.Open()
        Cmd = New OleDbCommand("Select max(CID) From tblCustMast", Con)
        Dr = Cmd.ExecuteReader
        Dr.Read()
        If (Dr.Item(0) IsNot DBNull.Value) Then
            t = Dr.Item(0) + 1
        Else
            t = 1
        End If
        txtCID.Text = t.ToString
        txtCName.Focus()
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
            Cmd = New OleDbCommand("Insert Into tblCustMast Values(" & txtCID.Text & ",'" & txtCName.Text & "','" & txtCAddress.Text & "','" & txtCCity.Text & "'," & txtCContact.Text & ")", Con)
            Cmd.ExecuteNonQuery()
            MsgBox("Record Inserted !")

            txtCID.Clear()
            txtCName.Clear()
            txtCName.Enabled = False
            txtCAddress.Clear()
            txtCAddress.Enabled = False
            txtCCity.Clear()
            txtCCity.Enabled = False
            txtCContact.Clear()
            txtCContact.Enabled = False
            btnSave.Enabled = False
            btnAdd.Enabled = True
            btnFind.Enabled = True
            Con.Close()
        Else
            Con = New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\Bhaiyya\Lalsai.accdb")
            Con.Open()
            Cmd = New OleDbCommand("Update tblCustMast Set CName='" & txtCName.Text & "',CAddress='" & txtCAddress.Text & "',CCity='" & txtCCity.Text & "',CNumber=" & txtCContact.Text & " Where CID=" & txtCID.Text & "", Con)
            Cmd.ExecuteNonQuery()
            MsgBox("Record is Updated !")
            txtCID.Clear()
            txtCName.Clear()
            txtCName.Enabled = False
            txtCAddress.Clear()
            txtCAddress.Enabled = False
            txtCCity.Clear()
            txtCCity.Enabled = False
            txtCContact.Clear()
            txtCContact.Enabled = False
            btnSave.Enabled = False
            btnAdd.Enabled = True
            btnFind.Enabled = True
            Con.Close()
        End If
    End Sub

    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        Dim res As DialogResult = MessageBox.Show("Do U Want To Update Record?", "UPdate Record?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

        If res = DialogResult.Yes Then
            txtCID.ReadOnly = True
            txtCName.Enabled = True
            txtCAddress.Enabled = True
            txtCCity.Enabled = True
            txtCContact.Enabled = True
            btnSave.Enabled = True
            btnAdd.Enabled = False
            btnDelete.Enabled = False
            btnUpdate.Enabled = False
            btnFind.Enabled = False
            f = 1
        End If

    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Dim res As DialogResult = MessageBox.Show("Do U Want To Delete Record?", "Delete Record?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

        If res = DialogResult.Yes Then
            Con = New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\Bhaiyya\Lalsai.accdb")
            Con.Open()


            Cmd = New OleDbCommand("Delete From tblCustMast Where CID=" & txtCID.Text & "", Con)


            Cmd.ExecuteNonQuery()

            MsgBox("Record Deleted !")

            txtCID.Clear()
            txtCName.Clear()
            txtCName.Enabled = False
            txtCAddress.Clear()
            txtCAddress.Enabled = False
            txtCCity.Clear()
            txtCCity.Enabled = False
            txtCContact.Clear()
            txtCContact.Enabled = False
            btnSave.Enabled = False
            btnAdd.Enabled = True
            btnFind.Enabled = True
            btnDelete.Enabled = False
            btnUpdate.Enabled = False
            Con.Close()

        End If

    End Sub


    Private Sub btnFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFind.Click

        Dim id As String = InputBox("Plz Enter Customer ID:")

        If String.IsNullOrEmpty(id) Then
            Exit Sub
        Else
            Try
                Con = New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\Bhaiyya\Lalsai.accdb")
                Con.Open()
                Cmd = New OleDbCommand("Select * From tblCustMast Where CID=" & id & "", Con)
                Dr = Cmd.ExecuteReader
                Dr.Read()

                txtCID.Text = Dr.GetValue(0)
                txtCName.Text = Dr.GetValue(1)
                txtCAddress.Text = Dr.GetValue(2)
                txtCCity.Text = Dr.GetValue(3)
                txtCContact.Text = Dr.GetValue(4)

                Dr.Close()
                Con.Close()

                btnUpdate.Enabled = True
                btnDelete.Enabled = True
                btnAdd.Enabled = False

            Catch ex As Exception
                MsgBox("Record Does Not Found????")
            End Try
        End If

        ' ''txtCID.Clear()
        ' ''txtCName.Clear()
        ' ''txtCAddress.Clear()
        ' ''txtCCity.Clear()
        ' ''txtCContact.Clear()
        ' ''txtCID.ReadOnly = False
        ' ''txtCID.Focus()


        'If Val(txtCID.Text.Trim) > 0 Then
        '    txtCID_leave(sender, e)
        'Else
        '    MsgBox("Pl Enter Cust ID:")
        '    txtCID.Clear()
        '    txtCID.Focus()
        'End If
        
    End Sub

    Private Sub txtCID_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCID.Leave
        'Try
        '    Con = New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\Bhaiyya\Lalsai.accdb")
        '    Con.Open()
        '    Cmd = New OleDbCommand("Select * From tblCustMast Where CID=" & txtCID.Text & "", Con)
        '    Dr = Cmd.ExecuteReader()
        '    Dr.Read()

        '    txtCID.Text = Dr.GetValue(0)
        '    txtCName.Text = Dr.GetValue(1)
        '    txtCAddress.Text = Dr.GetValue(2)
        '    txtCCity.Text = Dr.GetValue(3)
        '    txtCContact.Text = Dr.GetValue(4)

        '    Dr.Close()
        '    Con.Close()
        'Catch ex As Exception
        '    MsgBox("Record Does Not Found????")
        'End Try
    End Sub

    Private Sub txtCID_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCID.DoubleClick
        'Con = New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\Bhaiyya\Lalsai.accdb")
        'Con.Open()
        'Cmd = New OleDbCommand("Select * From tblCustMast Where CID=" & txtCID.Text & "", Con)
        'Dr = Cmd.ExecuteReader()
        'Dr.Read()

        'txtCID.Text = Dr.GetValue(0)
        ' '' ''txtCName.Text = Dr.GetValue(1)
        'txtCAddress.Text = Dr.GetValue(2)
        'txtCCity.Text = Dr.GetValue(3)
        'txtCContact.Text = Dr.GetValue(4)

        'btnUpdate.Enabled = True
        'btnDelete.Enabled = True
        'btnAdd.Enabled = False

        'Dr.Close()
        'Con.Close()
    End Sub

  
    Private Sub txtCContact_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCContact.KeyPress
        If Asc(e.KeyChar) <> 13 AndAlso Asc(e.KeyChar) <> 8 AndAlso Not IsNumeric(e.KeyChar) Then
            'MsgBox("Plz Enter Number Only")
            e.Handled = True
        End If
    End Sub


    Private Sub txtCName_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCName.KeyPress
        If Not Char.IsLetter(e.KeyChar) And Not e.KeyChar = Chr(Keys.Delete) And Not e.KeyChar = Chr(Keys.Back) And Not e.KeyChar = Chr(Keys.Space) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtCCity_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCCity.KeyPress
        If Not Char.IsLetter(e.KeyChar) And Not e.KeyChar = Chr(Keys.Delete) And Not e.KeyChar = Chr(Keys.Back) Then
            e.Handled = True
        End If
    End Sub
End Class