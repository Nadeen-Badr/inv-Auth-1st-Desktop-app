using CrystalDecisions.Windows.Forms;
using System.Windows.Forms;

namespace InventoryManagement
{
    public partial class ReportForm
    {
        private CrystalReportViewer crystalReportViewer1;

        private void InitializeComponent()
        {
            this.crystalReportViewer1 = new CrystalReportViewer();
            this.SuspendLayout();

            // crystalReportViewer1 configuration
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BorderStyle = BorderStyle.FixedSingle;
            this.crystalReportViewer1.Dock = DockStyle.Fill;
            this.crystalReportViewer1.TabIndex = 0;

            // ReportForm configuration
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.crystalReportViewer1);
            this.Name = "ReportForm";
            this.Text = "Inventory Report";
            this.ResumeLayout(false);
        }
    }
}
