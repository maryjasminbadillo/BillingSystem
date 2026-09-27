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

    private DataGridView dgvCustomer;

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
        dgvCustomer = new DataGridView();
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
        ((ISupportInitialize)dgvCustomer).BeginInit();
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
        // dgvCustomer
        // 
        dgvCustomer.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvCustomer.Columns.AddRange(new DataGridViewColumn[] { CustomerID, FullName, Address, ContactNumber, Email, Balance });
        dgvCustomer.Location = new Point(12, 105);
        dgvCustomer.Name = "dgvCustomer";
        dgvCustomer.RowHeadersWidth = 51;
        dgvCustomer.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvCustomer.Size = new Size(758, 268);
        dgvCustomer.TabIndex = 1;
        dgvCustomer.CellContentClick += dgvCustomer_CellContentClick_1;
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
        Controls.Add(dgvCustomer);
        Controls.Add(lblTitle);
        Name = "CustomerListForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Billing System v1.0 - Customer List (M.J.B.)";
        Load += CustomerListForm_Load;
        ((ISupportInitialize)dgvCustomer).EndInit();
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
                    dgvCustomer.DataSource = dt;

                    // Improve column headers for readability
                    if (dgvCustomer.Columns.Count > 0)
                    {
                        dgvCustomer.Columns["CustomerID"].HeaderText = "ID";
                        dgvCustomer.Columns["FullName"].HeaderText = "Full Name";
                        dgvCustomer.Columns["ContactNumber"].HeaderText = "Contact No.";
                        dgvCustomer.Columns["Balance"].HeaderText = "Balance (₱)";
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

    private void CustomerListForm_Load(object sender, EventArgs e)
    {
        LoadCustomers();
    }

    private void btnAdd_Click(object sender, System.EventArgs e)
    {
        AddCustomerForm addCustomerForm = new AddCustomerForm();
        addCustomerForm.ShowDialog();
    }

    private void dgvCustomer_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {

    }

    private void dgvCustomer_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
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

                        dgvCustomer.DataSource = dt;
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
        dgvCustomer.AutoGenerateColumns = false;
        dgvCustomer.Columns["CustomerID"].DataPropertyName = "CustomerID";
        dgvCustomer.Columns["FullName"].DataPropertyName = "FullName";
        dgvCustomer.Columns["Address"].DataPropertyName = "Address";
        dgvCustomer.Columns["ContactNumber"].DataPropertyName = "ContactNumber";
        dgvCustomer.Columns["Email"].DataPropertyName = "Email";
        dgvCustomer.Columns["Balance"].DataPropertyName = "Balance";
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
}
