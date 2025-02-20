using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using InventoryManagement.Database;

namespace InventoryManagement
{
    public partial class AuditLogsForm : Form
    {
        public AuditLogsForm()
        {
            InitializeComponent();
            LoadAuditLogs();
        }

         private void LoadAuditLogs()
        {
            auditGrid.DataSource = DatabaseHelper.GetAuditLogs();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
