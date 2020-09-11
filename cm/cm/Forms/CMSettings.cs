using System;
using System.Management;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;

namespace cm
{
    public partial class CMSettings : Form
    {
        public Settings m_settings { get; set; }

        public CMSettings(Settings settings)
        {
            InitializeComponent();
            UpdateWindow(settings);

            listBox_COM.BeginUpdate();
            listBox_COM.Items.Clear();
            listBox_COM.Items.AddRange(GetUSBCOMDevices());
            listBox_COM.EndUpdate();
        }

        private static string[] GetUSBCOMDevices()
        {
            List<string> list = new List<string>();

            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_PnPEntity");
            foreach (ManagementObject mo in searcher.Get())
            {
                var name = mo.GetPropertyValue("Name");

                if (name!= null && name.ToString().Contains("(COM"))
                {
                    list.Add(name.ToString());                    
                }
            }
            
            string[] ports = list.Distinct().OrderBy(s => s).ToArray();
            return ports;
        }

        private void UpdateWindow(Settings settings)
        {
            m_settings = settings;

            listBox_COM.Text = m_settings.COM;
            comboBox_Baudrate.Text = m_settings.Baudrate.ToString();

            textBox_Uab_step.Text = m_settings.Uab_step.ToString();
            textBox_Ia_step.Text = m_settings.Ia_step.ToString();

            textBox_Ia_mult.Text = m_settings.Ia_mult.ToString("0.################");
            textBox_Ib_mult.Text = m_settings.Ib_mult.ToString("0.################");
            textBox_Ic_mult.Text = m_settings.Ic_mult.ToString("0.################");

            textBox_Uab_mult.Text = m_settings.Uab_mult.ToString("0.################");
            textBox_Uc_mult.Text = m_settings.Uc_mult.ToString("0.################");

            textBox_Timeout.Text = m_settings.Timeout.ToString();
        }

        private void UpdateSettings(Settings setting)
        {
            var b = listBox_COM.Text.IndexOf("(COM") + 1;
            setting.COM = listBox_COM.Text.Substring(b, 4);

            m_settings.Baudrate = int.Parse(comboBox_Baudrate.Text);

            textBox_Uab_step.Text = textBox_Uab_step.Text.Replace(".", ",");
            setting.Uab_step = double.Parse(textBox_Uab_step.Text);

            textBox_Ia_step.Text = textBox_Ia_step.Text.Replace(".", ",");
            setting.Ia_step = double.Parse(textBox_Ia_step.Text);

            textBox_Ia_mult.Text = textBox_Ia_mult.Text.Replace(".", ",");
            setting.Ia_mult = double.Parse(textBox_Ia_mult.Text);

            textBox_Ib_mult.Text = textBox_Ib_mult.Text.Replace(".", ",");
            setting.Ib_mult = double.Parse(textBox_Ib_mult.Text);

            textBox_Ic_mult.Text = textBox_Ic_mult.Text.Replace(".", ",");
            setting.Ic_mult = double.Parse(textBox_Ic_mult.Text);

            textBox_Uab_mult.Text = textBox_Uab_mult.Text.Replace(".", ",");
            setting.Uab_mult = double.Parse(textBox_Uab_mult.Text);

            textBox_Uc_mult.Text = textBox_Uc_mult.Text.Replace(".", ",");
            setting.Uc_mult = double.Parse(textBox_Uc_mult.Text);

            setting.Timeout = int.Parse(textBox_Timeout.Text);
        }

        private void OK_Click(object sender, EventArgs e)
        {
            UpdateSettings(m_settings);
            m_settings.Save(Settings.lastCFG);
            DialogResult = DialogResult.OK;
            Close();
        }

        private void Save_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "cfg files|*.cfg",
                FilterIndex = 1,
                RestoreDirectory = true
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                UpdateSettings(m_settings);
                m_settings.Save(saveFileDialog.FileName);
            }

            saveFileDialog.Dispose();
        }

        private void Load_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "cfg files|*.cfg",
                FilterIndex = 1,
                RestoreDirectory = true
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                UpdateWindow(Settings.FromFile(openFileDialog.FileName));
            }

            openFileDialog.Dispose();
        }
    }
}
