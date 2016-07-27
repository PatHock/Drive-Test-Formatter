using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Drive_Test_Formatter
{
    public partial class Form1 : Form
    {
        public string[] fileNames;
        public string FileNamesString
        {
            get
            {
                string ret = "";
                if (fileNames.Length > 1)
                {
                    foreach (string file in fileNames)
                    {
                        ret += file + ";";
                    }
                }
                else
                {
                    ret = fileNames[0];
                }
                
                return ret;
            }
        }
        private Logfile log;

        public Form1()
        {
            Application.EnableVisualStyles();
            //create the log file 
            log = new Logfile(".", "errors.log");
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Show the dialog and get result.
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
                fileNames = openFileDialog1.FileNames;
                textBox_FileName.Text = FileNamesString;
                btn_beginFormatting.Visible = true;
            }
        }

        private void btn_beginFormatting_Click(object sender, EventArgs e)
        {
            progressBar1.Show();

            btn_beginFormatting.Text = "Working...";
            btn_beginFormatting.Enabled = false;

            BackgroundWorker workerThread = new BackgroundWorker();

            workerThread.DoWork += bw_DoWork;
            workerThread.RunWorkerCompleted += bw_RunWorkerCompleted;
            workerThread.RunWorkerAsync();
        }

        void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressBar1.Hide();
            btn_beginFormatting.Text = "Begin Formatting";
            btn_beginFormatting.Enabled = true;
        }

        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            processAllFiles();
        }

        private void processAllFiles()
        {
            Dictionary<string, string> failedFiles = new Dictionary<string, string>();
            foreach (string fileName in fileNames)
            {
                try
                {
                    processFile(fileName);
                }
                catch (Exception ex)
                {
                    log.logException(ex);
                    if (ex.Message.Contains("The system could not find the file specified"))
                    {
                        failedFiles.Add(fileName, "The system could not find the file specified.");
                    }
                    else if (ex.Message.Contains("it is being used by another process"))
                    {
                        failedFiles.Add(fileName, ex.Message);
                    }
                    else
                    {
                        failedFiles.Add(fileName, "An uncaught exception occurred when trying to write the file.");
                    }
                }
            }
            if (failedFiles.Count == 0)
            {
                MessageBox.Show("All files processed successfully!");
            }
            else
            {
                string message = "Some files could not be processed or written correctly: " + Environment.NewLine;
                foreach (string fileName in failedFiles.Keys)
                {
                    message += fileName + ":" + Environment.NewLine + failedFiles[fileName] + Environment.NewLine + Environment.NewLine;
                }

                MessageBox.Show(message);
            }
        }

        private void processFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                string csvData = File.ReadAllText(filePath);
                DriveTestData driveTestData = new DriveTestData(csvData);
                string xmlData = driveTestData.XmlText;
                string[] formattedCsvFiles = driveTestData.XMLtoCSV();
                if (!Directory.Exists(filePath + @".output"))
                {
                    Directory.CreateDirectory(filePath + @".output");
                }
                try
                {
                    //File.WriteAllText(filePath + @".output\output.xml", xmlData);
                    for (int i = 0; i < formattedCsvFiles.Length; i++)
                    {
                        File.WriteAllText(filePath + @".output\output_" + i + ".csv", formattedCsvFiles[i]);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                throw new FileNotFoundException("The system could not find the file specified.");
            }
        }
    }
}
