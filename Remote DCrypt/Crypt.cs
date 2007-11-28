using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Security.Cryptography;
using System.IO;
using System.Windows.Forms;

namespace Remote_DCrypt
{
    public class Crypt
    {
        public static string default_key = "ZXCVBNMfghfghfggh67890$%^+_)(*&?><-GERTYUIOP123%^+_)"+
                                            "(*&?>YUIfghsda67890$%^+_)(*&?><-GER&?><-GERTYUIOP123%^+_)"+
                                            "(*af&?>YUIOP1RgfgjghkWsdfdfYUIOP12jjfghddfsfds67890$%^+_)"+
                                            "(*dfhg565547dfvghg?>YUIOP12345678dfghytfER?><-GEfgh123456"+
                                            "78dfghytfER&678dfghytf6dfghytf78";

        public static bool CheckKeyFNameLen(string key)
        {
            if (key.Length < 255)
            {
                System.Windows.Forms.MessageBox.Show("Длина ключа для шифрования имен файлов не может быть меньше 255 символов." + Environment.NewLine + "Сейчас длина ключа: " + key.Length.ToString() + ", что меньше 255.");
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool isKeyFNameLen(string f_name)
        {
            if (f_name.Length > SshSettings.key_fname.Length)
            {
                System.Windows.Forms.MessageBox.Show("Такой файл не будет отправлен на сервер,\n\rпоскольку длина его имени превышает длину ключа (" + SshSettings.key_fname.Length + " символов)");
                return false;
            }
            else
            {
                return true;
            }
        }

        public string EncryptFName(string d_str)
        {
            string key_str = SshSettings.key_fname;
            if (string.IsNullOrEmpty(key_str)) { key_str = default_key; }
            string e_str = string.Empty;
            d_str = Encoding.GetEncoding(1251).GetString(Encoding.Convert(Encoding.UTF8, Encoding.GetEncoding(1251), Encoding.UTF8.GetBytes(d_str)));
            key_str = Encoding.GetEncoding(1251).GetString(Encoding.Convert(Encoding.UTF8, Encoding.GetEncoding(1251), Encoding.UTF8.GetBytes(key_str)));
            for (int i = 0; i < d_str.Length; i++)
            {
                e_str += "." + string.Format("{0}", (int)Convert.ToChar(d_str[i]) + (int)Convert.ToChar(key_str[i]));
            }
            return "0" + e_str;
        }

        public string DecryptFName(string e_str)
        {
            string key_str = SshSettings.key_fname;
            if (string.IsNullOrEmpty(key_str)) { key_str = default_key; }
            string d_str = string.Empty;
            key_str = Encoding.GetEncoding(1251).GetString(Encoding.Convert(Encoding.UTF8, Encoding.GetEncoding(1251), Encoding.UTF8.GetBytes(key_str)));
            string[] arr_e_str = Regex.Split(e_str, "\\.");
            int rr;
            if (arr_e_str[0]=="0" && Int32.TryParse(arr_e_str[1], out rr))
            {
                for (int i = 1; i < arr_e_str.Length; i++)
                {
                    d_str += Convert.ToChar(int.Parse(arr_e_str[i]) - (int)Convert.ToChar(key_str[i - 1]));
                }
            }
            return d_str;
        }

        public void encryt_file(string pwd_file_enc, int key_size, string src_dec_file, string dst_enc_file, ProgressBar pr_b)
        {
            if (string.IsNullOrEmpty(pwd_file_enc)) { pwd_file_enc = Crypt.default_key; }
            SymmetricAlgorithm alg;
            alg = (SymmetricAlgorithm)RijndaelManaged.Create(); //пример создания класса RijndaelManaged

            PasswordDeriveBytes pdb = new PasswordDeriveBytes(pwd_file_enc, null); //класс, позволяющий генерировать ключи на базе паролей
            pdb.HashName = "SHA512"; //будем использовать SHA512
            int keylen = key_size; //получаем размер ключа из ComboBox’а
            alg.KeySize = keylen; //устанавливаем размер ключа
            alg.Key = pdb.GetBytes(keylen >> 3); //получаем ключ из пароля
            alg.Mode = CipherMode.CBC; //используем режим CBC
            alg.IV = new Byte[alg.BlockSize >> 3]; //и пустой инициализационный вектор
            ICryptoTransform tr = alg.CreateEncryptor(); //создаем encryptor

            FileStream instream = new FileStream(src_dec_file, FileMode.Open, FileAccess.Read, FileShare.Read);
            FileStream outstream = new FileStream(dst_enc_file, FileMode.Create, FileAccess.Write, FileShare.None);
            int buflen = ((2 << 16) / alg.BlockSize) * alg.BlockSize;
            byte[] inbuf = new byte[buflen];
            byte[] outbuf = new byte[buflen];
            int len;
            long input_size = instream.Length;
            pr_b.Maximum = (int)input_size;
            while ((len = instream.Read(inbuf, 0, buflen)) == buflen)
            {
                int enclen = tr.TransformBlock(inbuf, 0, buflen, outbuf, 0); //собственно шифруем
                outstream.Write(outbuf, 0, enclen);
                pr_b.Value += enclen;
                Application.DoEvents();
            }
            instream.Close();
            outbuf = tr.TransformFinalBlock(inbuf, 0, len); //шифруем финальный блок
            outstream.Write(outbuf, 0, outbuf.Length);
            pr_b.Value = (int)input_size;
            outstream.Close();
            alg.Clear(); //осуществляем зачистку
        }

        public void decrypt_file(string pwd_file_enc, int key_size, string src_enc_file, string dst_dec_file, ProgressBar pr_b)
        {
            if (string.IsNullOrEmpty(pwd_file_enc)) { pwd_file_enc = Crypt.default_key; }
            SymmetricAlgorithm alg;
            alg = (SymmetricAlgorithm)RijndaelManaged.Create(); //пример создания класса RijndaelManaged

            PasswordDeriveBytes pdb = new PasswordDeriveBytes(pwd_file_enc, null); //класс, позволяющий генерировать ключи на базе паролей
            pdb.HashName = "SHA512"; //будем использовать SHA512
            int keylen = key_size; //получаем размер ключа из ComboBox’а
            alg.KeySize = keylen; //устанавливаем размер ключа
            alg.Key = pdb.GetBytes(keylen >> 3); //получаем ключ из пароля
            alg.Mode = CipherMode.CBC; //используем режим CBC
            alg.IV = new Byte[alg.BlockSize >> 3]; //и пустой инициализационный вектор
            ICryptoTransform tr = alg.CreateDecryptor(); //создаем decryptor

            FileStream instream = new FileStream(src_enc_file, FileMode.Open, FileAccess.Read, FileShare.Read);
            FileStream outstream = new FileStream(dst_dec_file, FileMode.Create, FileAccess.Write, FileShare.None);
            int buflen = ((2 << 16) / alg.BlockSize) * alg.BlockSize;
            byte[] inbuf = new byte[buflen];
            byte[] outbuf = new byte[buflen];
            int len;
            long input_size = instream.Length;
            pr_b.Maximum = (int)input_size;
            while ((len = instream.Read(inbuf, 0, buflen)) == buflen)
            {
                int enclen = tr.TransformBlock(inbuf, 0, buflen, outbuf, 0); //собственно расшифровываем
                outstream.Write(outbuf, 0, enclen);
                pr_b.Value += enclen;
                Application.DoEvents();
            }
            instream.Close();
            outbuf = tr.TransformFinalBlock(inbuf, 0, len); //расшифровываем финальный блок
            outstream.Write(outbuf, 0, outbuf.Length);
            pr_b.Value = (int)input_size;
            outstream.Close();
            alg.Clear(); //осуществляем зачистку
        }
    }
}
