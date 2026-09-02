using System.ComponentModel;
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
        // 
        // txtSearch
        // 
        txtSearch.Location = new Point(499, 43);
        txtSearch.Name = "txtSearch";
        txtSearch.Size = new Size(125, 27);
        txtSearch.TabIndex = 6;
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
        ((ISupportInitialize)dgvCustomer).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }
}
