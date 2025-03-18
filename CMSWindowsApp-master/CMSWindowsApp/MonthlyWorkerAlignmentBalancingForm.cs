using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CMSWindowsApp
{
    public partial class MonthlyWorkerAlignmentBalancingForm: Form
    {
        public MonthlyWorkerAlignmentBalancingForm()
        {
            InitializeComponent();
        }

        private void MonthlyWorkerAlignmentBalancingForm_Load(object sender, EventArgs e)
        {
            DataTable dt = GetCunsumableDate();
            ReportDataSource rds = new ReportDataSource("WorkerJobAlignmentBalanceDataSet", dt);

            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(rds);

            this.reportViewer1.RefreshReport();
        }

        private DataTable GetCunsumableDate()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection("Data Source=localhost;Initial Catalog=CMSDB;Integrated Security=True;TrustServerCertificate=True"))
            {
                string query = "SELECT \r\n    w.Name AS WorkerName,\r\n    w.WorkerID,\r\n    YEAR(j.JobDate) AS JobYear,     \r\n    MONTH(j.JobDate) AS JobMonth,   \r\n    COUNT(*) AS JobCount           \r\nFROM \r\n    [CMSDB].[dbo].[tblWorker] w\r\nINNER JOIN \r\n    [CMSDB].[dbo].[tblJobDetails] j \r\n    ON w.WorkerID = j.WorkerID      \r\nGROUP BY \r\n    w.WorkerID, \r\n    w.Name,\r\n    YEAR(j.JobDate),\r\n    MONTH(j.JobDate)\r\nORDER BY \r\n    w.WorkerID, \r\n    JobYear, \r\n    JobMonth;                       ";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.Fill(dt);

            }

            return dt;
        }
    }
}
