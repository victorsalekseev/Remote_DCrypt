using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Remote_DCrypt.Action
{
    public partial class FormPwd : Form
    {
        public FormPwd()
        {
            InitializeComponent();
        }

        private void button_ok_Click(object sender, EventArgs e)
        {
            //SshFileTransfer ssh_ft = new SshFileTransfer();
            SshSettings.pwd = textBox.Text;
        }

        private void frm_pwd_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormKeyboard c = new FormKeyboard();
            c.ShowDialog();
        }
    }
}