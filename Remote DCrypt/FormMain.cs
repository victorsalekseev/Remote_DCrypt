using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Remote_DCrypt.Settings;
using System.IO;
using System.Security;
using Remote_DCrypt.Action;
using System.Text.RegularExpressions;
using Tamir.SharpSsh;

namespace Remote_DCrypt
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void изменитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (FormSettings frm_fs = new FormSettings())
            {
                if (MessageBox.Show("Если Вы вносите новые настройки, Все соединения закрываются."+Environment.NewLine+"Согласны сделать это сейчас?", "Внимание", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    listView_remote.Items.Clear();
                    frm_fs.ShowDialog();                    
                }
            }
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Crypt cr = new Crypt();
            //textBox1.Text = cr.DecryptFName(textBox2.Text);
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            listView_Local.DoubleClick += new EventHandler(listView_Local_DoubleClick);
            listView_Local.SelectedIndexChanged += new EventHandler(listView_Local_SelectedIndexChanged);

            listView_remote.DoubleClick += new EventHandler(listView_remote_DoubleClick);
            listView_remote.SelectedIndexChanged += new EventHandler(listView_remote_SelectedIndexChanged);

            if (!File.Exists(SaveSetting.path_to_set_file))
            {
                FormSettings frm_set = new FormSettings();
                frm_set.ShowDialog();
            }
            SshConnection.KillSSH();
            if (!SshConnection.InitSSH())
            {
                MessageBox.Show("Ошибка загрузки файла настроек" + Environment.NewLine + "Удалите файл " + SaveSetting.path_to_set_file + Environment.NewLine + "и перезапустите программу." );
                Application.Exit();
            }
            GetDirs("", listView_Local);
        }

        private void listView_Local_DoubleClick(object sender, EventArgs e)
        {
            if (isSelectedLV(listView_Local))
            {
                switch (listView_Local.SelectedItems[0].Name)
                {
                    case "Directory":
                        {
                            textBoxPath.Text = listView_Local.SelectedItems[0].Tag.ToString();
                            GetDirs(listView_Local.SelectedItems[0].Tag.ToString(), listView_Local);
                        }
                        break;

                    case "File":
                        {
                            EnCrypting(listView_Local, SshSettings.local_path);
                        }
                        break;

                    case "Drive":
                        {
                            textBoxPath.Text = listView_Local.SelectedItems[0].Tag.ToString();
                            GetDirs(listView_Local.SelectedItems[0].Tag.ToString(), listView_Local);
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        private void listView_Local_SelectedIndexChanged(object sender, EventArgs e)
        {
            Enabled_btn_copy(listView_Local, listView_remote, button_to_remote, new ToolStripMenuItem[] { загрузитьToolStripMenuItem, открытьToolStripMenuItem, изменитьToolStripMenuItem1, удалитьToolStripMenuItem });
        }

        private void listView_remote_DoubleClick(object sender, EventArgs e)
        {
            if (isSelectedLV(listView_remote))
            {
                switch (listView_remote.SelectedItems[0].Name)
                {
                    case "File":
                        {
                            DeCrypting(listView_remote, SshSettings.local_path);
                        }
                        break;

                    default:
                        break;
                }
            }
        }

        private void listView_remote_SelectedIndexChanged(object sender, EventArgs e)
        {
            Enabled_btn_copy(listView_remote, listView_remote, button_from_remote, new ToolStripMenuItem[] { скачатьToolStripMenuItem, удалитьToolStripMenuItem_rem });
        }
        
        private void соединитьсяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Load_lv_remote();
        }

        private void Load_lv_remote()
        {
            if (SshSettings.pwd == null)
            {
                FormPwd fp = new FormPwd();
                if (fp.ShowDialog() == DialogResult.OK)
                {
                    GetFileList(listView_remote);
                }
            }
            else
            {
                GetFileList(listView_remote);
            }
        }
        
        private void button_to_remote_Click(object sender, EventArgs e)
        {
            EnCrypting(listView_Local, SshSettings.local_path);
        }

        private void GetFileList(ListView lv)
        {
            using (FormConnecting fl = new FormConnecting())
            {
                fl.Show();
                string[] srr = fl.GetFileList();
                if (srr != null)
                {
                    lv.Items.Clear();
                    foreach (string var in srr)
                    {
                        string dec_name = new Crypt().DecryptFName(var, SshSettings.key_fname);
                        if (!string.IsNullOrEmpty(dec_name))
                        {
                            ListViewItem li = new ListViewItem();
                            li.Name = "File";
                            li.Text = dec_name;
                            li.Group = lv.Groups["listViewGroupFiles"];
                            li.ImageIndex = 3;
                            li.Tag = SshSettings.base_dir + var;
                            lv.Items.Add(li);
                        }
                    }
                }
            }
        }

        private void GetDirs(string init_dir, ListView l_view)
        {
            l_view.Items.Clear();

            if (init_dir.Length == 0/* || init_dir.Length == 2*/)
            {
                DriveInfo[] dinf = DriveInfo.GetDrives();
                foreach (DriveInfo dic in dinf)
                {
                    ListViewItem li = new ListViewItem();
                    li.Name = "Drive";
                    //if (dic.IsReady)
                    //{
                    //    li.Text = dic.Name + "      (" + dic.VolumeLabel + ")";
                    //}
                    //else
                    {
                        li.Text = dic.Name;
                    }
                    li.Tag = Path.Combine(init_dir, dic.Name.Remove(dic.Name.LastIndexOf("\\")));
                    li.Group = l_view.Groups["listViewGroupDrives"];
                    li.ImageIndex = 2;
                    li.SubItems.Add(dic.DriveType.ToString());
                    l_view.Items.Add(li);
                }
                SshSettings.local_path = string.Empty;
            }
            else
            {
                ListViewItem liUp = new ListViewItem();
                liUp.Name = init_dir;
                liUp.Text = "..";

                if (init_dir.Length > 2)
                {
                    liUp.Tag = init_dir.Remove(init_dir.LastIndexOf("\\"));
                }
                else
                {
                    liUp.Tag = string.Empty;
                }
                liUp.Name = "Directory";
                liUp.Group = l_view.Groups["listViewGroupFolders"];
                liUp.ImageIndex = 0;
                l_view.Items.Add(liUp);

                if (init_dir.Length == 2)
                {
                    init_dir = init_dir + "\\";
                }

                DirectoryInfo di = new DirectoryInfo(init_dir);
                try
                {
                    foreach (DirectoryInfo dic in di.GetDirectories())
                    {
                        ListViewItem li = new ListViewItem();
                        li.Name = "Directory";
                        li.Text = dic.Name;
                        li.Tag = Path.Combine(init_dir, dic.Name);
                        SshSettings.local_path = init_dir;
                        li.Group = l_view.Groups["listViewGroupFolders"];
                        li.ImageIndex = 0;
                        l_view.Items.Add(li);
                    }

                    foreach (FileInfo dic in di.GetFiles())
                    {
                        ListViewItem li = new ListViewItem();
                        li.Name = "File";
                        li.Text = dic.Name;
                        li.Tag = Path.Combine(init_dir, dic.Name);
                        li.Group = l_view.Groups["listViewGroupFiles"];
                        li.ImageIndex = 1;
                        if (dic.Length < 10240)
                        {
                            li.SubItems.Add(dic.Length + " Байт");
                        }
                        else
                        {
                            li.SubItems.Add(Math.Floor((decimal)dic.Length / 1024) + " кБайт");
                        }
                        l_view.Items.Add(li);
                    }
                }
                catch (UnauthorizedAccessException)
                {
                    //i.e.: System Volyme Information
                }
                catch (IOException)
                {
                    //i.e.: File is Folder
                }
                catch (SecurityException)
                {
                }
                catch (ArgumentNullException)
                {
                }
            }
        }

        private void Enabled_btn_copy(ListView li, ListView li2, Button btn, ToolStripMenuItem[] tsm)
        {
            if ((isSelectedLV(li)) || (isSelectedLV(li2)))
            {
                string file_name = string.Empty;
                if (isSelectedLV(li))
                {
                    file_name = li.SelectedItems[0].Name;
                }
                else
                {
                    file_name = li2.SelectedItems[0].Name;
                }

                switch (file_name)
                {
                    case "File":
                        {
                            btn.Enabled = true;
                            foreach (ToolStripMenuItem t in tsm)
                            {
                                t.Enabled = true;
                            }
                            
                        }
                        break;
                    default:
                        {
                            btn.Enabled = false;
                            foreach (ToolStripMenuItem t in tsm)
                            {
                                t.Enabled = false;
                            }
                        }
                        break;
                }
            }
            else
            {
                btn.Enabled = false;
                foreach (ToolStripMenuItem t in tsm)
                {
                    t.Enabled = false;
                }
            }
        }

        private void стеретьПарольИзПамятиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SshSettings.pwd = null;
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            SshConnection.KillSSH();
        }

        private void button_from_remote_Click(object sender, EventArgs e)
        {
            DeCrypting(listView_remote, SshSettings.local_path);
        }

        private void EnCrypting(ListView li, string local_path)
        {
            string file_name = li.SelectedItems[0].Text;
            string full_path = li.SelectedItems[0].Tag.ToString();

            if (isSelectedLV(li) && (Crypt.isKeyFNameLen(file_name)))
            {
                using (FormAction frm_act = new FormAction(full_path, file_name, true, local_path))
                {
                    frm_act.ShowDialog();
                    Load_lv_remote();
                }
            }
        }

        private  void DeCrypting(ListView li, string local_path)
        {
            if (isSelectedLV(li))
            {
                using (FormAction frm_act = new FormAction(li.SelectedItems[0].Tag.ToString(), li.SelectedItems[0].Text, false, local_path))
                {
                    frm_act.ShowDialog();
                    GetDirs(local_path, listView_Local);
                }
            }
        }

        private void загрузитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EnCrypting(listView_Local, SshSettings.local_path);
        }

        private void скачатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeCrypting(listView_remote, SshSettings.local_path);
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isSelectedLV(listView_Local))
            {
                try
                {
                    System.Diagnostics.Process.Start(listView_Local.SelectedItems[0].Tag.ToString());
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка запуска: " + ex.Message);
                }
            }
        }

        private void изменитьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (isSelectedLV(listView_Local))
            {
                System.Diagnostics.Process p = new System.Diagnostics.Process();
                p.StartInfo.FileName = "notepad.exe";
                p.StartInfo.Arguments = listView_Local.SelectedItems[0].Tag.ToString();
                p.Start();
            }
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isSelectedLV(listView_Local))
            {
                if (MessageBox.Show("Удалить файл" + Environment.NewLine + listView_Local.SelectedItems[0].Text, "Внимание", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    File.Delete(listView_Local.SelectedItems[0].Tag.ToString());
                    GetDirs(SshSettings.local_path, listView_Local);
                }
            }
        }

        private void удалитьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (isSelectedLV(listView_remote))
            {
                if (MessageBox.Show("Удалить файл" + Environment.NewLine + listView_remote.SelectedItems[0].Text, "Внимание", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (DeleteRemoteFile(listView_remote.SelectedItems[0].Tag.ToString()))
                    {
                        Load_lv_remote();
                    }
                }
            }
        }

        private bool isSelectedLV(ListView lv)
        {
            if (lv.SelectedItems.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool DeleteRemoteFile(string file)
        {
            bool return_value = false;
            if (SshConnection.ExecBashCommand("rm " + file) != null)
            {
                return_value = true;
            }
            return return_value;
        }

        private void команднаяСтрокаСервераToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SshSettings.pwd == null)
            {
                FormPwd fp = new FormPwd();
                if (fp.ShowDialog() == DialogResult.OK)
                {
                    using (FormCmd frm_c = new FormCmd())
                    {
                        frm_c.ShowDialog();
                    }
                }
            }
            else
            {
                using (FormCmd frm_c = new FormCmd())
                {
                    frm_c.ShowDialog();
                }
            }
        }


    }
}