namespace Drive_Test_Formatter
{
    partial class Form1
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox_FileName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_beginFormatting = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "Comma Separated Values|*.csv|All Files|*.*";
            this.openFileDialog1.Multiselect = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(372, 32);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Browse...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox_FileName
            // 
            this.textBox_FileName.Location = new System.Drawing.Point(12, 35);
            this.textBox_FileName.Name = "textBox_FileName";
            this.textBox_FileName.Size = new System.Drawing.Size(354, 20);
            this.textBox_FileName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Choose File(s):";
            // 
            // btn_beginFormatting
            // 
            this.btn_beginFormatting.Location = new System.Drawing.Point(12, 61);
            this.btn_beginFormatting.Name = "btn_beginFormatting";
            this.btn_beginFormatting.Size = new System.Drawing.Size(435, 23);
            this.btn_beginFormatting.TabIndex = 3;
            this.btn_beginFormatting.Text = "Begin Formatting";
            this.btn_beginFormatting.UseVisualStyleBackColor = true;
            this.btn_beginFormatting.Visible = false;
            this.btn_beginFormatting.Click += new System.EventHandler(this.btn_beginFormatting_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 105);
            this.progressBar1.MarqueeAnimationSpeed = 20;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(435, 23);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar1.TabIndex = 4;
            this.progressBar1.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(459, 142);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btn_beginFormatting);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_FileName);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Drive Test CSV Formatter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox_FileName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_beginFormatting;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}

