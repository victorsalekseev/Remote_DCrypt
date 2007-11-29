using System;
using System.Collections.Generic;
using System.Text;
using Tamir.SharpSsh;
using Remote_DCrypt.Settings;
using Tamir.SharpSsh.java.io;
using System.Windows.Forms;

namespace Remote_DCrypt
{
    //public struct SshConnectionInfo
    //{
    //    public string Host;
    //    public string User;
    //    public string Pass;
    //    public string IdentityFile;
    //}
    /// <summary>
    /// Sample showing the use of the SSH file trasfer features of 
    /// SharpSSH such as SFTP and SCP
    /// </summary>
    public static class SshSettings
    {
        /// <summary>
        /// Пароль для входа по SSH
        /// </summary>
        public static string pwd;
        /// <summary>
        /// Ключ для шифрования имен файлов
        /// </summary>
        public static string key_fname;
        /// <summary>
        /// Ключ для шифрования файлов
        /// </summary>
        public static string pwd_file_enc; 

        public static string key_size;
        public static string local_path; 
        public static string base_dir;
        public static string server;
        public static string user;
    }

    public static class SshConnection
    {
        public static SshExec sshexec;
        public static SshTransferProtocolBase sshsess;
        public static bool InitSSH()
        {
            bool yes = false;
            if (LoadSettings())
            {
                SshExec exec = new SshExec(SshSettings.server, SshSettings.user);
                sshexec = exec;

                SshTransferProtocolBase sshCp = new Scp(SshSettings.server, SshSettings.user);
                //А можно и так
                //sshCp = new Sftp(input.Host, input.User);
                sshsess = sshCp;
                yes = true;
            }
            else
            {
                yes = false;
            }
            return yes;
        }
        public static void KillSSH()
        {
            if (SshConnection.sshexec != null)
            {
                if (SshConnection.sshexec.Connected)
                    SshConnection.sshexec.Close();
            }

            if (SshConnection.sshsess != null)
            {
                if (SshConnection.sshsess.Connected)
                    SshConnection.sshsess.Close();
            }
            SshSettings.pwd = null;
        }
        private static bool LoadSettings()
        {
            bool yes = false;
            try
            {
                Options o = new Options();
                if (System.IO.File.Exists(SaveSetting.path_to_set_file))
                {
                    SaveSetting.LoadSettings(ref o);
                }
                //else
                //{
                //    FormSettings frm_set = new FormSettings();
                //    if (frm_set.ShowDialog() == DialogResult.OK)
                //    {
                //        SaveSetting.LoadSettings(ref o);
                //    }
                //}
                SshSettings.base_dir = o.base_dir;
                SshSettings.key_fname = o.key_fname;
                SshSettings.key_size = o.key_size;
                SshSettings.pwd_file_enc = o.pwd_file_enc;
                //SshSettings.local_path = string.Empty;//AppDomain.CurrentDomain.BaseDirectory; 
                SshSettings.server = o.server;
                SshSettings.user = o.user;
                yes = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " +ex.Message);
                yes = false;
            }
            return yes;
        }
        public static string ExecBashCommand(string command)
        {
            string return_value = null;
            SshConnection.sshexec.Password = SshSettings.pwd;
            try
            {
                Application.DoEvents();
                if (!SshConnection.sshexec.Connected)
                {
                    SshConnection.sshexec.Connect();
                }
                Application.DoEvents();
                return_value = SshConnection.sshexec.RunCommand(command);
                Application.DoEvents();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Проверьте настройки подключения" + Environment.NewLine + "Произошла ошибка: " + ex.Message);
                return_value = null;
            }
            finally
            {

            }
            return return_value;
        }
    }
}
