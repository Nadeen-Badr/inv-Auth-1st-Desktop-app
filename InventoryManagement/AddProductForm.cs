using System;
using System.Windows.Forms;
using InventoryManagement.Database;

namespace InventoryManagement
{
    public partial class AddProductForm : Form
    {
        private string username;

        public AddProductForm(string loggedInUser)
        {
            InitializeComponent();
            this.username = loggedInUser;
        }

       private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string productName = txtProductName.Text.Trim();
                string category = txtCategory.Text.Trim();
                string description = txtDescription.Text.Trim();
                int quantity = int.TryParse(txtQuantity.Text, out int q) ? q : 0;
                decimal price = decimal.TryParse(txtPrice.Text, out decimal p) ? p : 0;
                string supplier = txtSupplier.Text.Trim();

                if (string.IsNullOrEmpty(productName) || string.IsNullOrEmpty(category) || quantity <= 0 || price <= 0)
                {
                    MessageBox.Show("Please fill all fields correctly.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DatabaseHelper.AddProduct(productName, category, description, quantity, price, supplier, username);
                MessageBox.Show("Product added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
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
