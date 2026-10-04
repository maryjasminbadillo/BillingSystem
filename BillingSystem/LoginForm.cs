using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using BillingSystem.Database;

namespace BillingSystem;

public class LoginForm : Form
{
 feature/customerlist-badillo
    private IContainer components = null;

    private Label lblTitle;

    private Label lblUsername;

    private TextBox txtUsername;

    private Label lblPassword;

    private TextBox txtPassword;

    private Button btnLogin;

    private Button btnCancel;

    public LoginForm()
    {
        InitializeComponent();
    }

    private void LoginForm_Load(object sender, EventArgs e)
    {
        // Test the database connection when the form opens.
        // This gives a clear warning if MySQL is not running.
        if (!DatabaseConnection.TestConnection())
        {
            MessageBox.Show(
                "Cannot connect to the database.\n\n" +
                "Please make sure:\n" +
                "  1. MySQL Server is running.\n" +
                "  2. BillingDB database exists.\n" +
                "  3. The password in DatabaseConnection.cs is correct.",
                "Database Connection Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
        
        txtUsername.Focus();
    }

    private void lblUsername_Click(object sender, EventArgs e)
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

	private IContainer components = null;

	private Label lblTitle;

	private Label lblUsername;

	private TextBox txtUsername;

	private Label lblPassword;

	private TextBox txtPassword;

	private Button btnLogin;

	private Button btnCancel;

	public LoginForm()
	{
		InitializeComponent();
	}

	private void LoginForm_Load(object sender, EventArgs e)
	{
	}

	private void lblUsername_Click(object sender, EventArgs e)
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
 main

    private void InitializeComponent()
    {
        lblTitle = new Label();
        lblUsername = new Label();
        txtUsername = new TextBox();
        lblPassword = new Label();
        txtPassword = new TextBox();
        btnLogin = new Button();
        btnCancel = new Button();
        SuspendLayout();
        // 
        // lblTitle
        // 
        lblTitle.AccessibleName = "";
        lblTitle.AutoSize = true;
        lblTitle.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
        lblTitle.Location = new Point(91, 22);
        lblTitle.Name = "lblTitle";
        lblTitle.Size = new Size(194, 31);
        lblTitle.TabIndex = 0;
        lblTitle.Text = "BILLING SYSTEM";
        // 
        // lblUsername
        // 
        lblUsername.AutoSize = true;
        lblUsername.Location = new Point(7, 86);
        lblUsername.Name = "lblUsername";
        lblUsername.Size = new Size(78, 20);
        lblUsername.TabIndex = 1;
        lblUsername.Text = "Username:";
        lblUsername.Click += lblUsername_Click;
        // 
        // txtUsername
        // 
        txtUsername.Location = new Point(99, 79);
        txtUsername.Name = "txtUsername";
        txtUsername.Size = new Size(125, 27);
        txtUsername.TabIndex = 2;
        // 
        // lblPassword
        // 
        lblPassword.AutoSize = true;
        lblPassword.Location = new Point(7, 137);
        lblPassword.Name = "lblPassword";
        lblPassword.Size = new Size(73, 20);
        lblPassword.TabIndex = 3;
        lblPassword.Text = "Password:";
        // 
        // txtPassword
        // 
        txtPassword.Location = new Point(96, 137);
        txtPassword.Name = "txtPassword";
        txtPassword.PasswordChar = '*';
        txtPassword.Size = new Size(125, 27);
        txtPassword.TabIndex = 5;
        // 
        // btnLogin
        // 
        btnLogin.Location = new Point(69, 198);
        btnLogin.Name = "btnLogin";
        btnLogin.Size = new Size(94, 29);
        btnLogin.TabIndex = 6;
        btnLogin.Text = "Login";
        btnLogin.UseVisualStyleBackColor = true;
 feature/customerlist-badillo
        btnLogin.Click += btnLogin_Click;

 main
        // 
        // btnCancel
        // 
        btnCancel.Location = new Point(202, 198);
        btnCancel.Name = "btnCancel";
        btnCancel.Size = new Size(94, 29);
        btnCancel.TabIndex = 7;
        btnCancel.Text = "Cancel";
        btnCancel.UseVisualStyleBackColor = true;
        // 
        // LoginForm
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(382, 253);
        Controls.Add(btnCancel);
        Controls.Add(btnLogin);
        Controls.Add(txtPassword);
        Controls.Add(lblPassword);
        Controls.Add(txtUsername);
        Controls.Add(lblUsername);
        Controls.Add(lblTitle);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MinimizeBox = false;
        Name = "LoginForm";
        StartPosition = FormStartPosition.CenterScreen;
 feature/customerlist-badillo
        Text = "Billing System - Login";

        Text = "Billing System v1.0 – Login (J.B.)";
 main
        Load += LoginForm_Load;
        ResumeLayout(false);
        PerformLayout();
    }
 feature/customerlist-badillo

    private void btnLogin_Click(object sender, EventArgs e)
    {
        // Step 1: Make sure both fields are filled
        if (string.IsNullOrWhiteSpace(txtUsername.Text))
        {
            MessageBox.Show("Please enter your username.",
                "Login", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtUsername.Focus();
            return;
        }

        if (string.IsNullOrWhiteSpace(txtPassword.Text))
        {
            MessageBox.Show("Please enter your password.",
                "Login", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtPassword.Focus();
            return;
        }

        // Step 2: Query the Users table to check credentials
        try
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();

                // Parameterized query — safe from SQL injection
                string sql = @"SELECT UserID, FullName, Role
                           FROM   Users
                           WHERE  Username = @Username
                             AND  Password = @Password;";

                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Username", txtUsername.Text.Trim());
                    cmd.Parameters.AddWithValue("@Password", txtPassword.Text);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Credentials matched — open the Customer List form
                            CustomerListForm listForm = new CustomerListForm();
                            listForm.Show();
                            this.Hide();
                        }
                        else
                        {
                            // No match found — wrong credentials
                            MessageBox.Show(
                                "Invalid username or password.\nPlease try again.",
                                "Login Failed",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                            txtPassword.Clear();
                            txtPassword.Focus();
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            // Show an error if the database cannot be reached
            MessageBox.Show(
                "Database error:\n" + ex.Message,
                "Connection Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }



 main
}
