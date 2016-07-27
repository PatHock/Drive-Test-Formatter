using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Drive_Test_Formatter
{
    public partial class NamingOptionsForm : Form
    {
        public string[] filenameParams{ get; set; }
        public NamingOptionsForm(string inputFilename)
        {
            InitializeComponent();
            this.Text = this.Text + inputFilename.Substring(inputFilename.LastIndexOf('\\') + 1);
            this.filenameParams = new string[3];
            this.filenameParams = filenameParams;
            this.lbl_inputFilename.Text = "Output file naming options for input file " + inputFilename.Substring(inputFilename.LastIndexOf('\\') + 1) + ":";
            this.gb_dateRadioButtons.Enabled = this.cb_includeDate.Checked;
            this.textBox_specifyDate.Enabled = this.rb_specifyDate.Checked;
        }

        private void cb_includeDate_CheckedChanged(object sender, EventArgs e)
        {
            this.gb_dateRadioButtons.Enabled = this.cb_includeDate.Checked;
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            Boolean success = generateFilenameParams();
            if (success)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Please fill out this form completely.");
                return;
            }
        }

        public Boolean generateFilenameParams()
        {
            if (this.cb_includeDate.Checked)
            {
                if(rb_specifyDate.Checked && (this.textBox_specifyDate.Text == null || this.textBox_specifyDate.Text == "")) return false;
            }

            if (this.textBox_outputFilenamePrefix.Text == null) filenameParams[0] = "";
            else
            {
                if (this.textBox_outputFilenamePrefix.Text != null && this.textBox_outputFilenamePrefix.Text != "")
                {
                    filenameParams[0] = this.textBox_outputFilenamePrefix.Text + "-";
                }
                else
                {
                    filenameParams[0] = "";
                }
            }

            if (this.cb_includeDate.Checked)
            {
                if (this.rb_todaysDate.Checked) filenameParams[1] = "true";
                else if (this.rb_specifyDate.Checked)
                {
                    filenameParams[1] = "specify";
                    filenameParams[2] = this.textBox_specifyDate.Text;
                }
            }
            else
            {
                filenameParams[1] = "false";
            }
            
            return true;
        }

        private void rb_specifyDate_CheckedChanged(object sender, EventArgs e)
        {
            this.textBox_specifyDate.Enabled = this.rb_specifyDate.Checked;
        }
    }
}
