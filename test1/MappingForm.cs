using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Automation
{
    public partial class MappingForm : Form
    {
        MainForm mainForm;
        public MappingForm(MainForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;

            //inputDataGridView
            inputDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            inputDataGridView.AllowUserToResizeRows = false;
            inputDataGridView.Columns.Add("typesColumn", "Types");
            var inputsColumn = inputDataGridView.Columns["typesColumn"];
            inputsColumn.ReadOnly = true;
            inputsColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
            inputsColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            foreach (var type in mainForm.inputChannelTypes)
            {
                inputDataGridView.Rows.Add(type);
            }

            using (DataGridViewComboBoxColumn comboColumn = new DataGridViewComboBoxColumn())
            {
                comboColumn.Name = "inputsColumn";
                comboColumn.HeaderText = "Device Inputs";
                comboColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
                comboColumn.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
                comboColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                comboColumn.DefaultCellStyle.Padding = new Padding(5, 0, 8, 0);
                comboColumn.FlatStyle = FlatStyle.Flat;
                foreach (var name in mainForm.inputChannelNames)
                {
                    comboColumn.Items.Add(name);
                }
                inputDataGridView.Columns.Add(comboColumn);
            }
            //load inputDataGrid combobox value
            for (int i = 0; i < inputDataGridView.Rows.Count; i++)
            {
                inputDataGridView.Rows[i].Cells[1].Value = mainForm.inputChannelNames.ElementAt(mainForm.inputMappingData[i]);
            }

            //outputDataGridView
            outputDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            outputDataGridView.AllowUserToResizeRows = false;
            outputDataGridView.Columns.Add("typesColumn", "Types");
            var outputsColumn = outputDataGridView.Columns["typesColumn"];
            outputsColumn.ReadOnly = true;
            outputsColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
            outputsColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            foreach (var type in mainForm.outputChannelTypes)
            {
                outputDataGridView.Rows.Add(type);
            }

            using (DataGridViewComboBoxColumn comboColumn = new DataGridViewComboBoxColumn())
            {
                comboColumn.Name = "outputsColumn";
                comboColumn.HeaderText = "Device Outputs";
                comboColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
                comboColumn.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
                comboColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                comboColumn.DefaultCellStyle.Padding = new Padding(5, 0, 8, 0);
                comboColumn.FlatStyle = FlatStyle.Flat;
                foreach (var name in mainForm.outputChannelNames)
                {
                    comboColumn.Items.Add(name);
                }
                outputDataGridView.Columns.Add(comboColumn);
            }
            //load outputDataGrid combobox value
            for (int i = 0; i < outputDataGridView.Rows.Count; i++)
            {
                outputDataGridView.Rows[i].Cells[1].Value = mainForm.outputChannelNames.ElementAt(mainForm.outputMappingData[i]);
            }

            //init comboboxs
            OutComboBox.Items.Add("Speech");
            OutComboBox.Items.Add("Noise");
            OutComboBox.SelectedIndex = 0;

        }

        public void OK_Btn_Click(object sender, EventArgs e)
        {
            if (getOutChannelTypeCount("Speech") == 0)
            {
                MessageBox.Show("There must be at least one Speech in the Types Column", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //add one speech row
                var count = getOutChannelTypeCount("Speech");
                outputDataGridView.Rows.Insert(count, $"Speech{count + 1}");
                outputDataGridView.Rows[count].Cells[1].Value = mainForm.outputChannelNames[0];
                return;
            }
            var lastSpeechCnt = mainForm.outputChannelTypes.Sum(t => t.Contains("Speech") ? 1 : 0);
            var lastNoiseCnt = mainForm.outputChannelTypes.Sum(t => t.Contains("Noise") ? 1 : 0);
            bool hasChanged = getOutChannelTypeCount("Speech") != lastSpeechCnt || getOutChannelTypeCount("Noise") != lastNoiseCnt;
            if (mainForm.DataList.Columns.Count != 1 && hasChanged)
            {
                DialogResult dialogResult = MessageBox.Show("The number of Speech or Noise has been changed. Data in the \"Data Set\" tab may be changed or lost. ", "WARNING", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.No)
                {
                    return;
                }
            }

            mainForm.inputChannelTypes.Clear();
            mainForm.inputMappingData.Clear();
            for (int i = 0; i < inputDataGridView.Rows.Count; i++)
            {
                //update type value
                mainForm.inputChannelTypes.Add(inputDataGridView.Rows[i].Cells[0].Value.ToString());
                //update channel name
                var name = inputDataGridView.Rows[i].Cells[1].Value.ToString();
                mainForm.inputMappingData.Add(mainForm.inputChannelNames.ToList().IndexOf(name));
            }
            mainForm.outputChannelTypes.Clear();
            mainForm.outputMappingData.Clear();
            for (int i = 0; i < outputDataGridView.Rows.Count; i++)
            {
                //update type value
                mainForm.outputChannelTypes.Add(outputDataGridView.Rows[i].Cells[0].Value.ToString());
                //update channel name
                var name = outputDataGridView.Rows[i].Cells[1].Value.ToString();
                mainForm.outputMappingData.Add(mainForm.outputChannelNames.ToList().IndexOf(name));
            }
            mainForm.update_dataset_control_panel();
            this.Close();
        }

        private void Cancel_Btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
                
        // select on first click
        private void dataGridView_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            bool validClick = (e.RowIndex != -1 && e.ColumnIndex != -1); //Make sure the clicked row/column is valid.
            var datagridview = sender as DataGridView;

            // Check to make sure the cell clicked is the cell containing the combobox 
            if (datagridview.Columns[e.ColumnIndex] is DataGridViewComboBoxColumn && validClick)
            {
                datagridview.BeginEdit(true);
                ((ComboBox)datagridview.EditingControl).DroppedDown = true;
            }
        }

        private void AddMic_Btn_Click(object sender, EventArgs e)
        {
            var count = inputDataGridView.Rows.Count;
            if (count > 30)
            {
                MessageBox.Show("Program only supports up to 30 tracks!", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            inputDataGridView.Rows.Insert(count, $"Mic{count + 1}");
            inputDataGridView.Rows[count].Cells[1].Value = mainForm.inputChannelNames[0];
        }

        private void DeleteMic_Btn_Click(object sender, EventArgs e)
        {
            for (int i = inputDataGridView.SelectedRows.Count - 1; i >= 0; i--)
            {
                inputDataGridView.Rows.Remove(inputDataGridView.SelectedRows[i]);
            }
            //update the type column
            var micCount = inputDataGridView.Rows.Count;
            for (int i = 0; i < micCount; i++)
            {
                inputDataGridView.Rows[i].Cells[0].Value = $"Mic{i + 1}";
            }
        }

        private void AddOutType_Btn_Click(object sender, EventArgs e)
        {
            if (getOutChannelTypeCount("Speech") + getOutChannelTypeCount("Noise") > 30)
            {
                MessageBox.Show("Program only supports up to 30 tracks!", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selected = OutComboBox.SelectedItem.ToString();
            if (selected.Equals("Speech"))
            {
                var count = getOutChannelTypeCount("Speech");
                outputDataGridView.Rows.Insert(count, $"Speech{count + 1}");
                outputDataGridView.Rows[count].Cells[1].Value = mainForm.outputChannelNames[0];
            }
            else if (selected.Equals("Noise"))
            {
                var count = getOutChannelTypeCount("Noise");
                var index = getOutChannelTypeCount("Speech") + count;
                outputDataGridView.Rows.Insert(index, $"Noise{count + 1}");
                outputDataGridView.Rows[index].Cells[1].Value = mainForm.outputChannelNames[0];
            }
        }

        private void DeleteOutType_Btn_Click(object sender, EventArgs e)
        {
            for(int i = outputDataGridView.SelectedRows.Count - 1; i >= 0 ; i--)
            {
                outputDataGridView.Rows.Remove(outputDataGridView.SelectedRows[i]);
            }
            //update the type column
            var speechCount = getOutChannelTypeCount("Speech");
            var noiseCount = getOutChannelTypeCount("Noise");
            for(int i = 0; i < speechCount; i++)
            {
                outputDataGridView.Rows[i].Cells[0].Value = $"Speech{i + 1}";
            }
            for (int i = speechCount; i < speechCount + noiseCount; i++)
            {
                outputDataGridView.Rows[i].Cells[0].Value = $"Noise{i-speechCount + 1}";
            }
        }
        
        private int getOutChannelTypeCount(String type)
        {
            int count = 0;
            for(int i = 0; i < outputDataGridView.Rows.Count; i++)
            {
                if (outputDataGridView.Rows[i].Cells[0].Value.ToString().Contains(type))
                    count++;
            }
            return count;
        }
    }
}
