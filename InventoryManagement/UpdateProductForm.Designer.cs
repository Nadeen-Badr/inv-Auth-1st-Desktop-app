using System.Windows.Forms;

namespace InventoryManagement
{
    partial class UpdateProductForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblProductName, lblCategory, lblDescription, lblQuantity, lblPrice, lblSupplier;
        private System.Windows.Forms.TextBox txtProductName, txtDescription, txtQuantity, txtPrice, txtSupplier;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.Button btnSave, btnCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 400);
            this.Text = "Update Product";

            // Labels
            lblProductName = new Label { Text = "Product Name:", Location = new System.Drawing.Point(20, 20) };
            lblCategory = new Label { Text = "Category:", Location = new System.Drawing.Point(20, 60) };
            lblDescription = new Label { Text = "Description:", Location = new System.Drawing.Point(20, 100) };
            lblQuantity = new Label { Text = "Quantity:", Location = new System.Drawing.Point(20, 140) };
            lblPrice = new Label { Text = "Price:", Location = new System.Drawing.Point(20, 180) };
            lblSupplier = new Label { Text = "Supplier:", Location = new System.Drawing.Point(20, 220) };

            // TextBoxes
            txtProductName = new TextBox { Location = new System.Drawing.Point(150, 20), Width = 200 };
            txtDescription = new TextBox { Location = new System.Drawing.Point(150, 100), Width = 200 };
            txtQuantity = new TextBox { Location = new System.Drawing.Point(150, 140), Width = 200 };
            txtPrice = new TextBox { Location = new System.Drawing.Point(150, 180), Width = 200 };
            txtSupplier = new TextBox { Location = new System.Drawing.Point(150, 220), Width = 200 };

            // Category Dropdown
            cmbCategory = new ComboBox { Location = new System.Drawing.Point(150, 60), Width = 200, DropDownStyle = ComboBoxStyle.DropDownList };

            // Buttons
            btnSave = new Button { Text = "Save", Location = new System.Drawing.Point(50, 300), Width = 100 };
            btnCancel = new Button { Text = "Cancel", Location = new System.Drawing.Point(200, 300), Width = 100 };
            btnSave.Click += new System.EventHandler(this.btnSave_Click);
            btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // Add controls to form
            this.Controls.Add(lblProductName);
            this.Controls.Add(lblCategory);
            this.Controls.Add(lblDescription);
            this.Controls.Add(lblQuantity);
            this.Controls.Add(lblPrice);
            this.Controls.Add(lblSupplier);
            this.Controls.Add(txtProductName);
            this.Controls.Add(txtDescription);
            this.Controls.Add(txtQuantity);
            this.Controls.Add(txtPrice);
            this.Controls.Add(txtSupplier);
            this.Controls.Add(cmbCategory);
            this.Controls.Add(btnSave);
            this.Controls.Add(btnCancel);
        }

        #endregion
    }
}
