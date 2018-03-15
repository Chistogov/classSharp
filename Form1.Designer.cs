namespace Classificator
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.индексацияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.начатьИндексациюСнимковToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.разметкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.входToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.приступитьКРазметкеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.повторнаяРазметкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.информацияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.количествоСнимковПоКатегориямToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.служебныеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выгрузкаСнимковToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBoxNotInUse = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.checkBoxSkipped = new System.Windows.Forms.CheckBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.указатьКорневойКаталогToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBoxNotInUse.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.индексацияToolStripMenuItem,
            this.разметкаToolStripMenuItem,
            this.информацияToolStripMenuItem,
            this.служебныеToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(848, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // индексацияToolStripMenuItem
            // 
            this.индексацияToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.начатьИндексациюСнимковToolStripMenuItem,
            this.указатьКорневойКаталогToolStripMenuItem});
            this.индексацияToolStripMenuItem.Name = "индексацияToolStripMenuItem";
            this.индексацияToolStripMenuItem.Size = new System.Drawing.Size(85, 20);
            this.индексацияToolStripMenuItem.Text = "Индексация";
            // 
            // начатьИндексациюСнимковToolStripMenuItem
            // 
            this.начатьИндексациюСнимковToolStripMenuItem.Name = "начатьИндексациюСнимковToolStripMenuItem";
            this.начатьИндексациюСнимковToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.начатьИндексациюСнимковToolStripMenuItem.Text = "Начать индексацию снимков";
            this.начатьИндексациюСнимковToolStripMenuItem.Click += new System.EventHandler(this.начатьИндексациюСнимковToolStripMenuItem_Click);
            // 
            // разметкаToolStripMenuItem
            // 
            this.разметкаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.входToolStripMenuItem,
            this.приступитьКРазметкеToolStripMenuItem,
            this.повторнаяРазметкаToolStripMenuItem});
            this.разметкаToolStripMenuItem.Name = "разметкаToolStripMenuItem";
            this.разметкаToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.разметкаToolStripMenuItem.Text = "Разметка";
            // 
            // входToolStripMenuItem
            // 
            this.входToolStripMenuItem.Name = "входToolStripMenuItem";
            this.входToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.входToolStripMenuItem.Text = "Вход";
            this.входToolStripMenuItem.Click += new System.EventHandler(this.входToolStripMenuItem_Click);
            // 
            // приступитьКРазметкеToolStripMenuItem
            // 
            this.приступитьКРазметкеToolStripMenuItem.Name = "приступитьКРазметкеToolStripMenuItem";
            this.приступитьКРазметкеToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.приступитьКРазметкеToolStripMenuItem.Text = "Приступить к разметке";
            this.приступитьКРазметкеToolStripMenuItem.Click += new System.EventHandler(this.приступитьКРазметкеToolStripMenuItem_Click);
            // 
            // повторнаяРазметкаToolStripMenuItem
            // 
            this.повторнаяРазметкаToolStripMenuItem.Name = "повторнаяРазметкаToolStripMenuItem";
            this.повторнаяРазметкаToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.повторнаяРазметкаToolStripMenuItem.Text = "Повторная разметка";
            this.повторнаяРазметкаToolStripMenuItem.Click += new System.EventHandler(this.повторнаяРазметкаToolStripMenuItem_Click);
            // 
            // информацияToolStripMenuItem
            // 
            this.информацияToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.количествоСнимковПоКатегориямToolStripMenuItem});
            this.информацияToolStripMenuItem.Name = "информацияToolStripMenuItem";
            this.информацияToolStripMenuItem.Size = new System.Drawing.Size(93, 20);
            this.информацияToolStripMenuItem.Text = "Информация";
            // 
            // количествоСнимковПоКатегориямToolStripMenuItem
            // 
            this.количествоСнимковПоКатегориямToolStripMenuItem.Name = "количествоСнимковПоКатегориямToolStripMenuItem";
            this.количествоСнимковПоКатегориямToolStripMenuItem.Size = new System.Drawing.Size(274, 22);
            this.количествоСнимковПоКатегориямToolStripMenuItem.Text = "Количество снимков по категориям";
            this.количествоСнимковПоКатегориямToolStripMenuItem.Click += new System.EventHandler(this.количествоСнимковПоКатегориямToolStripMenuItem_Click);
            // 
            // служебныеToolStripMenuItem
            // 
            this.служебныеToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.выгрузкаСнимковToolStripMenuItem});
            this.служебныеToolStripMenuItem.Name = "служебныеToolStripMenuItem";
            this.служебныеToolStripMenuItem.Size = new System.Drawing.Size(84, 20);
            this.служебныеToolStripMenuItem.Text = "Служебные";
            // 
            // выгрузкаСнимковToolStripMenuItem
            // 
            this.выгрузкаСнимковToolStripMenuItem.Name = "выгрузкаСнимковToolStripMenuItem";
            this.выгрузкаСнимковToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.выгрузкаСнимковToolStripMenuItem.Text = "Выгрузка снимков";
            this.выгрузкаСнимковToolStripMenuItem.Click += new System.EventHandler(this.выгрузкаСнимковToolStripMenuItem_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 27);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(429, 374);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // groupBoxNotInUse
            // 
            this.groupBoxNotInUse.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxNotInUse.Controls.Add(this.groupBox1);
            this.groupBoxNotInUse.Location = new System.Drawing.Point(447, 56);
            this.groupBoxNotInUse.Name = "groupBoxNotInUse";
            this.groupBoxNotInUse.Size = new System.Drawing.Size(389, 269);
            this.groupBoxNotInUse.TabIndex = 2;
            this.groupBoxNotInUse.TabStop = false;
            this.groupBoxNotInUse.Text = "Признаки";
            // 
            // groupBox1
            // 
            this.groupBox1.AutoScroll = true;
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(383, 250);
            this.groupBox1.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(447, 27);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Сохранить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(528, 27);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Пропустить";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Location = new System.Drawing.Point(447, 331);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(389, 70);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Добавить";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(6, 41);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 1;
            this.button3.Text = "Добавить";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(6, 19);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(178, 20);
            this.textBox1.TabIndex = 0;
            // 
            // checkBoxSkipped
            // 
            this.checkBoxSkipped.AutoSize = true;
            this.checkBoxSkipped.Location = new System.Drawing.Point(609, 31);
            this.checkBoxSkipped.Name = "checkBoxSkipped";
            this.checkBoxSkipped.Size = new System.Drawing.Size(162, 17);
            this.checkBoxSkipped.TabIndex = 5;
            this.checkBoxSkipped.Text = "Показывать пропущенные";
            this.checkBoxSkipped.UseVisualStyleBackColor = true;
            this.checkBoxSkipped.CheckedChanged += new System.EventHandler(this.checkBoxSkipped_CheckedChanged);
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.SystemColors.Highlight;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 404);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(848, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusLabel
            // 
            this.statusLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(24, 17);
            this.statusLabel.Text = "0/0";
            // 
            // указатьКорневойКаталогToolStripMenuItem
            // 
            this.указатьКорневойКаталогToolStripMenuItem.Name = "указатьКорневойКаталогToolStripMenuItem";
            this.указатьКорневойКаталогToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.указатьКорневойКаталогToolStripMenuItem.Text = "Указать корневой каталог";
            this.указатьКорневойКаталогToolStripMenuItem.Click += new System.EventHandler(this.указатьКорневойКаталогToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(848, 426);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.checkBoxSkipped);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.groupBoxNotInUse);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Классификатор. Клинка \"Ухо, Горло, Нос\"";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBoxNotInUse.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem индексацияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem начатьИндексациюСнимковToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem разметкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem приступитьКРазметкеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem информацияToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBoxNotInUse;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.CheckBox checkBoxSkipped;
        private System.Windows.Forms.ToolStripMenuItem входToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem повторнаяРазметкаToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.Panel groupBox1;
        private System.Windows.Forms.ToolStripMenuItem количествоСнимковПоКатегориямToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem служебныеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выгрузкаСнимковToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem указатьКорневойКаталогToolStripMenuItem;
    }
}

