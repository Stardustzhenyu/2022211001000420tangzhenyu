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
    public partial class CustomerForm: Form
    {
        private SqlConnection conn;
        private SqlDataAdapter adapter;
        private DataSet customerDataset;
        private BindingSource bindingSource;
        public CustomerForm()
        {
            InitializeComponent();
        }

        private void CustomerForm_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection("Data Source=localhost;Initial Catalog=CMSDB;Integrated Security=True;TrustServerCertificate=True");
            adapter = new SqlDataAdapter("Select * from tblCustomer",conn);
            customerDataset = new DataSet();

            SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(adapter);
            adapter.Fill(customerDataset, "tblCustomer");

            bindingSource = new BindingSource();
            bindingSource.DataSource = customerDataset;
            bindingSource.DataMember = "tblCustomer";

            textBox1.DataBindings.Add("Text", bindingSource, "CarNo");
            textBox2.DataBindings.Add("Text", bindingSource, "Name");
            textBox3.DataBindings.Add("Text", bindingSource, "Address");
            textBox4.DataBindings.Add("Text", bindingSource, "Make");

            textBox1.ReadOnly = true;
            textBox2.ReadOnly = true;
            textBox3.ReadOnly = true;
            textBox4.ReadOnly = true;

            UpdatePosition();
        }

        private void UpdatePosition()
        {
            lblPosition.Text = $"{bindingSource.Position + 1} / {bindingSource.Count}";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool flag;
            flag = true;
            if (textBox1.Text == "")
            {
                errorCustomerForm.SetError(textBox1, "Please specify a valid car number");
                flag = false;
            }
            else
                errorCustomerForm.SetError(textBox1, "");
            if (textBox2.Text == "")
            {
                errorCustomerForm.SetError(textBox2, "Please specify a valid name");
                flag = false;
            }
            else
                errorCustomerForm.SetError(textBox2, "");
            if (textBox3.Text == "")
            {
                errorCustomerForm.SetError(textBox3, "Please specify a valid address");
                flag = false;
            }
            else
                errorCustomerForm.SetError(textBox3, "");
            if (textBox4.Text == "")
            {
                errorCustomerForm.SetError(textBox4, "Please specify a valid make");
                flag = false;
            }
            else
                errorCustomerForm.SetError(textBox4, "");

            if (flag == false)
                return;
            else
            {
                try
                {
                    bindingSource.EndEdit();
                    adapter.Update(customerDataset, "tblCustomer");
                    MessageBox.Show("Record saved successfully!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error saving record: " + ex.Message);
                }
            }
            
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (bindingSource.Position < bindingSource.Count - 1)
            {
                bindingSource.Position += 1;
                
            }
            UpdatePosition();
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (bindingSource.Position > 0)
            {
                bindingSource.Position -= 1;

            }
            UpdatePosition();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            DataRow newRow = customerDataset.Tables["tblCustomer"].NewRow();

            newRow["CarNo"] = "";
            newRow["Name"] = "";
            newRow["Address"] = "";
            newRow["Make"] = "";

            customerDataset.Tables["tblCustomer"].Rows.Add(newRow);

            bindingSource.Position = bindingSource.Count - 1;

            textBox1.ReadOnly = false;
            textBox2.ReadOnly = false;
            textBox3.ReadOnly = false;
            textBox4.ReadOnly = false;

            UpdatePosition();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            textBox1.ReadOnly = false;
            textBox2.ReadOnly = false;
            textBox3.ReadOnly = false;
            textBox4.ReadOnly = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            bindingSource.CancelEdit();
            textBox1.ReadOnly = true;
            textBox2.ReadOnly = true;
            textBox3.ReadOnly = true;
            textBox4.ReadOnly = true;
        }
    }
}
