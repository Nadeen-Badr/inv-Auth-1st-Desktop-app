using System;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace InventoryManagement
{
    public partial class ReportForm : Form
    {
        public ReportForm()
        {
            InitializeComponent(); // Calls the Designer file to set up the form
            LoadReport();
        }

        private void LoadReport()
        {
            try
            {
                ReportDocument report = new ReportDocument();

                // Path to your Crystal Report file (.rpt)
                string reportPath = @"E:\.Task\InventoryManagement\Reports\CrystalReport1.rpt";

                report.Load(reportPath); // Load the report
                crystalReportViewer1.ReportSource = report; // Display it in the viewer
                crystalReportViewer1.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading report: " + ex.Message);
            }
        }
    }
}
