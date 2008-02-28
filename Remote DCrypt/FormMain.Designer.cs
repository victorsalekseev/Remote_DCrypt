namespace Remote_DCrypt
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("Файлы", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("Папки", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup3 = new System.Windows.Forms.ListViewGroup("Файлы", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup4 = new System.Windows.Forms.ListViewGroup("Диски", System.Windows.Forms.HorizontalAlignment.Left);
            this.menu = new System.Windows.Forms.MenuStrip();
            this.действияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.соединитьсяToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.команднаяСтрокаСервераToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.стеретьПарольИзПамятиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.настройкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.изменитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageListIcons = new System.Windows.Forms.ImageList(this.components);
            this.panel_main = new System.Windows.Forms.Panel();
            this.panel_remote = new System.Windows.Forms.Panel();
            this.listView_remote = new System.Windows.Forms.ListView();
            this.columnHeader_rfile = new System.Windows.Forms.ColumnHeader();
            this.contextMenuStrip_remote = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.скачатьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьToolStripMenuItem_rem = new System.Windows.Forms.ToolStripMenuItem();
            this.textBox_remote = new System.Windows.Forms.TextBox();
            this.textBox_remotep = new System.Windows.Forms.TextBox();
            this.panel_local = new System.Windows.Forms.Panel();
            this.listView_Local = new System.Windows.Forms.ListView();
            this.columnHeaderName = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderFileSize = new System.Windows.Forms.ColumnHeader();
            this.contextMenuStrip_local = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.загрузитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.изменитьToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textBox_local_name = new System.Windows.Forms.TextBox();
            this.textBoxPath = new System.Windows.Forms.TextBox();
            this.button_from_remote = new System.Windows.Forms.Button();
            this.button_to_remote = new System.Windows.Forms.Button();
            this.оПрограммеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сайтПрограммыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menu.SuspendLayout();
            this.panel_main.SuspendLayout();
            this.panel_remote.SuspendLayout();
            this.contextMenuStrip_remote.SuspendLayout();
            this.panel_local.SuspendLayout();
            this.contextMenuStrip_local.SuspendLayout();
            this.SuspendLayout();
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.действияToolStripMenuItem,
            this.настройкиToolStripMenuItem,
            this.оПрограммеToolStripMenuItem});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(654, 24);
            this.menu.TabIndex = 0;
            this.menu.Text = "menuStrip1";
            // 
            // действияToolStripMenuItem
            // 
            this.действияToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.соединитьсяToolStripMenuItem,
            this.команднаяСтрокаСервераToolStripMenuItem,
            this.стеретьПарольИзПамятиToolStripMenuItem,
            this.выходToolStripMenuItem});
            this.действияToolStripMenuItem.Name = "действияToolStripMenuItem";
            this.действияToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.действияToolStripMenuItem.Text = "Действия";
            // 
            // соединитьсяToolStripMenuItem
            // 
            this.соединитьсяToolStripMenuItem.Name = "соединитьсяToolStripMenuItem";
            this.соединитьсяToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.соединитьсяToolStripMenuItem.Text = "Список файлов на сервере";
            this.соединитьсяToolStripMenuItem.Click += new System.EventHandler(this.соединитьсяToolStripMenuItem_Click);
            // 
            // команднаяСтрокаСервераToolStripMenuItem
            // 
            this.команднаяСтрокаСервераToolStripMenuItem.Name = "команднаяСтрокаСервераToolStripMenuItem";
            this.команднаяСтрокаСервераToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.команднаяСтрокаСервераToolStripMenuItem.Text = "Командная строка сервера";
            this.команднаяСтрокаСервераToolStripMenuItem.Click += new System.EventHandler(this.команднаяСтрокаСервераToolStripMenuItem_Click);
            // 
            // стеретьПарольИзПамятиToolStripMenuItem
            // 
            this.стеретьПарольИзПамятиToolStripMenuItem.Name = "стеретьПарольИзПамятиToolStripMenuItem";
            this.стеретьПарольИзПамятиToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.стеретьПарольИзПамятиToolStripMenuItem.Text = "Стереть пароль из памяти";
            this.стеретьПарольИзПамятиToolStripMenuItem.Click += new System.EventHandler(this.стеретьПарольИзПамятиToolStripMenuItem_Click);
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.выходToolStripMenuItem.Text = "Выход";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);
            // 
            // настройкиToolStripMenuItem
            // 
            this.настройкиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.изменитьToolStripMenuItem});
            this.настройкиToolStripMenuItem.Name = "настройкиToolStripMenuItem";
            this.настройкиToolStripMenuItem.Size = new System.Drawing.Size(73, 20);
            this.настройкиToolStripMenuItem.Text = "Настройки";
            // 
            // изменитьToolStripMenuItem
            // 
            this.изменитьToolStripMenuItem.Name = "изменитьToolStripMenuItem";
            this.изменитьToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.изменитьToolStripMenuItem.Text = "Изменить";
            this.изменитьToolStripMenuItem.Click += new System.EventHandler(this.изменитьToolStripMenuItem_Click);
            // 
            // imageListIcons
            // 
            this.imageListIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListIcons.ImageStream")));
            this.imageListIcons.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListIcons.Images.SetKeyName(0, "f_hot.gif");
            this.imageListIcons.Images.SetKeyName(1, "f_moved.gif");
            this.imageListIcons.Images.SetKeyName(2, "LeftPane_HardDrive.png");
            this.imageListIcons.Images.SetKeyName(3, "r_moved.gif");
            // 
            // panel_main
            // 
            this.panel_main.BackColor = System.Drawing.SystemColors.Window;
            this.panel_main.Controls.Add(this.panel_remote);
            this.panel_main.Controls.Add(this.panel_local);
            this.panel_main.Controls.Add(this.button_from_remote);
            this.panel_main.Controls.Add(this.button_to_remote);
            this.panel_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_main.Location = new System.Drawing.Point(0, 24);
            this.panel_main.Name = "panel_main";
            this.panel_main.Size = new System.Drawing.Size(654, 431);
            this.panel_main.TabIndex = 3;
            // 
            // panel_remote
            // 
            this.panel_remote.Controls.Add(this.listView_remote);
            this.panel_remote.Controls.Add(this.textBox_remote);
            this.panel_remote.Controls.Add(this.textBox_remotep);
            this.panel_remote.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel_remote.Location = new System.Drawing.Point(362, 0);
            this.panel_remote.Name = "panel_remote";
            this.panel_remote.Size = new System.Drawing.Size(292, 431);
            this.panel_remote.TabIndex = 5;
            // 
            // listView_remote
            // 
            this.listView_remote.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader_rfile});
            this.listView_remote.ContextMenuStrip = this.contextMenuStrip_remote;
            this.listView_remote.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView_remote.GridLines = true;
            listViewGroup1.Header = "Файлы";
            listViewGroup1.Name = "listViewGroupFiles";
            this.listView_remote.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1});
            this.listView_remote.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView_remote.HideSelection = false;
            this.listView_remote.LargeImageList = this.imageListIcons;
            this.listView_remote.Location = new System.Drawing.Point(0, 20);
            this.listView_remote.MultiSelect = false;
            this.listView_remote.Name = "listView_remote";
            this.listView_remote.Size = new System.Drawing.Size(292, 391);
            this.listView_remote.SmallImageList = this.imageListIcons;
            this.listView_remote.TabIndex = 9;
            this.listView_remote.UseCompatibleStateImageBehavior = false;
            this.listView_remote.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader_rfile
            // 
            this.columnHeader_rfile.Text = "";
            this.columnHeader_rfile.Width = 255;
            // 
            // contextMenuStrip_remote
            // 
            this.contextMenuStrip_remote.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.contextMenuStrip_remote.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.скачатьToolStripMenuItem,
            this.удалитьToolStripMenuItem_rem});
            this.contextMenuStrip_remote.Name = "contextMenuStrip_remote";
            this.contextMenuStrip_remote.Size = new System.Drawing.Size(124, 48);
            // 
            // скачатьToolStripMenuItem
            // 
            this.скачатьToolStripMenuItem.Enabled = false;
            this.скачатьToolStripMenuItem.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.скачатьToolStripMenuItem.Name = "скачатьToolStripMenuItem";
            this.скачатьToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.скачатьToolStripMenuItem.Text = "Скачать";
            this.скачатьToolStripMenuItem.Click += new System.EventHandler(this.скачатьToolStripMenuItem_Click);
            // 
            // удалитьToolStripMenuItem_rem
            // 
            this.удалитьToolStripMenuItem_rem.Name = "удалитьToolStripMenuItem_rem";
            this.удалитьToolStripMenuItem_rem.Size = new System.Drawing.Size(123, 22);
            this.удалитьToolStripMenuItem_rem.Text = "Удалить";
            this.удалитьToolStripMenuItem_rem.Click += new System.EventHandler(this.удалитьToolStripMenuItem1_Click);
            // 
            // textBox_remote
            // 
            this.textBox_remote.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBox_remote.Enabled = false;
            this.textBox_remote.Location = new System.Drawing.Point(0, 0);
            this.textBox_remote.Name = "textBox_remote";
            this.textBox_remote.Size = new System.Drawing.Size(292, 20);
            this.textBox_remote.TabIndex = 8;
            this.textBox_remote.Text = "Удаленный компьютер (сервер)";
            this.textBox_remote.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox_remotep
            // 
            this.textBox_remotep.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.textBox_remotep.Enabled = false;
            this.textBox_remotep.Location = new System.Drawing.Point(0, 411);
            this.textBox_remotep.Name = "textBox_remotep";
            this.textBox_remotep.Size = new System.Drawing.Size(292, 20);
            this.textBox_remotep.TabIndex = 7;
            // 
            // panel_local
            // 
            this.panel_local.Controls.Add(this.listView_Local);
            this.panel_local.Controls.Add(this.textBox_local_name);
            this.panel_local.Controls.Add(this.textBoxPath);
            this.panel_local.Location = new System.Drawing.Point(0, 0);
            this.panel_local.Name = "panel_local";
            this.panel_local.Size = new System.Drawing.Size(292, 431);
            this.panel_local.TabIndex = 4;
            // 
            // listView_Local
            // 
            this.listView_Local.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderName,
            this.columnHeaderFileSize});
            this.listView_Local.ContextMenuStrip = this.contextMenuStrip_local;
            this.listView_Local.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView_Local.GridLines = true;
            listViewGroup2.Header = "Папки";
            listViewGroup2.Name = "listViewGroupFolders";
            listViewGroup3.Header = "Файлы";
            listViewGroup3.Name = "listViewGroupFiles";
            listViewGroup4.Header = "Диски";
            listViewGroup4.Name = "listViewGroupDrives";
            this.listView_Local.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup2,
            listViewGroup3,
            listViewGroup4});
            this.listView_Local.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView_Local.HideSelection = false;
            this.listView_Local.LargeImageList = this.imageListIcons;
            this.listView_Local.Location = new System.Drawing.Point(0, 20);
            this.listView_Local.MultiSelect = false;
            this.listView_Local.Name = "listView_Local";
            this.listView_Local.Size = new System.Drawing.Size(292, 391);
            this.listView_Local.SmallImageList = this.imageListIcons;
            this.listView_Local.TabIndex = 9;
            this.listView_Local.UseCompatibleStateImageBehavior = false;
            this.listView_Local.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderName
            // 
            this.columnHeaderName.Text = "";
            this.columnHeaderName.Width = 187;
            // 
            // columnHeaderFileSize
            // 
            this.columnHeaderFileSize.Text = "";
            this.columnHeaderFileSize.Width = 78;
            // 
            // contextMenuStrip_local
            // 
            this.contextMenuStrip_local.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.загрузитьToolStripMenuItem,
            this.открытьToolStripMenuItem,
            this.изменитьToolStripMenuItem1,
            this.удалитьToolStripMenuItem});
            this.contextMenuStrip_local.Name = "contextMenuStrip_local";
            this.contextMenuStrip_local.Size = new System.Drawing.Size(138, 92);
            // 
            // загрузитьToolStripMenuItem
            // 
            this.загрузитьToolStripMenuItem.Enabled = false;
            this.загрузитьToolStripMenuItem.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.загрузитьToolStripMenuItem.Name = "загрузитьToolStripMenuItem";
            this.загрузитьToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.загрузитьToolStripMenuItem.Text = "Отправить";
            this.загрузитьToolStripMenuItem.Click += new System.EventHandler(this.загрузитьToolStripMenuItem_Click);
            // 
            // открытьToolStripMenuItem
            // 
            this.открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
            this.открытьToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.открытьToolStripMenuItem.Text = "Открыть";
            this.открытьToolStripMenuItem.Click += new System.EventHandler(this.открытьToolStripMenuItem_Click);
            // 
            // изменитьToolStripMenuItem1
            // 
            this.изменитьToolStripMenuItem1.Name = "изменитьToolStripMenuItem1";
            this.изменитьToolStripMenuItem1.Size = new System.Drawing.Size(137, 22);
            this.изменитьToolStripMenuItem1.Text = "Изменить";
            this.изменитьToolStripMenuItem1.Click += new System.EventHandler(this.изменитьToolStripMenuItem1_Click);
            // 
            // удалитьToolStripMenuItem
            // 
            this.удалитьToolStripMenuItem.Name = "удалитьToolStripMenuItem";
            this.удалитьToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.удалитьToolStripMenuItem.Text = "Удалить";
            this.удалитьToolStripMenuItem.Click += new System.EventHandler(this.удалитьToolStripMenuItem_Click);
            // 
            // textBox_local_name
            // 
            this.textBox_local_name.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBox_local_name.Enabled = false;
            this.textBox_local_name.Location = new System.Drawing.Point(0, 0);
            this.textBox_local_name.Name = "textBox_local_name";
            this.textBox_local_name.Size = new System.Drawing.Size(292, 20);
            this.textBox_local_name.TabIndex = 8;
            this.textBox_local_name.Text = "Локальный компьютер";
            this.textBox_local_name.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxPath
            // 
            this.textBoxPath.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.textBoxPath.Enabled = false;
            this.textBoxPath.Location = new System.Drawing.Point(0, 411);
            this.textBoxPath.Name = "textBoxPath";
            this.textBoxPath.Size = new System.Drawing.Size(292, 20);
            this.textBoxPath.TabIndex = 7;
            // 
            // button_from_remote
            // 
            this.button_from_remote.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button_from_remote.Enabled = false;
            this.button_from_remote.Location = new System.Drawing.Point(298, 216);
            this.button_from_remote.Name = "button_from_remote";
            this.button_from_remote.Size = new System.Drawing.Size(58, 24);
            this.button_from_remote.TabIndex = 3;
            this.button_from_remote.Text = "<<";
            this.button_from_remote.UseVisualStyleBackColor = true;
            this.button_from_remote.Click += new System.EventHandler(this.button_from_remote_Click);
            // 
            // button_to_remote
            // 
            this.button_to_remote.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button_to_remote.Enabled = false;
            this.button_to_remote.Location = new System.Drawing.Point(298, 171);
            this.button_to_remote.Name = "button_to_remote";
            this.button_to_remote.Size = new System.Drawing.Size(58, 24);
            this.button_to_remote.TabIndex = 2;
            this.button_to_remote.Text = ">>";
            this.button_to_remote.UseVisualStyleBackColor = true;
            this.button_to_remote.Click += new System.EventHandler(this.button_to_remote_Click);
            // 
            // оПрограммеToolStripMenuItem
            // 
            this.оПрограммеToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.сайтПрограммыToolStripMenuItem});
            this.оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
            this.оПрограммеToolStripMenuItem.Size = new System.Drawing.Size(83, 20);
            this.оПрограммеToolStripMenuItem.Text = "О программе";
            // 
            // сайтПрограммыToolStripMenuItem
            // 
            this.сайтПрограммыToolStripMenuItem.Name = "сайтПрограммыToolStripMenuItem";
            this.сайтПрограммыToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.сайтПрограммыToolStripMenuItem.Text = "Сайт программы";
            this.сайтПрограммыToolStripMenuItem.Click += new System.EventHandler(this.сайтПрограммыToolStripMenuItem_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(654, 455);
            this.Controls.Add(this.panel_main);
            this.Controls.Add(this.menu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menu;
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.ShowIcon = false;
            this.Text = "Remote DCrypter";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.panel_main.ResumeLayout(false);
            this.panel_remote.ResumeLayout(false);
            this.panel_remote.PerformLayout();
            this.contextMenuStrip_remote.ResumeLayout(false);
            this.panel_local.ResumeLayout(false);
            this.panel_local.PerformLayout();
            this.contextMenuStrip_local.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem действияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem настройкиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem изменитьToolStripMenuItem;
        private System.Windows.Forms.ImageList imageListIcons;
        private System.Windows.Forms.ToolStripMenuItem соединитьсяToolStripMenuItem;
        private System.Windows.Forms.Panel panel_main;
        private System.Windows.Forms.Panel panel_local;
        private System.Windows.Forms.ListView listView_Local;
        private System.Windows.Forms.ColumnHeader columnHeaderName;
        private System.Windows.Forms.ColumnHeader columnHeaderFileSize;
        private System.Windows.Forms.TextBox textBox_local_name;
        private System.Windows.Forms.TextBox textBoxPath;
        private System.Windows.Forms.Button button_from_remote;
        private System.Windows.Forms.Button button_to_remote;
        private System.Windows.Forms.Panel panel_remote;
        private System.Windows.Forms.ListView listView_remote;
        private System.Windows.Forms.ColumnHeader columnHeader_rfile;
        private System.Windows.Forms.TextBox textBox_remote;
        private System.Windows.Forms.TextBox textBox_remotep;
        private System.Windows.Forms.ToolStripMenuItem стеретьПарольИзПамятиToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_remote;
        private System.Windows.Forms.ToolStripMenuItem скачатьToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_local;
        private System.Windows.Forms.ToolStripMenuItem загрузитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem открытьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem изменитьToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem удалитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem удалитьToolStripMenuItem_rem;
        private System.Windows.Forms.ToolStripMenuItem команднаяСтрокаСервераToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem оПрограммеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сайтПрограммыToolStripMenuItem;
    }
}

