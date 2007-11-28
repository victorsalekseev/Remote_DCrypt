using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Remote_DCrypt.Action
{
    public partial class FormCmd : Form
    {
        public FormCmd()
        {
            InitializeComponent();
            textBox_cmd.KeyDown += new KeyEventHandler(textBox_cmd_KeyDown);
        }

        private void textBox_cmd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ExCmd();
            }
        }

        private void button_go_Click(object sender, EventArgs e)
        {
            ExCmd();
        }

        private void ExCmd()
        {
            string cmd = SshConnection.ExecBashCommand(textBox_cmd.Text);
            if (cmd == null)
            {
                textBox_text.AppendText("Error executing command!" + Environment.NewLine);
            }
            else
            {
                cmd = Regex.Replace(cmd, "\n\r", "\n");
                cmd = Regex.Replace(cmd, "\n", Environment.NewLine);
                textBox_text.AppendText(Environment.NewLine + "[" + SshConnection.sshexec.Username + "@" + SshConnection.sshexec.Host + "]: " + textBox_cmd.Text + Environment.NewLine + cmd + Environment.NewLine);
            }
        }

        private void FormCmd_Load(object sender, EventArgs e)
        {
        }

        private void FormCmd_Shown(object sender, EventArgs e)
        {
            FormConnecting fl = new FormConnecting();
            try
            {
                fl.Show();
                textBox_text.AppendText(fl.GetFirstSSH());
                Application.DoEvents();                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
            finally
            {
                
            }

        }
    }
}