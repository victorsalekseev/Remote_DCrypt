using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using Remote_DCrypt.Action;
using Remote_DCrypt.Settings;

namespace Remote_DCrypt
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] argc)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if ((argc.Length > 0) && (File.Exists(argc[0])))
            {
                //MessageBox.Show(argc[0]);
                FileInfo fi = new FileInfo(argc[0]);
                if (!SshConnection.InitSSH())
                {
                    MessageBox.Show("Ошибка загрузки файла настроек" + Environment.NewLine + "Удалите файл " + SaveSetting.path_to_set_file + Environment.NewLine + "и перезапустите программу.");
                    Application.Exit();
                }
                Application.Run(new FormAction(fi.FullName, fi.Name, true, fi.DirectoryName));
                SshConnection.KillSSH();
            }
            else
            {
                //MessageBox.Show(argc[0]);
                Application.Run(new FormMain());
            }
        }
    }
}