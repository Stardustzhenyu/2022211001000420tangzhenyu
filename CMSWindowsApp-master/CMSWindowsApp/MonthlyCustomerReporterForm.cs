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
    public partial class MonthlyCustomerReporterForm: Form
    {
        public MonthlyCustomerReporterForm()
        {
            InitializeComponent();
        }

        private void MonthlyCustomerReporterForm_Load(object sender, EventArgs e)
        {
            DataTable dt = GetCunsumableDate();
            ReportDataSource rds = new ReportDataSource("CustomerJobDataSet", dt);

            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(rds);

            this.reportViewer1.RefreshReport();
        }

        private DataTable GetCunsumableDate()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection("Data Source=localhost;Initial Catalog=CMSDB;Integrated Security=True;TrustServerCertificate=True"))
            {
                string query = "SELECT \r\n    c.CarNo,\r\n    c.Name,\r\n    c.Address,\r\n    c.Make,\r\n    YEAR(j.JobDate) AS JobYear,\r\n    MONTH(j.JobDate) AS JobMonth,\r\n    COUNT(j.JobDate) AS JobCount  \r\nFROM \r\n    [CMSDB].[dbo].[tblCustomer] c\r\nINNER JOIN \r\n    [CMSDB].[dbo].[tblJobDetails] j ON c.CarNo = j.CarNo  \r\nGROUP BY \r\n    c.CarNo, \r\n    c.Name, \r\n    c.Address, \r\n    c.Make,\r\n    YEAR(j.JobDate),\r\n    MONTH(j.JobDate)\r\nORDER BY \r\n    c.CarNo, \r\n    JobYear, \r\n    JobMonth;  ";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.Fill(dt);

            }

            return dt;
        }
    }
}
