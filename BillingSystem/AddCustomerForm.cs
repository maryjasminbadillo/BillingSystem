using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using BillingSystem.Database;  

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
        lblTitle.Location = new Point(97, 23);
        lblTitle.Name = "lblTitle";
        lblTitle.Size = new Size(201, 28);
        lblTitle.TabIndex = 0;
        lblTitle.Text = "Add New Customer ";
        // 
        // lblFullName
        // 
        lblFullName.AutoSize = true;
        lblFullName.Location = new Point(38, 76);
        lblFullName.Name = "lblFullName";
        lblFullName.Size = new Size(79, 20);
        lblFullName.TabIndex = 1;
        lblFullName.Text = "Full Name:";
        // 
        // txtFullName
        // 
        txtFullName.Location = new Point(182, 73);
        txtFullName.Name = "txtFullName";
        txtFullName.Size = new Size(125, 27);
        txtFullName.TabIndex = 2;
        // 
        // lblAddress
        // 
        lblAddress.AutoSize = true;
        lblAddress.Location = new Point(38, 114);
        lblAddress.Name = "lblAddress";
        lblAddress.Size = new Size(65, 20);
        lblAddress.TabIndex = 3;
        lblAddress.Text = "Address:";
        // 
        // txtAddress
        // 
        txtAddress.Location = new Point(182, 111);
        txtAddress.Name = "txtAddress";
        txtAddress.Size = new Size(125, 27);
        txtAddress.TabIndex = 4;
        // 
        // lblContact
        // 
        lblContact.AutoSize = true;
        lblContact.Location = new Point(38, 153);
        lblContact.Name = "lblContact";
        lblContact.Size = new Size(121, 20);
        lblContact.TabIndex = 5;
        lblContact.Text = "Contact Number:";
        // 
        // txtContact
        // 
        txtContact.Location = new Point(182, 150);
        txtContact.Name = "txtContact";
        txtContact.Size = new Size(125, 27);
        txtContact.TabIndex = 6;
        // 
        // txtEmail
        // 
        txtEmail.Location = new Point(182, 186);
        txtEmail.Name = "txtEmail";
        txtEmail.Size = new Size(125, 27);
        txtEmail.TabIndex = 7;
        txtEmail.TextChanged += textBox1_TextChanged;
        // 
        // lblEmail
        // 
        lblEmail.AutoSize = true;
        lblEmail.Location = new Point(38, 189);
        lblEmail.Name = "lblEmail";
        lblEmail.Size = new Size(49, 20);
        lblEmail.TabIndex = 8;
        lblEmail.Text = "Email:";
        // 
        // lblBalance
        // 
        lblBalance.AutoSize = true;
        lblBalance.Location = new Point(38, 224);
        lblBalance.Name = "lblBalance";
        lblBalance.Size = new Size(105, 20);
        lblBalance.TabIndex = 9;
        lblBalance.Text = "Initial Balance:";
        // 
        // txtBalance
        // 
        txtBalance.Location = new Point(182, 222);
        txtBalance.Name = "txtBalance";
        txtBalance.Size = new Size(125, 27);
        txtBalance.TabIndex = 10;
        txtBalance.Text = "0.00";
        // 
        // btnSave
        // 
        btnSave.Location = new Point(49, 291);
        btnSave.Name = "btnSave";
        btnSave.Size = new Size(94, 29);
        btnSave.TabIndex = 11;
        btnSave.Text = "Save";
        btnSave.UseVisualStyleBackColor = true;
        btnSave.Click += btnSave_Click;
        // 
        // btnClear
        // 
        btnClear.Location = new Point(163, 291);
        btnClear.Name = "btnClear";
        btnClear.Size = new Size(94, 29);
        btnClear.TabIndex = 12;
        btnClear.Text = "Clear";
        btnClear.UseVisualStyleBackColor = true;
        // 
        // btnBack
        // 
        btnBack.Location = new Point(286, 291);
        btnBack.Name = "btnBack";
        btnBack.Size = new Size(94, 29);
        btnBack.TabIndex = 13;
        btnBack.Text = "Back";
        btnBack.UseVisualStyleBackColor = true;
        // 
        // AddCustomerForm
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(432, 373);
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
        MaximizeBox = false;
        Name = "AddCustomerForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Billing System - Add Customer";
        ResumeLayout(false);
        PerformLayout();
    }
    private bool ValidateInputs()
    {
        // Check Full Name
        if (string.IsNullOrWhiteSpace(txtFullName.Text))
        {
            MessageBox.Show("Full Name is required.", "Validation",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtFullName.Focus();
            return false;
        }

        // Check Address
        if (string.IsNullOrWhiteSpace(txtAddress.Text))
        {
            MessageBox.Show("Address is required.", "Validation",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtAddress.Focus();
            return false;
        }

        // Check Contact Number
        if (string.IsNullOrWhiteSpace(txtContact.Text))
        {
            MessageBox.Show("Contact Number is required.", "Validation",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtContact.Focus();
            return false;
        }

        // Check Email
        if (string.IsNullOrWhiteSpace(txtEmail.Text))
        {
            MessageBox.Show("Email is required.", "Validation",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtEmail.Focus();
            return false;
        }

        // Check Balance is a valid number
        if (!decimal.TryParse(txtBalance.Text, out _))
        {
            MessageBox.Show("Initial Balance must be a valid number (e.g. 0.00).",
                "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtBalance.Focus();
            return false;
        }

        return true;
    }
    private void ClearFields()
    {
        txtFullName.Clear();
        txtAddress.Clear();
        txtContact.Clear();
        txtEmail.Clear();
        txtBalance.Text = "0.00";
        txtFullName.Focus();
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
        // Step 1: Validate input before touching the database
        if (!ValidateInputs()) return;

        try
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();

                // Parameterized INSERT — safe from SQL injection
                string sql = @"INSERT INTO Customers
                               (FullName, Address, ContactNumber, Email, Balance, Status)
                           VALUES
                               (@FullName, @Address, @ContactNumber, @Email, @Balance, @Status);";

                using (var cmd = new MySqlCommand(sql, conn))
                {
                    // Each @parameter safely carries one value from the form
                    cmd.Parameters.AddWithValue("@FullName", txtFullName.Text.Trim());
                    cmd.Parameters.AddWithValue("@Address", txtAddress.Text.Trim());
                    cmd.Parameters.AddWithValue("@ContactNumber", txtContact.Text.Trim());
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                    cmd.Parameters.AddWithValue("@Balance", decimal.Parse(txtBalance.Text));
                    cmd.Parameters.AddWithValue("@Status", "Active");

                    // ExecuteNonQuery runs INSERT/UPDATE/DELETE and
                    // returns the number of rows affected
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Customer saved successfully.",
                            "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        ClearFields();
                    }
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error saving customer:\n{ex.Message}",
                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

    }
}
