namespace InventoryManagement
{
    partial class AuditLogsForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView auditGrid;
        private System.Windows.Forms.Button btnClose;

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
            this.auditGrid = new System.Windows.Forms.DataGridView();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.auditGrid)).BeginInit();
            this.SuspendLayout();

            this.auditGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.auditGrid.Location = new System.Drawing.Point(20, 20);
            this.auditGrid.Name = "auditGrid";
            this.auditGrid.Size = new System.Drawing.Size(760, 350);
            this.auditGrid.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right); // Expands with form
            this.auditGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // Columns fill space dynamically
            this.auditGrid.TabIndex = 0;

            // Close Button
            this.btnClose.Text = "Close";
            this.btnClose.Location = new System.Drawing.Point(350, 400);
            this.btnClose.Size = new System.Drawing.Size(100, 30);
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);

            // AuditLogsForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.auditGrid);
            this.Controls.Add(this.btnClose);
            this.Name = "AuditLogsForm";
            this.Text = "Audit Logs";
            ((System.ComponentModel.ISupportInitialize)(this.auditGrid)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
