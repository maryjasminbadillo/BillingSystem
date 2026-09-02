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
        lblTitle = new Label();
        lblFullName = new Label();
        txtFullName = new TextBox();
        lblAddress = new Label();
        txtAddress = new TextBox();
        lblContact = new Label();
        txtContact = new TextBox();
        txtEmail = new TextBox();
        lblEmail = new Label();
        lblBalance = new Label();
        txtBalance = new TextBox();
        btnSave = new Button();
        btnClear = new Button();
        btnBack = new Button();
        SuspendLayout();
        // 
        // lblTitle
        // 
        lblTitle.AutoSize = true;
        lblTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
        lblTitle.Location = new Point(85, 17);
        lblTitle.Name = "lblTitle";
        lblTitle.Size = new Size(161, 21);
        lblTitle.TabIndex = 0;
        lblTitle.Text = "Add New Customer ";
        // 
        // lblFullName
        // 
        lblFullName.AutoSize = true;
        lblFullName.Location = new Point(33, 57);
        lblFullName.Name = "lblFullName";
        lblFullName.Size = new Size(64, 15);
        lblFullName.TabIndex = 1;
        lblFullName.Text = "Full Name:";
        // 
        // txtFullName
        // 
        txtFullName.Location = new Point(159, 55);
        txtFullName.Margin = new Padding(3, 2, 3, 2);
        txtFullName.Name = "txtFullName";
        txtFullName.Size = new Size(110, 23);
        txtFullName.TabIndex = 2;
        // 
        // lblAddress
        // 
        lblAddress.AutoSize = true;
        lblAddress.Location = new Point(33, 86);
        lblAddress.Name = "lblAddress";
        lblAddress.Size = new Size(52, 15);
        lblAddress.TabIndex = 3;
        lblAddress.Text = "Address:";
        // 
        // txtAddress
        // 
        txtAddress.Location = new Point(159, 83);
        txtAddress.Margin = new Padding(3, 2, 3, 2);
        txtAddress.Name = "txtAddress";
        txtAddress.Size = new Size(110, 23);
        txtAddress.TabIndex = 4;
        // 
        // lblContact
        // 
        lblContact.AutoSize = true;
        lblContact.Location = new Point(33, 115);
        lblContact.Name = "lblContact";
        lblContact.Size = new Size(99, 15);
        lblContact.TabIndex = 5;
        lblContact.Text = "Contact Number:";
        // 
        // txtContact
        // 
        txtContact.Location = new Point(159, 112);
        txtContact.Margin = new Padding(3, 2, 3, 2);
        txtContact.Name = "txtContact";
        txtContact.Size = new Size(110, 23);
        txtContact.TabIndex = 6;
        // 
        // txtEmail
        // 
        txtEmail.Location = new Point(159, 140);
        txtEmail.Margin = new Padding(3, 2, 3, 2);
        txtEmail.Name = "txtEmail";
        txtEmail.Size = new Size(110, 23);
        txtEmail.TabIndex = 7;
        txtEmail.TextChanged += textBox1_TextChanged;
        // 
        // lblEmail
        // 
        lblEmail.AutoSize = true;
        lblEmail.Location = new Point(33, 142);
        lblEmail.Name = "lblEmail";
        lblEmail.Size = new Size(39, 15);
        lblEmail.TabIndex = 8;
        lblEmail.Text = "Email:";
        // 
        // lblBalance
        // 
        lblBalance.AutoSize = true;
        lblBalance.Location = new Point(33, 168);
        lblBalance.Name = "lblBalance";
        lblBalance.Size = new Size(83, 15);
        lblBalance.TabIndex = 9;
        lblBalance.Text = "Initial Balance:";
        // 
        // txtBalance
        // 
        txtBalance.Location = new Point(159, 166);
        txtBalance.Margin = new Padding(3, 2, 3, 2);
        txtBalance.Name = "txtBalance";
        txtBalance.Size = new Size(110, 23);
        txtBalance.TabIndex = 10;
        txtBalance.Text = "0.00";
        // 
        // btnSave
        // 
        btnSave.Location = new Point(43, 218);
        btnSave.Margin = new Padding(3, 2, 3, 2);
        btnSave.Name = "btnSave";
        btnSave.Size = new Size(82, 22);
        btnSave.TabIndex = 11;
        btnSave.Text = "Save";
        btnSave.UseVisualStyleBackColor = true;
        // 
        // btnClear
        // 
        btnClear.Location = new Point(143, 218);
        btnClear.Margin = new Padding(3, 2, 3, 2);
        btnClear.Name = "btnClear";
        btnClear.Size = new Size(82, 22);
        btnClear.TabIndex = 12;
        btnClear.Text = "Clear";
        btnClear.UseVisualStyleBackColor = true;
        // 
        // btnBack
        // 
        btnBack.Location = new Point(250, 218);
        btnBack.Margin = new Padding(3, 2, 3, 2);
        btnBack.Name = "btnBack";
        btnBack.Size = new Size(82, 22);
        btnBack.TabIndex = 13;
        btnBack.Text = "Back";
        btnBack.UseVisualStyleBackColor = true;
        // 
        // AddCustomerForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(378, 280);
        Controls.Add(btnBack);
        Controls.Add(btnClear);
        Controls.Add(btnSave);
        Controls.Add(txtBalance);
        Controls.Add(lblBalance);
        Controls.Add(lblEmail);
        Controls.Add(txtEmail);
        Controls.Add(txtContact);
        Controls.Add(lblContact);
        Controls.Add(txtAddress);
        Controls.Add(lblAddress);
        Controls.Add(txtFullName);
        Controls.Add(lblFullName);
        Controls.Add(lblTitle);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        Margin = new Padding(3, 2, 3, 2);
        MaximizeBox = false;
        Name = "AddCustomerForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Billing System - Add Customer (L.M.P)";
        ResumeLayout(false);
        PerformLayout();
    }
}
