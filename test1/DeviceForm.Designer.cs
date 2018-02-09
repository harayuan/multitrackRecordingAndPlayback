namespace Automation
{
    partial class DeviceForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.sourceList = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Refresh_Btn = new System.Windows.Forms.Button();
            this.Cancel_Btn = new System.Windows.Forms.Button();
            this.OK_Btn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.sourceList);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.Refresh_Btn);
            this.splitContainer1.Panel2.Controls.Add(this.Cancel_Btn);
            this.splitContainer1.Panel2.Controls.Add(this.OK_Btn);
            this.splitContainer1.Size = new System.Drawing.Size(515, 222);
            this.splitContainer1.SplitterDistance = 372;
            this.splitContainer1.TabIndex = 0;
            // 
            // sourceList
            // 
            this.sourceList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sourceList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.sourceList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sourceList.FullRowSelect = true;
            this.sourceList.GridLines = true;
            this.sourceList.Location = new System.Drawing.Point(0, 0);
            this.sourceList.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.sourceList.MultiSelect = false;
            this.sourceList.Name = "sourceList";
            this.sourceList.Size = new System.Drawing.Size(372, 222);
            this.sourceList.TabIndex = 1;
            this.sourceList.UseCompatibleStateImageBehavior = false;
            this.sourceList.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Devices";
            this.columnHeader1.Width = 164;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "In Channels";
            this.columnHeader2.Width = 69;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Out Channels";
            this.columnHeader3.Width = 76;
            // 
            // Refresh_Btn
            // 
            this.Refresh_Btn.Location = new System.Drawing.Point(24, 32);
            this.Refresh_Btn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Refresh_Btn.Name = "Refresh_Btn";
            this.Refresh_Btn.Size = new System.Drawing.Size(88, 29);
            this.Refresh_Btn.TabIndex = 20;
            this.Refresh_Btn.Text = "Refresh";
            this.Refresh_Btn.UseVisualStyleBackColor = true;
            this.Refresh_Btn.Click += new System.EventHandler(this.Refresh_Btn_Click);
            // 
            // Cancel_Btn
            // 
            this.Cancel_Btn.Location = new System.Drawing.Point(24, 150);
            this.Cancel_Btn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Cancel_Btn.Name = "Cancel_Btn";
            this.Cancel_Btn.Size = new System.Drawing.Size(88, 29);
            this.Cancel_Btn.TabIndex = 19;
            this.Cancel_Btn.Text = "Cancel";
            this.Cancel_Btn.UseVisualStyleBackColor = true;
            this.Cancel_Btn.Click += new System.EventHandler(this.Cancel_Btn_Click);
            // 
            // OK_Btn
            // 
            this.OK_Btn.Location = new System.Drawing.Point(24, 113);
            this.OK_Btn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.OK_Btn.Name = "OK_Btn";
            this.OK_Btn.Size = new System.Drawing.Size(88, 29);
            this.OK_Btn.TabIndex = 18;
            this.OK_Btn.Text = "OK";
            this.OK_Btn.UseVisualStyleBackColor = true;
            this.OK_Btn.Click += new System.EventHandler(this.OK_Btn_Click);
            // 
            // DeviceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(515, 222);
            this.ControlBox = false;
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Calibri", 10F);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MinimumSize = new System.Drawing.Size(531, 238);
            this.Name = "DeviceForm";
            this.Text = "Select Device (ASIO only)";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListView sourceList;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Button Cancel_Btn;
        private System.Windows.Forms.Button OK_Btn;
        private System.Windows.Forms.Button Refresh_Btn;
    }
}