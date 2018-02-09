using System;
using System.IO;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using NAudio.Wave.Asio;
using NAudio.Wave.SampleProviders;
using NAudio.Wave;
using System.Media;
using Automation.Compute;
using Automation.Player;
using System.Drawing;
using System.Diagnostics;
using System.Threading;

namespace Automation
{
    public partial class MainForm : Form
    {
        public String[] inputChannelNames { get; set; }
        public String[] outputChannelNames { get; set; }
        public List<String> inputChannelTypes { get; set; }
        public List<String> outputChannelTypes { get; set; }
        public List<int> inputMappingData { get; set; }
        public List<int> outputMappingData { get; set; }
        private AudioPlaybackEngine playbackEngine;
        private bool echoDotStarted;
        private ToolTip comboToolTip;
        
        public MainForm()
        {
            InitializeComponent();

            Mapping_Btn.Enabled = false;
            Play_Stop_Btn.Enabled = false;
            SPCheckBox.Enabled = false;
            spComboBox.Enabled = false;
            foreach (var c in Dataset_tableLayoutPanel.Controls.OfType<Button>()) { c.Enabled = false; }
            Use_Default_CheckBox.Checked = true;

            DirectoryInfo dinfo = new DirectoryInfo(Directory.GetCurrentDirectory());
            bool exists = System.IO.Directory.Exists($"{dinfo.ToString()}/sync_pattern");
            if (!exists)
                System.IO.Directory.CreateDirectory($"{dinfo.ToString()}/sync_pattern");
            FileInfo[] sp_files = dinfo.GetFiles(@"sync_pattern/*.wav");

            //list sp files
            foreach (FileInfo file in sp_files)
            {
                spComboBox.Items.Add(file.Name);
            }
            spComboBox.SelectedIndex = Math.Min(sp_files.Length - 1, 0);

            playbackEngine = null;
            echoDotStarted = false;

            comboToolTip = new ToolTip();
        }

        private void cmdTextBox_TextChanged(object sender, EventArgs e)
        {
            cmdTextBox.Focus();
            cmdTextBox.SelectionStart = cmdTextBox.Text.Length;
            cmdTextBox.ScrollToCaret();
            tabControl1.SelectedTab = Command_Tab;
        }

        private void combobox_DropdownChanged(object sender, EventArgs e)
        {
            ComboBox combo = sender as ComboBox;
            combo.Items.Clear();

            DirectoryInfo dinfo = new DirectoryInfo(Directory.GetCurrentDirectory());
            FileInfo[] files = null;
            if (combo.Name.Contains("Speech"))
            {
                files = dinfo.GetFiles(@"speech/*.wav");
            }
            else if(combo.Name.Contains("Noise"))
            {
                files = dinfo.GetFiles(@"noise/*.wav");
            }
            else if(combo.Name.Equals("spComboBox"))
            {
                files = dinfo.GetFiles(@"sync_pattern/*.wav");
            }
            if (files != null)
            {
                if (!combo.Name.Equals("spComboBox"))
                    combo.Items.Add("[Silence]");
                foreach (FileInfo file in files)
                {
                    combo.Items.Add(file.Name);
                }
            }
        }

        public void Mapping_Btn_Click(object sender, EventArgs e)
        {
            if (playbackEngine == null)
            {
                addText("You must select a device first\n\n", Color.Red);
                return;
            }
            MappingForm mappingForm;
            mappingForm = new MappingForm(this);
            mappingForm.Show(this);
        }

        //the last changed value of y
        //used to determine the location of the new added labels and comboboxes
        int lastY = 0;
        public void update_dataset_control_panel()
        {
            tabControl1.SelectedTab = Data_Tab;

            //clear the labels, comboboxes and listview columns
            while (Dataset_splitContainer.Panel2.Controls.OfType<Label>().Count() > 0)
            {
                Dataset_splitContainer.Panel2.Controls.Remove(Dataset_splitContainer.Panel2.Controls.OfType<Label>().ElementAt(0));
            }
            while (Dataset_splitContainer.Panel2.Controls.OfType<ComboBox>().Count() > 0)
            {
                Dataset_splitContainer.Panel2.Controls.Remove(Dataset_splitContainer.Panel2.Controls.OfType<ComboBox>().ElementAt(0));
            }
            var headers = DataList.Columns.OfType<ColumnHeader>().Select(header => header.Text).ToArray();
            var speechCnt = headers.Sum(h => h.Contains("Speech") ? 1 : 0);
            var noiseCnt = headers.Any(t => t.Contains("Noise")) ? 1 : 0;
            var newSpeechCnt = outputChannelTypes.Sum(t => t.Contains("Speech") ? 1 : 0);
            var newNoiseCnt = outputChannelTypes.Any(t => t.Contains("Noise")) ? 1 : 0;
            if (newSpeechCnt > speechCnt || newNoiseCnt > noiseCnt)
            {
                DataList.Items.Clear();
            }
            else
            {
                if (newNoiseCnt < noiseCnt)
                {
                    foreach(ListViewItem item in DataList.Items)
                    {
                        for (int i = speechCnt + noiseCnt; i >= speechCnt + newNoiseCnt + 1; i--)
                        {
                            item.SubItems.RemoveAt(i);
                        }
                    }
                    for (int i = speechCnt + noiseCnt; i >= speechCnt + newNoiseCnt + 1; i--)
                    {
                        DataList.Columns.Remove(DataList.Columns[i]);
                    }
                }
                if (newSpeechCnt < speechCnt)
                {
                    foreach (ListViewItem item in DataList.Items)
                    {
                        for (int i = speechCnt; i >= newSpeechCnt + 1; i--)
                        {
                            item.SubItems.RemoveAt(i);
                        }
                    }
                    for (int i = speechCnt; i >= newSpeechCnt + 1; i--)
                    {
                        DataList.Columns.Remove(DataList.Columns[i]);
                    }
                }
            }

            //get directory info of speech and noise folders
            DirectoryInfo dinfo = new DirectoryInfo(Directory.GetCurrentDirectory());
            String[] paths = { $"{dinfo.ToString()}/speech", $"{dinfo.ToString()}/noise"};
            foreach (var path in paths)
            {
                bool exists = System.IO.Directory.Exists(path);
                if (!exists)
                    System.IO.Directory.CreateDirectory(path);
            }
            FileInfo[] speech_files = dinfo.GetFiles(@"speech/*.wav");
            FileInfo[] noise_files = dinfo.GetFiles(@"noise/*.wav");

            //update labels, comboBoxes and listView columns
            bool hasNoise = false;
            int y = 15;
            foreach(var type in outputChannelTypes)
            {
                if (type.Contains("Noise") && hasNoise)
                    continue;
                else
                {
                    var newLabel = new Label();
                    var newComboBox = new ComboBox();

                    if (type.Contains("Noise"))
                    {
                        hasNoise = true;
                        newLabel.Text = "Noise";
                        newComboBox.Name = $"Noise_comboBox";
                        newComboBox.Items.Add("[Silence]");
                        foreach (FileInfo file in noise_files)
                        {
                            newComboBox.Items.Add(file.Name);
                        }
                        newComboBox.SelectedIndex = 1;

                        if (!headers.Contains("Noise"))
                        {
                            DataList.Columns.Add("Noise", 80);
                        }
                    }
                    else
                    {
                        newLabel.Text = type;
                        newComboBox.Name = $"{type}_comboBox";
                        newComboBox.Items.Add("[Silence]");
                        foreach (FileInfo file in speech_files)
                        {
                            newComboBox.Items.Add(file.Name);
                        }
                        newComboBox.SelectedIndex = 1;

                        if (!headers.Contains(type))
                        {
                            int index = DataList.Columns.OfType<ColumnHeader>().Sum(header => header.Text.Contains("Speech") ? 1 : 0);
                            DataList.Columns.Insert(index + 1, type, 80);
                        }
                    }

                    //add the new labels and comboBoxes to the splitContainer
                    newLabel.AutoSize = true;
                    newLabel.Location = new Point(20, y);
                    newLabel.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
                    newLabel.Parent = Dataset_splitContainer.Panel2;

                    newComboBox.DropDownStyle = ComboBoxStyle.DropDown;
                    newComboBox.FlatStyle = FlatStyle.Standard;
                    newComboBox.Location = new Point(newLabel.Location.X, newLabel.Location.Y + newLabel.Height);
                    newComboBox.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
                    newComboBox.Parent = Dataset_splitContainer.Panel2;
                    newComboBox.DrawMode = DrawMode.OwnerDrawFixed;
                    newComboBox.DrawItem += comboBox_DrawItem;
                    newComboBox.DropDown += combobox_DropdownChanged;
                    newComboBox.DropDownClosed += combobox_DropdownClosed;

                    y = newComboBox.Location.Y + newComboBox.Height;
                }
            }
            if (lastY != y)
                Dataset_tableLayoutPanel.Location = new Point(Dataset_tableLayoutPanel.Location.X, Dataset_tableLayoutPanel.Location.Y + (y - lastY));
            lastY = y;
        }
        
        private void Add_Data_Btn_Click(object sender, EventArgs e)
        {
            if (DataList.Columns.Count <= 1)
                return;

            //get index
            int index;
            if(DataList.SelectedIndices.Count == 0)
            {
                index = DataList.Items.Count + 1;
            }
            else
            {
                index = DataList.SelectedIndices[0] + 1;
            }
            //get item
            var item = new ListViewItem(index.ToString());
            var comboBoxes = Dataset_splitContainer.Panel2.Controls.OfType<ComboBox>().OrderBy(c=>c.Location.X);
            foreach(var combo in comboBoxes)
            {
                if(combo.Equals(comboBoxes.ElementAt(0)) && combo.SelectedItem.ToString().Equals("[Silence]"))
                    MessageBox.Show("Choosing silence as speech will cause never-ending-playback, you have to stop the playback manually.", "WARNING", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                item.SubItems.Add(new ListViewItem.ListViewSubItem(item, combo.SelectedItem.ToString()));
            }

            //add
            var arr = new ListViewItem[DataList.Items.Count];
            DataList.Items.CopyTo(arr, 0);
            DataList.Items.Clear();
            var arrList = arr.ToList();
            arrList.Insert(index - 1, item);
            DataList.Items.AddRange(arrList.ToArray());
            //update #
            foreach (ListViewItem listViewItem in DataList.Items)
            {
                listViewItem.SubItems[0].Text = (listViewItem.Index + 1).ToString();
            }
            //select the new item
            foreach(ListViewItem listViewItem in DataList.SelectedItems)
            {
                listViewItem.Selected = false;
            }
            DataList.Items[index - 1].Selected = true;
            DataList.Select();
            DataList.EnsureVisible(index - 1);
        }

        private void Clear_Data_Btn_Click(object sender, EventArgs e)
        {
            if (DataList.SelectedItems.Count > 0)
            {
                foreach (ListViewItem item in DataList.SelectedItems)
                    DataList.Items.Remove(item);
            }
            else if(DataList.Items.Count > 0)
            {
                DataList.Items[0].Remove();
            }
            foreach (ListViewItem item in DataList.Items)
            {
                item.SubItems[0].Text = (item.Index + 1).ToString();
            }
        }

        private void Clear_All_Btn_Click(object sender, EventArgs e)
        {
            DataList.Items.Clear();
        }

        private void Load_Btn_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "Load Data";
            dialog.InitialDirectory = ".\\";
            dialog.SupportMultiDottedExtensions = true;
            dialog.Multiselect = true;
            dialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                foreach (var name in dialog.FileNames)
                {
                    List<String[]> inputSets = new List<string[]>();
                    try
                    { 
                        using (StreamReader sr = new StreamReader(name))
                        {
                            String line;
                            while ((line = sr.ReadLine()) != null)
                            {
                                if(line != "")
                                inputSets.Add(line.Trim().Split(','));
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        addText($"{ex.Message}\n\n", Color.Red);
                    }

                    bool hasSilenceSpeech = false;
                    foreach (var set in inputSets)
                    {
                        if(set.Count() != DataList.Columns.Count - 1)
                        {
                            addText($"Number of input files in each line must match column count, line{inputSets.IndexOf(set)+1}\n\n", Color.Red);
                            return;
                        }

                        var index = DataList.Items.Count + 1; //# of set to be displayed
                        var item = new ListViewItem(index.ToString());
                        for (int i = 0; i < set.Length; i++)
                        {
                            if (i == 0 && set[i].Equals("[Silence]"))
                            {
                                if (!hasSilenceSpeech)
                                {
                                    MessageBox.Show("Choosing silence as speech will cause never-ending-playback, you have to stop the playback manually.", "WARNING", 
                                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    hasSilenceSpeech = true;
                                }
                                else
                                {
                                    MessageBox.Show("More than one silence speech exist in the insert list, which will cause part of the data cannot be reached.\nLoading stopped.", "WARNING",
                                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }
                            }
                            item.SubItems.Add(new ListViewItem.ListViewSubItem(item, set[i]));
                        }
                        DataList.Items.Add(item);
                    }
                }
            }
        }

        private void Save_Btn_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Title = "Save Data";
            dialog.InitialDirectory = ".\\";
            dialog.SupportMultiDottedExtensions = true;
            dialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            dialog.FileName = "Untitled.txt";
            dialog.OverwritePrompt = true;
            
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(dialog.FileName))
                {
                    // get the data sets to play
                    foreach (ListViewItem item in DataList.Items)
                    {
                        var subItem = item.SubItems;
                        for (int i = 1; i <= subItem.Count - 1; i++)
                        {
                            if (i == 1)
                                sw.Write($"{subItem[i].Text}");
                            else
                                sw.Write($",{subItem[i].Text}");
                        }
                        sw.Write(Environment.NewLine);
                    }
                }
            }
        }

        private void Device_Btn_Click(object sender, EventArgs e)
        {
            DeviceForm deviceForm;
            deviceForm = new DeviceForm(this);
            deviceForm.Show(this);
        }

        public void setDeviceName(String deviceName)
        {
            Mapping_Btn.Enabled = true;
            Play_Stop_Btn.Enabled = true;
            SPCheckBox.Enabled = true;
            foreach (var c in Dataset_tableLayoutPanel.Controls.OfType<Button>()) { c.Enabled = true; }

            this.playbackEngine = new AudioPlaybackEngine(deviceName);

            //set default
            inputChannelTypes = new List<String> { "Mic1" };
            outputChannelTypes = new List<String> { "Speech1", "Speech2", "Noise1", "Noise2", "Noise3", "Noise4", "Noise5", "Noise6" };
            inputMappingData = new List<int>();
            outputMappingData = new List<int>();
            inputChannelNames = playbackEngine.GetInputChannelNames();
            outputChannelNames = playbackEngine.GetOutputChannelNames();

            for (int i = 0; i < inputChannelTypes.Count; i++)
            {
                if (i < playbackEngine.inputChannelCount)
                    inputMappingData.Add(i);
                else
                    inputMappingData.Add(0);
                //set the first Mic manually because we plug the mic into analog9
                inputMappingData[0] = 8;
            }
            for (int i = 0; i < outputChannelTypes.Count; i++)
            {
                if (i < playbackEngine.outputChannelCount)
                    outputMappingData.Add(i);
                else
                    outputMappingData.Add(0);
            }
        }

        private void Play_Stop_Click(object sender, EventArgs e)
        {
            if (Play_Stop_Btn.Text.Equals("Play"))
            {
                if (playbackEngine == null)
                {
                    addText("You must select a device first\n\n", Color.Red);
                    return;
                }
                if (DataList.Items.Count == 0)
                {
                    addText("You must add dataset first\n\n", Color.Red);
                    return;
                }

                SPCheckBox.Enabled = false;
                foreach (var c in Dataset_splitContainer.Panel2.Controls.OfType<ComboBox>()) { c.Enabled = false; };
                Add_Data_Btn.Enabled = false;
                Clear_Data_Btn.Enabled = false;
                Clear_All_Btn.Enabled = false;
                Load_Btn.Enabled = false;
                Save_Btn.Enabled = false;

                // get the data sets to play
                var datasets = new List<String[]>();
                foreach (ListViewItem item in DataList.Items)
                {
                    var subItem = item.SubItems;
                    var dataset = new String[subItem.Count - 1];
                    for(int i = 0; i < subItem.Count-1; i++)
                    {
                        if (subItem[i + 1].Text.Equals("[Silence]"))
                            dataset[i] = null;
                        else
                        {
                            var headers = DataList.Columns.OfType<ColumnHeader>().Select(header => header.Text).ToArray();
                            if(headers[i+1].Contains("Speech"))
                            {
                                dataset[i] = String.Format($@"speech/{subItem[i + 1].Text}");
                            }
                            else if(headers[i + 1].Contains("Noise"))
                            {
                                dataset[i] = String.Format($@"noise/{subItem[i + 1].Text}");
                            }
                        }
                    }
                    datasets.Add(dataset);
                }
                
                DirectoryInfo dinfo = new DirectoryInfo(Directory.GetCurrentDirectory());
                String path = $"{dinfo.ToString()}/auto_generated";
                bool exists = System.IO.Directory.Exists(path);
                if (!exists)
                    System.IO.Directory.CreateDirectory(path);
                playbackEngine.asioWriterPath = @"auto_generated";

                //Init the playbackEngine and mwProvider
                try
                {
                    if (SPCheckBox.Checked)
                    {
                        var spFilename = $@"sync_pattern/{spComboBox.SelectedItem.ToString()}";
                        playbackEngine.Init(datasets, spFilename, inputChannelTypes, inputMappingData, outputChannelTypes, outputMappingData);
                    }
                    else
                    {
                        playbackEngine.Init(datasets, null, inputChannelTypes, inputMappingData, outputChannelTypes, outputMappingData);
                    }
                    playbackEngine.mwProvider.PlaybackChanged += new EventHandler<PlaybackChangedEventArgs>(PlaybackChangedEvent);
                    playbackEngine.asioOut.PlaybackStopped += new EventHandler<StoppedEventArgs>(PlaybackStoppedEvent);
                    playbackEngine.Play();
                    //must raise the playbackChanged event manually at the first time
                    playbackEngine.mwProvider.RaisePlaybackChanged(0);
                    Play_Stop_Btn.Text = "Stop";
                }
                catch (Exception ex)
                {
                    if (playbackEngine != null)
                        playbackEngine.Dispose();

                    SPCheckBox.Enabled = true;
                    foreach (var c in Dataset_splitContainer.Panel2.Controls.OfType<ComboBox>()) { c.Enabled = true; };
                    Add_Data_Btn.Enabled = true;
                    Clear_Data_Btn.Enabled = true;
                    Clear_All_Btn.Enabled = true;
                    Load_Btn.Enabled = true;
                    Save_Btn.Enabled = true;
                    SetList(-1);

                    Play_Stop_Btn.Text = "Play";

                    addText(ex.ToString()+"\n\n", Color.Red);
                    return;
                }
            }
            else if (Play_Stop_Btn.Text.Equals("Stop"))
            {
                playbackEngine.Dispose();
                SPCheckBox.Enabled = true;
                foreach (var c in Dataset_splitContainer.Panel2.Controls.OfType<ComboBox>()) { c.Enabled = true; };
                Add_Data_Btn.Enabled = true;
                Clear_Data_Btn.Enabled = true;
                Clear_All_Btn.Enabled = true;
                Load_Btn.Enabled = true;
                Save_Btn.Enabled = true;
                SetList(-1);

                Play_Stop_Btn.Text = "Play";
            }
        }

        // must delegate or the thread access will be invalid if we call from another thread
        delegate void IntArgReturningVoidDelegate(int index);
        int listViewLastChangedIndex = -1;
        // if index is -1, reset the last changed color and set the listViewLastChangedIndex to -1
        private void SetList(int index)
        {
            if (listViewLastChangedIndex != -1)
                this.DataList.Items[listViewLastChangedIndex].BackColor = this.DataList.BackColor;
            if (index != -1)
                this.DataList.Items[index].BackColor = Color.LightGray;
            listViewLastChangedIndex = index;
        }

        private void PlaybackChangedEvent(object sender, PlaybackChangedEventArgs e)
        {
            int index = e.NowPlaying;
            playbackEngine.InitWriter(index);
            if (this.DataList.InvokeRequired)
            {
                IntArgReturningVoidDelegate d = new IntArgReturningVoidDelegate(SetList);
                this.Invoke(d, new object[] { index });
            }
            else
            {
                SetList(index);
            }
        }

        private void PlaybackStoppedEvent(object sender, StoppedEventArgs e)
        {
            Play_Stop_Click(sender, e);
        }

        private void XCorr_Click(object sender, EventArgs e)
        {
            FindMatch cross = new FindMatch(@"sync_pattern/sweep_tone.wav", @"mixed.wav");
        }
        
        private void Dot_Root_Click(object sender, EventArgs e)
        {
            var stdout = execute("cmd", "adb get-state");
            if (stdout.Contains("device"))
            {
                execute("cmd", "adb root");
                execute("cmd", "adb remount");
                addText("device starts successfully\n\n", Color.Black);
                echoDotStarted = true;
            }
            else
            {
                addText("start failed\n\n", Color.Red);
            }
        }

        private void Dot_Clear_Click(object sender, EventArgs e)
        {
            if(!echoDotStarted)
            {
                addText("device has not started yet\n\n", Color.Red);
                return;
            }
            else if (checkDir("adb", "sdcard/mtklog/audio_dump"))
            {
                execute("cmd", "adb shell rm -rf sdcard/mtklog/audio_dump");
            }
        }

        private void Dot_Record_Stop_Click(object sender, EventArgs e)
        {
            if (!echoDotStarted)
            {
                addText("device has not started yet\n\n", Color.Red);
                return;
            }
            else if(Dot_Record_Stop.Text.Equals("Record"))
            {
                if (checkDir("adb", "sdcard/mtklog/audio_dump"))
                {
                    execute("cmd", "adb shell setprop streamin.pcm.dump 1");
                }
                Dot_Record_Stop.Text = "Stop";
            }
            else if (Dot_Record_Stop.Text.Equals("Stop"))
            {
                if (checkDir("adb", "sdcard/mtklog/audio_dump"))
                {
                    execute("cmd", "adb shell setprop streamin.pcm.dump 0");
                }
                Dot_Record_Stop.Text = "Record";
            }
        }

        private void Dot_Pull_Click(object sender, EventArgs e)
        {
            if (!echoDotStarted)
            {
                addText("device has not start yet\n\n", Color.Red);
                return;
            }
            else if (checkDir("adb", "sdcard/mtklog/audio_dump"))
            {
                execute("cmd", "adb pull sdcard/mtklog/audio_dump audio_dump/ ");

                //catch the converted file names
                filenameBox.Clear();
                System.IO.DirectoryInfo dinfo = new System.IO.DirectoryInfo(@"audio_dump/");
                System.IO.FileInfo[] mono_files = dinfo.GetFiles("StreamIn_Dump.pcm*.pcm");
                System.IO.FileInfo[] multi_files = dinfo.GetFiles("*.AudioALSACaptureDataProviderNormal.pcm");
                foreach (var f in mono_files)
                {
                    filenameBox.AppendText($"audio_dump/{f.Name}\n");
                }
                tabControl1.SelectedTab = PCM2WAV_tab;
            }
        }

        private void Browse_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "Select file";
            dialog.InitialDirectory = ".\\";
            dialog.Filter = "pcm files (*.pcm)|*.pcm";
            dialog.Multiselect = true;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                foreach (var name in dialog.FileNames)
                {
                    var path = System.IO.Path.GetFullPath(name);
                    filenameBox.AppendText($"{path}\n");
                }
            }
        }

        private void Convert_Click(object sender, EventArgs e)
        {
            if (checkDir("cmd", "PCM2WAV.exe"))
            {
                for (int i = 0; i < filenameBox.Lines.Count(); i++)
                {
                    String line = filenameBox.Lines[i].Trim();
                    if (line == "") continue;
                    var isOneCh = new System.Text.RegularExpressions.Regex(@"\bpcm\d*.pcm\b$").IsMatch(line);
                    var isNineCh = new System.Text.RegularExpressions.Regex(@"\bAudioALSACaptureDataProviderNormal.pcm\b$").IsMatch(line);
                    if (isOneCh)
                    {
                        int bit;
                        int sample;
                        if(!Int32.TryParse(OneCh_Bit_TextBox.Text, out bit) || !Int32.TryParse(OneCh_Rate_TextBox.Text, out sample))
                        {
                            addText("bit rate or sample rate must be numbers\n\n", Color.Red);
                            return;
                        }
                        String outFilename = line.Substring(0, line.Count() - 4) + "_1ch.wav";
                        execute($"PCM2WAV.exe", $"-b{bit} -c1 -s{sample} {line} {outFilename}");
                        addText("\n", Color.Black);
                    }
                    else if (isNineCh)
                    {
                        int bit;
                        int sample;
                        if (!Int32.TryParse(NineCh_Bit_TextBox.Text, out bit) || !Int32.TryParse(NineCh_Rate_TextBox.Text, out sample))
                        {
                            addText("bit rate or sample rate must be numbers\n\n", Color.Red);
                            return;
                        }
                        String outFilename = line.Substring(0, line.Count() - 4) + "_9ch.wav";
                        execute($"PCM2WAV.exe", $"-b{bit} -c9 -s{sample} {line} {outFilename}");
                        addText("\n", Color.Black);
                    }
                    else
                    {
                        addText("unknown file type ", Color.Red);
                        addText($"{line}\n\n", Color.Black);
                    }
                }
                filenameBox.Clear();
                //execute($"FOR /f %f  IN ('DIR *.pcm /b /od') DO pcm2wav -b16 -c1 -s16000 %f 1ch_output.wav");
            }
        }

        public void addText(String text, Color color)
        {
            cmdTextBox.SelectionColor = color;
            cmdTextBox.AppendText($"{text}");
        }

        private String execute(String filename, String cmd)
        {
            String command;
            if (filename == "cmd")
                command = "/c" + cmd;
            else
                command = cmd;

            addText($"{filename}>> {cmd}\n", Color.DarkCyan);

            ProcessStartInfo startInfo = new ProcessStartInfo(filename, command)
            {
                WindowStyle = ProcessWindowStyle.Hidden,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                CreateNoWindow = true
            };

            Process process = Process.Start(startInfo);
            String output = process.StandardOutput.ReadToEnd();

            if (output != "")
                addText(output, Color.Black);
            return output;
        }

        private bool checkDir(String filename, String dir)
        {
            String cmd = null;
            if (filename == "adb")
            {
                if (checkDir("cmd", "adb.exe"))
                {
                    cmd = $"adb shell if [ {dir} ]; then echo 1; else echo 0; fi";
                }
            }
            else if (filename == "cmd")
            {
                cmd = $"if exist {dir} (echo 1) else (echo 0)";
            }
            else
            {
                addText("unknown commnad\n\n", Color.Red);
                return false;
            }

            ProcessStartInfo startInfo = new ProcessStartInfo("cmd", "/c" + cmd)
            {
                WindowStyle = ProcessWindowStyle.Hidden,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                CreateNoWindow = true
            };
            
            Process process = Process.Start(startInfo);
            String output = process.StandardOutput.ReadLine();

            if (output == null)
                return false;
            else if (output.Equals("1"))
            {
                return true;
            }
            else
            {
                addText($"{dir} : no such file or directory\n\n", Color.Red);
                return false;
            }
        }

        private void SPCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (SPCheckBox.Checked)
            {
                spComboBox.Enabled = true;
            }
            else
            {
                spComboBox.Enabled = false;
            }
        }

        private void Use_Default_CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if(Use_Default_CheckBox.Checked == true)
            {
                NineCh_Bit_TextBox.Text = "24";
                NineCh_Rate_TextBox.Text = "16000";
                NineCh_Bit_TextBox.Enabled = false;
                NineCh_Rate_TextBox.Enabled = false;

                OneCh_Bit_TextBox.Text = "16";
                OneCh_Rate_TextBox.Text = "16000";
                OneCh_Bit_TextBox.Enabled = false;
                OneCh_Rate_TextBox.Enabled = false;
            }
            else
            {
                NineCh_Bit_TextBox.Enabled = true;
                NineCh_Rate_TextBox.Enabled = true;
                OneCh_Bit_TextBox.Enabled = true;
                OneCh_Rate_TextBox.Enabled = true;
            }
        }

        private void Browse_Keyword_Source_Btn_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "Select file";
            dialog.InitialDirectory = ".\\";
            dialog.Filter = "wav files (*.wav)|*.wav";
            dialog.Multiselect = false;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                var name = dialog.FileName;
                var path = System.IO.Path.GetFullPath(name);
                Keyword_Source_TextBox.Text = path;
            }
        }
        
        private void Browse_Keyword_Sample_Btn_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "Select file";
            dialog.InitialDirectory = ".\\";
            dialog.Filter = "Text files (*.txt)|*.txt";
            dialog.Multiselect = false;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                var name = dialog.FileName;
                var path = System.IO.Path.GetFullPath(name);
                Keyword_Sample_TextBox.Text = path;
            }
        }

        private void Browse_Task_Source_Btn_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "Select file";
            dialog.InitialDirectory = ".\\";
            dialog.Filter = "Text files (*.txt)|*.txt";
            dialog.Multiselect = false;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                var name = dialog.FileName;
                var path = System.IO.Path.GetFullPath(name);
                Task_Source_TextBox.Text = path;
            }
        }

        private void Start_AddTask_Btn_Click(object sender, EventArgs e)
        {
            /*
            //start concat test

            var extList = new string[] { ".wav" };
            var files = Directory.GetFiles("D:/share/concat", "*.wav").ToList();
            var sampleRate = 48000;
            var bit = 16;
            var channel = 1;
            var outFormat = new WaveFormat(sampleRate, bit, channel);
            var writer = new WaveFileWriter("concat.wav", outFormat);
            foreach (var name in files)
            {
                using (WaveFormatConversionStream stream = new WaveFormatConversionStream(outFormat, new WaveFileReader(name)))
                {
                    byte[] taskBuffer = new byte[stream.WaveFormat.BitsPerSample * stream.WaveFormat.Channels / 4];
                    int read;
                    try
                    {
                        while ((read = stream.Read(taskBuffer, 0, taskBuffer.Length)) > 0)
                        {
                            writer.Write(taskBuffer, 0, read);
                        }
                    }
                    catch (Exception ex)
                    {
                        addText(ex.Message + "\n" + "filename: " + name, Color.Black);
                        if (writer != null)
                            writer.Dispose();
                        return;
                    }
                }
            }
            writer.Dispose();
            */

            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Title = "Save";
            dialog.InitialDirectory = ".\\";
            dialog.SupportMultiDottedExtensions = true;
            dialog.Filter = "wav files (*.wav)|*.wav|All files (*.*)|*.*";
            dialog.FileName = "Untitled.wav";
            dialog.OverwritePrompt = true;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    //read the cut location
                    var location = new List<int>();
                    using (StreamReader sr = new StreamReader(Keyword_Sample_TextBox.Text.Trim()))
                    {
                        String line;
                        while ((line = sr.ReadLine()) != null)
                        {
                            location.Add(Int32.Parse(line));
                        }
                    }

                    //read the task filenames
                    var taskFilenames = new List<String>();
                    using (StreamReader sr = new StreamReader(Task_Source_TextBox.Text.Trim()))
                    {
                        String line;
                        while ((line = sr.ReadLine()) != null)
                        {
                            if (line != "")
                                taskFilenames.Add(line.Trim());
                        }
                    }

                    if (location.Count > taskFilenames.Count)
                        throw new ArgumentException("the number cut location must equal or less than the number of input task files");

                    using (var keywordWaveReader = new WaveFileReader(Keyword_Source_TextBox.Text.Trim()))
                    {
                        var keywordSampleProvider = WaveExtensionMethods.ToSampleProvider(keywordWaveReader);

                        //set writer               
                        var sampleRate = keywordWaveReader.WaveFormat.SampleRate;
                        var bit = keywordWaveReader.WaveFormat.BitsPerSample;
                        var channel = 1;
                        var outFormat = new WaveFormat(sampleRate, bit, channel);
                        var writer = new WaveFileWriter(dialog.FileName, outFormat);

                        //start writing file
                        float[] buffer = new float[2 * keywordWaveReader.WaveFormat.Channels]; //2 samples per buffer
                        int samplesRead;
                        int currentLocation = 0; //number of samples has been read
                        int taskCount = 0;
                        int cutLocation = location[taskCount];
                        while ((samplesRead = keywordSampleProvider.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            writer.WriteSamples(buffer, 0, samplesRead);
                            currentLocation += samplesRead;
                            //when encounter the cut location, write the task stream
                            if (currentLocation > cutLocation)
                            {
                                //convert the task stream into the same waveFormat as keyword stream's
                                var taskFilename = $@"task/{taskFilenames[taskCount]}";
                                using (WaveFormatConversionStream taskStream = new WaveFormatConversionStream(outFormat, new WaveFileReader(taskFilename)))
                                {
                                    byte[] taskBuffer = new byte[taskStream.WaveFormat.BitsPerSample * taskStream.WaveFormat.Channels / 4];
                                    int taskBytesRead;
                                    while ((taskBytesRead = taskStream.Read(taskBuffer, 0, taskBuffer.Length)) > 0)
                                    {
                                        writer.Write(taskBuffer, 0, taskBytesRead);
                                    }
                                    //insert 5sec silence
                                    for (int sec = 0; sec < 5; sec++)
                                    {
                                        float[] silenceBuffer = Enumerable.Repeat((float)0, writer.WaveFormat.SampleRate).ToArray();
                                        writer.WriteSamples(silenceBuffer, 0, silenceBuffer.Length);
                                    }
                                }
                                taskCount++;
                                cutLocation = location[taskCount];
                            }
                        }
                        writer.Dispose();
                    }

                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            execute("cmd", "adb kill-server");
            if (playbackEngine != null)
                playbackEngine.Dispose();
            this.Close();
        }

        private void comboBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            var combo = sender as ComboBox;
            if (e.Index < 0) { return; }
            string text = combo.Items[e.Index].ToString();
            e.DrawBackground();
            using (SolidBrush br = new SolidBrush(e.ForeColor))
            { e.Graphics.DrawString(text, combo.Font, br, e.Bounds); }
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            { comboToolTip.Show(text, combo, e.Bounds.Right, e.Bounds.Bottom); }
            e.DrawFocusRectangle();
        }

        private void combobox_DropdownClosed(object sender, EventArgs e)
        {
            comboToolTip.Hide(sender as ComboBox);
        }
    }
}
