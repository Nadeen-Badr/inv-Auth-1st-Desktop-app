using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using InventoryManagement.Database;

namespace InventoryManagement
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }
private bool IsValidPassword(string password)
{
    return password.Length >= 8 && password.Any(char.IsDigit);
}
  private void btnRegister_Click(object sender, EventArgs e)
    {
        string username = txtUsername.Text.Trim();
        string password = txtPassword.Text.Trim();
        string role = cmbRole.SelectedItem?.ToString() ?? "Viewer"; // Default to Viewer

        // Validate password before checking the database
        if (!IsValidPassword(password))
        {
            lblError.Text = "Password must be at least 8 characters long and include a number.";
            lblError.Visible = true;
            return;
        }

        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
        {
            lblError.Text = "Please fill in all fields.";
            lblError.Visible = true;
            return;
        }

        try
        {
            DatabaseHelper.RegisterUser(username, password, role);
            MessageBox.Show("Account created successfully! You can now log in.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            this.Hide();
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
        }
        catch (SqlException ex)
        {
            if (ex.Number == 2627) // SQL error code for duplicate key
            {
                lblError.Text = "Username already exists. Please choose a different one.";
                lblError.Visible = true;
            }
            else
            {
                MessageBox.Show("An error occurred while creating your account.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }


        private void btnBackToLogin_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
        }
    }
}
