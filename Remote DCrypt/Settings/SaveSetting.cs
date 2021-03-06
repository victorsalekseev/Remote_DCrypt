﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace Remote_DCrypt.Settings
{
    //структура для хранения сохраняемой в файл инфы
    public struct Options
    {
        public string key_fname;
        public string server;
        public string base_dir;
        public string user;
        public string key_size;
        public string pwd_file_enc;
    }

    /// <summary>
    /// Класс для сериализации объекта в xml-файл 
    /// </summary>
    public class SaveSetting
    {
        //Лишаем возможности создавать объекты этого класса
        private SaveSetting()
        {

        }

        public static string path_to_set_file = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "keys.key");

        public static void CreateSettings(object o)
        {

            XmlSerializer myXmlSer = new XmlSerializer(o.GetType());
            using (FileStream fStream = File.Open(path_to_set_file, FileMode.OpenOrCreate))
            {
                Rijndael rijndaelAlg = Rijndael.Create();
                PasswordDeriveBytes pdb = new PasswordDeriveBytes("пароль", null); //класс, позволяющий генерировать ключи на базе паролей
                pdb.HashName = "SHA512"; //будем использовать SHA512
                byte[] iv = new Byte[rijndaelAlg.BlockSize >> 3];
                byte[] key = pdb.GetBytes(rijndaelAlg.KeySize >> 3);

                using (CryptoStream cStream = new CryptoStream(fStream,
                  rijndaelAlg.CreateEncryptor(key, iv),
                  CryptoStreamMode.Write))
                using (StreamWriter sWriter = new StreamWriter(cStream))
                {
                    myXmlSer.Serialize(sWriter, o);
                    sWriter.Close();
                }
            }
            //XmlSerializer myXmlSer = new XmlSerializer(o.GetType());
            //StreamWriter myWriter = new StreamWriter(path_to_set_file);
            //myXmlSer.Serialize(myWriter, o);
            //myWriter.Close();
        }

        public static void LoadSettings(ref Options o)
        {
            XmlSerializer myXmlSer = new XmlSerializer(typeof(Options));
            using (FileStream fStream = File.Open(path_to_set_file, FileMode.Open))
            {
                Rijndael rijndaelAlg = Rijndael.Create();
                PasswordDeriveBytes pdb = new PasswordDeriveBytes("пароль", null); //класс, позволяющий генерировать ключи на базе паролей
                pdb.HashName = "SHA512"; //будем использовать SHA512
                byte[] iv = new Byte[rijndaelAlg.BlockSize >> 3];
                byte[] key = pdb.GetBytes(rijndaelAlg.KeySize >> 3);

                using (CryptoStream cStream = new CryptoStream(fStream,
                  rijndaelAlg.CreateDecryptor(key, iv),
                  CryptoStreamMode.Read))
                using (StreamReader sReader = new StreamReader(cStream))
                {
                    o = (Options)myXmlSer.Deserialize(sReader);
                    sReader.Close();
                }
            }
            //XmlSerializer myXmlSer = new XmlSerializer(typeof(Options));
            //FileStream mySet = new FileStream(path_to_set_file, FileMode.Open);
            //o = (Options)myXmlSer.Deserialize(mySet);
            //mySet.Close();
        }
    }
}
