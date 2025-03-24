using Microsoft.SqlServer.Management.Sdk.Sfc;
using Microsoft.SqlServer.Management.Smo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Xml;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace ChengHaoERSWindowsFormsApp
{
    public partial class EmployeeRecordsForm: Form
    {
        private TreeNode tvRootNode;

        public EmployeeRecordsForm()
        {
            InitializeComponent();
            PopulateTreeView();
            InitalizeListControl();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void PopulateTreeView()
        {
            statusBarPanel1.Tag = "Refreshing Employee Code. Please wait...";
            this.Cursor = Cursors.WaitCursor;
            treeView1.Nodes.Clear();
            tvRootNode = new TreeNode("Emlpoyee Records");
            this.Cursor = Cursors.Default;
            treeView1.Nodes.Add(tvRootNode);

            TreeNodeCollection nodeCollection = tvRootNode.Nodes;
            XmlTextReader reader = new XmlTextReader("C:\\Users\\yu'chen\\Desktop\\CMSWindowsApp-master\\CMSWindowsApp-master\\tangzhenyuERSWindowsFormsApp\\EmpRec.xml");

            reader.MoveToElement();
            try
            {
                while (reader.Read())
                {
                    if (reader.HasAttributes && reader.NodeType == XmlNodeType.Element)
                    {
                        reader.MoveToElement();
                        reader.MoveToElement();

                        reader.MoveToAttribute("Id");
                        String strVal = reader.Value;

                        reader.Read();
                        reader.Read();
                        if (reader.Name == "Dept")
                        {
                            reader.Read();
                        }

                        TreeNode EcodeNode = new TreeNode(strVal);

                        nodeCollection.Add(EcodeNode);

                    }
                }
                statusBarPanel1.Text = "Click on an employee code to see their record.";
            }
            catch(XmlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        protected void InitalizeListControl()
        {
            listView1.Clear();
            listView1.Columns.Add("Employee Name", 125, HorizontalAlignment.Left);
            listView1.Columns.Add("Date of Join", 100, HorizontalAlignment.Right);
            listView1.Columns.Add("Grade", 105, HorizontalAlignment.Left);
            listView1.Columns.Add("Salary", 105, HorizontalAlignment.Left);
        }

        protected void PopulateListView(TreeNode crrNode)
        {
            InitalizeListControl();
            XmlTextReader listRead = new XmlTextReader("C:\\Users\\yu'chen\\Desktop\\CMSWindowsApp-master\\CMSWindowsApp-master\\tangzhenyuERSWindowsFormsApp\\EmpRec.xml");
            listRead.MoveToElement();
            while (listRead.Read())
            {
                String strNodeName;
                String strNodePath;
                String name;
                String grade;
                string doj;
                string sal;
                string[] strItemArr = new string[4];
                listRead.MoveToFirstAttribute();
                strNodeName = listRead.Value;
                strNodePath = crrNode.FullPath.Remove(0, 17);
                if (strNodeName == strNodePath)
                {
                    ListViewItem lvi;

                    listRead.MoveToNextAttribute();
                    name = listRead.Value;
                    lvi = listView1.Items.Add(listRead.Value);

                    listRead.Read();
                    listRead.Read();

                    listRead.MoveToFirstAttribute();
                    doj = listRead.Value;
                    lvi.SubItems.Add(doj);

                    listRead.MoveToNextAttribute();
                    grade = listRead.Value;
                    lvi.SubItems.Add(grade);

                    listRead.MoveToNextAttribute();
                    sal = listRead.Value;
                    lvi.SubItems.Add(sal);

                    listRead.MoveToNextAttribute();
                    listRead.MoveToElement();
                    listRead.ReadString();
                }

            }

        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode curNode = e.Node;
            if (tvRootNode == curNode)
            {
                InitalizeListControl();
                statusBarPanel1.Text = "Double Click the Employee Recorde";
                return;
            }
            else
            {
                statusBarPanel1.Text = "Click an Employee code to view individual record";
            }
            PopulateListView(curNode);
        }
    }
}
