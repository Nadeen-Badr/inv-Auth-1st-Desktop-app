namespace InventoryManagement
{
    partial class RegisterForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.ComboBox cmbRole;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Button btnBackToLogin;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Panel panelContainer;
        private System.Windows.Forms.Label lblPasswordRequirements;

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
            this.Text = "Register";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ClientSize = new System.Drawing.Size(400, 280);

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
            // Password Requirements Label
            this.lblPasswordRequirements = new System.Windows.Forms.Label();
            this.lblPasswordRequirements.Text = "Password must be at least 8 characters and contain a number.";
            this.lblPasswordRequirements.ForeColor = System.Drawing.Color.Gray;
            this.lblPasswordRequirements.Left = 50;
            this.lblPasswordRequirements.Top = 90;
            this.lblPasswordRequirements.AutoSize = true;

            // Add to Panel
            this.panelContainer.Controls.Add(lblPasswordRequirements);

            // Role Label
            this.lblRole = new System.Windows.Forms.Label();
            this.lblRole.Text = "Role:";
            this.lblRole.Left = 50;
            this.lblRole.Top = 110;

            // Role ComboBox
            this.cmbRole = new System.Windows.Forms.ComboBox();
            this.cmbRole.Left = 150;
            this.cmbRole.Top = 105;
            this.cmbRole.Width = 200;
            this.cmbRole.Items.AddRange(new string[] { "Admin", "Viewer" });
            this.cmbRole.SelectedIndex = 1; // Default to Viewer

            // Error Label
            this.lblError = new System.Windows.Forms.Label();
            this.lblError.Text = "";
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Left = 50;
            this.lblError.Top = 140;
            this.lblError.AutoSize = true;
            this.lblError.Visible = false;

            // Register Button
            this.btnRegister = new System.Windows.Forms.Button();
            this.btnRegister.Text = "Register";
            this.btnRegister.Left = 50;
            this.btnRegister.Top = 170;
            this.btnRegister.Width = 100;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);

            // Back to Login Button
            this.btnBackToLogin = new System.Windows.Forms.Button();
            this.btnBackToLogin.Text = "Back to Login";
            this.btnBackToLogin.Left = 160;
            this.btnBackToLogin.Top = 170;
            this.btnBackToLogin.Width = 120;
            this.btnBackToLogin.Click += new System.EventHandler(this.btnBackToLogin_Click);

            // Add Components to Panel
            this.panelContainer.Controls.Add(lblUsername);
            this.panelContainer.Controls.Add(txtUsername);
            this.panelContainer.Controls.Add(lblPassword);
            this.panelContainer.Controls.Add(txtPassword);
            this.panelContainer.Controls.Add(lblRole);
            this.panelContainer.Controls.Add(cmbRole);
            this.panelContainer.Controls.Add(lblError);
            this.panelContainer.Controls.Add(btnRegister);
            this.panelContainer.Controls.Add(btnBackToLogin);
        }
    }
}
