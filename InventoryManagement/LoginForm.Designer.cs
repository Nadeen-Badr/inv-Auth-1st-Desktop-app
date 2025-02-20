namespace InventoryManagement
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Panel panelContainer;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.Text = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ClientSize = new System.Drawing.Size(400, 250);

            // Panel to hold all components
            this.panelContainer = new System.Windows.Forms.Panel();
            this.panelContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContainer.Padding = new System.Windows.Forms.Padding(20);
            this.Controls.Add(this.panelContainer);

            // Username Label
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblUsername.Text = "Username:";
            this.lblUsername.Left = 50;
            this.lblUsername.Top = 30;

            // Username TextBox
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtUsername.Left = 150;
            this.txtUsername.Top = 25;
            this.txtUsername.Width = 200;

            // Password Label
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblPassword.Text = "Password:";
            this.lblPassword.Left = 50;
            this.lblPassword.Top = 70;

            // Password TextBox
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtPassword.Left = 150;
            this.txtPassword.Top = 65;
            this.txtPassword.Width = 200;
            this.txtPassword.PasswordChar = '*';

            // Error Label
            this.lblError = new System.Windows.Forms.Label();
            this.lblError.Text = "";
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Left = 50;
            this.lblError.Top = 100;
            this.lblError.AutoSize = true;
            this.lblError.Visible = false;

            // Login Button
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnLogin.Text = "Login";
            this.btnLogin.Left = 50;
            this.btnLogin.Top = 130;
            this.btnLogin.Width = 100;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);

            // Register Button
            this.btnRegister = new System.Windows.Forms.Button();
            this.btnRegister.Text = "Register";
            this.btnRegister.Left = 160;
            this.btnRegister.Top = 130;
            this.btnRegister.Width = 100;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);

            // Exit Button
            this.btnExit = new System.Windows.Forms.Button();
            this.btnExit.Text = "Exit";
            this.btnExit.Left = 270;
            this.btnExit.Top = 130;
            this.btnExit.Width = 100;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);

            // Add Components to Panel
            this.panelContainer.Controls.Add(lblUsername);
            this.panelContainer.Controls.Add(txtUsername);
            this.panelContainer.Controls.Add(lblPassword);
            this.panelContainer.Controls.Add(txtPassword);
            this.panelContainer.Controls.Add(lblError);
            this.panelContainer.Controls.Add(btnLogin);
            this.panelContainer.Controls.Add(btnRegister);
            this.panelContainer.Controls.Add(btnExit);
        }
    }
}
