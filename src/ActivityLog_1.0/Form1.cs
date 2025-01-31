using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.IO;
using System.Net.Configuration;

namespace ActivityLog_1._0
{
    public partial class Form1 : Form
    {
                                           
        string pyScript = Application.StartupPath.ToString() + "\\database_writer.py";
        string actLst = Application.StartupPath.ToString() + "\\activities.lst";
        string pypath = Application.StartupPath.ToString() + "\\pypath.config";
        string python3;
        string starttime;
        string endtime;
        string durationtime;
        string scriptArgs;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load_1(object sender, EventArgs e)           // Checks if configFile exists
        {
            if (!check_file_exists(actLst))
            {
                MessageBox.Show("MISSING: " + actLst, "configFile Not Found.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (!check_file_exists(pyScript))
            {
                MessageBox.Show("MISSING: " + pyScript, "Python Script Not Found.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            get_activities1();
            get_config();
            comboBox1.SelectedIndex = 0;
        }
        static bool check_file_exists(string path)
        {
            if (File.Exists(path)) { return true; } return false;
        }

        private void get_config()
        {
            python3 = File.ReadAllText(pypath);
        }

        private void get_activities1()                                  // Open and read activities.lst 
        {
            bool firstLine = true;
            const Int32 BufferSize = 128;
            using (var fileStream = File.OpenRead(actLst))
            {
                using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, BufferSize))
                {
                    string line;
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        if (firstLine)
                        {
                            firstLine = false;                          // Skip Headerline
                        }
                        else
                        {
                            comboBox1.Items.Add(line);                  // Populate ComboBox
                        }
                    }
                }
            }
        }


        private void button1_Click(object sender, EventArgs e)          // Update Button
        {
            scriptArgs = comboBox1.Text + " " + System.DateTime.Now.ToString("dd/MM/yyyy") + " " + starttime + " " + endtime + " " + durationtime + " " + format_text(textBox1.Text);
            db_update(scriptArgs);
            button1.Enabled = false;    
            resetUI();
        }

        static string format_text(string s)
        {
            if (s == "") { return "--"; } return s.Trim().Replace(" ", "_");
        }
        void db_update(string sArgs)                                    // Update Database
        {
            System.Diagnostics.Process.Start(python3, pyScript + " " + sArgs);  // BUG: this can't take paths right now with spaces as it will think of it as more arguments
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            resetUI();
            timer1.Stop();
        }

                                                                        // Start Button
        private void button2_Click(object sender, EventArgs e)
        {
            starttime = DateTime.Now.ToString("HH:mm:ss");
            button3.Enabled = true;                                     // GUI
            button2.Enabled = false;
            label1.Text = starttime;
            timer1.Start();
        }

        private void button3_Click(object sender, EventArgs e)          // End Button
        {
            endtime = DateTime.Now.ToString("HH:mm:ss");
            button2.Enabled = true;                                     // GUI
            button3.Enabled = false;            
            button1.Enabled = true;
            label2.Text = endtime;
            timer1.Stop();                      
        }

                                                                        // Timer
        private void timer1_Tick(object sender, EventArgs e)
        {
            label2.Text = DateTime.Now.ToString("HH:mm:ss");
            endtime = DateTime.Now.ToString("HH:mm:ss");
            TimeSpan start = TimeSpan.Parse(starttime);
            TimeSpan end = TimeSpan.Parse(endtime);
            TimeSpan difference = end - start;
            durationtime = label_elap.Text;
            label_elap.Text = difference.ToString();
        }

                                                                         // Resets all the Labels
        private void resetUI() {
            string s = "--:--:--";
            label1.Text = s;
            label2.Text = s;
            label_elap.Text = s;
        }
    }
}

