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
        public string filePath;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Show the dialog and get result.
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
                filePath = openFileDialog1.FileName;
                textBox_FileName.Text = filePath;
                btn_beginFormatting.Visible = true;
            }
        }

        private void btn_beginFormatting_Click(object sender, EventArgs e)
        {
            if (File.Exists(filePath))
            {
                string csvData = File.ReadAllText(filePath);
                DriveTestData driveTestData = new DriveTestData(csvData);
                string xmlData = driveTestData.XmlText;
                if (!Directory.Exists(filePath + @".output"))
                {
                    Directory.CreateDirectory(filePath + @".output");
                }
                try
                {
                    File.WriteAllText(filePath + @".output\output.xml", xmlData);
                    MessageBox.Show("Output file written successfully!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Something went wrong when trying to write the output file. Please try again." + Environment.NewLine + ex);
                }
            }
            else
            {
                MessageBox.Show("The system could not find the file specified.");
            }
        }
    }
}
