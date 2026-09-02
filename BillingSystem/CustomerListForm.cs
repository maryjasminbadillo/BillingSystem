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
		this.lblTitle = new System.Windows.Forms.Label();
		this.dgvCustomer = new System.Windows.Forms.DataGridView();
		this.CustomerID = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.FullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.Address = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.ContactNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.Balance = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.btnAdd = new System.Windows.Forms.Button();
		this.btnDelete = new System.Windows.Forms.Button();
		this.btnLogout = new System.Windows.Forms.Button();
		this.btnSearch = new System.Windows.Forms.Button();
		this.txtSearch = new System.Windows.Forms.TextBox();
		((System.ComponentModel.ISupportInitialize)this.dgvCustomer).BeginInit();
		base.SuspendLayout();
		this.lblTitle.AccessibleName = "";
		this.lblTitle.AutoSize = true;
		this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 13.8f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.lblTitle.Location = new System.Drawing.Point(22, 41);
		this.lblTitle.Name = "lblTitle";
		this.lblTitle.Size = new System.Drawing.Size(161, 31);
		this.lblTitle.TabIndex = 0;
		this.lblTitle.Text = "Customer List";
		this.dgvCustomer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		this.dgvCustomer.Columns.AddRange(this.CustomerID, this.FullName, this.Address, this.ContactNumber, this.Email, this.Balance);
		this.dgvCustomer.Location = new System.Drawing.Point(12, 105);
		this.dgvCustomer.Name = "dgvCustomer";
		this.dgvCustomer.RowHeadersWidth = 51;
		this.dgvCustomer.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
		this.dgvCustomer.Size = new System.Drawing.Size(758, 268);
		this.dgvCustomer.TabIndex = 1;
		this.CustomerID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
		this.CustomerID.HeaderText = "ID";
		this.CustomerID.MinimumWidth = 6;
		this.CustomerID.Name = "CustomerID";
		this.CustomerID.ReadOnly = true;
		this.FullName.HeaderText = "Full Name";
		this.FullName.MinimumWidth = 6;
		this.FullName.Name = "FullName";
		this.FullName.ReadOnly = true;
		this.FullName.Width = 125;
		this.Address.HeaderText = "Address";
		this.Address.MinimumWidth = 6;
		this.Address.Name = "Address";
		this.Address.ReadOnly = true;
		this.Address.Width = 125;
		this.ContactNumber.HeaderText = "Contact No.";
		this.ContactNumber.MinimumWidth = 6;
		this.ContactNumber.Name = "ContactNumber";
		this.ContactNumber.ReadOnly = true;
		this.ContactNumber.Width = 125;
		this.Email.HeaderText = "Email";
		this.Email.MinimumWidth = 6;
		this.Email.Name = "Email";
		this.Email.ReadOnly = true;
		this.Email.Width = 125;
		this.Balance.HeaderText = "Balance";
		this.Balance.MinimumWidth = 6;
		this.Balance.Name = "Balance";
		this.Balance.ReadOnly = true;
		this.Balance.Width = 125;
		this.btnAdd.Location = new System.Drawing.Point(88, 393);
		this.btnAdd.Name = "btnAdd";
		this.btnAdd.Size = new System.Drawing.Size(182, 29);
		this.btnAdd.TabIndex = 2;
		this.btnAdd.Text = "Add Customer";
		this.btnAdd.UseVisualStyleBackColor = true;
		this.btnDelete.Location = new System.Drawing.Point(315, 393);
		this.btnDelete.Name = "btnDelete";
		this.btnDelete.Size = new System.Drawing.Size(94, 29);
		this.btnDelete.TabIndex = 3;
		this.btnDelete.Text = "Delete";
		this.btnDelete.UseVisualStyleBackColor = true;
		this.btnLogout.Location = new System.Drawing.Point(450, 393);
		this.btnLogout.Name = "btnLogout";
		this.btnLogout.Size = new System.Drawing.Size(94, 29);
		this.btnLogout.TabIndex = 4;
		this.btnLogout.Text = "Logout";
		this.btnLogout.UseVisualStyleBackColor = true;
		this.btnSearch.Location = new System.Drawing.Point(399, 41);
		this.btnSearch.Name = "btnSearch";
		this.btnSearch.Size = new System.Drawing.Size(94, 29);
		this.btnSearch.TabIndex = 5;
		this.btnSearch.Text = "Search";
		this.btnSearch.UseVisualStyleBackColor = true;
		this.txtSearch.Location = new System.Drawing.Point(499, 43);
		this.txtSearch.Name = "txtSearch";
		this.txtSearch.Size = new System.Drawing.Size(125, 27);
		this.txtSearch.TabIndex = 6;
		base.AutoScaleDimensions = new System.Drawing.SizeF(8f, 20f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(782, 453);
		base.Controls.Add(this.txtSearch);
		base.Controls.Add(this.btnSearch);
		base.Controls.Add(this.btnLogout);
		base.Controls.Add(this.btnDelete);
		base.Controls.Add(this.btnAdd);
		base.Controls.Add(this.dgvCustomer);
		base.Controls.Add(this.lblTitle);
		base.Name = "CustomerListForm";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Billing System - Customer List";
		((System.ComponentModel.ISupportInitialize)this.dgvCustomer).EndInit();
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
