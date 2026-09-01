using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace BillingSystem;

public class AddCustomerForm : Form
{
	private IContainer components = null;

	private Label lblTitle;

	private Label lblFullName;

	private TextBox txtFullName;

	private Label lblAddress;

	private TextBox txtAddress;

	private Label lblContact;

	private TextBox txtContact;

	private TextBox txtEmail;

	private Label lblEmail;

	private Label lblBalance;

	private TextBox txtBalance;

	private Button btnSave;

	private Button btnClear;

	private Button btnBack;

	public AddCustomerForm()
	{
		InitializeComponent();
	}

	private void textBox1_TextChanged(object sender, EventArgs e)
	{
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
		this.lblFullName = new System.Windows.Forms.Label();
		this.txtFullName = new System.Windows.Forms.TextBox();
		this.lblAddress = new System.Windows.Forms.Label();
		this.txtAddress = new System.Windows.Forms.TextBox();
		this.lblContact = new System.Windows.Forms.Label();
		this.txtContact = new System.Windows.Forms.TextBox();
		this.txtEmail = new System.Windows.Forms.TextBox();
		this.lblEmail = new System.Windows.Forms.Label();
		this.lblBalance = new System.Windows.Forms.Label();
		this.txtBalance = new System.Windows.Forms.TextBox();
		this.btnSave = new System.Windows.Forms.Button();
		this.btnClear = new System.Windows.Forms.Button();
		this.btnBack = new System.Windows.Forms.Button();
		base.SuspendLayout();
		this.lblTitle.AutoSize = true;
		this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.lblTitle.Location = new System.Drawing.Point(97, 23);
		this.lblTitle.Name = "lblTitle";
		this.lblTitle.Size = new System.Drawing.Size(201, 28);
		this.lblTitle.TabIndex = 0;
		this.lblTitle.Text = "Add New Customer ";
		this.lblFullName.AutoSize = true;
		this.lblFullName.Location = new System.Drawing.Point(38, 76);
		this.lblFullName.Name = "lblFullName";
		this.lblFullName.Size = new System.Drawing.Size(79, 20);
		this.lblFullName.TabIndex = 1;
		this.lblFullName.Text = "Full Name:";
		this.txtFullName.Location = new System.Drawing.Point(182, 73);
		this.txtFullName.Name = "txtFullName";
		this.txtFullName.Size = new System.Drawing.Size(125, 27);
		this.txtFullName.TabIndex = 2;
		this.lblAddress.AutoSize = true;
		this.lblAddress.Location = new System.Drawing.Point(38, 114);
		this.lblAddress.Name = "lblAddress";
		this.lblAddress.Size = new System.Drawing.Size(65, 20);
		this.lblAddress.TabIndex = 3;
		this.lblAddress.Text = "Address:";
		this.txtAddress.Location = new System.Drawing.Point(182, 111);
		this.txtAddress.Name = "txtAddress";
		this.txtAddress.Size = new System.Drawing.Size(125, 27);
		this.txtAddress.TabIndex = 4;
		this.lblContact.AutoSize = true;
		this.lblContact.Location = new System.Drawing.Point(38, 153);
		this.lblContact.Name = "lblContact";
		this.lblContact.Size = new System.Drawing.Size(121, 20);
		this.lblContact.TabIndex = 5;
		this.lblContact.Text = "Contact Number:";
		this.txtContact.Location = new System.Drawing.Point(182, 150);
		this.txtContact.Name = "txtContact";
		this.txtContact.Size = new System.Drawing.Size(125, 27);
		this.txtContact.TabIndex = 6;
		this.txtEmail.Location = new System.Drawing.Point(182, 186);
		this.txtEmail.Name = "txtEmail";
		this.txtEmail.Size = new System.Drawing.Size(125, 27);
		this.txtEmail.TabIndex = 7;
		this.txtEmail.TextChanged += new System.EventHandler(textBox1_TextChanged);
		this.lblEmail.AutoSize = true;
		this.lblEmail.Location = new System.Drawing.Point(38, 189);
		this.lblEmail.Name = "lblEmail";
		this.lblEmail.Size = new System.Drawing.Size(49, 20);
		this.lblEmail.TabIndex = 8;
		this.lblEmail.Text = "Email:";
		this.lblBalance.AutoSize = true;
		this.lblBalance.Location = new System.Drawing.Point(38, 224);
		this.lblBalance.Name = "lblBalance";
		this.lblBalance.Size = new System.Drawing.Size(105, 20);
		this.lblBalance.TabIndex = 9;
		this.lblBalance.Text = "Initial Balance:";
		this.txtBalance.Location = new System.Drawing.Point(182, 222);
		this.txtBalance.Name = "txtBalance";
		this.txtBalance.Size = new System.Drawing.Size(125, 27);
		this.txtBalance.TabIndex = 10;
		this.txtBalance.Text = "0.00";
		this.btnSave.Location = new System.Drawing.Point(49, 291);
		this.btnSave.Name = "btnSave";
		this.btnSave.Size = new System.Drawing.Size(94, 29);
		this.btnSave.TabIndex = 11;
		this.btnSave.Text = "Save";
		this.btnSave.UseVisualStyleBackColor = true;
		this.btnClear.Location = new System.Drawing.Point(163, 291);
		this.btnClear.Name = "btnClear";
		this.btnClear.Size = new System.Drawing.Size(94, 29);
		this.btnClear.TabIndex = 12;
		this.btnClear.Text = "Clear";
		this.btnClear.UseVisualStyleBackColor = true;
		this.btnBack.Location = new System.Drawing.Point(286, 291);
		this.btnBack.Name = "btnBack";
		this.btnBack.Size = new System.Drawing.Size(94, 29);
		this.btnBack.TabIndex = 13;
		this.btnBack.Text = "Back";
		this.btnBack.UseVisualStyleBackColor = true;
		base.AutoScaleDimensions = new System.Drawing.SizeF(8f, 20f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(432, 373);
		base.Controls.Add(this.btnBack);
		base.Controls.Add(this.btnClear);
		base.Controls.Add(this.btnSave);
		base.Controls.Add(this.txtBalance);
		base.Controls.Add(this.lblBalance);
		base.Controls.Add(this.lblEmail);
		base.Controls.Add(this.txtEmail);
		base.Controls.Add(this.txtContact);
		base.Controls.Add(this.lblContact);
		base.Controls.Add(this.txtAddress);
		base.Controls.Add(this.lblAddress);
		base.Controls.Add(this.txtFullName);
		base.Controls.Add(this.lblFullName);
		base.Controls.Add(this.lblTitle);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
		base.MaximizeBox = false;
		base.Name = "AddCustomerFormcs";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Billing System - Add Customer";
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
