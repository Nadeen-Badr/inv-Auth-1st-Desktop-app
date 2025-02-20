using System;
using System.Collections.Generic;
using System.Windows.Forms;
using InventoryManagement.Database;

namespace InventoryManagement
{
    public partial class UpdateProductForm : Form
    {
        private int productId;
        private string username;

        public UpdateProductForm(int productId, string productName, string category, string description, int quantity, decimal price, string supplier, string username)
        {
            InitializeComponent();
            this.productId = productId;
            this.username = username;

            // Pre-fill fields
            txtProductName.Text = productName;
            txtDescription.Text = description;
            txtQuantity.Text = quantity.ToString();
            txtPrice.Text = price.ToString();
            txtSupplier.Text = supplier;

            // Load categories
            LoadCategories(category);
        }

        private void LoadCategories(string selectedCategory)
        {
            cmbCategory.Items.Clear();
            cmbCategory.Items.Add("Select Category");

            List<string> categories = DatabaseHelper.GetDistinctCategories();
            foreach (string cat in categories)
            {
                cmbCategory.Items.Add(cat);
            }

            cmbCategory.SelectedItem = selectedCategory ?? "Select Category";
        }

        private void btnSave_Click(object sender, EventArgs e)
{
    try
    {
        string productName = txtProductName.Text.Trim();
        string category = cmbCategory.SelectedItem?.ToString();
        string description = txtDescription.Text.Trim();
        int quantity = int.TryParse(txtQuantity.Text, out int q) ? q : 0;
        decimal price = decimal.TryParse(txtPrice.Text, out decimal p) ? p : 0;
        string supplier = txtSupplier.Text.Trim();

        if (string.IsNullOrEmpty(productName) || category == "Select Category" || quantity <= 0 || price <= 0)
        {
            MessageBox.Show("Please fill all fields correctly.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        // Try updating product & check for duplicate error
        bool updateSuccess = DatabaseHelper.UpdateProduct(productId, productName, category, description, quantity, price, supplier, username);

        if (updateSuccess)
        {
            MessageBox.Show("Product updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
    catch (Exception ex)
    {
        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
