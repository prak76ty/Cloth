<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMDI
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
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.MasterFormToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ProductMasterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DealerMasterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CustomerMasterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.StaffMasterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.TransactionsFormToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PurchaseOrderToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PurchaseDeliveryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SalesOrderToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ProductMasterToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.CustomerMasterToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.SupplierMasterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.StaffMasterToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.PurchaseOrderMasterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PurchaseDeliveryToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.SalesOrderToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.StockReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.YesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MasterFormToolStripMenuItem, Me.TransactionsFormToolStripMenuItem, Me.ExitToolStripMenuItem, Me.ExitToolStripMenuItem1})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Padding = New System.Windows.Forms.Padding(7, 2, 0, 2)
        Me.MenuStrip1.Size = New System.Drawing.Size(896, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'MasterFormToolStripMenuItem
        '
        Me.MasterFormToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ProductMasterToolStripMenuItem, Me.DealerMasterToolStripMenuItem, Me.CustomerMasterToolStripMenuItem, Me.StaffMasterToolStripMenuItem})
        Me.MasterFormToolStripMenuItem.Name = "MasterFormToolStripMenuItem"
        Me.MasterFormToolStripMenuItem.Size = New System.Drawing.Size(86, 20)
        Me.MasterFormToolStripMenuItem.Text = "Master Form"
        '
        'ProductMasterToolStripMenuItem
        '
        Me.ProductMasterToolStripMenuItem.Name = "ProductMasterToolStripMenuItem"
        Me.ProductMasterToolStripMenuItem.Size = New System.Drawing.Size(165, 22)
        Me.ProductMasterToolStripMenuItem.Text = "&Product Master"
        '
        'DealerMasterToolStripMenuItem
        '
        Me.DealerMasterToolStripMenuItem.Name = "DealerMasterToolStripMenuItem"
        Me.DealerMasterToolStripMenuItem.Size = New System.Drawing.Size(165, 22)
        Me.DealerMasterToolStripMenuItem.Text = "Dealer Master"
        '
        'CustomerMasterToolStripMenuItem
        '
        Me.CustomerMasterToolStripMenuItem.Name = "CustomerMasterToolStripMenuItem"
        Me.CustomerMasterToolStripMenuItem.Size = New System.Drawing.Size(165, 22)
        Me.CustomerMasterToolStripMenuItem.Text = "Customer Master"
        '
        'StaffMasterToolStripMenuItem
        '
        Me.StaffMasterToolStripMenuItem.Name = "StaffMasterToolStripMenuItem"
        Me.StaffMasterToolStripMenuItem.Size = New System.Drawing.Size(165, 22)
        Me.StaffMasterToolStripMenuItem.Text = "Staff Master"
        '
        'TransactionsFormToolStripMenuItem
        '
        Me.TransactionsFormToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PurchaseOrderToolStripMenuItem, Me.PurchaseDeliveryToolStripMenuItem, Me.SalesOrderToolStripMenuItem})
        Me.TransactionsFormToolStripMenuItem.Name = "TransactionsFormToolStripMenuItem"
        Me.TransactionsFormToolStripMenuItem.Size = New System.Drawing.Size(117, 20)
        Me.TransactionsFormToolStripMenuItem.Text = "Transactions Form"
        '
        'PurchaseOrderToolStripMenuItem
        '
        Me.PurchaseOrderToolStripMenuItem.Name = "PurchaseOrderToolStripMenuItem"
        Me.PurchaseOrderToolStripMenuItem.Size = New System.Drawing.Size(167, 22)
        Me.PurchaseOrderToolStripMenuItem.Text = "Purchase Order "
        '
        'PurchaseDeliveryToolStripMenuItem
        '
        Me.PurchaseDeliveryToolStripMenuItem.Name = "PurchaseDeliveryToolStripMenuItem"
        Me.PurchaseDeliveryToolStripMenuItem.Size = New System.Drawing.Size(167, 22)
        Me.PurchaseDeliveryToolStripMenuItem.Text = "Purchase Delivery"
        '
        'SalesOrderToolStripMenuItem
        '
        Me.SalesOrderToolStripMenuItem.Name = "SalesOrderToolStripMenuItem"
        Me.SalesOrderToolStripMenuItem.Size = New System.Drawing.Size(167, 22)
        Me.SalesOrderToolStripMenuItem.Text = "Sales Order"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ProductMasterToolStripMenuItem1, Me.CustomerMasterToolStripMenuItem1, Me.SupplierMasterToolStripMenuItem, Me.StaffMasterToolStripMenuItem1, Me.PurchaseOrderMasterToolStripMenuItem, Me.PurchaseDeliveryToolStripMenuItem1, Me.SalesOrderToolStripMenuItem1, Me.StockReportToolStripMenuItem})
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(59, 20)
        Me.ExitToolStripMenuItem.Text = "Reports"
        '
        'ProductMasterToolStripMenuItem1
        '
        Me.ProductMasterToolStripMenuItem1.Name = "ProductMasterToolStripMenuItem1"
        Me.ProductMasterToolStripMenuItem1.Size = New System.Drawing.Size(167, 22)
        Me.ProductMasterToolStripMenuItem1.Text = "Product Master"
        '
        'CustomerMasterToolStripMenuItem1
        '
        Me.CustomerMasterToolStripMenuItem1.Name = "CustomerMasterToolStripMenuItem1"
        Me.CustomerMasterToolStripMenuItem1.Size = New System.Drawing.Size(167, 22)
        Me.CustomerMasterToolStripMenuItem1.Text = "Customer Master"
        '
        'SupplierMasterToolStripMenuItem
        '
        Me.SupplierMasterToolStripMenuItem.Name = "SupplierMasterToolStripMenuItem"
        Me.SupplierMasterToolStripMenuItem.Size = New System.Drawing.Size(167, 22)
        Me.SupplierMasterToolStripMenuItem.Text = "Supplier Master"
        '
        'StaffMasterToolStripMenuItem1
        '
        Me.StaffMasterToolStripMenuItem1.Name = "StaffMasterToolStripMenuItem1"
        Me.StaffMasterToolStripMenuItem1.Size = New System.Drawing.Size(167, 22)
        Me.StaffMasterToolStripMenuItem1.Text = "Staff Master"
        '
        'PurchaseOrderMasterToolStripMenuItem
        '
        Me.PurchaseOrderMasterToolStripMenuItem.Name = "PurchaseOrderMasterToolStripMenuItem"
        Me.PurchaseOrderMasterToolStripMenuItem.Size = New System.Drawing.Size(167, 22)
        Me.PurchaseOrderMasterToolStripMenuItem.Text = "Purchase Order"
        '
        'PurchaseDeliveryToolStripMenuItem1
        '
        Me.PurchaseDeliveryToolStripMenuItem1.Name = "PurchaseDeliveryToolStripMenuItem1"
        Me.PurchaseDeliveryToolStripMenuItem1.Size = New System.Drawing.Size(167, 22)
        Me.PurchaseDeliveryToolStripMenuItem1.Text = "Purchase Delivery"
        '
        'SalesOrderToolStripMenuItem1
        '
        Me.SalesOrderToolStripMenuItem1.Name = "SalesOrderToolStripMenuItem1"
        Me.SalesOrderToolStripMenuItem1.Size = New System.Drawing.Size(167, 22)
        Me.SalesOrderToolStripMenuItem1.Text = "Sales Order"
        '
        'StockReportToolStripMenuItem
        '
        Me.StockReportToolStripMenuItem.Name = "StockReportToolStripMenuItem"
        Me.StockReportToolStripMenuItem.Size = New System.Drawing.Size(167, 22)
        Me.StockReportToolStripMenuItem.Text = "Stock Report"
        '
        'ExitToolStripMenuItem1
        '
        Me.ExitToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.YesToolStripMenuItem})
        Me.ExitToolStripMenuItem1.Name = "ExitToolStripMenuItem1"
        Me.ExitToolStripMenuItem1.Size = New System.Drawing.Size(37, 20)
        Me.ExitToolStripMenuItem1.Text = "Exit"
        '
        'YesToolStripMenuItem
        '
        Me.YesToolStripMenuItem.Name = "YesToolStripMenuItem"
        Me.YesToolStripMenuItem.Size = New System.Drawing.Size(92, 22)
        Me.YesToolStripMenuItem.Text = "Yes"
        '
        'frmMDI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(896, 524)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Name = "frmMDI"
        Me.Text = "Lal Sai Fasion  Center,  Station Road, Pachora"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents MasterFormToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ProductMasterToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DealerMasterToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CustomerMasterToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StaffMasterToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TransactionsFormToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PurchaseOrderToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PurchaseDeliveryToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SalesOrderToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents YesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ProductMasterToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CustomerMasterToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SupplierMasterToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StaffMasterToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PurchaseOrderMasterToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PurchaseDeliveryToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SalesOrderToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StockReportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
