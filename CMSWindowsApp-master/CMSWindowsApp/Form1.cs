using System;
using System.Windows.Forms;

namespace CMSWindowsApp
{
    public partial class Form1: Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void wokerToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            WorkerForm workerform = new WorkerForm();
            workerform.ShowDialog();
        }

        private void customerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CustomerForm customerform = new CustomerForm();
            customerform.ShowDialog();
        }

        private void jobDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            JobDetailsForm jobdetailform = new JobDetailsForm();
            jobdetailform.ShowDialog();
        }

        private void reportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportForm reportform = new ReportForm();
            reportform.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
