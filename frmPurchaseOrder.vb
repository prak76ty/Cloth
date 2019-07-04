Imports System.Data.OleDb

Public Class frmPurchaseOrder
    Public Con As OleDbConnection
    Public Cmd As OleDbCommand
    Public Dr As OleDbDataReader
    Dim t As Integer
    Dim f As Integer
    Dim Avl_Qty As Integer
    Dim i As Integer
    Dim Status As String
    Private rowIndex As Integer = 0

    Private Sub frmPurchaseOrder_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Con = New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\Bhaiyya\Lalsai.accdb")
        Con.Open()


        Cmd = New OleDbCommand("Select Distinct(SID) From tblSupplierMast", Con)
        Dr = Cmd.ExecuteReader

        cmbSID.Items.Clear()
        While Dr.Read
            cmbSID.Items.Add(Dr.GetValue(0))
            'cmbPID.Items.Add(Dr.GetValue(0))
        End While
        Dr.Close()

        Cmd = New OleDbCommand("Select PID From tblProductMast", Con)
        Dr = Cmd.ExecuteReader

        cmbPID.Items.Clear()
        While Dr.Read
            cmbPID.Items.Add(Dr.GetValue(0))
        End While

        btnSave.Enabled = False
        btnDelete.Enabled = False
        btnUpdate.Enabled = False

        Me.DGV.RowsDefaultCellStyle.BackColor = Color.Bisque
        Me.DGV.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige

        Dr.Close()
        Con.Close()

    End Sub

    Private Sub cmbSID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbSID.SelectedIndexChanged
        Con = New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\Bhaiyya\Lalsai.accdb")
        Con.Open()

        Cmd = New OleDbCommand("Select SName From tblSupplierMast Where SID=" & cmbSID.SelectedItem & "", Con)
        Dr = Cmd.ExecuteReader

        Dr.Read()
        TxtSName.Text = Dr.GetValue(0)
        Dr.Close()
        Con.Close()
    End Sub

    Private Sub cmbPID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbPID.SelectedIndexChanged
        Con = New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\Bhaiyya\Lalsai.accdb")
        Con.Open()

        Cmd = New OleDbCommand("Select * From tblProductMast Where PID=" & cmbPID.SelectedItem & "", Con)
        Dr = Cmd.ExecuteReader

        Dr.Read()
        txtCCat.Text = Dr.GetValue(1)
        txtCType.Text = Dr.GetValue(2)
        txtPSize.Text = Dr.GetValue(3)
        txtCComp.Text = Dr.GetValue(4)
        txtQty.Focus()

        Dr.Close()
        Con.Close()
    End Sub


    Private Sub txtQty_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtQty.Leave

        'For j As Integer = 0 To DGV.Rows.Count - 2
        '    If (DGV.Item(1, j).Value) = cmbPID.Text Then
        '        MessageBox.Show("You Have allready Entered this Item")
        '        Exit Sub
        '    End If
        'Next

        'Try
        '    If txtQty.Text = 0 Then
        '        MsgBox("Plz Enter Product Quantity")
        '        txtQty.Focus()
        '    Else
        '        DGV.Rows.Add()
        '        DGV.Item(0, i).Value = cmbPID.Text
        '        DGV.Item(1, i).Value = txtCCat.Text
        '        DGV.Item(2, i).Value = txtCType.Text
        '        DGV.Item(3, i).Value = txtPSize.Text
        '        DGV.Item(4, i).Value = txtCComp.Text
        '        DGV.Item(5, i).Value = txtQty.Text
        '        i += 1
        '        cmbPID.Items.RemoveAt(cmbPID.SelectedIndex)
        '        cmbPID.Refresh()
        '        txtQty.Clear()
        '    End If
        'Catch ex As Exception
        '    MsgBox("Plz Enter Value")
        '    txtQty.Focus()

        'End Try
       
        If Val(txtQty.Text) > 0 Then
            DGV.Rows.Add()
            DGV.Item(0, i).Value = cmbPID.Text
            DGV.Item(1, i).Value = txtCCat.Text
            DGV.Item(2, i).Value = txtCType.Text
            DGV.Item(3, i).Value = txtPSize.Text
            DGV.Item(4, i).Value = txtCComp.Text
            DGV.Item(5, i).Value = txtQty.Text
            i += 1
            cmbPID.Items.RemoveAt(cmbPID.SelectedIndex)
            cmbPID.Refresh()
            txtQty.Clear()
        Else
            MsgBox("Plz Enter Product Quantity")
            txtQty.Clear()
            txtQty.Focus()
        End If

    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        cmbSID.Enabled = True
        cmbPID.Enabled = True
        txtQty.Enabled = True
        DTP.Enabled = True



        Con = New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\Bhaiyya\Lalsai.accdb")
        Con.Open()

        Cmd = New OleDbCommand("Select max(POID) From tblPurchaseOrderMast", Con)

        Dr = Cmd.ExecuteReader

        Dr.Read()

        If (Dr.Item(0) IsNot DBNull.Value) Then
            t = Dr.Item(0) + 1
        Else
            t = 1
        End If
        txtPOID.Text = t.ToString
        cmbSID.Focus()

        btnAdd.Enabled = False
        btnSave.Enabled = True
        'btnFind.Enabled = False
        Dr.Close()

        Con.Close()

        f = 0
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
       
        If f = 0 Then
            Con = New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\Bhaiyya\Lalsai.accdb")
            Con.Open()

            Cmd = New OleDbCommand("Insert Into tblPurchaseOrderMast(POID,PODate,SID,SName) Values(" & txtPOID.Text & ",'" & DTP.Value.Date & "'," & cmbSID.Text & ",'" & TxtSName.Text & "')", Con)
            Cmd.ExecuteNonQuery()

            For i As Integer = 0 To DGV.Rows.Count - 2

                Cmd = New OleDbCommand("Insert Into tblPurchaseOrderDetail Values(" & txtPOID.Text & "," & DGV.Rows(i).Cells(0).Value & ",'" & DGV.Rows(i).Cells(1).Value & "','" & DGV.Rows(i).Cells(2).Value & "','" & DGV.Rows(i).Cells(3).Value & "','" & DGV.Rows(i).Cells(4).Value & "'," & DGV.Rows(i).Cells(5).Value & ")", Con)
                Cmd.ExecuteNonQuery()

            Next
            MsgBox("Record Inserted...")

            txtPOID.Clear()
            DTP.Enabled = False
            cmbSID.Text = ""

            cmbSID.Enabled = False
            TxtSName.Clear()
            txtCCat.Clear()
            txtCType.Clear()
            txtPSize.Clear()
            txtCComp.Clear()
            DGV.Rows.Clear()

            btnSave.Enabled = False
            btnAdd.Enabled = True

            frmPurchaseOrder_Load(sender, e)

            Con.Close()



        Else
            Con = New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\Bhaiyya\Lalsai.accdb")
            Con.Open()

            For i As Integer = 0 To DGV.Rows.Count - 2
                Cmd = New OleDbCommand("Update tblPurchaseOrderDetail Set PQty=" & DGV.Rows(i).Cells(5).Value & " Where POID= " & txtPOID.Text & " and PID=" & DGV.Rows(i).Cells(0).Value & "", Con)
                Cmd.ExecuteNonQuery()
            Next

            MsgBox("Record Is Updated....!")

            txtPOID.Clear()
            DTP.Enabled = False
            cmbSID.Text = ""

            cmbSID.Enabled = False
            TxtSName.Clear()
            txtCCat.Clear()
            txtCType.Clear()
            txtPSize.Clear()
            txtCComp.Clear()
            DGV.Rows.Clear()
            i = 0

            btnSave.Enabled = False
            btnAdd.Enabled = True
            btnFind.Enabled = True
            Con.Close()
        End If
        

    End Sub



    Private Sub txtQty_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtQty.KeyPress
        If Asc(e.KeyChar) <> 13 AndAlso Asc(e.KeyChar) <> 8 AndAlso Not IsNumeric(e.KeyChar) Then
            'MsgBox("Plz Enter Number Only")
            e.Handled = True
        End If
    End Sub


    Private Sub btnFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFind.Click

        '' ''Con = New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\Bhaiyya\Lalsai.accdb")
        '' ''Con.Open()


        '' ''Cmd = New OleDbCommand("Select  Deliverd From OrderDelivery Where POID=1", Con)
        '' ''Dr = Cmd.ExecuteReader

        '' ''Dr.Read()

        '' ''Status = Dr.GetValue(0).ToString

        '' ''Dr.Close()

        '' ''Con.Close()


        Try
            txtPOID.Clear()
            DTP.Text = ""
            cmbSID.Text = ""
            TxtSName.Clear()
            DGV.Rows.Clear()

            Dim id As Integer
            id = InputBox("Plz Enter Order No:")

            Con = New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\Bhaiyya\Lalsai.accdb")
            Con.Open()

            Cmd = New OleDbCommand("Select  * From tblPurchaseOrderMast Where POID=" & id & "", Con)
            Dr = Cmd.ExecuteReader

            Dr.Read()

            txtPOID.Text = Dr.GetValue(0)
            DTP.Text = Dr.GetValue(1)
            cmbSID.Text = Dr.GetValue(2)

            Dr.Close()

            Con.Open()
            Cmd = New OleDbCommand("Select  * From tblPurchaseOrderDetail Where POID=" & id & "", Con)
            Dr = Cmd.ExecuteReader

            i = 0
            While Dr.Read
                DGV.Rows.Add()
                DGV.Item(0, i).Value = Dr.GetValue(1)
                DGV.Item(1, i).Value = Dr.GetValue(2)
                DGV.Item(2, i).Value = Dr.GetValue(3)
                DGV.Item(3, i).Value = Dr.GetValue(4)
                DGV.Item(4, i).Value = Dr.GetValue(5)
                DGV.Item(5, i).Value = Dr.GetValue(6)
                i += 1
            End While

            Dr.Close()
            Con.Close()

            btnUpdate.Enabled = True
            btnDelete.Enabled = True
            btnAdd.Enabled = False
            btnSave.Enabled = False

        Catch ex As Exception
            MsgBox("Record Does Not Found????")
        End Try

    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Dim res As DialogResult = MessageBox.Show("Do U Want To Delete Record?", "Delete Record?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

        If res = DialogResult.Yes Then

            If Status = "Yes" Then
                MsgBox("Record is Not Deleted...!)")
            Else
                Con = New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\Bhaiyya\Lalsai.accdb")
                Con.Open()


                Cmd = New OleDbCommand("Delete From tblPurchaseOrderMast Where POID=" & txtPOID.Text & "", Con)


                Cmd.ExecuteNonQuery()

                Cmd = New OleDbCommand("Delete From tblPurchaseOrderDetail Where POID=" & txtPOID.Text & "", Con)

                Cmd.ExecuteNonQuery()

                MsgBox("Recored Is Deleted..!")

                txtPOID.Clear()
                DTP.Text = ""
                cmbSID.Text = ""
                TxtSName.Clear()
                DGV.Rows.Clear()
                btnSave.Enabled = False
                btnAdd.Enabled = True
                btnFind.Enabled = True
                btnDelete.Enabled = False
                btnUpdate.Enabled = False


                Con.Close()

            End If

            
        End If
    End Sub

    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        Dim res As DialogResult = MessageBox.Show("Do U Want To Update Record?", "UPdate Record?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

        If res = DialogResult.Yes Then
            cmbSID.Enabled = True
            TxtSName.Enabled = True

            DGV.Columns(5).ReadOnly = False

            btnSave.Enabled = True
            btnAdd.Enabled = False
            btnDelete.Enabled = False
            btnUpdate.Enabled = False
            btnFind.Enabled = False
            f = 1
        End If
    End Sub


    'Datagridview Codding For Deleting The Selected Reocrds/Rows....
    Private Sub DataGridView1_CellMouseUp_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DGV.CellMouseUp

        If f = 1 Then
            If e.Button = MouseButtons.Right Then
                Me.DGV.Rows(e.RowIndex).Selected = True
                Me.rowIndex = e.RowIndex
                Me.DGV.CurrentCell = Me.DGV.Rows(e.RowIndex).Cells(1)
                Me.ContextMenuStrip1.Show(Me.DGV, e.Location)
                ContextMenuStrip1.Show(Cursor.Position)
            End If
        End If

    End Sub

    Private Sub ContextMenuStrip1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ContextMenuStrip1.Click

        If Not Me.dgv.Rows(Me.rowIndex).IsNewRow Then

            Dim con As New OleDbConnection
            con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\Bhaiyya\Lalsai.accdb"
            con.Open()

            Dim cmd As New OleDbCommand
            cmd.Connection = con
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "Delete From tblPurchaseOrderDetail Where POID=" & txtPOID.Text & " and PID=" & DGV.Rows(Me.rowIndex).Cells(0).Value & ""
            cmd.ExecuteNonQuery()
            con.Close()

            Me.dgv.Rows.RemoveAt(Me.rowIndex)
        End If
    End Sub

  
End Class