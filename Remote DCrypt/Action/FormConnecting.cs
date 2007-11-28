using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Tamir.SharpSsh;
using Remote_DCrypt.Settings;
using System.Text.RegularExpressions;

namespace Remote_DCrypt.Action
{
    public partial class FormConnecting : Form
    {
        public FormConnecting()
        {
            InitializeComponent();
        }

        private void FormFileList_Shown(object sender, EventArgs e)
        {
        }

        public string[] GetFileList()
        {
            //FileLists fil_lst = new FileLists();
            string[] return_value = null;
            SshConnection.sshexec.Password = SshSettings.pwd;
            //изменитьToolStripMenuItem.Enabled = false;
            ////TODO Соединение с сервером, получение списка файлов
            try
            {
                listBox_log.Items.Add("Connecting...");
                Application.DoEvents();
                if (!SshConnection.sshexec.Connected)
                {
                    SshConnection.sshexec.Connect();
                }
                Application.DoEvents();
                listBox_log.Items.Add("Connected");

                string files = SshConnection.sshexec.RunCommand("ls " + SshSettings.base_dir);
                files = Regex.Replace(files, "\n\r", "\n");
                string[] arr_files = Regex.Split(files, "\n");

                listBox_log.Items.Add("Disconnecting...");
                //FileLists.sshexec.Close();
                listBox_log.Items.Add("OK");
                return_value = arr_files;               
            }
            catch (Exception ex)
            {
                MessageBox.Show("Проверьте настройки подключения" + Environment.NewLine + "Произошла ошибка: " + ex.Message);
                //изменитьToolStripMenuItem.Enabled = true;
                listBox_log.Items.Add("ERROR");
                return_value = null;
            }
            finally
            {
                if (return_value != null)
                {
                    this.Close();
                }
            }

            return return_value;
        }

        public string GetFirstSSH()
        {
            //FileLists fil_lst = new FileLists();
            string return_value = null;
            SshConnection.sshexec.Password = SshSettings.pwd;
            //изменитьToolStripMenuItem.Enabled = false;
            ////TODO Соединение с сервером, получение списка файлов
            try
            {
                listBox_log.Items.Add("Connecting...");
                Application.DoEvents();
                if (!SshConnection.sshexec.Connected)
                {
                    SshConnection.sshexec.Connect();
                }
                Application.DoEvents();
                listBox_log.Items.Add("Connected");

                string first_cmd = SshConnection.ExecBashCommand("ls -la");
                first_cmd = Regex.Replace(first_cmd, "\n\r", "\n");
                first_cmd = Regex.Replace(first_cmd, "\n", Environment.NewLine);

                return_value = "Server version:  " + SshConnection.sshexec.ServerVersion + Environment.NewLine +
                     "Chiper algorytm: " + SshConnection.sshexec.Cipher + Environment.NewLine + first_cmd;

                listBox_log.Items.Add("Disconnecting...");
                //FileLists.sshexec.Close();
                listBox_log.Items.Add("OK");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Проверьте настройки подключения" + Environment.NewLine + "Произошла ошибка: " + ex.Message);
                //изменитьToolStripMenuItem.Enabled = true;
                listBox_log.Items.Add("ERROR");
                return_value = null;
            }
            finally
            {
                if (return_value != null)
                {
                    this.Close();
                }
            }

            return return_value;

        }

        private void FormFileList_Load(object sender, EventArgs e)
        {

        }
    }
}