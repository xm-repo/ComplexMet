using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace cm
{
    public partial class CMForm : Form
    {
        private Settings m_settings = new Settings();
        private Reader m_reader;
        private Thread m_readerThread;
        private Thread m_updateThread;
        private Mutex m_mutex = new Mutex();
        private DateTime m_lastRedraw = DateTime.Now;
        private System.Windows.Forms.Timer m_timer;

        private void DrawingThread()
        {
            while(true)
            {
                Redraw();
                Thread.Sleep(10);
            }
        }

        public CMForm()
        {
            InitializeComponent();

            if (File.Exists(Settings.lastCFG))
            {
                m_settings = Settings.FromFile(Settings.lastCFG);
            }
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Settings_Click(object sender, EventArgs e)
        {
            using (var cmSettings = new CMSettings(m_settings))
            {
                var result = cmSettings.ShowDialog(this);

                if (result == DialogResult.OK)
                {
                    m_settings = cmSettings.m_settings;                    
                }
            }
        }

        private void Start_Click(object sender, EventArgs e)
        {
            try
            {
                m_reader = new Reader(m_settings, OnRead);

                m_readerThread = new Thread(m_reader.Read)
                {
                    IsBackground = true
                };

                m_readerThread.Start();

                btn_Start.Checked = true;
                btn_Start.Enabled = false;

                m_updateThread = new Thread(DrawingThread)
                {
                    IsBackground = true
                };
                m_updateThread.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void Save_Click(object sender, EventArgs e)
        {
            if (m_readerThread == null || !m_readerThread.IsAlive)
            {
                return;
            }

            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog
            {
                ShowNewFolderButton = true,                
            };

            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {                
                var indicators = m_reader.GetIndicators();

                List<Indicators> sorted = indicators.OrderBy(x => x.m_Ia).ToList();
                List<Indicators> average = new List<Indicators>();

                var maxIa = sorted.Max(t => t.m_Ia);
                var Ia_step = m_settings.Ia_step;
                var Ia = Ia_step;

                int i = 1;
                while (Ia < maxIa)
                {
                    while (sorted[i].m_Ia <= Ia)
                    {
                        i++;
                    }

                    if (i >= sorted.Count - 2)
                    {
                        break;
                    }

                    if (Ia == sorted[i - 1].m_Ia)
                    {
                        Indicators ind = new Indicators(sorted[i - 1].m_Uab, Ia, 0, 0, 0);
                        average.Add(ind);
                    }
                    else
                    {
                        var y1 = sorted[i - 1].m_Uab;
                        var y2 = sorted[i].m_Uab;
                        var x1 = sorted[i - 1].m_Ia;
                        var x2 = sorted[i].m_Ia;

                        var y = y1 + (y2 - y1) / ((x2 - x1) / (Ia - x1));

                        Indicators ind = new Indicators(y, Ia, 0, 0, 0);
                        average.Add(ind);
                    }

                    Ia += Ia_step;
                }

                string folderpath = folderBrowserDialog.SelectedPath;
                string fileName = folderpath.Split(Path.DirectorySeparatorChar).Last();

                SaveIndicators(indicators, folderpath + "//" + fileName + "(raw).txt", true);
                SaveIndicators(sorted, folderpath + "//" + fileName + "(sorted).txt");
                SaveIndicators(average, folderpath + "//" + fileName + "(average).txt");

                SavePlot(indicators, folderBrowserDialog.SelectedPath + "//" + fileName + "(raw).png");
                SavePlot(average, folderBrowserDialog.SelectedPath + "//" + fileName + "(average).png");
            }

            folderBrowserDialog.Dispose();
        }

        private void SaveIndicators(List<Indicators> indicators, string file, bool saveTC = false)
        {
            using (StreamWriter sw = new StreamWriter(file))
            {
                var TC = "";
                if (saveTC)
                {
                    TC = " ; Ib ; Ic ; Ktt";
                }
                sw.WriteLine("Ia ; Uab" + TC);


                foreach (var indicator in indicators)
                {
                    TC = "";
                    if (saveTC)
                    {
                        TC = " ; " + indicator.m_Ib.ToString("F3") + " ; " + indicator.m_Ic.ToString("F3") + " ; " + (indicator.m_Ic / indicator.m_Ib).ToString("F3");
                    }
                    sw.WriteLine(indicator.m_Ia.ToString("F3") + " ; " + indicator.m_Uab.ToString("F3") + TC);
                }
            }
        }

        private void SavePlot(List<Indicators> indicators, string file)
        {
            Plot visual = new Plot(pictureBox_G.Width, pictureBox_G.Height, m_settings, indicators);
            visual.Clear();
            visual.DrawAxis();
            visual.DrawPlot(false, null);
            visual.m_bitmap.Save(file);
        }

        private void Pause_Click(object sender, EventArgs e)
        {
            if (m_readerThread == null || !m_readerThread.IsAlive)
            {
                return;
            }

            if (btn_Pause.Checked)
            {
                m_reader.RequestResume();
            }
            else
            {
                m_reader.RequestPause();
            }

            btn_Pause.Checked = !btn_Pause.Checked;
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            if (m_readerThread == null || !m_readerThread.IsAlive)
            {
                return;
            }

            m_reader.RequestClear();
        }

        private void KeyUp_Click(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                Pause_Click(sender, e);
            }
            else if (e.KeyCode == Keys.Escape)
            {
                Exit_Click(sender, e);
            }
        }

        private void About_Click(object sender, EventArgs e)
        {
            new CMAbout().ShowDialog(this);
        }

        private void OnRead(bool redraw)
        {
            toolStrip1.BeginInvoke(new MethodInvoker(delegate
            {
                var lastIndicators = m_reader.GetLastIndicators();

                label_Uab.Text = "U: " + lastIndicators.m_Uab.ToString("F3");

                label_Ia.Text = "I: " + lastIndicators.m_Ia.ToString("F3");
                if (lastIndicators.m_Ia >= 8)
                {
                    label_Ia.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    label_Ia.ForeColor = Control.DefaultForeColor;
                }

                label_Uc.Text = "Uc: " + lastIndicators.m_Uc.ToString("F3");
                if (lastIndicators.m_Uc >= 8)
                {
                    label_Uc.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    label_Uc.ForeColor = Control.DefaultForeColor;
                }

                label_Ic.Text = "Ic: " + lastIndicators.m_Ic.ToString("F3");
                label_Ib.Text = "Ib: " + lastIndicators.m_Ib.ToString("F3");

                try
                {
                    label_TC.Text = "Ktt: " + (lastIndicators.m_Ic / lastIndicators.m_Ib).ToString("F3");
                } catch
                {

                }
            }));
        }

        private void Redraw()
        {
            if (m_reader == null)
            {
                return;
            }

            if (pictureBox_G.Width <= 0 || pictureBox_G.Height <= 0)
            {
                return;
            }

            Plot plot = new Plot(pictureBox_G.Width, pictureBox_G.Height, m_settings, m_reader.GetIndicators());
            plot.DrawAxis();
            plot.DrawPlot(false, m_reader.GetLastIndicators());

            pictureBox_G.BeginInvoke(new MethodInvoker(delegate
            {
                pictureBox_G.Image = plot.m_bitmap;
            }));
        }

        private void CMForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (m_readerThread != null && m_readerThread.IsAlive)
            {
                m_reader.RequestStop();
                m_readerThread.Join();
            }
        }
    }
}
