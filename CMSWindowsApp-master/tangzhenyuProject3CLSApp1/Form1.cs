using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using Application = System.Windows.Forms.Application;

namespace ChengHaoProject3CLSApp1
{
    public partial class frmCreative: Form
    {


        private Icon m_info = new Icon(SystemIcons.Information, 40, 40);
        private Icon m_error = new Icon(SystemIcons.Error, 40, 40);
        private Icon m_ready = new Icon(SystemIcons.WinLogo, 40, 40);


        public frmCreative()
        {
            InitializeComponent();
        }
        
        private void frmCreative_Load(object sender, EventArgs e)
        {
            txtSource.Text = "D:\\Creative\\Source\\";
            txtProcessedFile.Text = "D:\\Creative\\Processed\\";
            txtDest.Text = "D:\\Creative\\Destination\\";
            optGenerateLog.Checked = true;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(txtSource.Text))
            {
                errMessage.SetError(txtSource, "Invaild Source Directory");
                txtSource.Focus();
                tabControl1.SelectedTab = tabSource;
                return;
            }
            else
                errMessage.SetError(txtSource, "");

            if (!Directory.Exists(txtDest.Text))
            {
                errMessage.SetError(txtDest, "Invaild Destination Directory");
                txtDest.Focus();
                tabControl1.SelectedTab = tabDest;
                return;
            }
            else
                errMessage.SetError(txtDest, "");
            if (!Directory.Exists(txtProcessedFile.Text))
            {
                errMessage.SetError(txtProcessedFile, "Invaild Source Directory");
                txtProcessedFile.Focus();
                tabControl1.SelectedTab = tabSource;
                return;
            }
            else
                errMessage.SetError(txtProcessedFile, "");

            watchDir.EnableRaisingEvents = true;
            watchDir.Path = txtSource.Text;

            mnuNotify.Icon = m_ready;
            mnuNotify.Visible = true;
            this.ShowInTaskbar = false;
            this.Hide();
        }

        private void txtSource_KeyUp(object sender, KeyEventArgs e)
        {
            if (Directory.Exists(txtSource.Text))
            {
                txtSource.BackColor = Color.White;
            }
            else
                txtSource.BackColor = Color.Pink;
        }

        private void txtDest_KeyUp(object sender, KeyEventArgs e)
        {
            if (Directory.Exists(txtDest.Text))
            {
                txtDest.BackColor = Color.White;
            }
            else
                txtDest.BackColor = Color.Pink;
        }

        private void txtProcessedFile_KeyUp(object sender, KeyEventArgs e)
        {
            if (Directory.Exists(txtProcessedFile.Text))
            {
                txtProcessedFile.BackColor = Color.White;
            }
            else
                txtProcessedFile.BackColor = Color.Pink;
        }

        private void mnuConfigure_Click(object sender, EventArgs e)
        {
            mnuNotify.Visible = false;
            this.ShowInTaskbar = true;
            this.Show();
        }

        private void mnuExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void mnuNotify_DoubleClick(object sender, EventArgs e)
        {
            mnuNotify.Visible = false;
            this.ShowInTaskbar = true;
            this.Show();
        }

        private void watchDir_Created(object sender, FileSystemEventArgs e)
        {
            watchDir.EnableRaisingEvents = false;
            mnuNotify.Icon = m_info;
            mnuNotify.Text = "Processed" + e.Name;

            Microsoft.Office.Interop.Word.Application wdApp = new Microsoft.Office.Interop.Word.Application();
            object optional = System.Reflection.Missing.Value;

            XmlTextWriter xmlTextWriter = new XmlTextWriter(txtDest.Text + "summary.xml", null);
            try
            {
                Microsoft.Office.Interop.Word.Document doc = new Microsoft.Office.Interop.Word.Document();
                object fiename = e.Name;
                doc = wdApp.Documents.Open(ref fiename, ref optional, ref optional,
                    ref optional, ref optional, ref optional, ref optional, ref optional,
                    ref optional, ref optional, ref optional);

                Microsoft.Office.Interop.Word.Range wdRange;
                wdRange = doc.Paragraphs[2].Range;

                string strMemo, strAmount;
                int intParacount;

                strMemo = wdRange.Text;
                strMemo = strMemo.Substring(13, 4);

                intParacount = doc.Paragraphs.Count;
                intParacount = intParacount - 2;

                wdRange = doc.Paragraphs[intParacount].Range;
                object count = -1;
                object wdCharater = "1";

                wdRange.MoveEnd(ref wdCharater, ref count);
                strAmount = wdRange.Text;

                strAmount = strAmount.Substring(21);

                xmlTextWriter.Formatting = Formatting.Indented;
                xmlTextWriter.WriteDocType("Sales", null, null, null);
                xmlTextWriter.WriteComment("Summary of sales at Creative Learing");
                xmlTextWriter.WriteStartElement("Sales");
                xmlTextWriter.WriteStartElement(Convert.ToString(DateTime.Today));
                xmlTextWriter.WriteElementString("Memo", strMemo);
                xmlTextWriter.WriteElementString("Amount", strAmount);
                xmlTextWriter.WriteEndElement();
                xmlTextWriter.WriteEndElement();
                mnuNotify.Icon = m_ready;
            }
            catch (Exception catchException)
            {
                mnuNotify.Icon = m_error;
                mnuNotify.Text = "Error in" + e.Name;
                if (optGenerateLog.Checked == true)
                    eventLog1.WriteEntry(e.Name + ": " + catchException);
            }
            finally
            {
                xmlTextWriter.Flush();
                xmlTextWriter.Close();

                wdApp.Quit(ref optional, ref optional, ref optional);
                wdApp = null;
                watchDir.EnableRaisingEvents = true;
            }
        tryAgain:
            try
            {
                File.Move(e.FullPath, txtProcessedFile.Text + e.Name);
            }
            catch
            {
                goto tryAgain;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            lstEvents.Items.Clear();
            eventLog1.Log = "Application";
            eventLog1.MachineName = ".";
            foreach (EventLogEntry logEntry in eventLog1.Entries)
            {
                if (logEntry.Source == "CrealtiveLearing")
                {
                    lstEvents.Items.Add(logEntry.Message);
                }
            }
        }

        private void btnViewSummary_Click(object sender, EventArgs e)
        {
            StreamReader strRead;
            try
            {
                strRead = new StreamReader(txtDest.Text + "Summary.xml");
                MessageBox.Show(strRead.ReadToEnd(), txtDest.Text + "Summary.xml", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
                strRead.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An Error was returned : " + ex.Message + "Please check the destination folder for summary");
            }
        }
    }
}
