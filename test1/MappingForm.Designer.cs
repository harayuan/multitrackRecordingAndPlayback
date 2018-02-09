namespace Automation
{
    partial class MappingForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Cancel_Btn = new System.Windows.Forms.Button();
            this.OK_Btn = new System.Windows.Forms.Button();
            this.inputDataGridView = new System.Windows.Forms.DataGridView();
            this.outputDataGridView = new System.Windows.Forms.DataGridView();
            this.AddOutType_Btn = new System.Windows.Forms.Button();
            this.OutComboBox = new System.Windows.Forms.ComboBox();
            this.DeleteOutType_Btn = new System.Windows.Forms.Button();
            this.AddOutput_Btn = new System.Windows.Forms.Button();
            this.DeleteMic_Btn = new System.Windows.Forms.Button();
            this.AddMic_Btn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.inputDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.outputDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // Cancel_Btn
            // 
            this.Cancel_Btn.Location = new System.Drawing.Point(562, 71);
            this.Cancel_Btn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Cancel_Btn.Name = "Cancel_Btn";
            this.Cancel_Btn.Size = new System.Drawing.Size(88, 29);
            this.Cancel_Btn.TabIndex = 24;
            this.Cancel_Btn.Text = "Cancel";
            this.Cancel_Btn.UseVisualStyleBackColor = true;
            this.Cancel_Btn.Click += new System.EventHandler(this.Cancel_Btn_Click);
            // 
            // OK_Btn
            // 
            this.OK_Btn.Location = new System.Drawing.Point(562, 34);
            this.OK_Btn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.OK_Btn.Name = "OK_Btn";
            this.OK_Btn.Size = new System.Drawing.Size(88, 29);
            this.OK_Btn.TabIndex = 23;
            this.OK_Btn.Text = "OK";
            this.OK_Btn.UseVisualStyleBackColor = true;
            this.OK_Btn.Click += new System.EventHandler(this.OK_Btn_Click);
            // 
            // inputDataGridView
            // 
            this.inputDataGridView.AllowUserToAddRows = false;
            this.inputDataGridView.AllowUserToDeleteRows = false;
            this.inputDataGridView.AllowUserToResizeRows = false;
            this.inputDataGridView.BackgroundColor = System.Drawing.SystemColors.Control;
            this.inputDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.inputDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.inputDataGridView.GridColor = System.Drawing.SystemColors.ControlLight;
            this.inputDataGridView.Location = new System.Drawing.Point(12, 34);
            this.inputDataGridView.Name = "inputDataGridView";
            this.inputDataGridView.RowHeadersVisible = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Calibri", 9.75F);
            this.inputDataGridView.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.inputDataGridView.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Calibri", 9.75F);
            this.inputDataGridView.RowTemplate.Height = 24;
            this.inputDataGridView.Size = new System.Drawing.Size(264, 229);
            this.inputDataGridView.TabIndex = 26;
            this.inputDataGridView.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellEnter);
            // 
            // outputDataGridView
            // 
            this.outputDataGridView.AllowUserToAddRows = false;
            this.outputDataGridView.AllowUserToDeleteRows = false;
            this.outputDataGridView.AllowUserToResizeRows = false;
            this.outputDataGridView.BackgroundColor = System.Drawing.SystemColors.Control;
            this.outputDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Calibri", 10F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.outputDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.outputDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.outputDataGridView.GridColor = System.Drawing.SystemColors.ControlLight;
            this.outputDataGridView.Location = new System.Drawing.Point(282, 34);
            this.outputDataGridView.Name = "outputDataGridView";
            this.outputDataGridView.RowHeadersVisible = false;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Calibri", 9.75F);
            this.outputDataGridView.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.outputDataGridView.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Calibri", 9.75F);
            this.outputDataGridView.RowTemplate.Height = 24;
            this.outputDataGridView.Size = new System.Drawing.Size(264, 229);
            this.outputDataGridView.TabIndex = 27;
            this.outputDataGridView.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellEnter);
            // 
            // AddOutType_Btn
            // 
            this.AddOutType_Btn.Location = new System.Drawing.Point(282, 269);
            this.AddOutType_Btn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.AddOutType_Btn.Name = "AddOutType_Btn";
            this.AddOutType_Btn.Size = new System.Drawing.Size(68, 29);
            this.AddOutType_Btn.TabIndex = 29;
            this.AddOutType_Btn.Text = "Add Type";
            this.AddOutType_Btn.UseVisualStyleBackColor = true;
            this.AddOutType_Btn.Click += new System.EventHandler(this.AddOutType_Btn_Click);
            // 
            // OutComboBox
            // 
            this.OutComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.OutComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.OutComboBox.FormattingEnabled = true;
            this.OutComboBox.Location = new System.Drawing.Point(423, 273);
            this.OutComboBox.Name = "OutComboBox";
            this.OutComboBox.Size = new System.Drawing.Size(121, 23);
            this.OutComboBox.TabIndex = 31;
            // 
            // DeleteOutType_Btn
            // 
            this.DeleteOutType_Btn.Location = new System.Drawing.Point(357, 269);
            this.DeleteOutType_Btn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.DeleteOutType_Btn.Name = "DeleteOutType_Btn";
            this.DeleteOutType_Btn.Size = new System.Drawing.Size(60, 29);
            this.DeleteOutType_Btn.TabIndex = 32;
            this.DeleteOutType_Btn.Text = "Delete";
            this.DeleteOutType_Btn.UseVisualStyleBackColor = true;
            this.DeleteOutType_Btn.Click += new System.EventHandler(this.DeleteOutType_Btn_Click);
            // 
            // AddOutput_Btn
            // 
            this.AddOutput_Btn.Location = new System.Drawing.Point(282, 279);
            this.AddOutput_Btn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.AddOutput_Btn.Name = "AddOutput_Btn";
            this.AddOutput_Btn.Size = new System.Drawing.Size(68, 29);
            this.AddOutput_Btn.TabIndex = 29;
            this.AddOutput_Btn.Text = "Add Type";
            this.AddOutput_Btn.UseVisualStyleBackColor = true;
            this.AddOutput_Btn.Click += new System.EventHandler(this.AddOutType_Btn_Click);
            // 
            // DeleteMic_Btn
            // 
            this.DeleteMic_Btn.Location = new System.Drawing.Point(88, 269);
            this.DeleteMic_Btn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.DeleteMic_Btn.Name = "DeleteMic_Btn";
            this.DeleteMic_Btn.Size = new System.Drawing.Size(60, 29);
            this.DeleteMic_Btn.TabIndex = 35;
            this.DeleteMic_Btn.Text = "Delete";
            this.DeleteMic_Btn.UseVisualStyleBackColor = true;
            this.DeleteMic_Btn.Click += new System.EventHandler(this.DeleteMic_Btn_Click);
            // 
            // AddMic_Btn
            // 
            this.AddMic_Btn.Location = new System.Drawing.Point(13, 269);
            this.AddMic_Btn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.AddMic_Btn.Name = "AddMic_Btn";
            this.AddMic_Btn.Size = new System.Drawing.Size(68, 29);
            this.AddMic_Btn.TabIndex = 33;
            this.AddMic_Btn.Text = "Add Type";
            this.AddMic_Btn.UseVisualStyleBackColor = true;
            this.AddMic_Btn.Click += new System.EventHandler(this.AddMic_Btn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 17);
            this.label1.TabIndex = 36;
            this.label1.Text = "Input";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(282, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 17);
            this.label2.TabIndex = 37;
            this.label2.Text = "Output";
            // 
            // MappingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(659, 316);
            this.ControlBox = false;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DeleteMic_Btn);
            this.Controls.Add(this.AddMic_Btn);
            this.Controls.Add(this.DeleteOutType_Btn);
            this.Controls.Add(this.OutComboBox);
            this.Controls.Add(this.AddOutType_Btn);
            this.Controls.Add(this.outputDataGridView);
            this.Controls.Add(this.inputDataGridView);
            this.Controls.Add(this.Cancel_Btn);
            this.Controls.Add(this.OK_Btn);
            this.Font = new System.Drawing.Font("Calibri", 10F);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "MappingForm";
            this.Text = "Channel Mapping";
            ((System.ComponentModel.ISupportInitialize)(this.inputDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.outputDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button Cancel_Btn;
        private System.Windows.Forms.Button OK_Btn;
        private System.Windows.Forms.DataGridView inputDataGridView;
        private System.Windows.Forms.DataGridView outputDataGridView;
        private System.Windows.Forms.Button AddOutType_Btn;
        private System.Windows.Forms.ComboBox OutComboBox;
        private System.Windows.Forms.Button DeleteOutType_Btn;
        private System.Windows.Forms.Button AddOutput_Btn;
        private System.Windows.Forms.Button DeleteMic_Btn;
        private System.Windows.Forms.Button AddMic_Btn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}