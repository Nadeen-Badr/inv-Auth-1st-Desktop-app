using System.Windows.Forms;

namespace InventoryManagement
{
    partial class AddProductForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblProductName, lblCategory, lblDescription, lblQuantity, lblPrice, lblSupplier;
        private TextBox txtProductName, txtDescription, txtQuantity, txtPrice, txtSupplier ,txtCategory;
        private ComboBox cmbCategory;
        private Button btnSave, btnCancel;

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
            this.lblProductName = new Label();
            this.lblCategory = new Label();
            this.lblDescription = new Label();
            this.lblQuantity = new Label();
            this.lblPrice = new Label();
            this.lblSupplier = new Label();

            this.txtProductName = new TextBox();
            this.txtCategory = new TextBox(); 
            this.txtDescription = new TextBox();
            this.txtQuantity = new TextBox();
            this.txtPrice = new TextBox();
            this.txtSupplier = new TextBox();

            this.btnSave = new Button();
            this.btnCancel = new Button();

            // Labels
            lblProductName.Text = "Product Name:";
            lblCategory.Text = "Category:";
            lblDescription.Text = "Description:";
            lblQuantity.Text = "Quantity:";
            lblPrice.Text = "Price:";
            lblSupplier.Text = "Supplier:";

            lblProductName.Location = new System.Drawing.Point(20, 20);
            lblCategory.Location = new System.Drawing.Point(20, 60);
            lblDescription.Location = new System.Drawing.Point(20, 100);
            lblQuantity.Location = new System.Drawing.Point(20, 140);
            lblPrice.Location = new System.Drawing.Point(20, 180);
            lblSupplier.Location = new System.Drawing.Point(20, 220);

            // Inputs
            txtProductName.Location = new System.Drawing.Point(120, 20);
             txtCategory.Location = new System.Drawing.Point(120, 60);
            txtDescription.Location = new System.Drawing.Point(120, 100);
            txtQuantity.Location = new System.Drawing.Point(120, 140);
            txtPrice.Location = new System.Drawing.Point(120, 180);
            txtSupplier.Location = new System.Drawing.Point(120, 220);

            // Buttons
            btnSave.Text = "Save";
            btnCancel.Text = "Cancel";

            btnSave.Location = new System.Drawing.Point(50, 260);
            btnCancel.Location = new System.Drawing.Point(150, 260);

            btnSave.Click += new System.EventHandler(this.btnSave_Click);
            btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            // Add Controls
            this.Controls.Add(lblProductName);
            this.Controls.Add(txtProductName);
            this.Controls.Add(lblCategory);
             this.Controls.Add(txtCategory);
            this.Controls.Add(lblDescription);
            this.Controls.Add(txtDescription);
            this.Controls.Add(lblQuantity);
            this.Controls.Add(txtQuantity);
            this.Controls.Add(lblPrice);
            this.Controls.Add(txtPrice);
            this.Controls.Add(lblSupplier);
            this.Controls.Add(txtSupplier);
            this.Controls.Add(btnSave);
            this.Controls.Add(btnCancel);
        }
    }
}
