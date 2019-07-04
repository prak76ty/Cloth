
Public Class frmMDI

    Private Sub ProductMasterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProductMasterToolStripMenuItem.Click
        frmProductMaster.MdiParent = Me
        frmProductMaster.Show()
    End Sub

    Private Sub DealerMasterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DealerMasterToolStripMenuItem.Click
        frmSupplierMaster.MdiParent = Me
        frmSupplierMaster.Show()
    End Sub

    Private Sub CustomerMasterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CustomerMasterToolStripMenuItem.Click
        frmCustomerMaster.MdiParent = Me
        frmCustomerMaster.Show()
    End Sub

    Private Sub StaffMasterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StaffMasterToolStripMenuItem.Click
        frmStaffMaster.MdiParent = Me
        frmStaffMaster.Show()
    End Sub

    Private Sub PurchaseOrderToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PurchaseOrderToolStripMenuItem.Click
        frmPurchaseOrder.MdiParent = Me
        frmPurchaseOrder.Show()
    End Sub

    Private Sub PurchaseDeliveryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PurchaseDeliveryToolStripMenuItem.Click
        frmPurchaseDelivery.MdiParent = Me
        frmPurchaseDelivery.Show()
    End Sub

    Private Sub SalesOrderToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalesOrderToolStripMenuItem.Click
        frmSalesOrderMaster.MdiParent = Me
        frmSalesOrderMaster.Show()
    End Sub

    Private Sub YesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles YesToolStripMenuItem.Click
        Dim res As DialogResult = MessageBox.Show("Do U Want To Exit Application?", "Exit?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
        If res = DialogResult.Yes Then
            Application.Exit()
        End If
    End Sub

    Private Sub ProductMasterToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProductMasterToolStripMenuItem1.Click
        rptProductMaster.MdiParent = Me
        rptProductMaster.Show()
    End Sub

    Private Sub CustomerMasterToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CustomerMasterToolStripMenuItem1.Click
        RptCustomerMaster.MdiParent = Me
        RptCustomerMaster.Show()
    End Sub

    Private Sub SupplierMasterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SupplierMasterToolStripMenuItem.Click
        RptSupplierMaster.MdiParent = Me
        RptSupplierMaster.Show()
    End Sub

    Private Sub StaffMasterToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StaffMasterToolStripMenuItem1.Click
        RptStaffMaster.MdiParent = Me
        RptStaffMaster.Show()
    End Sub

    Private Sub PurchaseOrderMasterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PurchaseOrderMasterToolStripMenuItem.Click
        RptPurchaseOrderMaster.MdiParent = Me
        RptPurchaseOrderMaster.Show()

    End Sub

    Private Sub PurchaseDeliveryToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PurchaseDeliveryToolStripMenuItem1.Click
        RptPurchaseDeliveryMaster.MdiParent = Me
        RptPurchaseDeliveryMaster.Show()

    End Sub

    Private Sub SalesOrderToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalesOrderToolStripMenuItem1.Click
        RptSalesOrderMaster.MdiParent = Me
        RptSalesOrderMaster.Show()

    End Sub

    Private Sub StockReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StockReportToolStripMenuItem.Click
        RptStockReport.MdiParent = Me
        RptStockReport.Show()

    End Sub
End Class