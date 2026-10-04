using BillingSystem.Database;
using MySql.Data.MySqlClient;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace BillingSystem;

public class CustomerListForm : Form
{
    private IContainer components = null;

    private Label lblTitle;

    private DataGridView dgvCustomers;

    private DataGridViewTextBoxColumn CustomerID;

    private DataGridViewTextBoxColumn FullName;

    private DataGridViewTextBoxColumn Address;

    private DataGridViewTextBoxColumn ContactNumber;

    private DataGridViewTextBoxColumn Email;

    private DataGridViewTextBoxColumn Balance;

    private Button btnAdd;

    private Button btnDelete;

    private Button btnLogout;

    private Button btnSearch;

    private TextBox txtSearch;

    // Stores the CustomerID of the currently selected row.
    // 0 means no customer is currently selected.

    private int _selectedCustomerId = 0;

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
        lblTitle = new Label();
        dgvCustomers = new DataGridView();
        CustomerID = new DataGridViewTextBoxColumn();
        FullName = new DataGridViewTextBoxColumn();
        Address = new DataGridViewTextBoxColumn();
        ContactNumber = new DataGridViewTextBoxColumn();
        Email = new DataGridViewTextBoxColumn();
        Balance = new DataGridViewTextBoxColumn();
        btnAdd = new Button();
        btnDelete = new Button();
        btnLogout = new Button();
        btnSearch = new Button();
        txtSearch = new TextBox();
        ((ISupportInitialize)dgvCustomers).BeginInit();
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
        dgvCustomers.Columns.AddRange(new DataGridViewColumn[] { CustomerID, FullName, Address, ContactNumber, Email, Balance });
        dgvCustomers.Location = new Point(12, 105);
        dgvCustomers.Name = "dgvCustomers";
        dgvCustomers.RowHeadersWidth = 51;
        dgvCustomers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvCustomers.Size = new Size(758, 268);
        dgvCustomers.TabIndex = 1;
        dgvCustomers.CellContentClick += dgvCustomers_CellDoubleClick;
        dgvCustomers.CellDoubleClick += dgvCustomers_CellDoubleClick;
        dgvCustomers.SelectionChanged += dgvCustomers_SelectionChanged;
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
        // btnAdd
        // 
        btnAdd.Location = new Point(88, 393);
        btnAdd.Name = "btnAdd";
        btnAdd.Size = new Size(182, 29);
        btnAdd.TabIndex = 2;
        btnAdd.Text = "Add Customer";
        btnAdd.UseVisualStyleBackColor = true;
        btnAdd.Click += btnAdd_Click;
        // 
        // btnDelete
        // 
        btnDelete.Location = new Point(315, 393);
        btnDelete.Name = "btnDelete";
        btnDelete.Size = new Size(94, 29);
        btnDelete.TabIndex = 3;
        btnDelete.Text = "Delete";
        btnDelete.UseVisualStyleBackColor = true;
        btnDelete.Click += btnDelete_Click;
        // 
        // btnLogout
        // 
        btnLogout.Location = new Point(450, 393);
        btnLogout.Name = "btnLogout";
        btnLogout.Size = new Size(94, 29);
        btnLogout.TabIndex = 4;
        btnLogout.Text = "Logout";
        btnLogout.UseVisualStyleBackColor = true;
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
        txtSearch.KeyPress += txtSearch_KeyPress_1;
        // 
        // CustomerListForm
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(782, 453);
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
        ResumeLayout(false);
        PerformLayout();
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
                    dgvCustomers.ClearSelection();
                    _selectedCustomerId = 0;
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error loading customers:\n{ex.Message}",
                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void CustomerListForm_Load(object sender, EventArgs e)
    {
        LoadCustomers();
    }

    private void btnAdd_Click(object sender, System.EventArgs e)
    {
        AddCustomerForm addCustomerForm = new AddCustomerForm();
        addCustomerForm.ShowDialog();
    }

    private void dgvCustomers_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
    {

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
    }

    private void btnSearch_Click(object sender, EventArgs e)
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

    private void txtSearch_KeyPress_1(object sender, KeyPressEventArgs e)
    {

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

                        LoadCustomers();   // Refresh the grid
                        _selectedCustomerId = 0;   // Clear selection tracker
                        dgvCustomers.ClearSelection(); // Clear any selection in the grid
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
    private void dgvCustomers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
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
}
