Imports System.Data.OleDb

Public Class frmSalesOrderMaster
    Public Con As OleDbConnection
    Public Cmd As OleDbCommand
    Public Dr As OleDbDataReader
    Dim t As Integer
    Dim f As Integer
    Dim Avl_Qty As Integer
    Dim i As Integer
    Dim Status As String
    Private rowIndex As Integer = 0

    Private Sub frmSalesOrderMaster_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Con = New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\Bhaiyya\Lalsai.accdb")
        Con.Open()
        Cmd = New OleDbCommand("Select CID From tblCustMast", Con)
        Dr = Cmd.ExecuteReader

        cmbCID.Items.Clear()
        While Dr.Read
            cmbCID.Items.Add(Dr.GetValue(0))
        End While
        Dr.Close()

        Cmd = New OleDbCommand("Select PID From tblProductMast", Con)
        Dr = Cmd.ExecuteReader
        cmbPID.Items.Clear()
        While Dr.Read
            cmbPID.Items.Add(Dr.GetValue(0))
        End While
        Dr.Close()

        btnSave.Enabled = False
        Con.Close()
    End Sub

    Private Sub cmbCID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCID.SelectedIndexChanged
        Con = New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\Bhaiyya\Lalsai.accdb")
        Con.Open()
        Cmd = New OleDbCommand("Select CName,CCity From tblCustMast Where CID=" & cmbCID.SelectedItem & "", Con)
        Dr = Cmd.ExecuteReader
        Dr.Read()
        txtCName.Text = Dr.GetValue(0)
        txtCCity.Text = Dr.GetValue(1)
        Dr.Close()
        Con.Close()
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Panel1.Enabled = True
        'cmbCID.Enabled = True
        cmbPID.Enabled = True
        txtQty.Enabled = True
        btnInsert.Enabled = True
        cmbCID.Enabled = True



        Con = New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\Bhaiyya\Lalsai.accdb")
        Con.Open()

        Cmd = New OleDbCommand("Select max(SOID) From tblSalesMast", Con)
        Dr = Cmd.ExecuteReader
        Dr.Read()

        If (Dr.Item(0) IsNot DBNull.Value) Then
            t = Dr.Item(0) + 1
        Else
            t = 1
        End If
        txtSOID.Text = t.ToString
        txtQty.Enabled = True
        'txtSprice.Enabled = True
        btnAdd.Enabled = False
        btnSave.Enabled = True
        'btnFind.Enabled = False
        Dr.Close()
        Con.Close()
    End Sub

    Private Sub btnInsert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInsert.Click

        If Not Avl_Qty = 0 Then
            If Val(txtQty.Text) > 0 Then
                Con = New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\Bhaiyya\Lalsai.accdb")
                Con.Open()

                Cmd = New OleDbCommand("Select tblProductMast.PID,tblProductMast.PCatagory,tblProductMast.PType,tblProductMast.PSize,tblProductMast.PCompany,SPrice From tblProductMast,tblPurchaseDeliveryDetail Where tblProductMast.PID=" & cmbPID.SelectedItem & "", Con)
                Dr = Cmd.ExecuteReader
                Dr.Read()

                DGV.Rows.Add()
                DGV.Item(0, i).Value = Dr.GetValue(0)
                DGV.Item(1, i).Value = Dr.GetValue(1)
                DGV.Item(2, i).Value = Dr.GetValue(2)
                DGV.Item(3, i).Value = Dr.GetValue(3)
                DGV.Item(4, i).Value = Dr.GetValue(4)
                DGV.Item(5, i).Value = txtQty.Text
                DGV.Item(6, i).Value = Dr.GetValue(5)
                DGV.Item(7, i).Value = Val(txtQty.Text) * Dr.GetValue(5)
                'DGV.Item(6, i).Value = txtPPrice.Text
                'DGV.Item(7, i).Value = txtSprice.Text
                'DGV.Item(8, i).Value = Dr.GetValue(6) * DGV.Item(6, i).Value
                txtTAmt.Text = Val(txtTAmt.Text) + DGV.Item(7, i).Value
                i += 1
                txtQty.Clear()
                cmbPID.Items.RemoveAt(cmbPID.SelectedIndex)
                cmbPID.Refresh()
            Else
                MsgBox("Sales Qty Does Not Empty Or Zero")
                txtQty.Clear()
                txtQty.Focus()
            End If
        Else
            MsgBox("Stock is not available")
        End If



    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Con = New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\Bhaiyya\Lalsai.accdb")
        Con.Open()

        Cmd = New OleDbCommand("Insert Into tblSalesMast Values(" & txtSOID.Text & ",'" & dtp.Value.Date & "'," & cmbCID.Text & ",'" & txtCName.Text & "','" & txtCCity.Text & "')", Con)
        Cmd.ExecuteNonQuery()

        For i As Integer = 0 To DGV.Rows.Count - 2

            Cmd = New OleDbCommand("Insert Into tblsalesDetail Values(" & txtSOID.Text & "," & DGV.Rows(i).Cells(0).Value & ",'" & DGV.Rows(i).Cells(1).Value & "','" & DGV.Rows(i).Cells(2).Value & "','" & DGV.Rows(i).Cells(3).Value & "','" & DGV.Rows(i).Cells(4).Value & "'," & DGV.Rows(i).Cells(5).Value & "," & DGV.Rows(i).Cells(6).Value & "," & DGV.Rows(i).Cells(7).Value & ")", Con)
            Cmd.ExecuteNonQuery()

            Cmd = New OleDbCommand("Update tblProductMast Set Avl_Qty=Avl_Qty - " & DGV.Item(5, i).Value & "  Where PID=" & DGV.Item(0, i).Value & "", Con)
            Cmd.ExecuteNonQuery()

        Next
        MsgBox("Record Inserted...")
        txtSOID.Clear()
        dtp.Enabled = False
        cmbCID.Text = ""

        cmbCID.Enabled = False
        txtCCity.Text = ""
        txtCCity.Enabled = False
        txtCName.Text = ""
        txtCName.Enabled = False
        cmbPID.Text = ""
        cmbPID.Enabled = False
        txtQty.Text = ""
        txtQty.Enabled = False
        'TxtSName.Clear()
        'txtCCat.Clear()
        'txtCType.Clear()
        'txtPSize.Clear()
        'txtCComp.Clear()
        DGV.Rows.Clear()
        i = 0
        btnSave.Enabled = False
        btnAdd.Enabled = True

        frmSalesOrderMaster_Load(sender, e)
    End Sub

    Private Sub txtQty_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtQty.KeyPress
        If Asc(e.KeyChar) <> 13 AndAlso Asc(e.KeyChar) <> 8 AndAlso Not IsNumeric(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub cmbPID_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbPID.SelectedIndexChanged

        Con = New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\Bhaiyya\Lalsai.accdb")
        Con.Open()

        Cmd = New OleDbCommand("Select Avl_Qty From tblProductMast Where PID=" & cmbPID.SelectedItem & "", Con)
        Cmd.ExecuteNonQuery()
        Dr = Cmd.ExecuteReader
        Dr.Read()
        Avl_Qty = Dr.GetValue(0)
        Dr.Close()
        'MsgBox("Avl_Qty is:" & Avl_Qty)
        Con.Close()
    End Sub
End Class