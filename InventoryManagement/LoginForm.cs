using System;
using System.Windows.Forms;
using InventoryManagement.Database;

namespace InventoryManagement
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both username and password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (DatabaseHelper.ValidateLogin(username, password))
            {
                string role = DatabaseHelper.GetUserRole(username);
                MessageBox.Show($"Login successful! Welcome, {username}.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                MainForm mainForm = new MainForm(username, role);
                this.Hide();
                mainForm.Show();
            }
            else
            {
                lblError.Text = "Invalid username or password!";
                lblError.Visible = true;
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            this.Hide();
            RegisterForm registerForm = new RegisterForm();
            registerForm.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
