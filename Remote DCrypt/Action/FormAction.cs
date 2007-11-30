using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Remote_DCrypt.Settings;
using System.IO;
using Tamir.SharpSsh;
using System.Security.Cryptography;
using System.Threading;

namespace Remote_DCrypt.Action
{
    public partial class FormAction : Form
    {
        public FormAction()
        {
            InitializeComponent();
        }

        string _src_file = string.Empty;
        string _enc_file_name = string.Empty;
        string _dec_file_name = string.Empty;
        string _curr_local_path = string.Empty;
        bool _IsUpload = true;
        static string src_file_se;
        static string dst_file_se;

        private void FileTransfer(bool isUpload)
        {
            Crypt cr = new Crypt();
            cr.EncryptingFile += new Crypt.OnEncryptingFile(cr_EncryptingFile);
            cr.EncryptedFile += new Crypt.OnEncryptedFile(cr_EncryptedFile);
            cr.DecryptingFile += new Crypt.OnDecryptingFile(cr_DecryptingFile);
            cr.DecryptedFile += new Crypt.OnDecryptedFile(cr_DecryptedFile);

            AddItem("Loading settings...");

            SshConnection.sshsess.Password = SshSettings.pwd;// o.pwd;
            //TODO Файлов ключей пока нет if (ssh_a.IdentityFile != null) sshCp.AddIdentityFile(ssh_a.IdentityFile);
            AddItem("Connecting...");
            Application.DoEvents();
            //TODO: здесь копирование на сервер

            src_file_se = _src_file;

            if (isUpload)
            {
                dst_file_se = SshSettings.base_dir + _enc_file_name;
            }
            else
            {
                dst_file_se = Path.Combine(SshSettings.local_path, _dec_file_name);
            }

            textBox_src_file.Text = src_file_se.Remove(0, index_b(src_file_se));
            textBox_dst_file.Text = dst_file_se.Remove(0, index_b(dst_file_se));

            try
            {
                if (!SshConnection.sshsess.Connected)
                {
                    SshConnection.sshsess.Connect();
                }

                SshConnection.sshsess.OnTransferStart += new FileTransferEvent(sshCp_OnTransferStart);
                SshConnection.sshsess.OnTransferProgress += new FileTransferEvent(sshCp_OnTransferProgress);
                SshConnection.sshsess.OnTransferEnd += new FileTransferEvent(sshCp_OnTransferEnd);
                AddItem("Connected...");
                Application.DoEvents();

                if (isUpload)
                {
                    string tmp_name_for_enc = Path.GetTempFileName();
                    PackEnCryptParam pk = new PackEnCryptParam();
                    pk.pwd_file_enc = SshSettings.pwd_file_enc;
                    pk.key_size = int.Parse(SshSettings.key_size);
                    pk.src_dec_file = src_file_se;
                    pk.dst_enc_file = tmp_name_for_enc;
                    pk.pr_b = progressBar_status;

                    System.Threading.Thread th = new System.Threading.Thread(new ParameterizedThreadStart(cr.encryt_file));
                    th.Start(pk);
                }
                else
                {
                    //Из удаленной в локальную
                    if (SshSettings.local_path.Length < 3)
                    {
                        MessageBox.Show("В эту папку сохранять нельзя");
                    }
                    else
                    {
                        if (File.Exists(dst_file_se))
                        {
                            if (MessageBox.Show("Файл с таким именем существует. Перезаписать?", "Внимание", MessageBoxButtons.YesNo) == DialogResult.Yes)
                            {
                                GetFileAndDecrypt(cr);
                            }
                        }
                        else
                        {
                            GetFileAndDecrypt(cr);
                            //string tmp_name_for_dec = Path.GetTempFileName();
                            //SshConnection.sshsess.Get(src_file_se, tmp_name_for_dec);
                            //cr.decrypt_file(SshSettings.pwd_file_enc, int.Parse(SshSettings.key_size), tmp_name_for_dec, dst_file_se, progressBar_status);
                            //File.Delete(tmp_name_for_dec);

                        }
                    }
                }
                AddItem("OK");
                //DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                listBox_log.Items.Add(ex.Message);
                AddItem("ERROR...");
                Application.OpenForms["FormAction"].ControlBox = true;
            }
            finally
            {
                //button_ok.Enabled = true;
            }
        }

        private static int index_b(string src_file_se)
        {
            int index_b = 0;
            if (src_file_se.LastIndexOf("\\") > 0)
            {
                index_b = src_file_se.LastIndexOf("\\");
            }
            else
            {
                if (src_file_se.LastIndexOf("/") > 0)
                {
                    index_b = src_file_se.LastIndexOf("/");
                }
            }
            return index_b;
        }

        void cr_DecryptedFile(string dst_enc_file)
        {

        }

        void cr_DecryptingFile(long curr_byte, long count_byte)
        {
            
        }

        private void GetFileAndDecrypt(Crypt cr)
        {
            string tmp_name_for_dec = Path.GetTempFileName();
            SshConnection.sshsess.Get(src_file_se, tmp_name_for_dec);

            PackDeCryptParam pk = new PackDeCryptParam();
            pk.pwd_file_enc = SshSettings.pwd_file_enc;
            pk.key_size = int.Parse(SshSettings.key_size);
            pk.src_enc_file = tmp_name_for_dec;
            pk.dst_dec_file = dst_file_se;
            pk.pr_b = progressBar_status;

            System.Threading.Thread th = new System.Threading.Thread(new ParameterizedThreadStart(cr.decrypt_file));
            th.Start(pk);

            //cr.decrypt_file(SshSettings.pwd_file_enc, int.Parse(SshSettings.key_size), tmp_name_for_dec, dst_file_se, progressBar_status);
            //File.Delete(tmp_name_for_dec);
        }

        private void AddItem(string text)
        {
            listBox_log.Items.Add(DateTime.Now.ToLongTimeString() + ": " + text);
            listBox_log.SetSelected(listBox_log.Items.Count - 1, true);
        }

        public FormAction(string src_file, string file_name, bool IsUpload, string curr_local_path)
        {
            Crypt cr = new Crypt();
            InitializeComponent();
            _src_file = src_file;
            _IsUpload = IsUpload;
            if (_IsUpload)
            {
                _enc_file_name = cr.EncryptFName(file_name, SshSettings.key_fname);
            }
            else
            {
                _dec_file_name = file_name;
            }
        }

        private void FormAction_Load(object sender, EventArgs e)
        {

        }

        public static void SetTextEncrypting(long val, long cnt, int percent)
        {
            Application.OpenForms["FormAction"].Text = "Шифрование (" + percent.ToString() + " %)";
        }

        public static void SendingFile(string dst_enc_file)
        {
            Application.OpenForms["FormAction"].ControlBox = true;
            Application.OpenForms["FormAction"].Text = "Загрузка...";
            SshConnection.sshsess.Put(dst_enc_file, dst_file_se);
            File.Delete(dst_enc_file);
            Application.OpenForms["FormAction"].Controls["panel1"].Controls["button_ok"].Enabled = true;
        }

        public static void SetTextDecrypting(long val, long cnt, int percent)
        {
            Application.OpenForms["FormAction"].Text = "Дешифрование (" + percent.ToString() + " %)";
        }

        public static void RecievedFile(string src_enc_file)
        {
            Application.OpenForms["FormAction"].ControlBox = true;
            Application.OpenForms["FormAction"].Text = "Дешифровано";
            File.Delete(src_enc_file);
            Application.OpenForms["FormAction"].Controls["panel1"].Controls["button_ok"].Enabled = true;
        }

        private void sshCp_OnTransferStart(string src, string dst, int transferredBytes, int totalBytes, string message)
        {
            progressBar_status.Value = 0;
            progressBar_status.Maximum = totalBytes;
            AddItem(message);
        }

        private void sshCp_OnTransferProgress(string src, string dst, int transferredBytes, int totalBytes, string message)
        {
            progressBar_status.Value = transferredBytes;
            Application.OpenForms["FormAction"].Text = "Загрузка (" + (int)Math.Floor((double)transferredBytes*100/totalBytes) + " %)";
            Application.DoEvents();
        }

        private void sshCp_OnTransferEnd(string src, string dst, int transferredBytes, int totalBytes, string message)
        {
            progressBar_status.Value = transferredBytes;
            AddItem(message);
        }

        private void FormAction_Shown(object sender, EventArgs e)
        {
            if (SshSettings.pwd == null)
            {
                FormPwd fp = new FormPwd();
                if (fp.ShowDialog() == DialogResult.OK)
                {
                    FileTransfer(_IsUpload);
                }
            }
            else
            {
                FileTransfer(_IsUpload);
            }
        }


        void cr_EncryptedFile(string dst_enc_file)
        {
            //SshConnection.sshsess.Put(dst_enc_file, dst_file_se);
            //File.Delete(dst_enc_file);
        }

        void cr_EncryptingFile(long curr_byte, long count_byte)
        {
            //TODO!!!
            //progressBar_crypt.Maximum = (int)cntl;
            //progressBar_crypt.Value = (int)vall;
        }

        private void button_ok_Click(object sender, EventArgs e)
        {
            this.Close();            
        }

        private void FormAction_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!button_ok.Enabled)
            {
                SshConnection.sshsess.Cancel();
            }
        }

    }
}