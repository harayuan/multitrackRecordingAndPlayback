using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NAudio.Wave.Asio;
using NAudio.Wave;
using Automation.Player;

namespace Automation
{
    public partial class DeviceForm : Form
    {
        MainForm mainForm;
        public DeviceForm(MainForm mainForm)
        {
            InitializeComponent();
            refresh_sources();
            this.mainForm = mainForm;
        }

        private void Refresh_Btn_Click(object sender, EventArgs e)
        {
            refresh_sources();
        }

        private void refresh_sources()
        {
            String[] sources = AsioDriver.GetAsioDriverNames();
            sourceList.Items.Clear();
            var activateDeviceCount = 0;

            for (int i = 0; i < sources.Length; i++)
            {
                var item = new ListViewItem(sources[i]);
                try
                {
                    var driverCapability = (new MyAsioDriverExt(MyAsioDriver.GetAsioDriverByName(sources[i]))).Capabilities;
                    item.SubItems.Add(new ListViewItem.ListViewSubItem(item, driverCapability.NbInputChannels.ToString()));
                    item.SubItems.Add(new ListViewItem.ListViewSubItem(item, driverCapability.NbOutputChannels.ToString()));
                }
                catch (Exception ex)
                {
                    //ignore the exception and try the next source
                    continue;
                }
                activateDeviceCount += 1;
                sourceList.Items.Add(item);
            }
            if (sourceList.Items.Count > 0)
            {
                //always select the first device as default
                var deviceName = sourceList.Items[0].Name.ToString();
                foreach(ListViewItem item in sourceList.Items)
                {
                    item.Selected = item.Name.ToString() == deviceName;
                }
                sourceList.Items[0].Selected = true;
            }
            if(activateDeviceCount == 0)
            {
                MessageBox.Show("Device not found, please insert a device.", "Error");
            }
        }

        private void OK_Btn_Click(object sender, EventArgs e)
        {
            if (sourceList.SelectedItems.Count > 0)
            {
                mainForm.setDeviceName(sourceList.SelectedItems[0].Text);
                mainForm.addText($"select device: {sourceList.SelectedItems[0].Text}\n", Color.Black);
                using (var mappingForm = new MappingForm(mainForm))
                {
                    mappingForm.OK_Btn_Click(sender, e);
                }
            }
            this.Close();
        }

        private void Cancel_Btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
