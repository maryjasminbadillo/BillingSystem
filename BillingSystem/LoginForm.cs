using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace BillingSystem;

public class LoginForm : Form
{
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

	private void InitializeComponent()
	{
		this.lblTitle = new System.Windows.Forms.Label();
		this.lblUsername = new System.Windows.Forms.Label();
		this.txtUsername = new System.Windows.Forms.TextBox();
		this.lblPassword = new System.Windows.Forms.Label();
		this.txtPassword = new System.Windows.Forms.TextBox();
		this.btnLogin = new System.Windows.Forms.Button();
		this.btnCancel = new System.Windows.Forms.Button();
		base.SuspendLayout();
		this.lblTitle.AccessibleName = "";
		this.lblTitle.AutoSize = true;
		this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 13.8f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.lblTitle.Location = new System.Drawing.Point(91, 22);
		this.lblTitle.Name = "lblTitle";
		this.lblTitle.Size = new System.Drawing.Size(194, 31);
		this.lblTitle.TabIndex = 0;
		this.lblTitle.Text = "BILLING SYSTEM";
		this.lblUsername.AutoSize = true;
		this.lblUsername.Location = new System.Drawing.Point(7, 86);
		this.lblUsername.Name = "lblUsername";
		this.lblUsername.Size = new System.Drawing.Size(78, 20);
		this.lblUsername.TabIndex = 1;
		this.lblUsername.Text = "Username:";
		this.lblUsername.Click += new System.EventHandler(lblUsername_Click);
		this.txtUsername.Location = new System.Drawing.Point(99, 79);
		this.txtUsername.Name = "txtUsername";
		this.txtUsername.Size = new System.Drawing.Size(125, 27);
		this.txtUsername.TabIndex = 2;
		this.lblPassword.AutoSize = true;
		this.lblPassword.Location = new System.Drawing.Point(7, 137);
		this.lblPassword.Name = "lblPassword";
		this.lblPassword.Size = new System.Drawing.Size(73, 20);
		this.lblPassword.TabIndex = 3;
		this.lblPassword.Text = "Password:";
		this.txtPassword.Location = new System.Drawing.Point(96, 137);
		this.txtPassword.Name = "txtPassword";
		this.txtPassword.PasswordChar = '*';
		this.txtPassword.Size = new System.Drawing.Size(125, 27);
		this.txtPassword.TabIndex = 5;
		this.btnLogin.Location = new System.Drawing.Point(69, 198);
		this.btnLogin.Name = "btnLogin";
		this.btnLogin.Size = new System.Drawing.Size(94, 29);
		this.btnLogin.TabIndex = 6;
		this.btnLogin.Text = "Login";
		this.btnLogin.UseVisualStyleBackColor = true;
		this.btnCancel.Location = new System.Drawing.Point(202, 198);
		this.btnCancel.Name = "btnCancel";
		this.btnCancel.Size = new System.Drawing.Size(94, 29);
		this.btnCancel.TabIndex = 7;
		this.btnCancel.Text = "Cancel";
		this.btnCancel.UseVisualStyleBackColor = true;
		base.AutoScaleDimensions = new System.Drawing.SizeF(8f, 20f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(382, 253);
		base.Controls.Add(this.btnCancel);
		base.Controls.Add(this.btnLogin);
		base.Controls.Add(this.txtPassword);
		base.Controls.Add(this.lblPassword);
		base.Controls.Add(this.txtUsername);
		base.Controls.Add(this.lblUsername);
		base.Controls.Add(this.lblTitle);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
		base.MinimizeBox = false;
		base.Name = "LoginForm";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Billing System - Login";
		base.Load += new System.EventHandler(LoginForm_Load);
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
