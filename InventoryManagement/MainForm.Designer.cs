// using Telerik.WinControls.UI;
using System.Windows.Forms;
// using Telerik.WinControls;
using System.Windows.Forms;

namespace InventoryManagement
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Button btnAddProduct;
        private System.Windows.Forms.Button btnUpdateProduct;
        private System.Windows.Forms.Button btnDeleteProduct;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.DataGridView productGrid;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnClearFilters;
        private System.Windows.Forms.Label lblCategoryFilter;
        private System.Windows.Forms.ComboBox cmbCategoryFilter;
        private System.Windows.Forms.Label lblStockFilter;
        private System.Windows.Forms.ComboBox cmbStockFilter;
        private System.Windows.Forms.Button btnAuditLogs;
        private System.Windows.Forms.Button btnreport;


        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(850, 600);
            this.Text = "Inventory Management";

            // Initialize UI Components
            this.lblWelcome = new System.Windows.Forms.Label();
            this.btnAddProduct = new System.Windows.Forms.Button();
            this.btnUpdateProduct = new System.Windows.Forms.Button();
            this.btnDeleteProduct = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.productGrid = new System.Windows.Forms.DataGridView();
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnClearFilters = new System.Windows.Forms.Button();
            this.lblCategoryFilter = new System.Windows.Forms.Label();
            this.cmbCategoryFilter = new System.Windows.Forms.ComboBox();
            this.lblStockFilter = new System.Windows.Forms.Label();
            this.cmbStockFilter = new System.Windows.Forms.ComboBox();

            // Configure Welcome Label
            this.lblWelcome.Text = "Welcome, User";
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.lblWelcome.Location = new System.Drawing.Point(20, 20);

            // Configure Buttons
            int buttonWidth = 150;
            int buttonHeight = 40;
            int buttonSpacing = 15;
            int buttonStartX = 20;
            int buttonStartY = 70;

            this.btnAddProduct.Text = "Add Product";
            this.btnAddProduct.Size = new System.Drawing.Size(buttonWidth, buttonHeight);
            this.btnAddProduct.Location = new System.Drawing.Point(buttonStartX, buttonStartY);
            this.btnAddProduct.Click += new System.EventHandler(this.btnAddProduct_Click);

            this.btnUpdateProduct.Text = "Update Product";
            this.btnUpdateProduct.Size = new System.Drawing.Size(buttonWidth, buttonHeight);
            this.btnUpdateProduct.Location = new System.Drawing.Point(buttonStartX, buttonStartY + buttonHeight + buttonSpacing);
            this.btnUpdateProduct.Click += new System.EventHandler(this.btnUpdateProduct_Click);

            this.btnDeleteProduct.Text = "Delete Product";
            this.btnDeleteProduct.Size = new System.Drawing.Size(buttonWidth, buttonHeight);
            this.btnDeleteProduct.Location = new System.Drawing.Point(buttonStartX, buttonStartY + 2 * (buttonHeight + buttonSpacing));
            this.btnDeleteProduct.Click += new System.EventHandler(this.btnDeleteProduct_Click);

            this.btnLogout.Text = "Logout";
            this.btnLogout.Size = new System.Drawing.Size(buttonWidth, buttonHeight);
            this.btnLogout.Location = new System.Drawing.Point(buttonStartX, buttonStartY + 3 * (buttonHeight + buttonSpacing));
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // Audit Logs Button
            this.btnAuditLogs = new System.Windows.Forms.Button();
            this.btnAuditLogs.Text = "View Audit Logs";
            this.btnAuditLogs.Size = new System.Drawing.Size(buttonWidth, buttonHeight);
            this.btnAuditLogs.Location = new System.Drawing.Point(buttonStartX, buttonStartY + 4* (buttonHeight + buttonSpacing));
            this.btnAuditLogs.Click += new System.EventHandler(this.btnAuditLogs_Click);
            this.btnreport = new System.Windows.Forms.Button();
            this.btnreport.Text = "View Crystal Report";
            this.btnreport.Size = new System.Drawing.Size(buttonWidth, buttonHeight);
            this.btnreport.Location = new System.Drawing.Point(buttonStartX, buttonStartY + 5* (buttonHeight + buttonSpacing));
            this.btnreport.Click += new System.EventHandler(this.BtnViewReport_Click);
          

            // Configure Search Label & TextBox
            this.lblSearch.Text = "Search:";
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(220, 20);

            this.txtSearch.Size = new System.Drawing.Size(200, 30);
            this.txtSearch.Location = new System.Drawing.Point(280, 15);

            // Configure Search Button
            this.btnSearch.Text = "Search";
            this.btnSearch.Size = new System.Drawing.Size(80, 30);
            this.btnSearch.Location = new System.Drawing.Point(500, 15);
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);

            // Configure Clear Filters Button
            this.btnClearFilters.Text = "Clear Filters";
            this.btnClearFilters.Size = new System.Drawing.Size(100, 30);
            this.btnClearFilters.Location = new System.Drawing.Point(600, 15);
            this.btnClearFilters.Click += new System.EventHandler(this.btnClearFilters_Click);

            // Configure Category Filter
            this.lblCategoryFilter.Text = "Category:";
            this.lblCategoryFilter.AutoSize = true;
            this.lblCategoryFilter.Location = new System.Drawing.Point(220, 60);

            this.cmbCategoryFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbCategoryFilter.Size = new System.Drawing.Size(150, 30);
            this.cmbCategoryFilter.Location = new System.Drawing.Point(300, 55);
            this.cmbCategoryFilter.SelectedIndexChanged += new System.EventHandler(this.cmbCategoryFilter_SelectedIndexChanged);

            // Configure Stock Status Filter
            this.lblStockFilter.Text = "Stock:";
            this.lblStockFilter.AutoSize = true;
            this.lblStockFilter.Location = new System.Drawing.Point(470, 60);

            this.cmbStockFilter.Items.AddRange(new object[] { "All", "In Stock", "Low Stock", "Out of Stock" });
            this.cmbStockFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbStockFilter.Size = new System.Drawing.Size(130, 30);
            this.cmbStockFilter.Location = new System.Drawing.Point(530, 55);
            this.cmbStockFilter.SelectedIndexChanged += new System.EventHandler(this.cmbStockFilter_SelectedIndexChanged);

            // Configure DataGridView (Products Table)
            this.productGrid.Size = new System.Drawing.Size(800, 400);
            this.productGrid.Location = new System.Drawing.Point(220, 100);
            this.productGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.productGrid.AllowUserToAddRows = false;
            this.productGrid.AllowUserToDeleteRows = false;
            this.productGrid.ReadOnly = true;

            // Add Controls to the Form
            this.Controls.Add(this.lblWelcome);
            this.Controls.Add(this.btnAddProduct);
            this.Controls.Add(this.btnUpdateProduct);
            this.Controls.Add(this.btnDeleteProduct);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnClearFilters);
            this.Controls.Add(this.lblCategoryFilter);
            this.Controls.Add(this.cmbCategoryFilter);
            this.Controls.Add(this.lblStockFilter);
            this.Controls.Add(this.cmbStockFilter);
            this.Controls.Add(this.productGrid);
            this.Controls.Add(this.btnAuditLogs);
            this.Controls.Add(this.btnreport);
        }

        #endregion
    }
}
