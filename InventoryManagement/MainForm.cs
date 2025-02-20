namespace InventoryManagement;

using System.Data;
using InventoryManagement.Database;
//using Telerik.WinControls.UI;


public partial class MainForm : Form
{
     private string currentUsername;
    private string userRole;
   public MainForm(string username, string role)
        {
           
            InitializeComponent();
            
            currentUsername = username;
            userRole = role;
            lblWelcome.Text = $"Welcome, {username} ({role})";

            if (role == "Viewer")
            {
                btnAddProduct.Enabled = false;
                btnUpdateProduct.Enabled = false;
                btnDeleteProduct.Enabled = false;
                btnAuditLogs.Enabled=false;
            }
            LoadProducts();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
       }
        private void LoadProducts(string productName = "", string category = "", string stockStatus = "")
        {
             DataTable products = DatabaseHelper.GetFilteredProducts(productName, category, stockStatus);
            //telerikGrid.DataSource = products;
            if (products == null || products.Rows.Count == 0)
            {
                // Create empty table with the same structure
                products = new DataTable();
                products.Columns.Add("ProductID", typeof(int));
                products.Columns.Add("ProductName", typeof(string));
                products.Columns.Add("ProductCategory", typeof(string));
                products.Columns.Add("Description", typeof(string));
                products.Columns.Add("QuantityInStock", typeof(int));
                products.Columns.Add("Price", typeof(decimal));
                products.Columns.Add("SupplierName", typeof(string));
                products.Columns.Add("StockStatus", typeof(string));
            }

            productGrid.DataSource = products;

            if (productGrid.Columns["IsDeleted"] != null)
            {
                productGrid.Columns["IsDeleted"].Visible = false;
            }
             if (productGrid.Columns["ProductID"] != null)
            {
                productGrid.Columns["ProductID"].Visible = false;
            }
           if (cmbCategoryFilter.Items.Count == 0)
            {
                cmbCategoryFilter.Items.Add("All");

                List<string> categories = DatabaseHelper.GetDistinctCategories(); // Fetch from DB
                foreach (string categoryName in categories)
                {
                    cmbCategoryFilter.Items.Add(categoryName);
                }

                cmbCategoryFilter.SelectedIndex = 0;
            }
        }
        
        private void btnClearFilters_Click(object sender, EventArgs e)
            {
                txtSearch.Clear();
                cmbCategoryFilter.SelectedIndex = 0;
                cmbStockFilter.SelectedIndex = 0;
                
                LoadProducts();
            }
        private void cmbStockFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.Trim();
            string category = cmbCategoryFilter.SelectedItem?.ToString();
            string stockStatus = cmbStockFilter.SelectedItem?.ToString();
            
            LoadProducts(searchText, category, stockStatus);
        }
        private void cmbCategoryFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.Trim();
            string category = cmbCategoryFilter.SelectedItem?.ToString();
            string stockStatus = cmbStockFilter.SelectedItem?.ToString();
            
            LoadProducts(searchText, category, stockStatus);
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.Trim();
            string category = cmbCategoryFilter.SelectedItem?.ToString();
            string stockStatus = cmbStockFilter.SelectedItem?.ToString();
            
            LoadProducts(searchText, category, stockStatus);
        }
        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            AddProductForm addForm = new AddProductForm(currentUsername);
            addForm.FormClosed += (s, args) => LoadProducts(); // Reload products after closing
            addForm.ShowDialog();
        }
        private void btnDeleteProduct_Click(object sender, EventArgs e)
        {
            if (productGrid.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a product to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int productId = Convert.ToInt32(productGrid.SelectedRows[0].Cells["ProductID"].Value);
            
            if (userRole != "Admin") // Prevent non-admin users from deleting
            {
                MessageBox.Show("You don't have permission to delete products.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = MessageBox.Show("Are you sure you want to delete this product?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                DatabaseHelper.SoftDeleteProduct(productId, currentUsername);
                MessageBox.Show("Product deleted successfully!", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadProducts();
            }
        }
        private void btnUpdateProduct_Click(object sender, EventArgs e)
        {
            if (productGrid.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a product to update.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataGridViewRow selectedRow = productGrid.SelectedRows[0];

            int productId = Convert.ToInt32(selectedRow.Cells["ProductID"].Value);
            string productName = selectedRow.Cells["ProductName"].Value.ToString();
            string category = selectedRow.Cells["ProductCategory"].Value.ToString();
            string description = selectedRow.Cells["Description"].Value.ToString();
            int quantity = Convert.ToInt32(selectedRow.Cells["QuantityInStock"].Value);
            decimal price = Convert.ToDecimal(selectedRow.Cells["Price"].Value);
            string supplier = selectedRow.Cells["SupplierName"].Value.ToString();

            UpdateProductForm updateForm = new UpdateProductForm(productId, productName, category, description, quantity, price, supplier, currentUsername);
            updateForm.ShowDialog();

            LoadProducts(); // Refresh data after updating
        }
        private void btnAuditLogs_Click(object sender, EventArgs e)
        {
            AuditLogsForm logsForm = new AuditLogsForm();
            logsForm.ShowDialog();
        }
        private void BtnViewReport_Click(object sender, EventArgs e)
        {
            ReportForm reportForm = new ReportForm();
            reportForm.ShowDialog(); // Opens the Report Form
        }
}
