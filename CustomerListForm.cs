using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Data;
using MySql.Data.MySqlClient;
using System;
using ClosedXML.Excel;
using System.IO;
using PdfSharp.Pdf;
using PdfSharp.Drawing;
using BillingSystem.Utils;

namespace BillingSystem;

public class CustomerListForm : Form
{
    private IContainer components = null;

    private Label lblTitle;

    private DataGridView dgvCustomers;

    private Button btnAdd;

    private Button btnDelete;

    private Button btnLogout;

    private Button btnSearch;

    private TextBox txtSearch;
    private Button btnAnalytics;
    private Button btnExportExcel;
    private Button btnExportPdf;
    private Button btnAuditLog;
    private Button btnManagePermissions;

    // Stores the CustomerID of the currently selected row.
    // 0 means no customer is currently selected.
    private int _selectedCustomerId = 0;
    private StatusStrip statusStrip1;
    private ToolStripStatusLabel lblStatusUser;
    private ToolStripStatusLabel lblStatusSep;
    private ToolStripStatusLabel lblStatusTime;
    private Timer statusTimer;
    private DataGridViewTextBoxColumn CustomerID;
    private DataGridViewTextBoxColumn FullName;
    private DataGridViewTextBoxColumn Address;
    private DataGridViewTextBoxColumn ContactNumber;
    private DataGridViewTextBoxColumn Email;
    private DataGridViewTextBoxColumn Balance;
    private DataGridViewTextBoxColumn Status;
    private bool _canEdit = true;

    public CustomerListForm()
    {
        InitializeComponent();
        ConfigureDataGridView();
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null)
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        components = new Container();
        lblTitle = new Label();
        dgvCustomers = new DataGridView();
        btnAdd = new Button();
        btnDelete = new Button();
        btnLogout = new Button();
        btnSearch = new Button();
        txtSearch = new TextBox();
        btnAnalytics = new Button();
        btnExportExcel = new Button();
        btnExportPdf = new Button();
        btnAuditLog = new Button();
        btnManagePermissions = new Button();
        statusStrip1 = new StatusStrip();
        lblStatusUser = new ToolStripStatusLabel();
        lblStatusSep = new ToolStripStatusLabel();
        lblStatusTime = new ToolStripStatusLabel();
        statusTimer = new Timer(components);
        CustomerID = new DataGridViewTextBoxColumn();
        FullName = new DataGridViewTextBoxColumn();
        Address = new DataGridViewTextBoxColumn();
        ContactNumber = new DataGridViewTextBoxColumn();
        Email = new DataGridViewTextBoxColumn();
        Balance = new DataGridViewTextBoxColumn();
        Status = new DataGridViewTextBoxColumn();
        ((ISupportInitialize)dgvCustomers).BeginInit();
        statusStrip1.SuspendLayout();
        SuspendLayout();
        // 
        // lblTitle
        // 
        lblTitle.AccessibleName = "";
        lblTitle.AutoSize = true;
        lblTitle.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
        lblTitle.Location = new Point(22, 41);
        lblTitle.Name = "lblTitle";
        lblTitle.Size = new Size(161, 31);
        lblTitle.TabIndex = 0;
        lblTitle.Text = "Customer List";
        // 
        // dgvCustomers
        // 
        dgvCustomers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvCustomers.Columns.AddRange(new DataGridViewColumn[] { CustomerID, FullName, Address, ContactNumber, Email, Balance, Status });
        dgvCustomers.Location = new Point(11, 105);
        dgvCustomers.Name = "dgvCustomers";
        dgvCustomers.RowHeadersWidth = 51;
        dgvCustomers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvCustomers.Size = new Size(758, 268);
        dgvCustomers.TabIndex = 1;
        dgvCustomers.CellContentClick += dgvCustomers_CellContentClick;
        dgvCustomers.CellDoubleClick += dgvCustomers_CellDoubleClick;
        dgvCustomers.CellFormatting += dgvCustomers_CellFormatting;
        dgvCustomers.SelectionChanged += dgvCustomers_SelectionChanged;
        // 
        // btnAdd
        // 
        btnAdd.Location = new Point(33, 381);
        btnAdd.Name = "btnAdd";
        btnAdd.Size = new Size(182, 29);
        btnAdd.TabIndex = 2;
        btnAdd.Text = "Add Customer";
        btnAdd.UseVisualStyleBackColor = true;
        btnAdd.Click += btnAdd_Click;
        // 
        // btnDelete
        // 
        btnDelete.Location = new Point(253, 381);
        btnDelete.Name = "btnDelete";
        btnDelete.Size = new Size(94, 29);
        btnDelete.TabIndex = 3;
        btnDelete.Text = "Delete";
        btnDelete.UseVisualStyleBackColor = true;
        btnDelete.Click += btnDelete_Click;
        // 
        // btnLogout
        // 
        btnLogout.Location = new Point(392, 381);
        btnLogout.Name = "btnLogout";
        btnLogout.Size = new Size(94, 29);
        btnLogout.TabIndex = 4;
        btnLogout.Text = "Logout";
        btnLogout.UseVisualStyleBackColor = true;
        btnLogout.Click += btnLogout_Click;
        // 
        // btnSearch
        // 
        btnSearch.Location = new Point(399, 41);
        btnSearch.Name = "btnSearch";
        btnSearch.Size = new Size(94, 29);
        btnSearch.TabIndex = 5;
        btnSearch.Text = "Search";
        btnSearch.UseVisualStyleBackColor = true;
        btnSearch.Click += btnSearch_Click;
        // 
        // txtSearch
        // 
        txtSearch.Location = new Point(499, 43);
        txtSearch.Name = "txtSearch";
        txtSearch.Size = new Size(125, 27);
        txtSearch.TabIndex = 6;
        txtSearch.KeyPress += txtSearch_KeyPress;
        // 
        // btnAnalytics
        // 
        btnAnalytics.Location = new Point(528, 381);
        btnAnalytics.Margin = new Padding(3, 4, 3, 4);
        btnAnalytics.Name = "btnAnalytics";
        btnAnalytics.Size = new Size(86, 31);
        btnAnalytics.TabIndex = 7;
        btnAnalytics.Text = "Analytics";
        btnAnalytics.UseVisualStyleBackColor = true;
        btnAnalytics.Click += btnAnalytics_Click;
        // 
        // btnExportExcel
        // 
        btnExportExcel.Location = new Point(642, 381);
        btnExportExcel.Margin = new Padding(3, 4, 3, 4);
        btnExportExcel.Name = "btnExportExcel";
        btnExportExcel.Size = new Size(105, 31);
        btnExportExcel.TabIndex = 8;
        btnExportExcel.Text = "Export to Excel";
        btnExportExcel.UseVisualStyleBackColor = true;
        btnExportExcel.Click += btnExportExcel_Click;
        // 
        // btnExportPdf
        // 
        btnExportPdf.Location = new Point(59, 417);
        btnExportPdf.Margin = new Padding(3, 4, 3, 4);
        btnExportPdf.Name = "btnExportPdf";
        btnExportPdf.Size = new Size(114, 31);
        btnExportPdf.TabIndex = 9;
        btnExportPdf.Text = "Export to PDF";
        btnExportPdf.UseVisualStyleBackColor = true;
        btnExportPdf.Click += btnExportPdf_Click;
        // 
        // btnAuditLog
        // 
        btnAuditLog.Location = new Point(217, 417);
        btnAuditLog.Margin = new Padding(3, 4, 3, 4);
        btnAuditLog.Name = "btnAuditLog";
        btnAuditLog.Size = new Size(86, 31);
        btnAuditLog.TabIndex = 10;
        btnAuditLog.Text = "Audit Log";
        btnAuditLog.UseVisualStyleBackColor = true;
        btnAuditLog.Click += btnAuditLog_Click;
        // 
        // btnManagePermissions
        // 
        btnManagePermissions.Location = new Point(343, 417);
        btnManagePermissions.Margin = new Padding(3, 4, 3, 4);
        btnManagePermissions.Name = "btnManagePermissions";
        btnManagePermissions.Size = new Size(205, 31);
        btnManagePermissions.TabIndex = 11;
        btnManagePermissions.Text = "Manage Permissions";
        btnManagePermissions.UseVisualStyleBackColor = true;
        btnManagePermissions.Click += btnManagePermissions_Click;
        // 
        // statusStrip1
        // 
        statusStrip1.ImageScalingSize = new Size(20, 20);
        statusStrip1.Items.AddRange(new ToolStripItem[] { lblStatusUser, lblStatusSep, lblStatusTime });
        statusStrip1.Location = new Point(0, 427);
        statusStrip1.Name = "statusStrip1";
        statusStrip1.Size = new Size(782, 26);
        statusStrip1.TabIndex = 12;
        statusStrip1.Text = "statusStrip1";
        // 
        // lblStatusUser
        // 
        lblStatusUser.Name = "lblStatusUser";
        lblStatusUser.Size = new Size(151, 20);
        lblStatusUser.Text = "toolStripStatusLabel1";
        // 
        // lblStatusSep
        // 
        lblStatusSep.Name = "lblStatusSep";
        lblStatusSep.Size = new Size(151, 20);
        lblStatusSep.Text = "toolStripStatusLabel2";
        // 
        // lblStatusTime
        // 
        lblStatusTime.Name = "lblStatusTime";
        lblStatusTime.Size = new Size(151, 20);
        lblStatusTime.Text = "toolStripStatusLabel3";
        // 
        // statusTimer
        // 
        statusTimer.Enabled = true;
        statusTimer.Interval = 1000;
        statusTimer.Tick += statusTimer_Tick;
        // 
        // CustomerID
        // 
        CustomerID.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        CustomerID.HeaderText = "ID";
        CustomerID.MinimumWidth = 6;
        CustomerID.Name = "CustomerID";
        CustomerID.ReadOnly = true;
        // 
        // FullName
        // 
        FullName.HeaderText = "Full Name";
        FullName.MinimumWidth = 6;
        FullName.Name = "FullName";
        FullName.ReadOnly = true;
        FullName.Width = 125;
        // 
        // Address
        // 
        Address.HeaderText = "Address";
        Address.MinimumWidth = 6;
        Address.Name = "Address";
        Address.ReadOnly = true;
        Address.Width = 125;
        // 
        // ContactNumber
        // 
        ContactNumber.HeaderText = "Contact No.";
        ContactNumber.MinimumWidth = 6;
        ContactNumber.Name = "ContactNumber";
        ContactNumber.ReadOnly = true;
        ContactNumber.Width = 125;
        // 
        // Email
        // 
        Email.HeaderText = "Email";
        Email.MinimumWidth = 6;
        Email.Name = "Email";
        Email.ReadOnly = true;
        Email.Width = 125;
        // 
        // Balance
        // 
        Balance.HeaderText = "Balance";
        Balance.MinimumWidth = 6;
        Balance.Name = "Balance";
        Balance.ReadOnly = true;
        Balance.Width = 125;
        // 
        // Status
        // 
        Status.HeaderText = "Status";
        Status.MinimumWidth = 6;
        Status.Name = "Status";
        Status.Width = 125;
        // 
        // CustomerListForm
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(782, 453);
        Controls.Add(statusStrip1);
        Controls.Add(btnManagePermissions);
        Controls.Add(btnAuditLog);
        Controls.Add(btnExportPdf);
        Controls.Add(btnExportExcel);
        Controls.Add(btnAnalytics);
        Controls.Add(txtSearch);
        Controls.Add(btnSearch);
        Controls.Add(btnLogout);
        Controls.Add(btnDelete);
        Controls.Add(btnAdd);
        Controls.Add(dgvCustomers);
        Controls.Add(lblTitle);
        Name = "CustomerListForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Billing System v1.0 - Customer List (M.J.B.)";
        Load += CustomerListForm_Load;
        ((ISupportInitialize)dgvCustomers).EndInit();
        statusStrip1.ResumeLayout(false);
        statusStrip1.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }

    private void btnAdd_Click(object sender, System.EventArgs e)
    {
        AddCustomerForm addCustomerForm = new AddCustomerForm();
        addCustomerForm.ShowDialog();
        // LoadCustomers();  
    }

    private void LoadCustomers()
    {
        try
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();

                // SELECT all customers, most recently added first
                string sql = @"SELECT CustomerID,
                                  FullName,
                                  Address,
                                  ContactNumber,
                                  Email,
                                  Balance,
                                  Status
                           FROM   Customers
                           ORDER  BY FullName ASC;";

                using (var adapter = new MySqlDataAdapter(sql, conn))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    // Bind the DataTable to the grid
                    dgvCustomers.DataSource = dt;

                    // Improve column headers for readability
                    if (dgvCustomers.Columns.Count > 0)
                    {
                        dgvCustomers.Columns["CustomerID"].HeaderText = "ID";
                        dgvCustomers.Columns["FullName"].HeaderText = "Full Name";
                        dgvCustomers.Columns["ContactNumber"].HeaderText = "Contact No.";
                        dgvCustomers.Columns["Balance"].HeaderText = "Balance (₱)";
                    }

                    lblTitle.Text = $"Customer List  ({dt.Rows.Count} record(s))";
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error loading customers:\n{ex.Message}",
                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void CustomerListForm_Load(object sender, System.EventArgs e)
    {
        ApplyTheme();
        LoadCustomers();
        ApplyPermissions();
        InitStatusStrip();
    }

    private void SearchCustomers(string keyword)
    {
        try
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();

                // Parameterized SELECT with WHERE ... LIKE
                string sql = @"SELECT CustomerID,
                                  FullName,
                                  Address,
                                  ContactNumber,
                                  Email,
                                  Balance,
                                  Status
                           FROM   Customers
                           WHERE  FullName      LIKE @keyword
                              OR  Address       LIKE @keyword
                              OR  ContactNumber LIKE @keyword
                           ORDER  BY FullName ASC;";

                using (var cmd = new MySqlCommand(sql, conn))
                {
                    // %keyword% matches the search text anywhere in the column
                    cmd.Parameters.AddWithValue("@keyword", $"%{keyword}%");

                    using (var adapter = new MySqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        dgvCustomers.DataSource = dt;
                        lblTitle.Text = $"Customer List  ({dt.Rows.Count} result(s))";
                    }
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error searching customers:\n{ex.Message}",
                "Search Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btnSearch_Click(object sender, System.EventArgs e)
    {
        string keyword = txtSearch.Text.Trim();

        if (string.IsNullOrEmpty(keyword))
        {
            // Empty search box → show all customers again
            LoadCustomers();
        }
        else
        {
            SearchCustomers(keyword);
        }
    }

    private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (e.KeyChar == (char)Keys.Enter)
        {
            btnSearch_Click(sender, e);
        }
    }

    private void ConfigureDataGridView()
    {
        dgvCustomers.AutoGenerateColumns = false;
        dgvCustomers.Columns["CustomerID"].DataPropertyName = "CustomerID";
        dgvCustomers.Columns["FullName"].DataPropertyName = "FullName";
        dgvCustomers.Columns["Address"].DataPropertyName = "Address";
        dgvCustomers.Columns["ContactNumber"].DataPropertyName = "ContactNumber";
        dgvCustomers.Columns["Email"].DataPropertyName = "Email";
        dgvCustomers.Columns["Balance"].DataPropertyName = "Balance";
        dgvCustomers.Columns["Status"].DataPropertyName = "Status";
    }

    private void dgvCustomers_SelectionChanged(object sender, EventArgs e)
    {
        // If no row is selected (e.g., grid is empty), do nothing
        if (dgvCustomers.CurrentRow == null) return;

        // Read the CustomerID value from the selected row
        var idCell = dgvCustomers.CurrentRow.Cells["CustomerID"].Value;

        if (idCell != null && int.TryParse(idCell.ToString(), out int id))
        {
            _selectedCustomerId = id;
        }
    }

    private void dgvCustomers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
        if (!_canEdit) return;
        // e.RowIndex is -1 when the header row is double-clicked — ignore it
        if (e.RowIndex < 0) return;

        OpenEditForm();
    }

    private void OpenEditForm()
    {
        if (_selectedCustomerId == 0)
        {
            MessageBox.Show("Please select a customer to edit.",
                "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        // Open AddCustomerForm in EDIT mode, passing the selected CustomerID
        AddCustomerForm editForm = new AddCustomerForm(_selectedCustomerId);

        // Refresh the grid automatically once the edit form closes
        editForm.FormClosed += (s, args) => LoadCustomers();

        editForm.ShowDialog(this);
    }

    private void DeleteCustomer(int customerId)
    {
        try
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();

                // Parameterized DELETE — removes exactly one row
                string sql = "DELETE FROM Customers WHERE CustomerID = @CustomerID;";

                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@CustomerID", customerId);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Customer deleted successfully.",
                            "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        AuditLogger.Log("DELETE_CUSTOMER",
                            $"Customer ID {customerId} deleted by {AppSession.CurrentUsername}.");


                        LoadCustomers();   // Refresh the grid
                        _selectedCustomerId = 0;   // Clear selection tracker
                    }
                    else
                    {
                        MessageBox.Show("Customer could not be deleted. It may no longer exist.",
                            "Delete Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error deleting customer:\n{ex.Message}",
                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btnDelete_Click(object sender, EventArgs e)
    {
        // Step 1: Make sure a customer is selected
        if (_selectedCustomerId == 0)
        {
            MessageBox.Show("Please select a customer to delete.",
                "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        // Step 2: Confirm before deleting — this cannot be undone
        DialogResult confirm = MessageBox.Show(
            "Are you sure you want to delete this customer?\n" +
            "All billing records for this customer will also be deleted.",
            "Confirm Delete",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning);

        // Step 3: Only delete if the user clicked Yes
        if (confirm == DialogResult.Yes)
        {
            DeleteCustomer(_selectedCustomerId);
        }
        // If the user clicked No, do nothing — the record is preserved
    }

    private void btnAnalytics_Click(object sender, EventArgs e)
    {
        // Open the Analytics Dashboard as a dialog so the
        // Customer List stays open in the background
        frmAnalytics analyticsForm = new frmAnalytics();

        AuditLogger.Log("VIEW_ANALYTICS",
          $"{AppSession.CurrentUsername} opened the Analytics Dashboard.");

        analyticsForm.ShowDialog(this);
    }

    private void btnExportExcel_Click(object sender, EventArgs e)
    {
        // Make sure there is something to export
        if (dgvCustomers.Rows.Count == 0)
        {
            MessageBox.Show("There are no records to export.",
                "Export to Excel", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        // Let the user choose where to save the file
        using (SaveFileDialog saveDialog = new SaveFileDialog())
        {
            saveDialog.Filter = "Excel Workbook (.xlsx)|.xlsx";
            saveDialog.FileName = "CustomerList.xlsx";

            if (saveDialog.ShowDialog() != DialogResult.OK) return;

            try
            {
                using (var workbook = new XLWorkbook())
                {
                    var worksheet = workbook.Worksheets.Add("Customers");

                    // Write column headers in row 1
                    for (int col = 0; col < dgvCustomers.Columns.Count; col++)
                    {
                        worksheet.Cell(1, col + 1).Value = dgvCustomers.Columns[col].HeaderText;
                        worksheet.Cell(1, col + 1).Style.Font.Bold = true;
                    }

                    // Write each data row starting from row 2
                    for (int row = 0; row < dgvCustomers.Rows.Count; row++)
                    {
                        for (int col = 0; col < dgvCustomers.Columns.Count; col++)
                        {
                            var cellValue = dgvCustomers.Rows[row].Cells[col].Value;
                            worksheet.Cell(row + 2, col + 1).Value = cellValue?.ToString() ?? "";
                        }
                    }

                    // Auto-adjust column widths to fit the content
                    worksheet.Columns().AdjustToContents();

                    workbook.SaveAs(saveDialog.FileName);
                }
                AuditLogger.Log("EXPORT_EXCEL",
                  $"{AppSession.CurrentUsername} exported customer list to Excel.");

                MessageBox.Show("Customer list exported successfully to Excel.",
                    "Export Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error exporting to Excel:\n{ex.Message}",
                    "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    private void btnExportPdf_Click(object sender, EventArgs e)
    {
        // Make sure there is something to export
        if (dgvCustomers.Rows.Count == 0)
        {
            MessageBox.Show("There are no records to export.",
                "Export to PDF", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        using (SaveFileDialog saveDialog = new SaveFileDialog())
        {
            saveDialog.Filter = "PDF Document (.pdf)|.pdf";
            saveDialog.FileName = "CustomerList.pdf";

            if (saveDialog.ShowDialog() != DialogResult.OK) return;

            try
            {
                using (PdfDocument document = new PdfDocument())
                {
                    // Create a new page set to Landscape orientation
                    PdfPage page = document.AddPage();
                    page.Orientation = PdfSharp.PageOrientation.Landscape;

                    XGraphics gfx = XGraphics.FromPdfPage(page);
                    {
                        XFont titleFont = new XFont("Arial", 16, XFontStyleEx.Bold);
                        XFont headerFont = new XFont("Arial", 10, XFontStyleEx.Bold);
                        XFont cellFont = new XFont("Arial", 9, XFontStyleEx.Regular);

                        // Title
                        gfx.DrawString("Customer List Report", titleFont, XBrushes.Black,
                            new XRect(0, 20, page.Width.Point, 30), XStringFormats.TopCenter);

                        int columnCount = dgvCustomers.Columns.Count;
                        double margin = 30;
                        double tableWidth = page.Width.Point - (margin * 2);
                        double colWidth = tableWidth / columnCount;
                        double rowHeight = 22;
                        double y = 60;

                        // Draw column headers
                        double x = margin;
                        for (int col = 0; col < columnCount; col++)
                        {
                            gfx.DrawString(dgvCustomers.Columns[col].HeaderText, headerFont,
                                XBrushes.Black, new XRect(x, y, colWidth, rowHeight),
                                XStringFormats.CenterLeft);
                            x += colWidth;
                        }

                        y += rowHeight;
                        gfx.DrawLine(XPens.Black, margin, y, page.Width.Point - margin, y);

                        // Draw each data row
                        foreach (DataGridViewRow row in dgvCustomers.Rows)
                        {
                            x = margin;
                            y += rowHeight;

                            // Start a new page if we run out of vertical space
                            if (y > page.Height.Point - margin)
                            {
                                page = document.AddPage();
                                page.Orientation = PdfSharp.PageOrientation.Landscape;
                                gfx.Dispose();
                                gfx = XGraphics.FromPdfPage(page);
                                y = 40;
                            }

                            for (int col = 0; col < columnCount; col++)
                            {
                                string text = row.Cells[col].Value?.ToString() ?? "";
                                gfx.DrawString(text, cellFont, XBrushes.Black,
                                    new XRect(x, y, colWidth, rowHeight),
                                    XStringFormats.CenterLeft);
                                x += colWidth;
                            }
                        }
                    }

                    gfx.Dispose();   // finish drawing before saving
                    document.Save(saveDialog.FileName);
                }
                AuditLogger.Log("EXPORT_PDF",
                  $"{AppSession.CurrentUsername} exported customer list to PDF.");

                MessageBox.Show("Customer list exported successfully to PDF.",
                    "Export Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error exporting to PDF:\n{ex.Message}",
                    "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    private void btnLogout_Click(object sender, EventArgs e)
    {
        AuditLogger.Log("LOGOUT",
    $"{AppSession.CurrentFullName} ({AppSession.CurrentRole}) logged out.");
        AppSession.Clear();

        this.Close();
    }

    private void btnAuditLog_Click(object sender, EventArgs e)
    {
        frmAuditLogs auditForm = new frmAuditLogs();
        auditForm.ShowDialog(this);
    }

    private void btnManagePermissions_Click(object sender, EventArgs e)
    {
        frmManagePermissions permForm = new frmManagePermissions();
        permForm.ShowDialog(this);
    }
    private void ApplyPermissions()
    {
        try
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                string sql = @"SELECT PermissionName, IsAllowed
                           FROM   UserPermissions
                           WHERE  Role = @Role;";

                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Role", AppSession.CurrentRole);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string permName = reader.GetString("PermissionName");
                            bool isAllowed = reader.GetBoolean("IsAllowed");

                            switch (permName)
                            {
                                case "AddCustomer":
                                    btnAdd.Enabled = isAllowed; break;
                                case "EditCustomer":
                                    // Edit is triggered by double-click — remember the
                                    // permission so CellDoubleClick can check it
                                    _canEdit = isAllowed;
                                    break;
                                case "DeleteCustomer":
                                    btnDelete.Enabled = isAllowed; break;
                                case "Analytics":
                                    btnAnalytics.Enabled = isAllowed; break;
                                case "ExportExcel":
                                    btnExportExcel.Enabled = isAllowed; break;
                                case "ExportPdf":
                                    btnExportPdf.Enabled = isAllowed; break;
                                case "AuditLogs":
                                    btnAuditLog.Enabled = isAllowed; break;
                                case "ManagePermissions":
                                    btnManagePermissions.Enabled = isAllowed; break;
                            }
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error loading permissions:\n{ex.Message}",
                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    // Call this inside CustomerListForm_Load after ApplyPermissions()
    private void InitStatusStrip()
    {
        lblStatusUser.Text =
            $"User: {AppSession.CurrentFullName}  |  Role: {AppSession.CurrentRole}";
        UpdateClock();
    }

    private void UpdateClock()
    {
        lblStatusTime.Text = DateTime.Now.ToString("dddd, MMMM dd yyyy   hh:mm:ss tt");
    }

    private void statusTimer_Tick(object sender, EventArgs e)
    {
        UpdateClock();
    }

    private void ApplyTheme()
    {
        // Form background
        this.BackColor = AppTheme.BackgroundColor;

        // Action buttons
        btnAdd.BackColor = AppTheme.SuccessColor;
        btnAdd.ForeColor = Color.White;
        btnDelete.BackColor = AppTheme.DangerColor;
        btnDelete.ForeColor = Color.White;
        btnAnalytics.BackColor = AppTheme.PrimaryColor;
        btnAnalytics.ForeColor = Color.White;
        btnExportExcel.BackColor = AppTheme.SecondaryColor;
        btnExportExcel.ForeColor = Color.White;
        btnExportPdf.BackColor = AppTheme.SecondaryColor;
        btnExportPdf.ForeColor = Color.White;
        btnAuditLog.BackColor = AppTheme.SecondaryColor;
        btnAuditLog.ForeColor = Color.White;
        btnManagePermissions.BackColor = AppTheme.DangerColor;
        btnManagePermissions.ForeColor = Color.White;

        // DataGridView header colors
        dgvCustomers.ColumnHeadersDefaultCellStyle.BackColor = AppTheme.PrimaryColor;
        dgvCustomers.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        dgvCustomers.ColumnHeadersDefaultCellStyle.Font =
            new Font("Segoe UI", 9f, FontStyle.Bold);

        // Alternating row colors
        dgvCustomers.AlternatingRowsDefaultCellStyle.BackColor = AppTheme.GridRowAlt;
    }

    private void dgvCustomers_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
        if (e.RowIndex < 0) return;


        // Read Status from the data behind this row (the DataTable from LoadCustomers)
        var rowData = dgvCustomers.Rows[e.RowIndex].DataBoundItem as DataRowView;
        string status = rowData?["Status"]?.ToString() ?? "";


        if (status == "Inactive")
        {
            // The whole row turns light red
            e.CellStyle.BackColor = AppTheme.InactiveRowColor;
        }
        else if (status == "Active" &&
                 dgvCustomers.Columns[e.ColumnIndex].DataPropertyName == "Status")
        {
            // Only the Status cell turns light green, so the
            // alternating row colors stay visible
            e.CellStyle.BackColor = AppTheme.ActiveRowColor;
        }


    }

    private void dgvCustomers_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {

    }
}