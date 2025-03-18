using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CMSWindowsApp
{
    public partial class ReportForm: Form
    {
        public ReportForm()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            MonthlyCusumableForm monthlyCusumableForm = new MonthlyCusumableForm();
            monthlyCusumableForm.ShowDialog();
        }

        private void radioButton2_Click(object sender, EventArgs e)
        {
            MonthlyCustomerReporterForm monthlyCustomerReporterForm = new MonthlyCustomerReporterForm();
            monthlyCustomerReporterForm.ShowDialog();
        }

        private void radioButton3_Click(object sender, EventArgs e)
        {
            MonthlyJobAlignmentBalanceForm monthlyJobAlignmentBalanceForm = new MonthlyJobAlignmentBalanceForm();
            monthlyJobAlignmentBalanceForm.ShowDialog();
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            MonthlyWorkerAlignmentBalancingForm monthlyWorkerAlignmentBalancingForm = new MonthlyWorkerAlignmentBalancingForm();
            monthlyWorkerAlignmentBalancingForm.ShowDialog();
        }

    }
}
