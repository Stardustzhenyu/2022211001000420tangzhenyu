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
    public partial class MonthlyCusumableForm: Form
    {
        public MonthlyCusumableForm()
        {
            InitializeComponent();
        }

        private void MonthlyCusumableForm_Load(object sender, EventArgs e)
        {
            DataTable dt = GetCunsumableDate();
            ReportDataSource rds = new ReportDataSource("JobDetailsDataSet", dt);

            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(rds);

            this.reportViewer1.RefreshReport();
        }

        private DataTable GetCunsumableDate()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection("Data Source=localhost;Initial Catalog=CMSDB;Integrated Security=True;TrustServerCertificate=True"))
            {
                string query = "SELECT  JobDate,  SUM(Tires) AS Tires,SUM(Weights) AS Weights,   SUM(OilChanged) AS OilChanged,  SUM(OilFilter) AS OilFilter,   SUM(GearOil) AS GearOil,    SUM(Point) AS Point,    SUM(Condenser) AS Condenser,   SUM(Plug) AS Plug, SUM(FuelFilter) AS FuelFilter,   SUM(AirFilter) AS AirFilter FROM [CMSDB].[dbo].[tblJobDetails] GROUP BY JobDate  ORDER BY JobDate;  ";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.Fill(dt);

            }

            return dt;
        }
    }
}
