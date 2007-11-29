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

        private void sshCp_OnTransferStart(string src, string dst, int transferredBytes, int totalBytes, string message)
        {
            progressBar_status.Value = 0;
            progressBar_status.Maximum = totalBytes;
            listBox_log.Items.Add(message);
        }

        private void sshCp_OnTransferProgress(string src, string dst, int transferredBytes, int totalBytes, string message)
        {
            progressBar_status.Value = transferredBytes;
            //listBox_log.Items.Add(message);
            Application.DoEvents();
        }

        private void sshCp_OnTransferEnd(string src, string dst, int transferredBytes, int totalBytes, string message)
        {
            progressBar_status.Value = transferredBytes;
            listBox_log.Items.Add(message);
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

        private void FileTransfer(bool isUpload)
        {
            Crypt cr = new Crypt();

            listBox_log.Items.Add("Loading settings...");

            SshConnection.sshsess.Password = SshSettings.pwd;// o.pwd;
            //TODO Файлов ключей пока нет if (ssh_a.IdentityFile != null) sshCp.AddIdentityFile(ssh_a.IdentityFile);

            listBox_log.Items.Add("Connecting...");
            Application.DoEvents();
            //TODO: здесь копирование на сервер

            string src_file_se = _src_file;
            string dst_file_se;

            if (isUpload)
            {
                dst_file_se = SshSettings.base_dir + _enc_file_name;
            }
            else
            {
                dst_file_se = Path.Combine(SshSettings.local_path, _dec_file_name);
            }

            textBox_src_file.Text = src_file_se;
            textBox_dst_file.Text = dst_file_se;

            try
            {
                if (!SshConnection.sshsess.Connected)
                {
                    SshConnection.sshsess.Connect();
                }

                SshConnection.sshsess.OnTransferStart += new FileTransferEvent(sshCp_OnTransferStart);
                SshConnection.sshsess.OnTransferProgress += new FileTransferEvent(sshCp_OnTransferProgress);
                SshConnection.sshsess.OnTransferEnd += new FileTransferEvent(sshCp_OnTransferEnd);
                listBox_log.Items.Add("Connected...");
                Application.DoEvents();

                if (isUpload)
                {
                    string tmp_name_for_enc = Path.GetTempFileName();
                    cr.encryt_file(SshSettings.pwd_file_enc, int.Parse(SshSettings.key_size), src_file_se, tmp_name_for_enc, progressBar_crypt);
                    SshConnection.sshsess.Put(tmp_name_for_enc, dst_file_se);
                    File.Delete(tmp_name_for_enc);
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
                                string tmp_name_for_dec = Path.GetTempFileName();
                                SshConnection.sshsess.Get(src_file_se, tmp_name_for_dec);
                                cr.decrypt_file(SshSettings.pwd_file_enc, int.Parse(SshSettings.key_size), tmp_name_for_dec, dst_file_se, progressBar_crypt);
                                File.Delete(tmp_name_for_dec);
                            }
                        }
                        else
                        {
                            string tmp_name_for_dec = Path.GetTempFileName();
                            SshConnection.sshsess.Get(src_file_se, tmp_name_for_dec);
                            cr.decrypt_file(SshSettings.pwd_file_enc, int.Parse(SshSettings.key_size), tmp_name_for_dec, dst_file_se, progressBar_crypt);
                            File.Delete(tmp_name_for_dec);
                        }
                    }
                    
                }
                listBox_log.Items.Add("OK");
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                listBox_log.Items.Add(ex.Message);
                listBox_log.Items.Add("ERROR...");
            }
            finally
            {
                button_ok.Enabled = true;
            }
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