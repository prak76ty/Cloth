Imports System.Data.OleDb

Public Class frmProductMaster
    Public Con As OleDbConnection
    Public Cmd As OleDbCommand
    Public Dr As OleDbDataReader
    Dim t As Integer
    Dim f As Integer
    Dim Avl_Qty As Integer

    Private Sub frmProductMaster_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        btnSave.Enabled = False
        btnUpdate.Enabled = False
        btnDelete.Enabled = False
        'txtPID.Enabled = False
        'cmbCatagory.Enabled = False
        'cmbType.Enabled = False
        'cmbSize.Enabled = False
        'cmbCompany.Enabled = False
        Clear()
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        txtPID.Enabled = True
        cmbCatagory.Enabled = True
        cmbType.Enabled = True
        cmbSize.Enabled = True
        cmbCompany.Enabled = True

        Con = New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\Bhaiyya\Lalsai.accdb")
        Con.Open()

        Cmd = New OleDbCommand("Select max(PID) From tblProductMast", Con)

        Dr = Cmd.ExecuteReader

        Dr.Read()

        If (Dr.Item(0) IsNot DBNull.Value) Then
            t = Dr.Item(0) + 1
        Else
            t = 1
        End If
        txtPID.Text = t.ToString
        cmbCatagory.Focus()
        btnAdd.Enabled = False
        btnSave.Enabled = True
        btnFind.Enabled = False
        Dr.Close()

        Con.Close()

        f = 0
        ' cmbCatagory.Text = "Select"

    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        'To Insert The New Record
        If f = 0 Then
            Avl_Qty = 0
            Con = New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\Bhaiyya\Lalsai.accdb")
            Con.Open()


            If cmbCatagory.Text = "Select" Then
                MsgBox("Select an Valid Catagory")
            ElseIf cmbType.Text = "Select" Then
                MsgBox("Select an Valid Type")
            ElseIf cmbSize.Text = "Select" Then
                MsgBox("Select an Valid Size")
            ElseIf cmbCompany.Text = "Select" Then
                MsgBox("Select an Valid Company")
            Else

                Cmd = New OleDbCommand("Insert Into tblProductMast Values(" & txtPID.Text & ",'" & cmbCatagory.Text & "','" & cmbType.Text & "','" & cmbSize.Text & "','" & cmbCompany.Text & "'," & Avl_Qty & ")", Con)


                Cmd.ExecuteNonQuery()

                MsgBox("Record Inserted !")

                txtPID.Clear()

                cmbCatagory.Text = "Select"
                cmbCatagory.Enabled = False
                cmbType.Text = "Select"

                cmbType.Enabled = False
                cmbSize.Text = "Select"
                cmbSize.Enabled = False
                cmbSize.Text = "Select"

                cmbCompany.Text = "Select"
                cmbCompany.Enabled = False

                Clear()

                btnSave.Enabled = False
                btnAdd.Enabled = True
                btnFind.Enabled = True
            End If



            Con.Close()

        Else
            Con = New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\Bhaiyya\Lalsai.accdb")
            Con.Open()


            If cmbCatagory.Text = "Select" Then
                MsgBox("Select an Valid Catagory")
            ElseIf cmbType.Text = "Select" Then
                MsgBox("Select an Valid Type")
            ElseIf cmbSize.Text = "Select" Then
                MsgBox("Select an Valid Size")
            ElseIf cmbCompany.Text = "Select" Then
                MsgBox("Select an Valid Company")
            Else

                Cmd = New OleDbCommand("Update tblProductMast Set PCatagory='" & cmbCatagory.Text & "',PType='" & cmbType.Text & "',PSize='" & cmbSize.Text & "',PCompany='" & cmbCompany.Text & "' Where PID=" & txtPID.Text & "", Con)


                Cmd.ExecuteNonQuery()

                MsgBox("Record is Updated !")

                'txtPID.Clear()
                'cmbCatagory.Enabled = False
                'cmbCatagory.Text = "Select"
                'cmbType.Enabled = False
                'cmbType.Text = "Select"
                'cmbSize.Enabled = False
                'cmbSize.Text = "Select"
                'cmbCompany.Enabled = False
                'cmbCompany.Text = "Select"

                Clear()

                btnSave.Enabled = False
                btnAdd.Enabled = True
                btnFind.Enabled = True
                Con.Close()
            End If
        End If



    End Sub

    Private Sub btnFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFind.Click
        Try
            Dim id As Integer
            id = InputBox("Plz Enter Product ID:")

            Con = New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\Bhaiyya\Lalsai.accdb")
            Con.Open()

            Cmd = New OleDbCommand("Select * From tblProductMast Where PID=" & id & "", Con)


            Dr = Cmd.ExecuteReader

            Dr.Read()

            txtPID.Text = Dr.GetValue(0)
            cmbCatagory.Text = Dr.GetValue(1)
            cmbType.Text = Dr.GetValue(2)
            cmbSize.Text = Dr.GetValue(3)
            cmbCompany.Text = Dr.GetValue(4)

            Dr.Close()
            Con.Close()

            btnUpdate.Enabled = True
            btnDelete.Enabled = True
            btnAdd.Enabled = False

            txtPID.ReadOnly = True
            cmbCatagory.Enabled = False
            cmbType.Enabled = False
            cmbSize.Enabled = False
            cmbCompany.Enabled = False



        Catch ex As Exception
            MsgBox("Record Does Not Found????")
        End Try
    End Sub

    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        Dim res As DialogResult = MessageBox.Show("Do U Want To Update Record?", "UPdate Record?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

        If res = DialogResult.Yes Then
            txtPID.ReadOnly = True
            cmbCatagory.Enabled = True
            cmbType.Enabled = True
            cmbSize.Enabled = True
            cmbCompany.Enabled = True
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
           
            Cmd = New OleDbCommand("Delete From tblProductMast Where PID=" & txtPID.Text & "", Con)


            Cmd.ExecuteNonQuery()

            MsgBox("Record Deleted !")

            'txtPID.Clear()
            'cmbCatagory.Enabled = False
            'cmbCatagory.Text = "Select"
            'cmbType.Enabled = False
            'cmbType.Text = "Select"
            'cmbSize.Enabled = False
            'cmbSize.Text = "Select"
            'cmbCompany.Enabled = False
            'cmbCompany.Text = "Select"

            Clear()

            btnSave.Enabled = False
            btnAdd.Enabled = True
            btnFind.Enabled = True
            btnDelete.Enabled = False
            btnUpdate.Enabled = False
            Con.Close()

        End If

    End Sub

    Private Sub cmbCatagory_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCatagory.SelectedIndexChanged

        If cmbCatagory.Text = "Gents" Then
            cmbType.Items.Clear()
            cmbType.Items.Add("Select")
            cmbType.Items.Add("Shirts/T-Shirts")
            cmbType.Items.Add("Formal Pants")
            cmbType.Items.Add("Jeans")
            cmbType.Items.Add("Shervani")
            cmbType.Items.Add("Kurta and pant")
            cmbType.Items.Add("Jackets")
            cmbType.Items.Add("Winter T- Shirt")
            cmbType.Items.Add("Jurkins")
        End If
        If cmbCatagory.Text = "Ladies" Then
            cmbType.Items.Clear()
            cmbType.Items.Add("Select")
            cmbType.Items.Add("Saree")
            cmbType.Items.Add("Panjabi Dress")
            cmbType.Items.Add("Jeans/Tops")
        End If

        If cmbCatagory.Text = "Childrens" Then
            cmbType.Items.Clear()
            cmbType.Items.Add("Select")
            cmbType.Items.Add("Kids Box")
            cmbType.Items.Add("Swetter")
            cmbType.Items.Add("jackets")
        End If
    End Sub

    Private Sub cmbType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbType.SelectedIndexChanged

        If cmbType.Text = "Formal Pants" Or cmbType.Text = "Jeans" Then
            cmbSize.Items.Clear()
            cmbSize.Items.Add("Select")
            cmbSize.Items.Add("28")
            cmbSize.Items.Add("30")
            cmbSize.Items.Add("32")
            cmbSize.Items.Add("34")
        End If
        If cmbType.Text = "Saree" Then
            cmbSize.Items.Clear()
        End If
        If cmbType.Text = "Panjabi Dress" Then
            cmbSize.Items.Clear()
            cmbSize.Items.Add("Select")
            cmbSize.Items.Add("S")
            cmbSize.Items.Add("M")
            cmbSize.Items.Add("L")
            cmbSize.Items.Add("XL")
        End If
    End Sub


    Public Sub Clear()
        txtPID.Clear()
        txtPID.Enabled = False
        cmbCatagory.Text = "select"
        cmbCatagory.Enabled = False
        cmbType.Text = "select"
        cmbType.Enabled = False
        cmbSize.Text = "select"
        cmbSize.Enabled = False
        cmbCompany.Text = "select"
        cmbCompany.Enabled = False

        'For Each ct As Control In Me.Controls
        '    If TypeOf ct Is TextBox Then
        '        For Each Control As Control In Controls
        '            If TypeOf Control Is TextBox Then
        '                Control.Text = ""
        '            ElseIf TypeOf Control Is ComboBox Then
        '                Control.Text = String.Empty
        '            End If
        '        Next

        '    End If
        'Next

    End Sub

End Class



