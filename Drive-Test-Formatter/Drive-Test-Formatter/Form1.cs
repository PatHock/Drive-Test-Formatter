using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading.Tasks;

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
        private Dictionary<string, string[]> filenameParams;
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
                filenameParams = new Dictionary<string, string[]>(); ;
                textBox_FileName.Text = FileNamesString;
                btn_beginFormatting.Visible = true;
            }
        }

        private void btn_beginFormatting_Click(object sender, EventArgs e)
        {
            progressBar1.Show();

            btn_beginFormatting.Text = "Working...";
            btn_beginFormatting.Enabled = false;
            button1.Enabled = false;
            textBox_FileName.Enabled = false;

            Boolean allOk = true;

            for(int i = 0; i < fileNames.Length; i ++)
            {
                NamingOptionsForm nameOptionsForm = new NamingOptionsForm(fileNames[i]);
                var result = nameOptionsForm.ShowDialog();
                if (result == DialogResult.OK)
                {
                    filenameParams[fileNames[i]] = nameOptionsForm.filenameParams;
                }
                else allOk = false;
            }

            if (allOk)
            {
                BackgroundWorker workerThread = new BackgroundWorker();

                workerThread.DoWork += bw_DoWork;
                workerThread.RunWorkerCompleted += bw_RunWorkerCompleted;
                workerThread.RunWorkerAsync();
            }
            else
            {
                progressBar1.Hide();
                btn_beginFormatting.Text = "Begin Formatting";
                btn_beginFormatting.Enabled = true;
                button1.Enabled = true;
                textBox_FileName.Enabled = true;
            }
        }

        void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressBar1.Hide();
            btn_beginFormatting.Text = "Begin Formatting";
            btn_beginFormatting.Enabled = true;
            button1.Enabled = true;
            textBox_FileName.Enabled = true;
        }

        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            processAllFilesInParallel();
        }

        private void processAllFilesInParallel()
        {
            Dictionary<string, string> failedFiles = new Dictionary<string, string>();
            //Parallelize file processing
            Parallel.ForEach(fileNames, fileName => 
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
                });
            //if all files were processed successfully, inform the user; else, show error message(s)
            if (failedFiles.Count == 0)
            {
                MessageBox.Show("All files processed successfully!");
            }
            else
            {
                string message = "Some files could not be processed or written correctly: " + Environment.NewLine;
                foreach (string fileName in failedFiles.Keys)
                {
                    message += fileName + ": " + failedFiles[fileName] + Environment.NewLine + Environment.NewLine;
                }

                MessageBox.Show(message);
            }
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
                string[] thisFilenameParams = filenameParams[filePath];
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
                        string outputFilename = thisFilenameParams[0];
                        //int ToString("D3") pads the int with leading zeros making it 3 digits total
                        outputFilename += "-" + (i + 1).ToString("D3");
                        if (thisFilenameParams[1] == "true") outputFilename += "-" + DateTime.Now.ToString("MM-dd-yyyy");
                        else if (thisFilenameParams[1] == "specify")
                        {
                            outputFilename += "-" + thisFilenameParams[2];
                        }
                        outputFilename += ".csv";
                        File.WriteAllText(filePath + @".output\" + outputFilename, formattedCsvFiles[i]);
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
