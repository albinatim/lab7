namespace lab7
{
    partial class Redactor
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
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.загрузитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.оПрограммеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.справкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.PaintImage = new System.Windows.Forms.PictureBox();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.ColorBtn = new System.Windows.Forms.Button();
            this.labelY = new System.Windows.Forms.Label();
            this.labelX = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.SpeedNumUpDown = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SizeNumUpDown = new System.Windows.Forms.NumericUpDown();
            this.AnglesNumUpDown = new System.Windows.Forms.NumericUpDown();
            this.RotationTrBar = new System.Windows.Forms.TrackBar();
            this.StarRB = new System.Windows.Forms.RadioButton();
            this.PolygonRB = new System.Windows.Forms.RadioButton();
            this.CircleRB = new System.Windows.Forms.RadioButton();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PaintImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpeedNumUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SizeNumUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnglesNumUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RotationTrBar)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.оПрограммеToolStripMenuItem,
            this.справкаToolStripMenuItem,
            this.выходToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(920, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.сохранитьToolStripMenuItem,
            this.загрузитьToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // сохранитьToolStripMenuItem
            // 
            this.сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            this.сохранитьToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.сохранитьToolStripMenuItem.Text = "Сохранить";
            this.сохранитьToolStripMenuItem.Click += new System.EventHandler(this.сохранитьToolStripMenuItem_Click);
            // 
            // загрузитьToolStripMenuItem
            // 
            this.загрузитьToolStripMenuItem.Name = "загрузитьToolStripMenuItem";
            this.загрузитьToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.загрузитьToolStripMenuItem.Text = "Загрузить";
            this.загрузитьToolStripMenuItem.Click += new System.EventHandler(this.загрузитьToolStripMenuItem_Click);
            // 
            // оПрограммеToolStripMenuItem
            // 
            this.оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
            this.оПрограммеToolStripMenuItem.Size = new System.Drawing.Size(94, 20);
            this.оПрограммеToolStripMenuItem.Text = "О программе";
            this.оПрограммеToolStripMenuItem.Click += new System.EventHandler(this.оПрограммеToolStripMenuItem_Click);
            // 
            // справкаToolStripMenuItem
            // 
            this.справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
            this.справкаToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.справкаToolStripMenuItem.Text = "Справка";
            this.справкаToolStripMenuItem.Click += new System.EventHandler(this.справкаToolStripMenuItem_Click);
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.выходToolStripMenuItem.Text = "Выход";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.PaintImage);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.treeView1);
            this.splitContainer1.Panel2.Controls.Add(this.ColorBtn);
            this.splitContainer1.Panel2.Controls.Add(this.labelY);
            this.splitContainer1.Panel2.Controls.Add(this.labelX);
            this.splitContainer1.Panel2.Controls.Add(this.label6);
            this.splitContainer1.Panel2.Controls.Add(this.label5);
            this.splitContainer1.Panel2.Controls.Add(this.button1);
            this.splitContainer1.Panel2.Controls.Add(this.label4);
            this.splitContainer1.Panel2.Controls.Add(this.SpeedNumUpDown);
            this.splitContainer1.Panel2.Controls.Add(this.label3);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.SizeNumUpDown);
            this.splitContainer1.Panel2.Controls.Add(this.AnglesNumUpDown);
            this.splitContainer1.Panel2.Controls.Add(this.RotationTrBar);
            this.splitContainer1.Panel2.Controls.Add(this.StarRB);
            this.splitContainer1.Panel2.Controls.Add(this.PolygonRB);
            this.splitContainer1.Panel2.Controls.Add(this.CircleRB);
            this.splitContainer1.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel2_Paint);
            this.splitContainer1.Size = new System.Drawing.Size(920, 509);
            this.splitContainer1.SplitterDistance = 658;
            this.splitContainer1.TabIndex = 1;
            // 
            // PaintImage
            // 
            this.PaintImage.BackColor = System.Drawing.Color.White;
            this.PaintImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PaintImage.Location = new System.Drawing.Point(0, 0);
            this.PaintImage.Name = "PaintImage";
            this.PaintImage.Size = new System.Drawing.Size(658, 509);
            this.PaintImage.TabIndex = 0;
            this.PaintImage.TabStop = false;
            this.PaintImage.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.PaintImage.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PaintImage_MouseClick);
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.treeView1.Location = new System.Drawing.Point(0, 369);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(258, 140);
            this.treeView1.TabIndex = 17;
            // 
            // ColorBtn
            // 
            this.ColorBtn.BackColor = System.Drawing.Color.Black;
            this.ColorBtn.Location = new System.Drawing.Point(210, 105);
            this.ColorBtn.Name = "ColorBtn";
            this.ColorBtn.Size = new System.Drawing.Size(23, 23);
            this.ColorBtn.TabIndex = 16;
            this.ColorBtn.UseVisualStyleBackColor = false;
            this.ColorBtn.Click += new System.EventHandler(this.button2_Click);
            // 
            // labelY
            // 
            this.labelY.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelY.ForeColor = System.Drawing.Color.Black;
            this.labelY.Location = new System.Drawing.Point(113, 165);
            this.labelY.Name = "labelY";
            this.labelY.Size = new System.Drawing.Size(120, 23);
            this.labelY.TabIndex = 15;
            // 
            // labelX
            // 
            this.labelX.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelX.Location = new System.Drawing.Point(113, 142);
            this.labelX.Name = "labelX";
            this.labelX.Size = new System.Drawing.Size(120, 23);
            this.labelX.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 167);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(14, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Y";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 143);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(14, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "X";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.button1.Location = new System.Drawing.Point(16, 105);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(185, 23);
            this.button1.TabIndex = 11;
            this.button1.Text = "Сгруппировать/Разгруппировать";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 250);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Size";
            // 
            // SpeedNumUpDown
            // 
            this.SpeedNumUpDown.InterceptArrowKeys = false;
            this.SpeedNumUpDown.Location = new System.Drawing.Point(113, 205);
            this.SpeedNumUpDown.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.SpeedNumUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.SpeedNumUpDown.Name = "SpeedNumUpDown";
            this.SpeedNumUpDown.ReadOnly = true;
            this.SpeedNumUpDown.Size = new System.Drawing.Size(120, 20);
            this.SpeedNumUpDown.TabIndex = 9;
            this.SpeedNumUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 212);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Speed";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 281);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Angles";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 318);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Rotation";
            // 
            // SizeNumUpDown
            // 
            this.SizeNumUpDown.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.SizeNumUpDown.InterceptArrowKeys = false;
            this.SizeNumUpDown.Location = new System.Drawing.Point(113, 243);
            this.SizeNumUpDown.Minimum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.SizeNumUpDown.Name = "SizeNumUpDown";
            this.SizeNumUpDown.ReadOnly = true;
            this.SizeNumUpDown.Size = new System.Drawing.Size(120, 20);
            this.SizeNumUpDown.TabIndex = 1;
            this.SizeNumUpDown.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.SizeNumUpDown.ValueChanged += new System.EventHandler(this.SizeNumUpDown_ValueChanged);
            // 
            // AnglesNumUpDown
            // 
            this.AnglesNumUpDown.InterceptArrowKeys = false;
            this.AnglesNumUpDown.Location = new System.Drawing.Point(113, 279);
            this.AnglesNumUpDown.Name = "AnglesNumUpDown";
            this.AnglesNumUpDown.ReadOnly = true;
            this.AnglesNumUpDown.Size = new System.Drawing.Size(120, 20);
            this.AnglesNumUpDown.TabIndex = 4;
            // 
            // RotationTrBar
            // 
            this.RotationTrBar.Location = new System.Drawing.Point(113, 318);
            this.RotationTrBar.Maximum = 360;
            this.RotationTrBar.Name = "RotationTrBar";
            this.RotationTrBar.Size = new System.Drawing.Size(120, 45);
            this.RotationTrBar.SmallChange = 0;
            this.RotationTrBar.TabIndex = 3;
            this.RotationTrBar.TickFrequency = 10;
            this.RotationTrBar.Scroll += new System.EventHandler(this.RotationTrBar_Scroll);
            this.RotationTrBar.ValueChanged += new System.EventHandler(this.RotationTrBar_ValueChanged);
            // 
            // StarRB
            // 
            this.StarRB.AutoSize = true;
            this.StarRB.Location = new System.Drawing.Point(16, 76);
            this.StarRB.Name = "StarRB";
            this.StarRB.Size = new System.Drawing.Size(44, 17);
            this.StarRB.TabIndex = 2;
            this.StarRB.TabStop = true;
            this.StarRB.Text = "Star";
            this.StarRB.UseVisualStyleBackColor = true;
            this.StarRB.CheckedChanged += new System.EventHandler(this.StarRB_CheckedChanged);
            // 
            // PolygonRB
            // 
            this.PolygonRB.AutoSize = true;
            this.PolygonRB.Location = new System.Drawing.Point(16, 43);
            this.PolygonRB.Name = "PolygonRB";
            this.PolygonRB.Size = new System.Drawing.Size(63, 17);
            this.PolygonRB.TabIndex = 1;
            this.PolygonRB.TabStop = true;
            this.PolygonRB.Text = "Polygon";
            this.PolygonRB.UseVisualStyleBackColor = true;
            this.PolygonRB.CheckedChanged += new System.EventHandler(this.PolygonRB_CheckedChanged);
            // 
            // CircleRB
            // 
            this.CircleRB.AutoSize = true;
            this.CircleRB.Location = new System.Drawing.Point(16, 9);
            this.CircleRB.Name = "CircleRB";
            this.CircleRB.Size = new System.Drawing.Size(51, 17);
            this.CircleRB.TabIndex = 0;
            this.CircleRB.TabStop = true;
            this.CircleRB.Text = "Circle";
            this.CircleRB.UseVisualStyleBackColor = true;
            this.CircleRB.CheckedChanged += new System.EventHandler(this.CircleRB_CheckedChanged);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "Текстовый файл(*txt)|*.txt";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "Текстовый файл(*txt)|*.txt";
            // 
            // Redactor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(920, 533);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Redactor";
            this.Text = "Векторный редактор";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PaintImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpeedNumUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SizeNumUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnglesNumUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RotationTrBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem оПрограммеToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.PictureBox PaintImage;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.ToolStripMenuItem справкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown SpeedNumUpDown;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown SizeNumUpDown;
        private System.Windows.Forms.NumericUpDown AnglesNumUpDown;
        private System.Windows.Forms.TrackBar RotationTrBar;
        private System.Windows.Forms.RadioButton StarRB;
        private System.Windows.Forms.RadioButton PolygonRB;
        private System.Windows.Forms.RadioButton CircleRB;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labelY;
        private System.Windows.Forms.Label labelX;
        private System.Windows.Forms.Button ColorBtn;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ToolStripMenuItem сохранитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem загрузитьToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

