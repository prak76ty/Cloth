Imports System.Data.OleDb

Public Class frmPurchaseDelivery

    Public Con As OleDbConnection
    Public Cmd As OleDbCommand
    Public Dr As OleDbDataReader
    Dim t As Integer
    Dim f As Integer
    Dim Avl_Qty As Integer
    Dim i As Integer
    Dim Status As String
    Private rowIndex As Integer = 0

    Private Sub frmPurchaseDelivery_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Con = New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\Bhaiyya\Lalsai.accdb")
        Con.Open()
        Cmd = New OleDbCommand("Select POID From tblPurchaseOrderMast Where DStatus='No'", Con)
        Dr = Cmd.ExecuteReader
        While Dr.Read
            cmbPOID.Items.Add(Dr.GetValue(0))
        End While
        Dr.Close()
        Con.Close()
    End Sub

    Private Sub cmbPOID_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbPOID.SelectedIndexChanged
        Con = New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\Bhaiyya\Lalsai.accdb")
        Con.Open()

        Cmd = New OleDbCommand("Select  SID, SName, PID From tblPurchaseOrderMast,tblPurchaseOrderDetail Where tblPurchaseOrderMast.POID=" & cmbPOID.SelectedItem & " and  tblPurchaseOrderDetail.POID=" & cmbPOID.SelectedItem & "", Con)
        Dr = Cmd.ExecuteReader

        While Dr.Read()
            txtSID.Text = Dr.GetValue(0)
            TxtSName.Text = Dr.GetValue(1)
            cmbPID.Items.Add(Dr.GetValue(2))
        End While
        
        Dr.Close()
        Con.Close()
    End Sub

    Private Sub btnInsert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInsert.Click
        Con = New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\Bhaiyya\Lalsai.accdb")
        Con.Open()

        Cmd = New OleDbCommand("Select * From tblPurchaseOrderDetail Where PID=" & cmbPID.SelectedItem & "", Con)
        Dr = Cmd.ExecuteReader
        Dr.Read()

        If Val(txtPPrice.Text) > 0 And Val(txtSprice.Text) > 0 Then
            If txtPPrice.Text < txtSprice.Text Then
                DGV.Rows.Add()
                DGV.Item(0, i).Value = Dr.GetValue(1)
                DGV.Item(1, i).Value = Dr.GetValue(2)
                DGV.Item(2, i).Value = Dr.GetValue(3)
                DGV.Item(3, i).Value = Dr.GetValue(4)
                DGV.Item(4, i).Value = Dr.GetValue(5)
                DGV.Item(5, i).Value = Dr.GetValue(6)
                DGV.Item(6, i).Value = txtPPrice.Text
                DGV.Item(7, i).Value = txtSprice.Text
                DGV.Item(8, i).Value = Dr.GetValue(6) * DGV.Item(6, i).Value
                txtTAmt.Text = Val(txtTAmt.Text) + DGV.Item(8, i).Value
                i += 1
                cmbPID.Items.RemoveAt(cmbPID.SelectedIndex)
                cmbPID.Refresh()
                txtPPrice.Clear()
                txtSprice.Clear()
            Else
                MsgBox("Purchase Price is Less Than Sales Price!...")
                txtPPrice.Clear()
                txtSprice.Clear()
                txtPPrice.Focus()
            End If
        Else
            MsgBox("Plz Eneter Proper Value")
            txtPPrice.Clear()
            txtSprice.Clear()
            txtPPrice.Focus()
        End If
    End Sub


    Private Sub btnAdd_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        cmbPOID.Enabled = True
        cmbPID.Enabled = True


        Con = New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\Bhaiyya\Lalsai.accdb")
        Con.Open()

        Cmd = New OleDbCommand("Select max(DIID) From tblPurchaseDeliveryMast", Con)

        Dr = Cmd.ExecuteReader
        Dr.Read()

        If (Dr.Item(0) IsNot DBNull.Value) Then
            t = Dr.Item(0) + 1
        Else
            t = 1
        End If
        txtDIID.Text = t.ToString
        txtPPrice.Enabled = True
        txtSprice.Enabled = True
        btnAdd.Enabled = False
        btnSave.Enabled = True
        btnInsert.Enabled = True

        'btnFind.Enabled = False
        Dr.Close()
        Con.Close()

        f = 0
    End Sub

    Private Sub btnSave_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        ' If f = 0 Then
        If cmbPID.Items.Count = 0 Then
            Con = New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\Bhaiyya\Lalsai.accdb")
            Con.Open()

            Cmd = New OleDbCommand("Insert Into tblPurchaseDeliveryMast Values(" & txtDIID.Text & "," & cmbPOID.Text & ",'" & dtp.Value.Date & "'," & txtSID.Text & ",'" & TxtSName.Text & "')", Con)
            Cmd.ExecuteNonQuery()

            For i As Integer = 0 To DGV.Rows.Count - 2

                Cmd = New OleDbCommand("Insert Into tblPurchaseDeliveryDetail Values(" & txtDIID.Text & "," & DGV.Rows(i).Cells(0).Value & ",'" & DGV.Rows(i).Cells(1).Value & "','" & DGV.Rows(i).Cells(2).Value & "','" & DGV.Rows(i).Cells(3).Value & "','" & DGV.Rows(i).Cells(4).Value & "'," & DGV.Rows(i).Cells(5).Value & "," & DGV.Rows(i).Cells(6).Value & "," & DGV.Rows(i).Cells(7).Value & "," & DGV.Rows(i).Cells(8).Value & ")", Con)
                Cmd.ExecuteNonQuery()

                Cmd = New OleDbCommand("Update tblProductMast Set Avl_Qty=Avl_Qty + " & DGV.Item(5, i).Value & "  Where PID=" & DGV.Item(0, i).Value & "", Con)
                Cmd.ExecuteNonQuery()

            Next

            Cmd = New OleDbCommand("UPdate tblPurchaseOrderMast Set DStatus='Yes' Where POID=" & cmbPOID.SelectedItem & "", Con)
            Cmd.ExecuteNonQuery()


            txtDIID.Clear()
            cmbPOID.Items.RemoveAt(cmbPOID.SelectedIndex)
            cmbPOID.Refresh()
            cmbPOID.Enabled = False
            dtp.Enabled = False
            txtSID.Clear()
            txtSID.Enabled = False
            TxtSName.Clear()
            TxtSName.Enabled = False
            cmbPID.Text = ""
            cmbPID.Enabled = False
            txtPPrice.Clear()
            txtPPrice.Enabled = False
            txtSprice.Clear()
            txtSprice.Enabled = False
            txtTAmt.Clear()
            DGV.Rows.Clear()
            i = 0

            btnSave.Enabled = False
            btnAdd.Enabled = True
            btnInsert.Enabled = False
            MsgBox("Record Inserted...")
            btnSave.Enabled = False

            'frmPurchaseDelivery_Load(sender, e)
            Con.Close()
        Else
            MsgBox("Item Is Remaining")
        End If


        'txtPOID.Clear()
        'DTP.Enabled = False
        'cmbSID.Text = ""

        'cmbSID.Enabled = False
        'TxtSName.Clear()
        'txtCCat.Clear()
        'txtCType.Clear()
        'txtPSize.Clear()
        'txtCComp.Clear()
        'DGV.Rows.Clear()

        'btnSave.Enabled = False
        'btnAdd.Enabled = True

        'frmPurchaseOrder_Load(sender, e)

        'Con.Close()



        'Else
        ''Con = New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\Bhaiyya\Lalsai.accdb")
        'Con.Open()

        'For i As Integer = 0 To DGV.Rows.Count - 2
        '    Cmd = New OleDbCommand("Update tblPurchaseOrderDetail Set PQty=" & DGV.Rows(i).Cells(5).Value & " Where POID= " & txtPOID.Text & " and PID=" & DGV.Rows(i).Cells(0).Value & "", Con)
        '    Cmd.ExecuteNonQuery()
        'Next

        'MsgBox("Record Is Updated....!")

        'txtPOID.Clear()
        'DTP.Enabled = False
        'cmbSID.Text = ""

        'cmbSID.Enabled = False
        'TxtSName.Clear()
        'txtCCat.Clear()
        'txtCType.Clear()
        'txtPSize.Clear()
        'txtCComp.Clear()
        'DGV.Rows.Clear()

        'btnSave.Enabled = False
        'btnAdd.Enabled = True
        'btnFind.Enabled = True
        'Con.Close()
        'End If
    End Sub

    Private Sub txtPPrice_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPPrice.KeyPress, txtSprice.KeyPress
        If Asc(e.KeyChar) <> 13 AndAlso Asc(e.KeyChar) <> 8 AndAlso Not IsNumeric(e.KeyChar) Then
            e.Handled = True
        End If

    End Sub

  
    Private Sub txtPPrice_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPPrice.Leave
        'If Not txtPPrice.Text = " " Then
        '    MsgBox("Plz Enter Puchase Price")
        '    txtPPrice.Focus()
        'Else
        '    If Not txtPPrice.Text = 0 Then
        '        MsgBox("Plz Enter Puchase Price")
        '        txtPPrice.Clear()
        '        txtPPrice.Focus()
        '    End If
        'End If
    End Sub
End Class