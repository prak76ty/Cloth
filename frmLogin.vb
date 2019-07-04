Imports System.Data.OleDb

Public Class frmLogin

    Private Sub btnLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLogin.Click
        Dim Con As New OleDbConnection()
        Con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\Bhaiyya\Lalsai.accdb"
        Con.Open()

        Dim Cmd As New OleDbCommand()
        Cmd.Connection = Con
        Cmd.CommandType = CommandType.Text
        Cmd.CommandText = "Select User_Name,Password From tblLogin Where User_Name='" & txtUserName.Text & "' and Password='" & txtPassword.Text & "'"

        Dim dr As OleDbDataReader
        dr = Cmd.ExecuteReader()
        dr.Read()

        If txtUserName.Text.Trim() = "" And txtPassword.Text.Trim() = "" Then
            MsgBox("Plz Enter User Name and PassWord!..")
            txtUserName.Focus()
        Else
            If dr.HasRows Then
                'MsgBox("Wel-Come To My Application!...")
                Me.Hide()
                frmMDI.Show()
            Else
                MsgBox("Its In Valid User!...")
                txtUserName.Clear()
                txtPassword.Clear()
                txtUserName.Focus()
            End If
        End If

        dr.Close()

        Con.Close()
    End Sub

  
End Class
