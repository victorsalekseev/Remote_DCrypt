using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Security.Cryptography;
using System.IO;
using System.Windows.Forms;

namespace Remote_DCrypt
{
    public struct PackEnCryptParam
    {
        public string pwd_file_enc;
        public int key_size;
        public string src_dec_file;
        public string dst_enc_file;
        public ProgressBar pr_b;
    }

    public struct PackDeCryptParam
    {
        public string pwd_file_enc;
        public int key_size;
        public string src_enc_file;
        public string dst_dec_file;
        public ProgressBar pr_b;
    }

    public class Crypt
    {
        public delegate void OnEncryptingFile(long curr_byte, long count_byte);
        public event OnEncryptingFile EncryptingFile;

        public delegate void OnEncryptedFile(string dst_enc_file);
        public event OnEncryptedFile EncryptedFile;

        private delegate void SetEncValCallback(long val, long cnt, int percent);
        private delegate void SetEncryptedFile(string dst_enc_file);


        public delegate void OnDecryptingFile(long curr_byte, long count_byte);
        public event OnDecryptingFile DecryptingFile;

        public delegate void OnDecryptedFile(string dst_enc_file);
        public event OnDecryptedFile DecryptedFile;

        private delegate void SetDecValCallback(long val, long cnt, int percent);
        private delegate void SetDecryptedFile(string dst_enc_file);


        public static string default_key = "ZXcvngjfgjfghfggh67890$%^+_)(*&?><-GERTYUIOP123%^+_)"+
                                            "(*&?>YUIfghfgj67890$%^+_)(*&?><-GER&?><-GERTYUIOP123gfh_)"+
                                            "(fgh&?>YUIOP1RcngcghkWsdfjtxcrhbdgry586jfheifm67890$%^fgh"+
                                            "ghdfhg565547dfvghg?>YUIOP12345678dfghytfER?><-GEfgh123456"+
                                            "78dfghytfEfgjb8dfgmytfgjfghytf78";

        public static bool CheckKeyFNameLen(string key)
        {
            return true;
        }

        public static bool isKeyFNameLen(string f_name)
        {
            return true;
        }

        public string EncryptFName(string d_str,string key_str)
        {
            if (string.IsNullOrEmpty(key_str)) { key_str = default_key; }
            string e_str = string.Empty;
            try
            {
                PasswordDeriveBytes pdb = new PasswordDeriveBytes(key_str, null); //класс, позволяющий генерировать ключи на базе паролей
                pdb.HashName = "SHA512"; //будем использовать SHA512

                SymmetricAlgorithm alg = new TripleDESCryptoServiceProvider();
                byte[] iv = new Byte[alg.BlockSize >> 3];
                byte[] key = pdb.GetBytes(alg.KeySize >> 3);
                // Шифрование
                ICryptoTransform transform = alg.CreateEncryptor(key, iv);
                byte[] passwordByte = Encoding.GetEncoding(1251).GetBytes(d_str);
                byte[] encryptedPassword = transform.TransformFinalBlock(passwordByte, 0, passwordByte.Length);

                foreach (byte enc in encryptedPassword)
                {
                    string dd = enc.ToString("X2");
                    e_str += dd;// "." + enc.ToString();
                }
                e_str = "0." + e_str;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
                e_str = string.Empty;
            }
            return e_str;
        }

        public string DecryptFName(string e_str, string key_str)
        {
            if (string.IsNullOrEmpty(key_str)) { key_str = default_key; }
            string d_str = string.Empty;
            try
            {
                string[] arr_e_str = Regex.Split(e_str, "\\.");
                if (arr_e_str.Length > 1)
                {
                    int rr;
                    if (arr_e_str[0] == "0" && Int32.TryParse(string.Format("{0}", arr_e_str[1].Length / 2), out rr))
                    {
                        d_str = "Имя файла не расшифровано ";
                        int count_bytes = (int)arr_e_str[1].Length / 2;
                        byte[] passwordByte = new byte[count_bytes];
                        for (int i = 0; i < count_bytes; i++)
                        {
                            passwordByte[i] = Convert.ToByte(int.Parse(arr_e_str[1].Substring(i * 2, 2), System.Globalization.NumberStyles.HexNumber));
                        }

                        SymmetricAlgorithm alg = new TripleDESCryptoServiceProvider();

                        PasswordDeriveBytes pdb = new PasswordDeriveBytes(key_str, null); //класс, позволяющий генерировать ключи на базе паролей
                        pdb.HashName = "SHA512"; //будем использовать SHA512
                        byte[] iv = new Byte[alg.BlockSize >> 3];
                        byte[] key = pdb.GetBytes(alg.KeySize >> 3);
                        // ДеШифрование
                        ICryptoTransform transform = alg.CreateDecryptor(key, iv);

                        byte[] decryptedPassword = transform.TransformFinalBlock(passwordByte, 0, passwordByte.Length);
                        d_str = Encoding.GetEncoding(1251).GetString(decryptedPassword);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
                DateTime dt;
                dt = DateTime.Now;
                string time = dt.Hour.ToString() + "-" + dt.Minute.ToString() + "-" + dt.Second.ToString() + " (" + dt.Millisecond.ToString() + ")";
                d_str += time;
            }
            return d_str;
        }


        public void encryt_file(object pcp /*string pwd_file_enc, int key_size, string src_dec_file, string dst_enc_file, ProgressBar pr_b*/)
        {
            PackEnCryptParam _vpcp = (PackEnCryptParam)pcp;
            string pwd_file_enc = _vpcp.pwd_file_enc;
            int key_size = _vpcp.key_size;
            string src_dec_file = _vpcp.src_dec_file;
            string dst_enc_file = _vpcp.dst_enc_file;
            ProgressBar pr_b = _vpcp.pr_b;

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
            long cur_byte = 0;
            while ((len = instream.Read(inbuf, 0, buflen)) == buflen)
            {
                int enclen = tr.TransformBlock(inbuf, 0, buflen, outbuf, 0); //собственно шифруем
                outstream.Write(outbuf, 0, enclen);
                cur_byte += enclen;
                NewMethod(pr_b, input_size, cur_byte);
                EncryptingFile(cur_byte, input_size);
            }
            instream.Close();
            outbuf = tr.TransformFinalBlock(inbuf, 0, len); //шифруем финальный блок
            outstream.Write(outbuf, 0, outbuf.Length);
            NewMethod(pr_b, input_size, input_size);
            outstream.Close();
            alg.Clear(); //осуществляем зачистку

            SetEncryptedFile d = new SetEncryptedFile(Action.FormAction.SendingFile);
            pr_b.Invoke(d, new object[] { dst_enc_file });
            EncryptedFile(dst_enc_file);
        }

        private static void NewMethod(ProgressBar pr_b, long input_size, long cur_byte)
        {
            int percent = (int)Math.Floor((double)cur_byte * 100 / input_size);
            SetEncValCallback d = new SetEncValCallback(Action.FormAction.SetTextEncrypting);
            pr_b.Invoke(d, new object[] { cur_byte, input_size, percent });
        }


        public void decrypt_file(object pcp /*string pwd_file_enc, int key_size, string src_enc_file, string dst_dec_file, ProgressBar pr_b*/)
        {
            PackDeCryptParam _vpcp = (PackDeCryptParam)pcp;
            string pwd_file_enc = _vpcp.pwd_file_enc;
            int key_size = _vpcp.key_size;
            string src_enc_file = _vpcp.src_enc_file;
            string dst_dec_file = _vpcp.dst_dec_file;
            ProgressBar pr_b = _vpcp.pr_b;

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
            long cur_byte = 0;
            while ((len = instream.Read(inbuf, 0, buflen)) == buflen)
            {
                int enclen = tr.TransformBlock(inbuf, 0, buflen, outbuf, 0); //собственно расшифровываем
                outstream.Write(outbuf, 0, enclen);
                cur_byte += enclen;
                NewMethod2(pr_b, input_size, cur_byte);
                EncryptingFile(cur_byte, input_size);
            }
            instream.Close();
            outbuf = tr.TransformFinalBlock(inbuf, 0, len); //расшифровываем финальный блок
            outstream.Write(outbuf, 0, outbuf.Length);
            pr_b.Value = (int)input_size;
            outstream.Close();
            alg.Clear(); //осуществляем зачистку

            SetDecryptedFile d = new SetDecryptedFile(Action.FormAction.RecievedFile);
            pr_b.Invoke(d, new object[] { src_enc_file });
            DecryptedFile(src_enc_file);
        }

        private static void NewMethod2(ProgressBar pr_b, long input_size, long cur_byte)
        {
            int percent = (int)Math.Floor((double)cur_byte * 100 / input_size);
            SetDecValCallback d = new SetDecValCallback(Action.FormAction.SetTextDecrypting);
            pr_b.Invoke(d, new object[] { cur_byte, input_size, percent });
        }
    }
}
