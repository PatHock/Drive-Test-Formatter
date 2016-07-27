namespace Drive_Test_Formatter
{
    partial class NamingOptionsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbl_inputFilename = new System.Windows.Forms.Label();
            this.lbl_filenamePrefix = new System.Windows.Forms.Label();
            this.textBox_outputFilenamePrefix = new System.Windows.Forms.TextBox();
            this.lbl_includeDate = new System.Windows.Forms.Label();
            this.cb_includeDate = new System.Windows.Forms.CheckBox();
            this.gb_dateRadioButtons = new System.Windows.Forms.GroupBox();
            this.textBox_specifyDate = new System.Windows.Forms.TextBox();
            this.rb_specifyDate = new System.Windows.Forms.RadioButton();
            this.rb_todaysDate = new System.Windows.Forms.RadioButton();
            this.btn_OK = new System.Windows.Forms.Button();
            this.gb_dateRadioButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_inputFilename
            // 
            this.lbl_inputFilename.AutoSize = true;
            this.lbl_inputFilename.Location = new System.Drawing.Point(13, 13);
            this.lbl_inputFilename.Name = "lbl_inputFilename";
            this.lbl_inputFilename.Size = new System.Drawing.Size(0, 13);
            this.lbl_inputFilename.TabIndex = 0;
            // 
            // lbl_filenamePrefix
            // 
            this.lbl_filenamePrefix.AutoSize = true;
            this.lbl_filenamePrefix.Location = new System.Drawing.Point(13, 30);
            this.lbl_filenamePrefix.Name = "lbl_filenamePrefix";
            this.lbl_filenamePrefix.Size = new System.Drawing.Size(121, 13);
            this.lbl_filenamePrefix.TabIndex = 1;
            this.lbl_filenamePrefix.Text = "Output File Name Prefix:";
            // 
            // textBox_outputFilenamePrefix
            // 
            this.textBox_outputFilenamePrefix.Location = new System.Drawing.Point(13, 47);
            this.textBox_outputFilenamePrefix.Name = "textBox_outputFilenamePrefix";
            this.textBox_outputFilenamePrefix.Size = new System.Drawing.Size(121, 20);
            this.textBox_outputFilenamePrefix.TabIndex = 2;
            // 
            // lbl_includeDate
            // 
            this.lbl_includeDate.AutoSize = true;
            this.lbl_includeDate.Location = new System.Drawing.Point(151, 30);
            this.lbl_includeDate.Name = "lbl_includeDate";
            this.lbl_includeDate.Size = new System.Drawing.Size(132, 13);
            this.lbl_includeDate.TabIndex = 3;
            this.lbl_includeDate.Text = "Include Date in File Name:";
            // 
            // cb_includeDate
            // 
            this.cb_includeDate.AutoSize = true;
            this.cb_includeDate.Location = new System.Drawing.Point(290, 30);
            this.cb_includeDate.Name = "cb_includeDate";
            this.cb_includeDate.Size = new System.Drawing.Size(15, 14);
            this.cb_includeDate.TabIndex = 4;
            this.cb_includeDate.UseVisualStyleBackColor = true;
            this.cb_includeDate.CheckedChanged += new System.EventHandler(this.cb_includeDate_CheckedChanged);
            // 
            // gb_dateRadioButtons
            // 
            this.gb_dateRadioButtons.Controls.Add(this.textBox_specifyDate);
            this.gb_dateRadioButtons.Controls.Add(this.rb_specifyDate);
            this.gb_dateRadioButtons.Controls.Add(this.rb_todaysDate);
            this.gb_dateRadioButtons.Location = new System.Drawing.Point(154, 50);
            this.gb_dateRadioButtons.Name = "gb_dateRadioButtons";
            this.gb_dateRadioButtons.Size = new System.Drawing.Size(200, 100);
            this.gb_dateRadioButtons.TabIndex = 5;
            this.gb_dateRadioButtons.TabStop = false;
            this.gb_dateRadioButtons.Text = "Date Options:";
            // 
            // textBox_specifyDate
            // 
            this.textBox_specifyDate.Location = new System.Drawing.Point(102, 44);
            this.textBox_specifyDate.Name = "textBox_specifyDate";
            this.textBox_specifyDate.Size = new System.Drawing.Size(91, 20);
            this.textBox_specifyDate.TabIndex = 2;
            // 
            // rb_specifyDate
            // 
            this.rb_specifyDate.AutoSize = true;
            this.rb_specifyDate.Location = new System.Drawing.Point(7, 44);
            this.rb_specifyDate.Name = "rb_specifyDate";
            this.rb_specifyDate.Size = new System.Drawing.Size(89, 17);
            this.rb_specifyDate.TabIndex = 1;
            this.rb_specifyDate.TabStop = true;
            this.rb_specifyDate.Text = "Specify Date:";
            this.rb_specifyDate.UseVisualStyleBackColor = true;
            this.rb_specifyDate.CheckedChanged += new System.EventHandler(this.rb_specifyDate_CheckedChanged);
            // 
            // rb_todaysDate
            // 
            this.rb_todaysDate.AutoSize = true;
            this.rb_todaysDate.Location = new System.Drawing.Point(7, 20);
            this.rb_todaysDate.Name = "rb_todaysDate";
            this.rb_todaysDate.Size = new System.Drawing.Size(88, 17);
            this.rb_todaysDate.TabIndex = 0;
            this.rb_todaysDate.TabStop = true;
            this.rb_todaysDate.Text = "Today\'s Date";
            this.rb_todaysDate.UseVisualStyleBackColor = true;
            // 
            // btn_OK
            // 
            this.btn_OK.Location = new System.Drawing.Point(12, 157);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(342, 23);
            this.btn_OK.TabIndex = 6;
            this.btn_OK.Text = "OK";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // NamingOptionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(366, 188);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.gb_dateRadioButtons);
            this.Controls.Add(this.cb_includeDate);
            this.Controls.Add(this.lbl_includeDate);
            this.Controls.Add(this.textBox_outputFilenamePrefix);
            this.Controls.Add(this.lbl_filenamePrefix);
            this.Controls.Add(this.lbl_inputFilename);
            this.Name = "NamingOptionsForm";
            this.Text = "Naming Options - ";
            this.gb_dateRadioButtons.ResumeLayout(false);
            this.gb_dateRadioButtons.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_inputFilename;
        private System.Windows.Forms.Label lbl_filenamePrefix;
        private System.Windows.Forms.TextBox textBox_outputFilenamePrefix;
        private System.Windows.Forms.Label lbl_includeDate;
        private System.Windows.Forms.CheckBox cb_includeDate;
        private System.Windows.Forms.GroupBox gb_dateRadioButtons;
        private System.Windows.Forms.TextBox textBox_specifyDate;
        private System.Windows.Forms.RadioButton rb_specifyDate;
        private System.Windows.Forms.RadioButton rb_todaysDate;
        private System.Windows.Forms.Button btn_OK;
    }
}