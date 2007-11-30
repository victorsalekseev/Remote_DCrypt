namespace Remote_DCrypt.Action
{
    partial class FormAction
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.button_ok = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.listBox_log = new System.Windows.Forms.ListBox();
            this.label_status = new System.Windows.Forms.Label();
            this.progressBar_status = new System.Windows.Forms.ProgressBar();
            this.textBox_dst_file = new System.Windows.Forms.TextBox();
            this.label_dst_file = new System.Windows.Forms.Label();
            this.textBox_src_file = new System.Windows.Forms.TextBox();
            this.label_src_file = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button_ok);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 160);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(345, 34);
            this.panel1.TabIndex = 2;
            // 
            // button_ok
            // 
            this.button_ok.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_ok.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button_ok.Enabled = false;
            this.button_ok.Location = new System.Drawing.Point(258, 3);
            this.button_ok.Name = "button_ok";
            this.button_ok.Size = new System.Drawing.Size(75, 23);
            this.button_ok.TabIndex = 0;
            this.button_ok.Text = "ОК";
            this.button_ok.UseVisualStyleBackColor = true;
            this.button_ok.Click += new System.EventHandler(this.button_ok_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.listBox_log);
            this.panel2.Controls.Add(this.label_status);
            this.panel2.Controls.Add(this.progressBar_status);
            this.panel2.Controls.Add(this.textBox_dst_file);
            this.panel2.Controls.Add(this.label_dst_file);
            this.panel2.Controls.Add(this.textBox_src_file);
            this.panel2.Controls.Add(this.label_src_file);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(345, 160);
            this.panel2.TabIndex = 3;
            // 
            // listBox_log
            // 
            this.listBox_log.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox_log.FormattingEnabled = true;
            this.listBox_log.Location = new System.Drawing.Point(12, 92);
            this.listBox_log.Name = "listBox_log";
            this.listBox_log.Size = new System.Drawing.Size(321, 56);
            this.listBox_log.TabIndex = 6;
            // 
            // label_status
            // 
            this.label_status.AutoSize = true;
            this.label_status.Location = new System.Drawing.Point(12, 68);
            this.label_status.Name = "label_status";
            this.label_status.Size = new System.Drawing.Size(54, 13);
            this.label_status.TabIndex = 5;
            this.label_status.Text = "Загрузка";
            // 
            // progressBar_status
            // 
            this.progressBar_status.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar_status.Location = new System.Drawing.Point(73, 63);
            this.progressBar_status.Name = "progressBar_status";
            this.progressBar_status.Size = new System.Drawing.Size(260, 23);
            this.progressBar_status.TabIndex = 4;
            // 
            // textBox_dst_file
            // 
            this.textBox_dst_file.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_dst_file.Enabled = false;
            this.textBox_dst_file.Location = new System.Drawing.Point(73, 38);
            this.textBox_dst_file.Name = "textBox_dst_file";
            this.textBox_dst_file.Size = new System.Drawing.Size(260, 20);
            this.textBox_dst_file.TabIndex = 3;
            // 
            // label_dst_file
            // 
            this.label_dst_file.AutoSize = true;
            this.label_dst_file.Location = new System.Drawing.Point(12, 41);
            this.label_dst_file.Name = "label_dst_file";
            this.label_dst_file.Size = new System.Drawing.Size(59, 13);
            this.label_dst_file.TabIndex = 2;
            this.label_dst_file.Text = "Приемник";
            // 
            // textBox_src_file
            // 
            this.textBox_src_file.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_src_file.Enabled = false;
            this.textBox_src_file.Location = new System.Drawing.Point(73, 12);
            this.textBox_src_file.Name = "textBox_src_file";
            this.textBox_src_file.Size = new System.Drawing.Size(260, 20);
            this.textBox_src_file.TabIndex = 1;
            // 
            // label_src_file
            // 
            this.label_src_file.AutoSize = true;
            this.label_src_file.Location = new System.Drawing.Point(12, 15);
            this.label_src_file.Name = "label_src_file";
            this.label_src_file.Size = new System.Drawing.Size(55, 13);
            this.label_src_file.TabIndex = 0;
            this.label_src_file.Text = "Источник";
            // 
            // FormAction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(345, 194);
            this.ControlBox = false;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormAction";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Копирование";
            this.Shown += new System.EventHandler(this.FormAction_Shown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormAction_FormClosing);
            this.Load += new System.EventHandler(this.FormAction_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox textBox_dst_file;
        private System.Windows.Forms.Label label_dst_file;
        private System.Windows.Forms.TextBox textBox_src_file;
        private System.Windows.Forms.Label label_src_file;
        private System.Windows.Forms.Button button_ok;
        private System.Windows.Forms.ListBox listBox_log;
        private System.Windows.Forms.Label label_status;
        private System.Windows.Forms.ProgressBar progressBar_status;
    }
}