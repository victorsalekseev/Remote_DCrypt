﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Tamir.SharpSsh.java.lang;
using System.Threading;
using System.Drawing;

namespace Remote_DCrypt
{
    #region Отдельный тред -- форма с ProgressBar
    /// <summary>
    /// Класс показа окошек с ProgrssBar в отдельных тредах
    /// </summary>
    class Wait
    {
        Form fn = new Form();
        ProgressBar pg = new ProgressBar();
        private delegate void SetTextCallback(string text);

        private void RunWait()
        {
            string help = "Пожалуйста, подождите...";
            fn.Size = new Size(176, 13);
            //fn.StartPosition = FormStartPosition.CenterParent;
            fn.FormBorderStyle = FormBorderStyle.None;
            fn.Text = help;
            fn.TopMost = true;
            fn.TextChanged += new System.EventHandler(this.fn_TextChanged);

            pg.Dock = DockStyle.Fill;
            pg.Style = ProgressBarStyle.Marquee;
            pg.Click += new System.EventHandler(this.pg_Click);


            fn.Controls.Add(pg);
            fn.ShowDialog();
        }

        private void pg_Click(object sender, EventArgs e)
        {
            fn.Close();
        }

        private void fn_TextChanged(object sender, EventArgs e)
        {
            fn.Close();
        }

        /// <summary>
        /// Показ / скрытие окна с ProgrssBar
        /// </summary>
        /// <param name="view">сначала true - показать; далее false - скрыть</param>
        public void ShowWait(bool view)
        {
            System.Threading.Thread th = new System.Threading.Thread(new ThreadStart(RunWait));
            if (view == true)
            {
                th.Start();
            }
            if (view == false)
            {
                SetText("Почти готово...");
                //th.Abort();
            }
        }

        private void SetText(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.fn.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                fn.Invoke(d, new object[] { text });
            }
            else
            {
                fn.Text = text;
            }
        }
    }
    #endregion

}
