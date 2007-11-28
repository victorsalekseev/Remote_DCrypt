namespace Remote_DCrypt.Action
{
    partial class FormCmd
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
            this.panel_cmd = new System.Windows.Forms.Panel();
            this.button_go = new System.Windows.Forms.Button();
            this.panel_list = new System.Windows.Forms.Panel();
            this.textBox_text = new System.Windows.Forms.TextBox();
            this.label = new System.Windows.Forms.Label();
            this.textBox_cmd = new System.Windows.Forms.TextBox();
            this.panel_cmd.SuspendLayout();
            this.panel_list.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_cmd
            // 
            this.panel_cmd.Controls.Add(this.textBox_cmd);
            this.panel_cmd.Controls.Add(this.label);
            this.panel_cmd.Controls.Add(this.button_go);
            this.panel_cmd.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel_cmd.Location = new System.Drawing.Point(0, 251);
            this.panel_cmd.Name = "panel_cmd";
            this.panel_cmd.Size = new System.Drawing.Size(620, 21);
            this.panel_cmd.TabIndex = 1;
            // 
            // button_go
            // 
            this.button_go.BackColor = System.Drawing.Color.WhiteSmoke;
            this.button_go.Dock = System.Windows.Forms.DockStyle.Right;
            this.button_go.Location = new System.Drawing.Point(576, 0);
            this.button_go.Name = "button_go";
            this.button_go.Size = new System.Drawing.Size(44, 21);
            this.button_go.TabIndex = 2;
            this.button_go.Text = "RUN";
            this.button_go.UseVisualStyleBackColor = false;
            this.button_go.Click += new System.EventHandler(this.button_go_Click);
            // 
            // panel_list
            // 
            this.panel_list.Controls.Add(this.textBox_text);
            this.panel_list.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_list.Location = new System.Drawing.Point(0, 0);
            this.panel_list.Name = "panel_list";
            this.panel_list.Size = new System.Drawing.Size(620, 251);
            this.panel_list.TabIndex = 2;
            // 
            // textBox_text
            // 
            this.textBox_text.BackColor = System.Drawing.Color.Black;
            this.textBox_text.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_text.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_text.ForeColor = System.Drawing.Color.White;
            this.textBox_text.Location = new System.Drawing.Point(0, 0);
            this.textBox_text.Multiline = true;
            this.textBox_text.Name = "textBox_text";
            this.textBox_text.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_text.Size = new System.Drawing.Size(620, 251);
            this.textBox_text.TabIndex = 0;
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Dock = System.Windows.Forms.DockStyle.Left;
            this.label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label.Location = new System.Drawing.Point(0, 0);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(70, 17);
            this.label.TabIndex = 3;
            this.label.Text = "Команда:";
            this.label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox_cmd
            // 
            this.textBox_cmd.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBox_cmd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_cmd.Location = new System.Drawing.Point(70, 0);
            this.textBox_cmd.Name = "textBox_cmd";
            this.textBox_cmd.Size = new System.Drawing.Size(506, 20);
            this.textBox_cmd.TabIndex = 5;
            // 
            // FormCmd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(620, 272);
            this.Controls.Add(this.panel_list);
            this.Controls.Add(this.panel_cmd);
            this.DoubleBuffered = true;
            this.Name = "FormCmd";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Командная строка сервера (упрощенная)";
            this.Shown += new System.EventHandler(this.FormCmd_Shown);
            this.Load += new System.EventHandler(this.FormCmd_Load);
            this.panel_cmd.ResumeLayout(false);
            this.panel_cmd.PerformLayout();
            this.panel_list.ResumeLayout(false);
            this.panel_list.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_cmd;
        private System.Windows.Forms.Button button_go;
        private System.Windows.Forms.Panel panel_list;
        private System.Windows.Forms.TextBox textBox_text;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.TextBox textBox_cmd;
    }
}