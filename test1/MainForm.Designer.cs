namespace Automation
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.Command_Tab = new System.Windows.Forms.TabPage();
            this.cmdTextBox = new System.Windows.Forms.RichTextBox();
            this.Data_Tab = new System.Windows.Forms.TabPage();
            this.Dataset_splitContainer = new System.Windows.Forms.SplitContainer();
            this.DataList = new System.Windows.Forms.ListView();
            this.num = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Dataset_tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.Save_Btn = new System.Windows.Forms.Button();
            this.Load_Btn = new System.Windows.Forms.Button();
            this.Clear_Data_Btn = new System.Windows.Forms.Button();
            this.Add_Data_Btn = new System.Windows.Forms.Button();
            this.Clear_All_Btn = new System.Windows.Forms.Button();
            this.PCM2WAV_tab = new System.Windows.Forms.TabPage();
            this.PCM2WAV_SplitContainer = new System.Windows.Forms.SplitContainer();
            this.filenameBox = new System.Windows.Forms.RichTextBox();
            this.Convert = new System.Windows.Forms.Button();
            this.Browse = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.OneCh_Rate_TextBox = new System.Windows.Forms.TextBox();
            this.OneCh_Bit_TextBox = new System.Windows.Forms.TextBox();
            this.Use_Default_CheckBox = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.NineCh_Rate_TextBox = new System.Windows.Forms.TextBox();
            this.NineCh_Bit_TextBox = new System.Windows.Forms.TextBox();
            this.AddTask_Tab = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.Browse_Task_Source_Btn = new System.Windows.Forms.Button();
            this.Task_Source_TextBox = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.Browse_Keyword_Sample_Btn = new System.Windows.Forms.Button();
            this.Browse_Keyword_Source_Btn = new System.Windows.Forms.Button();
            this.Keyword_Sample_TextBox = new System.Windows.Forms.TextBox();
            this.Keyword_Source_TextBox = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.Start_AddTask_Btn = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.spComboBox = new System.Windows.Forms.ComboBox();
            this.SPCheckBox = new System.Windows.Forms.CheckBox();
            this.Mapping_Btn = new System.Windows.Forms.Button();
            this.Device_Btn = new System.Windows.Forms.Button();
            this.Play_Stop_Btn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Dot_Pull = new System.Windows.Forms.Button();
            this.Dot_Record_Stop = new System.Windows.Forms.Button();
            this.Dot_Clear = new System.Windows.Forms.Button();
            this.Dot_Root = new System.Windows.Forms.Button();
            this.XCorr_Btn = new System.Windows.Forms.Button();
            this.Exit_Btn = new System.Windows.Forms.Button();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.Command_Tab.SuspendLayout();
            this.Data_Tab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dataset_splitContainer)).BeginInit();
            this.Dataset_splitContainer.Panel1.SuspendLayout();
            this.Dataset_splitContainer.Panel2.SuspendLayout();
            this.Dataset_splitContainer.SuspendLayout();
            this.Dataset_tableLayoutPanel.SuspendLayout();
            this.PCM2WAV_tab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PCM2WAV_SplitContainer)).BeginInit();
            this.PCM2WAV_SplitContainer.Panel1.SuspendLayout();
            this.PCM2WAV_SplitContainer.Panel2.SuspendLayout();
            this.PCM2WAV_SplitContainer.SuspendLayout();
            this.AddTask_Tab.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tabControl1);
            this.splitContainer1.Panel1MinSize = 400;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.AutoScroll = true;
            this.splitContainer1.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel2.Controls.Add(this.XCorr_Btn);
            this.splitContainer1.Panel2.Controls.Add(this.Exit_Btn);
            this.splitContainer1.Panel2.Font = new System.Drawing.Font("Calibri", 11F);
            this.splitContainer1.Panel2MinSize = 250;
            this.splitContainer1.Size = new System.Drawing.Size(914, 512);
            this.splitContainer1.SplitterDistance = 660;
            this.splitContainer1.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.Command_Tab);
            this.tabControl1.Controls.Add(this.Data_Tab);
            this.tabControl1.Controls.Add(this.PCM2WAV_tab);
            this.tabControl1.Controls.Add(this.AddTask_Tab);
            this.tabControl1.Font = new System.Drawing.Font("Calibri", 11F);
            this.tabControl1.Location = new System.Drawing.Point(25, 12);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(619, 472);
            this.tabControl1.TabIndex = 19;
            // 
            // Command_Tab
            // 
            this.Command_Tab.Controls.Add(this.cmdTextBox);
            this.Command_Tab.Location = new System.Drawing.Point(4, 27);
            this.Command_Tab.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Command_Tab.Name = "Command_Tab";
            this.Command_Tab.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Command_Tab.Size = new System.Drawing.Size(611, 441);
            this.Command_Tab.TabIndex = 0;
            this.Command_Tab.Text = "Command";
            this.Command_Tab.UseVisualStyleBackColor = true;
            // 
            // cmdTextBox
            // 
            this.cmdTextBox.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cmdTextBox.DetectUrls = false;
            this.cmdTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmdTextBox.Font = new System.Drawing.Font("Calibri", 11F);
            this.cmdTextBox.Location = new System.Drawing.Point(4, 3);
            this.cmdTextBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cmdTextBox.Name = "cmdTextBox";
            this.cmdTextBox.ReadOnly = true;
            this.cmdTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.cmdTextBox.Size = new System.Drawing.Size(603, 435);
            this.cmdTextBox.TabIndex = 30;
            this.cmdTextBox.Text = "";
            this.cmdTextBox.TextChanged += new System.EventHandler(this.cmdTextBox_TextChanged);
            // 
            // Data_Tab
            // 
            this.Data_Tab.BackColor = System.Drawing.SystemColors.Control;
            this.Data_Tab.Controls.Add(this.Dataset_splitContainer);
            this.Data_Tab.Font = new System.Drawing.Font("Calibri", 11F);
            this.Data_Tab.Location = new System.Drawing.Point(4, 27);
            this.Data_Tab.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Data_Tab.Name = "Data_Tab";
            this.Data_Tab.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Data_Tab.Size = new System.Drawing.Size(611, 441);
            this.Data_Tab.TabIndex = 1;
            this.Data_Tab.Text = "Data Set";
            // 
            // Dataset_splitContainer
            // 
            this.Dataset_splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Dataset_splitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.Dataset_splitContainer.IsSplitterFixed = true;
            this.Dataset_splitContainer.Location = new System.Drawing.Point(4, 3);
            this.Dataset_splitContainer.Name = "Dataset_splitContainer";
            // 
            // Dataset_splitContainer.Panel1
            // 
            this.Dataset_splitContainer.Panel1.AutoScroll = true;
            this.Dataset_splitContainer.Panel1.Controls.Add(this.DataList);
            // 
            // Dataset_splitContainer.Panel2
            // 
            this.Dataset_splitContainer.Panel2.AutoScroll = true;
            this.Dataset_splitContainer.Panel2.Controls.Add(this.Dataset_tableLayoutPanel);
            this.Dataset_splitContainer.Size = new System.Drawing.Size(603, 435);
            this.Dataset_splitContainer.SplitterDistance = 413;
            this.Dataset_splitContainer.TabIndex = 34;
            // 
            // DataList
            // 
            this.DataList.BackColor = System.Drawing.SystemColors.Window;
            this.DataList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DataList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.num});
            this.DataList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataList.FullRowSelect = true;
            this.DataList.GridLines = true;
            this.DataList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.DataList.LabelWrap = false;
            this.DataList.Location = new System.Drawing.Point(0, 0);
            this.DataList.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.DataList.Name = "DataList";
            this.DataList.ShowGroups = false;
            this.DataList.Size = new System.Drawing.Size(413, 435);
            this.DataList.TabIndex = 1;
            this.DataList.UseCompatibleStateImageBehavior = false;
            this.DataList.View = System.Windows.Forms.View.Details;
            // 
            // num
            // 
            this.num.Text = "#";
            this.num.Width = 24;
            // 
            // Dataset_tableLayoutPanel
            // 
            this.Dataset_tableLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Dataset_tableLayoutPanel.ColumnCount = 2;
            this.Dataset_tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.Dataset_tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.Dataset_tableLayoutPanel.Controls.Add(this.Save_Btn, 1, 1);
            this.Dataset_tableLayoutPanel.Controls.Add(this.Load_Btn, 1, 0);
            this.Dataset_tableLayoutPanel.Controls.Add(this.Clear_Data_Btn, 0, 1);
            this.Dataset_tableLayoutPanel.Controls.Add(this.Add_Data_Btn, 0, 0);
            this.Dataset_tableLayoutPanel.Controls.Add(this.Clear_All_Btn, 0, 2);
            this.Dataset_tableLayoutPanel.Location = new System.Drawing.Point(3, 3);
            this.Dataset_tableLayoutPanel.Name = "Dataset_tableLayoutPanel";
            this.Dataset_tableLayoutPanel.RowCount = 3;
            this.Dataset_tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.Dataset_tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.Dataset_tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.Dataset_tableLayoutPanel.Size = new System.Drawing.Size(180, 110);
            this.Dataset_tableLayoutPanel.TabIndex = 40;
            // 
            // Save_Btn
            // 
            this.Save_Btn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Save_Btn.Location = new System.Drawing.Point(94, 38);
            this.Save_Btn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Save_Btn.Name = "Save_Btn";
            this.Save_Btn.Size = new System.Drawing.Size(82, 29);
            this.Save_Btn.TabIndex = 37;
            this.Save_Btn.Text = "Save";
            this.Save_Btn.UseVisualStyleBackColor = true;
            this.Save_Btn.Click += new System.EventHandler(this.Save_Btn_Click);
            // 
            // Load_Btn
            // 
            this.Load_Btn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Load_Btn.Location = new System.Drawing.Point(94, 3);
            this.Load_Btn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Load_Btn.Name = "Load_Btn";
            this.Load_Btn.Size = new System.Drawing.Size(82, 29);
            this.Load_Btn.TabIndex = 36;
            this.Load_Btn.Text = "Load";
            this.Load_Btn.UseVisualStyleBackColor = true;
            this.Load_Btn.Click += new System.EventHandler(this.Load_Btn_Click);
            // 
            // Clear_Data_Btn
            // 
            this.Clear_Data_Btn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Clear_Data_Btn.Location = new System.Drawing.Point(4, 38);
            this.Clear_Data_Btn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Clear_Data_Btn.Name = "Clear_Data_Btn";
            this.Clear_Data_Btn.Size = new System.Drawing.Size(82, 29);
            this.Clear_Data_Btn.TabIndex = 37;
            this.Clear_Data_Btn.Text = "Clear";
            this.Clear_Data_Btn.UseVisualStyleBackColor = true;
            this.Clear_Data_Btn.Click += new System.EventHandler(this.Clear_Data_Btn_Click);
            // 
            // Add_Data_Btn
            // 
            this.Add_Data_Btn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Add_Data_Btn.Location = new System.Drawing.Point(4, 3);
            this.Add_Data_Btn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Add_Data_Btn.Name = "Add_Data_Btn";
            this.Add_Data_Btn.Size = new System.Drawing.Size(82, 29);
            this.Add_Data_Btn.TabIndex = 35;
            this.Add_Data_Btn.Text = "Add";
            this.Add_Data_Btn.UseVisualStyleBackColor = true;
            this.Add_Data_Btn.Click += new System.EventHandler(this.Add_Data_Btn_Click);
            // 
            // Clear_All_Btn
            // 
            this.Clear_All_Btn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Clear_All_Btn.Location = new System.Drawing.Point(4, 73);
            this.Clear_All_Btn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Clear_All_Btn.Name = "Clear_All_Btn";
            this.Clear_All_Btn.Size = new System.Drawing.Size(82, 29);
            this.Clear_All_Btn.TabIndex = 38;
            this.Clear_All_Btn.Text = "Clear All";
            this.Clear_All_Btn.UseVisualStyleBackColor = true;
            this.Clear_All_Btn.Click += new System.EventHandler(this.Clear_All_Btn_Click);
            // 
            // PCM2WAV_tab
            // 
            this.PCM2WAV_tab.BackColor = System.Drawing.Color.Transparent;
            this.PCM2WAV_tab.Controls.Add(this.PCM2WAV_SplitContainer);
            this.PCM2WAV_tab.Location = new System.Drawing.Point(4, 27);
            this.PCM2WAV_tab.Name = "PCM2WAV_tab";
            this.PCM2WAV_tab.Size = new System.Drawing.Size(611, 441);
            this.PCM2WAV_tab.TabIndex = 2;
            this.PCM2WAV_tab.Text = "PCM2WAV";
            // 
            // PCM2WAV_SplitContainer
            // 
            this.PCM2WAV_SplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PCM2WAV_SplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.PCM2WAV_SplitContainer.IsSplitterFixed = true;
            this.PCM2WAV_SplitContainer.Location = new System.Drawing.Point(0, 0);
            this.PCM2WAV_SplitContainer.Name = "PCM2WAV_SplitContainer";
            // 
            // PCM2WAV_SplitContainer.Panel1
            // 
            this.PCM2WAV_SplitContainer.Panel1.Controls.Add(this.filenameBox);
            // 
            // PCM2WAV_SplitContainer.Panel2
            // 
            this.PCM2WAV_SplitContainer.Panel2.Controls.Add(this.Convert);
            this.PCM2WAV_SplitContainer.Panel2.Controls.Add(this.Browse);
            this.PCM2WAV_SplitContainer.Panel2.Controls.Add(this.label6);
            this.PCM2WAV_SplitContainer.Panel2.Controls.Add(this.label7);
            this.PCM2WAV_SplitContainer.Panel2.Controls.Add(this.label8);
            this.PCM2WAV_SplitContainer.Panel2.Controls.Add(this.OneCh_Rate_TextBox);
            this.PCM2WAV_SplitContainer.Panel2.Controls.Add(this.OneCh_Bit_TextBox);
            this.PCM2WAV_SplitContainer.Panel2.Controls.Add(this.Use_Default_CheckBox);
            this.PCM2WAV_SplitContainer.Panel2.Controls.Add(this.label3);
            this.PCM2WAV_SplitContainer.Panel2.Controls.Add(this.label2);
            this.PCM2WAV_SplitContainer.Panel2.Controls.Add(this.label1);
            this.PCM2WAV_SplitContainer.Panel2.Controls.Add(this.NineCh_Rate_TextBox);
            this.PCM2WAV_SplitContainer.Panel2.Controls.Add(this.NineCh_Bit_TextBox);
            this.PCM2WAV_SplitContainer.Size = new System.Drawing.Size(611, 441);
            this.PCM2WAV_SplitContainer.SplitterDistance = 450;
            this.PCM2WAV_SplitContainer.TabIndex = 49;
            // 
            // filenameBox
            // 
            this.filenameBox.BackColor = System.Drawing.SystemColors.HighlightText;
            this.filenameBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.filenameBox.Font = new System.Drawing.Font("Calibri", 11F);
            this.filenameBox.Location = new System.Drawing.Point(0, 0);
            this.filenameBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.filenameBox.Name = "filenameBox";
            this.filenameBox.Size = new System.Drawing.Size(450, 441);
            this.filenameBox.TabIndex = 22;
            this.filenameBox.Text = "";
            this.filenameBox.WordWrap = false;
            // 
            // Convert
            // 
            this.Convert.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Convert.Font = new System.Drawing.Font("Calibri", 11F);
            this.Convert.Location = new System.Drawing.Point(35, 361);
            this.Convert.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Convert.Name = "Convert";
            this.Convert.Size = new System.Drawing.Size(88, 29);
            this.Convert.TabIndex = 63;
            this.Convert.Text = "Convert";
            this.Convert.UseVisualStyleBackColor = true;
            this.Convert.Click += new System.EventHandler(this.Convert_Click);
            // 
            // Browse
            // 
            this.Browse.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Browse.Font = new System.Drawing.Font("Calibri", 11F);
            this.Browse.Location = new System.Drawing.Point(35, 326);
            this.Browse.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Browse.Name = "Browse";
            this.Browse.Size = new System.Drawing.Size(88, 29);
            this.Browse.TabIndex = 62;
            this.Browse.Text = "Browse";
            this.Browse.UseVisualStyleBackColor = true;
            this.Browse.Click += new System.EventHandler(this.Browse_Click);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 11F);
            this.label6.Location = new System.Drawing.Point(48, 262);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 18);
            this.label6.TabIndex = 61;
            this.label6.Text = "Rate";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 11F);
            this.label7.Location = new System.Drawing.Point(21, 195);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 18);
            this.label7.TabIndex = 60;
            this.label7.Text = "1 Channel";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Calibri", 11F);
            this.label8.Location = new System.Drawing.Point(48, 213);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(25, 18);
            this.label8.TabIndex = 59;
            this.label8.Text = "Bit";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // OneCh_Rate_TextBox
            // 
            this.OneCh_Rate_TextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.OneCh_Rate_TextBox.Location = new System.Drawing.Point(51, 283);
            this.OneCh_Rate_TextBox.Name = "OneCh_Rate_TextBox";
            this.OneCh_Rate_TextBox.Size = new System.Drawing.Size(69, 25);
            this.OneCh_Rate_TextBox.TabIndex = 58;
            this.OneCh_Rate_TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // OneCh_Bit_TextBox
            // 
            this.OneCh_Bit_TextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.OneCh_Bit_TextBox.Location = new System.Drawing.Point(51, 234);
            this.OneCh_Bit_TextBox.Name = "OneCh_Bit_TextBox";
            this.OneCh_Bit_TextBox.Size = new System.Drawing.Size(69, 25);
            this.OneCh_Bit_TextBox.TabIndex = 57;
            this.OneCh_Bit_TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Use_Default_CheckBox
            // 
            this.Use_Default_CheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Use_Default_CheckBox.AutoSize = true;
            this.Use_Default_CheckBox.Font = new System.Drawing.Font("Calibri", 11F);
            this.Use_Default_CheckBox.Location = new System.Drawing.Point(24, 34);
            this.Use_Default_CheckBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Use_Default_CheckBox.Name = "Use_Default_CheckBox";
            this.Use_Default_CheckBox.Size = new System.Drawing.Size(99, 22);
            this.Use_Default_CheckBox.TabIndex = 53;
            this.Use_Default_CheckBox.Text = "Use Default";
            this.Use_Default_CheckBox.UseVisualStyleBackColor = true;
            this.Use_Default_CheckBox.CheckedChanged += new System.EventHandler(this.Use_Default_CheckBox_CheckedChanged);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 11F);
            this.label3.Location = new System.Drawing.Point(48, 126);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 18);
            this.label3.TabIndex = 56;
            this.label3.Text = "Rate";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 11F);
            this.label2.Location = new System.Drawing.Point(21, 59);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 18);
            this.label2.TabIndex = 55;
            this.label2.Text = "9 Channels";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Calibri", 11F);
            this.label1.Location = new System.Drawing.Point(48, 77);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 18);
            this.label1.TabIndex = 54;
            this.label1.Text = "Bit";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // NineCh_Rate_TextBox
            // 
            this.NineCh_Rate_TextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NineCh_Rate_TextBox.Location = new System.Drawing.Point(51, 147);
            this.NineCh_Rate_TextBox.Name = "NineCh_Rate_TextBox";
            this.NineCh_Rate_TextBox.Size = new System.Drawing.Size(69, 25);
            this.NineCh_Rate_TextBox.TabIndex = 52;
            this.NineCh_Rate_TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // NineCh_Bit_TextBox
            // 
            this.NineCh_Bit_TextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NineCh_Bit_TextBox.Location = new System.Drawing.Point(51, 98);
            this.NineCh_Bit_TextBox.Name = "NineCh_Bit_TextBox";
            this.NineCh_Bit_TextBox.Size = new System.Drawing.Size(69, 25);
            this.NineCh_Bit_TextBox.TabIndex = 51;
            this.NineCh_Bit_TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // AddTask_Tab
            // 
            this.AddTask_Tab.Controls.Add(this.panel1);
            this.AddTask_Tab.Location = new System.Drawing.Point(4, 27);
            this.AddTask_Tab.Name = "AddTask_Tab";
            this.AddTask_Tab.Padding = new System.Windows.Forms.Padding(3);
            this.AddTask_Tab.Size = new System.Drawing.Size(611, 441);
            this.AddTask_Tab.TabIndex = 3;
            this.AddTask_Tab.Text = "Add Task";
            this.AddTask_Tab.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.groupBox4);
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.Start_AddTask_Btn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(605, 435);
            this.panel1.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.Browse_Task_Source_Btn);
            this.groupBox4.Controls.Add(this.Task_Source_TextBox);
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(29, 155);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(540, 119);
            this.groupBox4.TabIndex = 65;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Task";
            // 
            // Browse_Task_Source_Btn
            // 
            this.Browse_Task_Source_Btn.Font = new System.Drawing.Font("Calibri", 11F);
            this.Browse_Task_Source_Btn.Location = new System.Drawing.Point(453, 34);
            this.Browse_Task_Source_Btn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Browse_Task_Source_Btn.Name = "Browse_Task_Source_Btn";
            this.Browse_Task_Source_Btn.Size = new System.Drawing.Size(65, 28);
            this.Browse_Task_Source_Btn.TabIndex = 67;
            this.Browse_Task_Source_Btn.Text = "Browse";
            this.Browse_Task_Source_Btn.UseVisualStyleBackColor = true;
            this.Browse_Task_Source_Btn.Click += new System.EventHandler(this.Browse_Task_Source_Btn_Click);
            // 
            // Task_Source_TextBox
            // 
            this.Task_Source_TextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Task_Source_TextBox.Font = new System.Drawing.Font("Calibri", 10F);
            this.Task_Source_TextBox.Location = new System.Drawing.Point(114, 34);
            this.Task_Source_TextBox.Name = "Task_Source_TextBox";
            this.Task_Source_TextBox.Size = new System.Drawing.Size(319, 24);
            this.Task_Source_TextBox.TabIndex = 65;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Calibri", 11F);
            this.label13.Location = new System.Drawing.Point(33, 34);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(74, 36);
            this.label13.TabIndex = 63;
            this.label13.Text = "Source List\r\n(txt file)";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.Browse_Keyword_Sample_Btn);
            this.groupBox3.Controls.Add(this.Browse_Keyword_Source_Btn);
            this.groupBox3.Controls.Add(this.Keyword_Sample_TextBox);
            this.groupBox3.Controls.Add(this.Keyword_Source_TextBox);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(29, 14);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(540, 122);
            this.groupBox3.TabIndex = 64;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Keyword";
            // 
            // Browse_Keyword_Sample_Btn
            // 
            this.Browse_Keyword_Sample_Btn.Font = new System.Drawing.Font("Calibri", 11F);
            this.Browse_Keyword_Sample_Btn.Location = new System.Drawing.Point(453, 75);
            this.Browse_Keyword_Sample_Btn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Browse_Keyword_Sample_Btn.Name = "Browse_Keyword_Sample_Btn";
            this.Browse_Keyword_Sample_Btn.Size = new System.Drawing.Size(65, 28);
            this.Browse_Keyword_Sample_Btn.TabIndex = 61;
            this.Browse_Keyword_Sample_Btn.Text = "Browse";
            this.Browse_Keyword_Sample_Btn.UseVisualStyleBackColor = true;
            this.Browse_Keyword_Sample_Btn.Click += new System.EventHandler(this.Browse_Keyword_Sample_Btn_Click);
            // 
            // Browse_Keyword_Source_Btn
            // 
            this.Browse_Keyword_Source_Btn.Font = new System.Drawing.Font("Calibri", 11F);
            this.Browse_Keyword_Source_Btn.Location = new System.Drawing.Point(453, 39);
            this.Browse_Keyword_Source_Btn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Browse_Keyword_Source_Btn.Name = "Browse_Keyword_Source_Btn";
            this.Browse_Keyword_Source_Btn.Size = new System.Drawing.Size(65, 28);
            this.Browse_Keyword_Source_Btn.TabIndex = 60;
            this.Browse_Keyword_Source_Btn.Text = "Browse";
            this.Browse_Keyword_Source_Btn.UseVisualStyleBackColor = true;
            this.Browse_Keyword_Source_Btn.Click += new System.EventHandler(this.Browse_Keyword_Source_Btn_Click);
            // 
            // Keyword_Sample_TextBox
            // 
            this.Keyword_Sample_TextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Keyword_Sample_TextBox.Font = new System.Drawing.Font("Calibri", 10F);
            this.Keyword_Sample_TextBox.Location = new System.Drawing.Point(114, 75);
            this.Keyword_Sample_TextBox.Name = "Keyword_Sample_TextBox";
            this.Keyword_Sample_TextBox.Size = new System.Drawing.Size(319, 24);
            this.Keyword_Sample_TextBox.TabIndex = 59;
            // 
            // Keyword_Source_TextBox
            // 
            this.Keyword_Source_TextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Keyword_Source_TextBox.Font = new System.Drawing.Font("Calibri", 10F);
            this.Keyword_Source_TextBox.Location = new System.Drawing.Point(114, 40);
            this.Keyword_Source_TextBox.Name = "Keyword_Source_TextBox";
            this.Keyword_Source_TextBox.Size = new System.Drawing.Size(319, 24);
            this.Keyword_Source_TextBox.TabIndex = 58;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Calibri", 11F);
            this.label11.Location = new System.Drawing.Point(13, 77);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(94, 18);
            this.label11.TabIndex = 57;
            this.label11.Text = "Sample Count";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Calibri", 11F);
            this.label10.Location = new System.Drawing.Point(57, 43);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(50, 18);
            this.label10.TabIndex = 56;
            this.label10.Text = "Source";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Start_AddTask_Btn
            // 
            this.Start_AddTask_Btn.Font = new System.Drawing.Font("Calibri", 11F);
            this.Start_AddTask_Btn.Location = new System.Drawing.Point(482, 294);
            this.Start_AddTask_Btn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Start_AddTask_Btn.Name = "Start_AddTask_Btn";
            this.Start_AddTask_Btn.Size = new System.Drawing.Size(65, 28);
            this.Start_AddTask_Btn.TabIndex = 63;
            this.Start_AddTask_Btn.Text = "Start";
            this.Start_AddTask_Btn.UseVisualStyleBackColor = true;
            this.Start_AddTask_Btn.Click += new System.EventHandler(this.Start_AddTask_Btn_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.spComboBox);
            this.groupBox2.Controls.Add(this.SPCheckBox);
            this.groupBox2.Controls.Add(this.Mapping_Btn);
            this.groupBox2.Controls.Add(this.Device_Btn);
            this.groupBox2.Controls.Add(this.Play_Stop_Btn);
            this.groupBox2.Location = new System.Drawing.Point(122, 24);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(117, 228);
            this.groupBox2.TabIndex = 67;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "FireFace";
            // 
            // spComboBox
            // 
            this.spComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.spComboBox.Font = new System.Drawing.Font("Calibri", 11F);
            this.spComboBox.FormattingEnabled = true;
            this.spComboBox.Location = new System.Drawing.Point(7, 186);
            this.spComboBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.spComboBox.Name = "spComboBox";
            this.spComboBox.Size = new System.Drawing.Size(104, 26);
            this.spComboBox.TabIndex = 45;
            this.spComboBox.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.comboBox_DrawItem);
            this.spComboBox.DropDown += new System.EventHandler(this.combobox_DropdownChanged);
            this.spComboBox.DropDownClosed += new System.EventHandler(this.combobox_DropdownClosed);
            // 
            // SPCheckBox
            // 
            this.SPCheckBox.AutoSize = true;
            this.SPCheckBox.Font = new System.Drawing.Font("Calibri", 11F);
            this.SPCheckBox.Location = new System.Drawing.Point(7, 158);
            this.SPCheckBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.SPCheckBox.Name = "SPCheckBox";
            this.SPCheckBox.Size = new System.Drawing.Size(104, 22);
            this.SPCheckBox.TabIndex = 44;
            this.SPCheckBox.Text = "Sync Pattern";
            this.SPCheckBox.UseVisualStyleBackColor = true;
            this.SPCheckBox.CheckedChanged += new System.EventHandler(this.SPCheckBox_CheckedChanged);
            // 
            // Mapping_Btn
            // 
            this.Mapping_Btn.Location = new System.Drawing.Point(24, 75);
            this.Mapping_Btn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Mapping_Btn.Name = "Mapping_Btn";
            this.Mapping_Btn.Size = new System.Drawing.Size(71, 29);
            this.Mapping_Btn.TabIndex = 43;
            this.Mapping_Btn.Text = "Mapping";
            this.Mapping_Btn.UseVisualStyleBackColor = true;
            this.Mapping_Btn.Click += new System.EventHandler(this.Mapping_Btn_Click);
            // 
            // Device_Btn
            // 
            this.Device_Btn.Font = new System.Drawing.Font("Calibri", 11F);
            this.Device_Btn.Location = new System.Drawing.Point(24, 32);
            this.Device_Btn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Device_Btn.Name = "Device_Btn";
            this.Device_Btn.Size = new System.Drawing.Size(71, 28);
            this.Device_Btn.TabIndex = 42;
            this.Device_Btn.Text = "Device";
            this.Device_Btn.UseVisualStyleBackColor = true;
            this.Device_Btn.Click += new System.EventHandler(this.Device_Btn_Click);
            // 
            // Play_Stop_Btn
            // 
            this.Play_Stop_Btn.Font = new System.Drawing.Font("Calibri", 11F);
            this.Play_Stop_Btn.Location = new System.Drawing.Point(24, 115);
            this.Play_Stop_Btn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Play_Stop_Btn.Name = "Play_Stop_Btn";
            this.Play_Stop_Btn.Size = new System.Drawing.Size(71, 29);
            this.Play_Stop_Btn.TabIndex = 41;
            this.Play_Stop_Btn.Text = "Play";
            this.Play_Stop_Btn.UseVisualStyleBackColor = true;
            this.Play_Stop_Btn.Click += new System.EventHandler(this.Play_Stop_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Dot_Pull);
            this.groupBox1.Controls.Add(this.Dot_Record_Stop);
            this.groupBox1.Controls.Add(this.Dot_Clear);
            this.groupBox1.Controls.Add(this.Dot_Root);
            this.groupBox1.Location = new System.Drawing.Point(12, 24);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(104, 228);
            this.groupBox1.TabIndex = 65;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Echo Dot";
            // 
            // Dot_Pull
            // 
            this.Dot_Pull.Font = new System.Drawing.Font("Calibri", 11F);
            this.Dot_Pull.Location = new System.Drawing.Point(15, 158);
            this.Dot_Pull.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Dot_Pull.Name = "Dot_Pull";
            this.Dot_Pull.Size = new System.Drawing.Size(73, 29);
            this.Dot_Pull.TabIndex = 27;
            this.Dot_Pull.Text = "Pull";
            this.Dot_Pull.UseVisualStyleBackColor = true;
            this.Dot_Pull.Click += new System.EventHandler(this.Dot_Pull_Click);
            // 
            // Dot_Record_Stop
            // 
            this.Dot_Record_Stop.Font = new System.Drawing.Font("Calibri", 11F);
            this.Dot_Record_Stop.Location = new System.Drawing.Point(15, 115);
            this.Dot_Record_Stop.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Dot_Record_Stop.Name = "Dot_Record_Stop";
            this.Dot_Record_Stop.Size = new System.Drawing.Size(73, 29);
            this.Dot_Record_Stop.TabIndex = 26;
            this.Dot_Record_Stop.Text = "Record";
            this.Dot_Record_Stop.UseVisualStyleBackColor = true;
            this.Dot_Record_Stop.Click += new System.EventHandler(this.Dot_Record_Stop_Click);
            // 
            // Dot_Clear
            // 
            this.Dot_Clear.Font = new System.Drawing.Font("Calibri", 11F);
            this.Dot_Clear.Location = new System.Drawing.Point(15, 75);
            this.Dot_Clear.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Dot_Clear.Name = "Dot_Clear";
            this.Dot_Clear.Size = new System.Drawing.Size(73, 29);
            this.Dot_Clear.TabIndex = 25;
            this.Dot_Clear.Text = "Clear";
            this.Dot_Clear.UseVisualStyleBackColor = true;
            this.Dot_Clear.Click += new System.EventHandler(this.Dot_Clear_Click);
            // 
            // Dot_Root
            // 
            this.Dot_Root.Font = new System.Drawing.Font("Calibri", 11F);
            this.Dot_Root.Location = new System.Drawing.Point(15, 32);
            this.Dot_Root.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Dot_Root.Name = "Dot_Root";
            this.Dot_Root.Size = new System.Drawing.Size(73, 28);
            this.Dot_Root.TabIndex = 24;
            this.Dot_Root.TabStop = false;
            this.Dot_Root.Text = "Root Remount";
            this.Dot_Root.UseVisualStyleBackColor = true;
            this.Dot_Root.Click += new System.EventHandler(this.Dot_Root_Click);
            // 
            // XCorr_Btn
            // 
            this.XCorr_Btn.Font = new System.Drawing.Font("Calibri", 11F);
            this.XCorr_Btn.Location = new System.Drawing.Point(31, 386);
            this.XCorr_Btn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.XCorr_Btn.Name = "XCorr_Btn";
            this.XCorr_Btn.Size = new System.Drawing.Size(71, 29);
            this.XCorr_Btn.TabIndex = 15;
            this.XCorr_Btn.Text = "XCorr";
            this.XCorr_Btn.UseVisualStyleBackColor = true;
            this.XCorr_Btn.Click += new System.EventHandler(this.XCorr_Click);
            // 
            // Exit_Btn
            // 
            this.Exit_Btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Exit_Btn.Font = new System.Drawing.Font("Calibri", 11F);
            this.Exit_Btn.Location = new System.Drawing.Point(31, 430);
            this.Exit_Btn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Exit_Btn.Name = "Exit_Btn";
            this.Exit_Btn.Size = new System.Drawing.Size(71, 29);
            this.Exit_Btn.TabIndex = 1;
            this.Exit_Btn.Text = "Exit";
            this.Exit_Btn.UseVisualStyleBackColor = true;
            this.Exit_Btn.Click += new System.EventHandler(this.Exit_Click);
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(914, 512);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Calibri", 10F);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MinimumSize = new System.Drawing.Size(614, 465);
            this.Name = "MainForm";
            this.Text = "Automation Test Program";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.Command_Tab.ResumeLayout(false);
            this.Data_Tab.ResumeLayout(false);
            this.Dataset_splitContainer.Panel1.ResumeLayout(false);
            this.Dataset_splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Dataset_splitContainer)).EndInit();
            this.Dataset_splitContainer.ResumeLayout(false);
            this.Dataset_tableLayoutPanel.ResumeLayout(false);
            this.PCM2WAV_tab.ResumeLayout(false);
            this.PCM2WAV_SplitContainer.Panel1.ResumeLayout(false);
            this.PCM2WAV_SplitContainer.Panel2.ResumeLayout(false);
            this.PCM2WAV_SplitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PCM2WAV_SplitContainer)).EndInit();
            this.PCM2WAV_SplitContainer.ResumeLayout(false);
            this.AddTask_Tab.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button Exit_Btn;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.Button XCorr_Btn;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage Command_Tab;
        private System.Windows.Forms.RichTextBox cmdTextBox;
        private System.Windows.Forms.TabPage PCM2WAV_tab;
        private System.Windows.Forms.TabPage Data_Tab;
        private System.Windows.Forms.SplitContainer Dataset_splitContainer;
        private System.Windows.Forms.ColumnHeader num;
        public System.Windows.Forms.ListView DataList;
        private System.Windows.Forms.TableLayoutPanel Dataset_tableLayoutPanel;
        private System.Windows.Forms.Button Save_Btn;
        private System.Windows.Forms.Button Clear_All_Btn;
        private System.Windows.Forms.Button Load_Btn;
        private System.Windows.Forms.Button Clear_Data_Btn;
        private System.Windows.Forms.Button Add_Data_Btn;
        private System.Windows.Forms.TabPage AddTask_Tab;
        private System.Windows.Forms.SplitContainer PCM2WAV_SplitContainer;
        private System.Windows.Forms.RichTextBox filenameBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox OneCh_Rate_TextBox;
        private System.Windows.Forms.TextBox OneCh_Bit_TextBox;
        private System.Windows.Forms.CheckBox Use_Default_CheckBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox NineCh_Rate_TextBox;
        private System.Windows.Forms.TextBox NineCh_Bit_TextBox;
        private System.Windows.Forms.Button Convert;
        private System.Windows.Forms.Button Browse;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button Start_AddTask_Btn;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox spComboBox;
        private System.Windows.Forms.CheckBox SPCheckBox;
        private System.Windows.Forms.Button Mapping_Btn;
        private System.Windows.Forms.Button Device_Btn;
        private System.Windows.Forms.Button Play_Stop_Btn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button Dot_Pull;
        private System.Windows.Forms.Button Dot_Record_Stop;
        private System.Windows.Forms.Button Dot_Clear;
        private System.Windows.Forms.Button Dot_Root;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button Browse_Task_Source_Btn;
        private System.Windows.Forms.TextBox Task_Source_TextBox;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button Browse_Keyword_Sample_Btn;
        private System.Windows.Forms.Button Browse_Keyword_Source_Btn;
        private System.Windows.Forms.TextBox Keyword_Sample_TextBox;
        private System.Windows.Forms.TextBox Keyword_Source_TextBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
    }
}

