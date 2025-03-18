namespace CMSWindowsApp
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.wokerToolStripMenuItem = new System.Windows.Forms.MenuStrip();
            this.wokerToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.customerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.jobDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.wokerToolStripMenuItem.SuspendLayout();
            this.SuspendLayout();
            // 
            // wokerToolStripMenuItem
            // 
            this.wokerToolStripMenuItem.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.wokerToolStripMenuItem.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.wokerToolStripMenuItem1,
            this.customerToolStripMenuItem,
            this.jobDetailsToolStripMenuItem,
            this.reportsToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.wokerToolStripMenuItem.Location = new System.Drawing.Point(0, 0);
            this.wokerToolStripMenuItem.Name = "wokerToolStripMenuItem";
            this.wokerToolStripMenuItem.Size = new System.Drawing.Size(1090, 28);
            this.wokerToolStripMenuItem.TabIndex = 0;
            this.wokerToolStripMenuItem.Text = "&Woker";
            // 
            // wokerToolStripMenuItem1
            // 
            this.wokerToolStripMenuItem1.Name = "wokerToolStripMenuItem1";
            this.wokerToolStripMenuItem1.Size = new System.Drawing.Size(71, 24);
            this.wokerToolStripMenuItem1.Text = "&Woker";
            this.wokerToolStripMenuItem1.Click += new System.EventHandler(this.wokerToolStripMenuItem1_Click);
            // 
            // customerToolStripMenuItem
            // 
            this.customerToolStripMenuItem.Name = "customerToolStripMenuItem";
            this.customerToolStripMenuItem.Size = new System.Drawing.Size(94, 24);
            this.customerToolStripMenuItem.Text = "&Customer";
            this.customerToolStripMenuItem.Click += new System.EventHandler(this.customerToolStripMenuItem_Click);
            // 
            // jobDetailsToolStripMenuItem
            // 
            this.jobDetailsToolStripMenuItem.Name = "jobDetailsToolStripMenuItem";
            this.jobDetailsToolStripMenuItem.Size = new System.Drawing.Size(102, 24);
            this.jobDetailsToolStripMenuItem.Text = "&Job Details";
            this.jobDetailsToolStripMenuItem.Click += new System.EventHandler(this.jobDetailsToolStripMenuItem_Click);
            // 
            // reportsToolStripMenuItem
            // 
            this.reportsToolStripMenuItem.Name = "reportsToolStripMenuItem";
            this.reportsToolStripMenuItem.Size = new System.Drawing.Size(81, 24);
            this.reportsToolStripMenuItem.Text = "&Reports";
            this.reportsToolStripMenuItem.Click += new System.EventHandler(this.reportsToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(49, 24);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F);
            this.label1.Location = new System.Drawing.Point(84, 116);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(576, 46);
            this.label1.TabIndex = 1;
            this.label1.Text = "Customer Maintenance System";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1090, 462);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.wokerToolStripMenuItem);
            this.MainMenuStrip = this.wokerToolStripMenuItem;
            this.Name = "Form1";
            this.Text = "Form1";
            this.wokerToolStripMenuItem.ResumeLayout(false);
            this.wokerToolStripMenuItem.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip wokerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wokerToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem customerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem jobDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Label label1;
    }
}

