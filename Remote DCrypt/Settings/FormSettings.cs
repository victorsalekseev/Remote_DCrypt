using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Security.Permissions;
using Microsoft.Win32;

// вот о чём речь
[assembly: RegistryPermissionAttribute(SecurityAction.RequestMinimum, All = "HKEY_CURRENT_USER")]
namespace Remote_DCrypt.Settings
{
    public partial class FormSettings : Form
    {
        public FormSettings()
        {
            InitializeComponent();
        }

        Options o = new Options();

        private void button_ok_Click(object sender, EventArgs e)
        {
            if (Crypt.CheckKeyFNameLen(textBox_fnamekey.Text))
            {
                SaveFromControls();
                SaveSetting.CreateSettings(o);
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                this.DialogResult = DialogResult.None;
            }
        }

        private void FormSettings_Load(object sender, EventArgs e)
        {
            SshConnection.KillSSH();
            //TODO Заглушка: аутентификация только с клавы
            comboBox_use_auth_key.SelectedIndex = 0;
            if (File.Exists(SaveSetting.path_to_set_file))
            {
                SaveSetting.LoadSettings(ref o);
            }
            else
            {
                o.key_fname = Crypt.default_key;//50;
                o.pwd_file_enc = Crypt.default_key;
                o.key_size = "256";
                o.server = "localhost";
                o.base_dir = "http/";
                o.user = "root";
                //o.pwd = "password";
                SaveSetting.CreateSettings(o);
            }
            LoadToControls();
        }

        private void LoadToControls()
        {
            textBox_fnamekey.Text = o.key_fname;
            textBox_serv.Text = o.server;
            textBox_basedir.Text = o.base_dir;
            textBox_user.Text = o.user;
            textBox_pwd.Text = o.pwd_file_enc;
            comboBox_key_size.Text = o.key_size;
            checkBox_shell.Checked = GetShellExCheck();
        }

        private bool GetShellExCheck()
        {
            string somename = Application.ProductName;
            RegistryKey regKey = Registry.CurrentUser;
            regKey = regKey.OpenSubKey(@"Software\Classes\*\shell\" + somename + @"\command");
            if (regKey != null)
            {
                try
                {
                    if (code_for_shell_exec() == regKey.GetValue("").ToString())
                        return true;
                    else
                        return false;
                }
                catch
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        private void SaveFromControls()
        {
            o.key_fname = textBox_fnamekey.Text;
            o.server = textBox_serv.Text;
            o.base_dir = textBox_basedir.Text;
            o.user = textBox_user.Text;
            o.pwd_file_enc = textBox_pwd.Text;
            o.key_size = comboBox_key_size.Text;
            SetShellEx(checkBox_shell.Checked);
        }

        private void SetShellEx(bool save)
        {
            string somename = Application.ProductName;
            if (save)
            {
                RegistryKey regKey = Registry.CurrentUser;
                regKey = regKey.CreateSubKey(@"Software\Classes\*\shell\" + somename + @"\command");
                regKey.SetValue("", (object)code_for_shell_exec());
            }
            else
            {
                RegistryKey regKey = Registry.CurrentUser;
                regKey = regKey.OpenSubKey(@"Software\Classes\*\shell", true);//\somename\command", true);
                if (regKey != null)
                {
                    try
                    {
                        regKey.DeleteSubKeyTree(somename);
                    }
                    catch
                    {}
                }
            }
        }

        private string code_for_shell_exec()
        {
            return Application.ExecutablePath + " \"" + "%1" + "\"";
        }

        private void textBox_fnamekey_TextChanged(object sender, EventArgs e)
        {
            textBox_count.Text = textBox_fnamekey.Text.Length.ToString();
        }

        private void FormSettings_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void FormSettings_FormClosed(object sender, FormClosedEventArgs e)
        {
            SshConnection.InitSSH();
        }

        private void label_msg_Click(object sender, EventArgs e)
        {

        }

        private void comboBox_key_size_SelectedIndexChanged(object sender, EventArgs e)
        {
            int key_err = 256;
            if (int.TryParse(comboBox_key_size.Text, out key_err))
            {
                comboBox_key_size.SelectedText = key_err.ToString();
            }
        }

    }
}