using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace lab7
{
    public partial class Redactor : Form
    {
        Dictionary<Keys,Command> commands = new Dictionary<Keys,Command>();
        Stack<Command> history = new Stack<Command>();
        Storage figures = new Storage();
        int count = 0;
        int BeginAngle;
        public Redactor()
        {
            InitializeComponent();
            KeyPreview = true;
            BeginAngle = RotationTrBar.Value;
            
            SizeNumUpDown.Maximum = (decimal)PaintImage.Width;
            commands[Keys.R] = new RotateCommand(-1);
            commands[Keys.T] = new RotateCommand(1);
            commands[Keys.Left] = new MoveCommand(-1, 0);
            commands[Keys.Right] = new MoveCommand(1, 0);
            commands[Keys.Up] = new MoveCommand(0, -1);
            commands[Keys.Down] = new MoveCommand(0, 1);
            commands[Keys.D1] = new AddCommand(ref figures);
            commands[Keys.D2] = new AddCommand(ref figures);
            commands[Keys.D3] = new AddCommand(ref figures);
            commands[Keys.Add] = new SizePlusCommand();
            commands[Keys.Subtract] = new SizeMinusCommand();
            commands[Keys.Delete] = new DeleteCommand(ref figures);
            commands[Keys.N] = new ChooseNextCommand(ref figures);
            commands[Keys.P] = new ChoosePrevCommand(ref figures);
            commands[Keys.LButton] = new AddCommand(ref figures);
            commands[Keys.U] = new UngroupCommand(ref figures);
            commands[Keys.G] = new MakeGroupCommand(ref figures);
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            Pen p = new Pen(Color.Black, 1);
            if (figures.Count != 0)
            {
                
                
                SizeNumUpDown.Value = (decimal)figures.Current.Data.R;
                if (figures.Current.Data.GetType() == new Circle().GetType())
                {
                    CircleRB.Checked = true;
                    RotationTrBar.Visible = false;
                    AnglesNumUpDown.Visible = false;
                }
                if (figures.Current.Data.GetType() == new Star().GetType()) StarRB.Checked = true;
                if (figures.Current.Data.GetType() == new Polygon().GetType()) PolygonRB.Checked = true;
                if (figures.Current.Data.GetType() != new Circle().GetType())
                {
                    RotationTrBar.Visible = true;
                    AnglesNumUpDown.Visible = true;
                    //RotationTrBar.Value = (int)figures.Current.Data.Angle / 361;
                    AnglesNumUpDown.Value = figures.Current.Data.NumOfAngles;
                }
                labelX.Text = figures.Current.Data.X.ToString();
                labelY.Text = figures.Current.Data.Y.ToString();
            }
            
            Node n = figures.Head;
            int t = 1;
            if (figures.Count != 0)
            {
                while (t <= figures.Count)
                {
                    
                    

                    if (n == figures.Current) n.Data.pen.Width=2;
                    else n.Data.pen.Width=1;
                    n.Data.Draw(g);
                    if (n.Chosen == true)
                    {
                        g.DrawRectangle(p, n.Data.Left, n.Data.Up, n.Data.Right-n.Data.Left,n.Data.Down-n.Data.Up);
                    }
                    t++; n = n.Next;
                }
            }
        }
        private void figuresChanged()
        {
            if (figures.Count != count)
            {
                treeView1.Nodes.Clear();
                if (figures.Count != 0)
                {
                    int t = 1;
                    Node node = figures.Head;
                    while (t <= figures.Count)
                    {
                        treeView1.Nodes.Add(node.Data.GetClassName());
                        t++;node = node.Next;
                    }
                }
                count = figures.Count;
            }
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            Keys key = e.KeyCode;
            Random rand = new Random();
            float r = rand.Next(20, 80);
            float y = rand.Next((int)r, PaintImage.Height - (int)r);
            float x = rand.Next((int)r, PaintImage.Width - (int)r);
            int angles = rand.Next(3, 20);
            int rays = 2 * rand.Next(2, 7) + 1;
            float rotate = rand.Next(360);
            if (commands.ContainsKey(key))
            {
                Command command = commands[key];
                if (key == Keys.D1)
                {

                    Circle c = new Circle(x, y, r);
                    c.pen.Color = Color.FromArgb(rand.Next(255), rand.Next(255), rand.Next(255));

                    Command newcommand = command.Clone();
                    newcommand.Execute(c);

                    ColorBtn.BackColor = figures.Current.Data.pen.Color;
                    //history.Push(newcommand);
                    figuresChanged();
                    PaintImage.Refresh();
                }
                else if (key == Keys.D2)
                {
                    Polygon p = new Polygon(x, y, angles, rotate, r);
                    p.pen.Color = Color.FromArgb(rand.Next(255), rand.Next(255), rand.Next(255));

                    Command newcommand = command.Clone();
                    newcommand.Execute(p);

                    ColorBtn.BackColor = figures.Current.Data.pen.Color;
                    //history.Push(newcommand);
                    figuresChanged();
                    PaintImage.Refresh();
                }
                else if (key == Keys.D3)
                {
                    Star s = new Star(x, y, r, rays, rotate);
                    s.pen.Color = Color.FromArgb(rand.Next(255), rand.Next(255), rand.Next(255));

                    Command newcommand = command.Clone();
                    newcommand.Execute(s);

                    ColorBtn.BackColor = figures.Current.Data.pen.Color;
                    //history.Push(newcommand);
                    figuresChanged();
                    PaintImage.Refresh();
                }

                else if (key == Keys.Left)
                {
                    float tmpx = figures.Current.Data.Left;
                    if (tmpx -(float)SpeedNumUpDown.Value >= 0)
                    {
                        command.DX = -(float)SpeedNumUpDown.Value;
                        Command newcommand = command.Clone();
                        newcommand.Execute(figures.Current.Data);
                        history.Push(newcommand);
                        PaintImage.Refresh();
                    }

                }
                else if (key == Keys.Right)
                {
                    float tmpx = figures.Current.Data.Right;
                    if (tmpx + (float)SpeedNumUpDown.Value <= PaintImage.Width)
                    { 
                        command.DX = (float)SpeedNumUpDown.Value;
                        Command newcommand = command.Clone();
                        newcommand.Execute(figures.Current.Data);
                        history.Push(newcommand);
                        PaintImage.Refresh();
                    }
                }
                else if (key == Keys.Up)
                {
                    float tmpy = figures.Current.Data.Up;
                    if (tmpy - (float)SpeedNumUpDown.Value >= 0)
                    {
                        command.DY = -(float)SpeedNumUpDown.Value;
                        Command newcommand = command.Clone();
                        newcommand.Execute(figures.Current.Data);
                        history.Push(newcommand);
                        PaintImage.Refresh();
                    }
                }
                else if  (key == Keys.Down)
                {
                    float tmpy = figures.Current.Data.Down;

                    if (tmpy + (float)SpeedNumUpDown.Value <= PaintImage.Height)
                    {
                        command.DY = (float)SpeedNumUpDown.Value;
                        Command newcommand = command.Clone();
                        newcommand.Execute(figures.Current.Data);
                        history.Push(newcommand);
                        PaintImage.Refresh();
                    }
                }
                else if (key == Keys.Add)
                {
                    float left = figures.Current.Data.Left;
                    float right = figures.Current.Data.Right;
                    float up = figures.Current.Data.Up;
                    float down = figures.Current.Data.Down;
                    if ((right+ 1<= PaintImage.Width)&&(left-1>=0)&& (down+1<=PaintImage.Height)&& (up-1>=0))
                    {
                        Command newcommand = command.Clone();
                        newcommand.Execute(figures.Current.Data);
                        history.Push(newcommand);
                        PaintImage.Refresh();
                    }
                    
                }
                else if (key == Keys.Subtract)
                {
                    if (figures.Current.Data.R - 1 >= 15)
                    {
                        Command newcommand = command.Clone();
                        newcommand.Execute(figures.Current.Data);
                        history.Push(newcommand);
                        PaintImage.Refresh();
                    }
                }
                else if ((key == Keys.R) || (key == Keys.T))
                {
                   if(figures.Current.Data.GetType()!=new Circle().GetType())
                    {
                        Star s = new Star();Star s1 = new Star();
                        s.Angle = figures.Current.Data.Angle;s1.Angle = s.Angle;
                        s.NumOfAngles = figures.Current.Data.NumOfAngles;s1.NumOfAngles = s.NumOfAngles;
                        s.X = figures.Current.Data.X;s1.X = s.X;
                        s.Y = figures.Current.Data.Y;s1.Y = s.Y;
                        s.R = (figures.Current.Data.Right- figures.Current.Data.Left)/2;s1.R = (figures.Current.Data.Down - figures.Current.Data.Up) / 2;
                        s.Left = figures.Current.Data.Left;
                        s.Right = figures.Current.Data.Right;
                        s.Up = figures.Current.Data.Up;
                        s.Down = figures.Current.Data.Down;
                        if (key == Keys.R) { s.Rotate(-1); s1.Rotate(-1); }
                        else {s.Rotate(1); s1.Rotate(1);}
                        float left = s.Left, right = s.Right;
                        float up1 = s1.Up, down1 = s1.Down;
                        if ((left >= 0) && (right <= PaintImage.Width) &&(up1 >= 0) && (down1 <= PaintImage.Height))
                        {
                            Command newcommand = command.Clone();
                            newcommand.Execute(figures.Current.Data);
                            history.Push(newcommand);
                            PaintImage.Refresh();
                        }
                    }
                    
                   
                    
                }
                else if ((key == Keys.N) ||( key == Keys.P))
                {
                    Command newcommand = command.Clone();
                    newcommand.Execute(figures.Current.Data);
                    ColorBtn.BackColor = figures.Current.Data.pen.Color;
                    //history.Push(newcommand);
                    PaintImage.Refresh();
                }
                
                else if (key == Keys.Delete)
                {
                    Command newcommand = command.Clone();
                    newcommand.Execute(figures.Current.Data);
                    history.Push(newcommand);
                    figuresChanged();
                    PaintImage.Refresh();
                    if (figures.Count == 0)
                    {
                        labelX.Text = "";
                        labelY.Text = "";
                        SizeNumUpDown.Value = SizeNumUpDown.Minimum;
                        AnglesNumUpDown.Value = AnglesNumUpDown.Minimum;
                        RotationTrBar.Value = RotationTrBar.Minimum;
                    }
                }
                else if ((key != Keys.LButton) && (key != Keys.G) && (key != Keys.U))
                {
                    Command newcommand = command.Clone();
                    newcommand.Execute(figures.Current.Data);
                    history.Push(newcommand);
                    PaintImage.Refresh();
                }
            }
            if (key == Keys.Z && history.Count!=0)
            {
                Command lastcommand = history.Peek();
                lastcommand.Unexecute();
                lastcommand = null;
                history.Pop();
                figuresChanged();
                PaintImage.Refresh();
            }

        }

        private void справкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form InfoForm = new Form();
            InfoForm.Text = "Справка";
            Label info = new Label();
            info.Text = "Клавиша 1 - добавление круга\n" +
                "Клавиша 2 - добавление многоугольника\n" +
                "Клавиша 3 - добавление звезды\n" +
                "Стрелка вверх - движение вверх\n" +
                "Стрелка вниз - движение вниз\n" +
                "Стрелка вправо - движение вправо\n" +
                "Стрелка влево - движение влево\n" +
                "Клавиша R - поворот влево\n" +
                "Клавиша T - поворот вправо\n" +
                "Клавиша C - изменение цвета\n" +
                "Клавиша + - увеличение размера\n" +
                "Клавиша - - уменьшение размера\n" +
                "Клавиша N - переключение на следующий \n" +
                "Клавиша P - переключение на предыдущий \n" +
                "Клавиша Delete - удаление текущего элемента";
            info.AutoSize = true;
            InfoForm.Controls.Add(info);
            InfoForm.Show();
        
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Лабораторная работа 6-7\nВыполнили студенты группы ПРО-216:\nТимербаева, Наследникова", "О программе");
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PaintImage_MouseClick(object sender, MouseEventArgs e)
        {
            
            if (e.Button == MouseButtons.Right)
            {
              if (figures.Count != 0)
                {
                    Node n = figures.Head;
                    int t = 1;
                    while (t <= figures.Count)
                    {
                        if ((e.X - n.Data.X) * (e.X - n.Data.X) + (e.Y - n.Data.Y) * (e.Y - n.Data.Y) <= (n.Data.R * n.Data.R))
                        {

                            if (n.Chosen == false)
                            {
                                n.Chosen = true;
                            }
                            else
                            {
                                n.Chosen = false;
                            }
                            PaintImage.Refresh();
                        }
                        t++;
                        n = n.Next;
                       
                    }
                }
               

            }

            if (e.Button == MouseButtons.Left)
            {
                Keys key = Keys.LButton;
                Command command = commands[key];
               
                    if (CircleRB.Checked)
                {
                   
                    Circle c = new Circle(e.X, e.Y, (float)SizeNumUpDown.Value);
                        if ((c.X + c.R <= PaintImage.Width) && (c.X - c.R >= 0) && (c.Y + c.R <= PaintImage.Height) && (c.Y - c.R >= 0))
                        {

                            c.pen.Color = ColorBtn.BackColor; 
                            Command newcommand = command.Clone();
                            newcommand.Execute(c);
                        //history.Push(newcommand);
                        figuresChanged();
                        PaintImage.Refresh();
                            
                        }
                    }
                    if (StarRB.Checked)
                    {
                    if (AnglesNumUpDown.Value < 5) AnglesNumUpDown.Value = 5;
                        if (AnglesNumUpDown.Value % 2 == 0) AnglesNumUpDown.Value--;
                        Star s = new Star(e.X, e.Y, (float)SizeNumUpDown.Value, (int)AnglesNumUpDown.Value, RotationTrBar.Value);
                        if ((s.Right <= PaintImage.Width) && (s.Left >= 0) && (s.Down <= PaintImage.Height) && (s.Up >= 0))

                        {
                            s.pen.Color = ColorBtn.BackColor;
                            Command newcommand = command.Clone();
                            newcommand.Execute(s);
                        //history.Push(newcommand);
                        figuresChanged();
                        PaintImage.Refresh();

                        }
                    }
                    if (PolygonRB.Checked)
                {
                    if (AnglesNumUpDown.Value < 3) AnglesNumUpDown.Value = 3;
                        Polygon p = new Polygon(e.X, e.Y, (int)AnglesNumUpDown.Value, RotationTrBar.Value, (float)SizeNumUpDown.Value);
                        if ((p.Right <= PaintImage.Width) && (p.Left >= 0) && (p.Down <= PaintImage.Height) && (p.Up >= 0))

                        {
                            p.pen.Color = ColorBtn.BackColor;
                        Command newcommand = command.Clone();
                            newcommand.Execute(p);
                        //history.Push(newcommand);
                        figuresChanged();
                        PaintImage.Refresh();

                        }
                    }
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                ColorBtn.BackColor = colorDialog1.Color;
                if (figures.Count != 0)
                {
                    figures.Current.Data.pen.Color= colorDialog1.Color;
                    if(figures.Current.Data.GetType()==new Storage().GetType())
                    {
                        int t = 1;
                        Node n = figures.Current.Data.GetHead();
                        while (t <= figures.Current.Data.GetCount())
                        {
                            n.Data.pen.Color= colorDialog1.Color;
                            //PaintImage.Refresh();
                            t++;n = n.Next;
                        }
                    }
                    PaintImage.Refresh();
                }
            }
        }

        private void CircleRB_CheckedChanged(object sender, EventArgs e)
        {
            RotationTrBar.Visible = false;
            AnglesNumUpDown.Visible = false;
        }

        private void PolygonRB_CheckedChanged(object sender, EventArgs e)
        {
            RotationTrBar.Visible = true;
            AnglesNumUpDown.Visible = true;
        }

        private void StarRB_CheckedChanged(object sender, EventArgs e)
        {
            RotationTrBar.Visible = true;
            AnglesNumUpDown.Visible = true;
        }

        private void RotationTrBar_ValueChanged(object sender, EventArgs e)
        {
            
        }
        
        private void RotationTrBar_Scroll(object sender, EventArgs e)
        {
            if (BeginAngle < RotationTrBar.Value)
            {
                int k =RotationTrBar.Value -BeginAngle;
                BeginAngle = RotationTrBar.Value;
                for(int i = 0; i < k; i++)
                {
                    if (figures.Current.Data.GetType() != new Circle().GetType())
                    {
                        Keys key = Keys.R;
                        Command command = commands[key];
                        Star s = new Star();
                        s.Angle = figures.Current.Data.Angle;
                        s.NumOfAngles = figures.Current.Data.NumOfAngles;
                        s.X = figures.Current.Data.X;
                        s.Y = figures.Current.Data.Y;
                        s.R = figures.Current.Data.R;
                        s.Left = figures.Current.Data.Left;
                        s.Right = figures.Current.Data.Right;
                        s.Up = figures.Current.Data.Up;
                        s.Down = figures.Current.Data.Down;
                        if (key == Keys.R) s.Rotate(-1);
                        else s.Rotate(1);
                        float left = s.Left, right = s.Right, up = s.Up, down = s.Down;
                        if ((left >= 0) && (right <= PaintImage.Width) && (up >= 0) && (down <= PaintImage.Height))
                        {
                            Command newcommand = command.Clone();
                            newcommand.Execute(figures.Current.Data);
                            history.Push(newcommand);
                            PaintImage.Refresh();
                        }
                    }

                }
                
            }
            else
            {
                int k = BeginAngle- RotationTrBar.Value;
                BeginAngle = RotationTrBar.Value;
                for (int i = 0; i < k; i++)
                {
                    if (figures.Current.Data.GetType() != new Circle().GetType())
                    {
                        Keys key = Keys.T;
                        Command command = commands[key];
                        Star s = new Star();
                        s.Angle = figures.Current.Data.Angle;
                        s.NumOfAngles = figures.Current.Data.NumOfAngles;
                        s.X = figures.Current.Data.X;
                        s.Y = figures.Current.Data.Y;
                        s.R = figures.Current.Data.R;
                        s.Left = figures.Current.Data.Left;
                        s.Right = figures.Current.Data.Right;
                        s.Up = figures.Current.Data.Up;
                        s.Down = figures.Current.Data.Down;
                        if (key == Keys.R) s.Rotate(-1);
                        else s.Rotate(1);
                        float left = s.Left, right = s.Right, up = s.Up, down = s.Down;
                        if ((left >= 0) && (right <= PaintImage.Width) && (up >= 0) && (down <= PaintImage.Height))
                        {
                            Command newcommand = command.Clone();
                            newcommand.Execute(figures.Current.Data);
                            history.Push(newcommand);
                            PaintImage.Refresh();
                        }
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (figures.Current.Data.GetType()==new Storage().GetType())
            {
                Keys key = Keys.U;
                Command command = commands[key];
                Command newcommand = command.Clone();
                newcommand.Execute(figures.Current.Data);
                //history.Push(newcommand);
                figuresChanged();
                PaintImage.Refresh();
            }
            else
            {
                if (figures.Count != 0)
                {
                    int m = 1;Node nd = figures.Head;
                    int k = 0;
                    while (m <= figures.Count)
                    {
                        if (nd.Chosen == true) { k++; }
                        m++;nd = nd.Next;
                    }
                    if (k > 0)
                    {
                        Storage Group = new Storage();
                        Node node = figures.Head;
                        int t = 1;
                        while (t <= figures.Count)
                        {
                            if (node.Chosen == true)
                            {
                                Group.Add(node.Data);
                            }
                            t++;
                            node = node.Next;
                        }
                        t = 1;
                        Node n = Group.Head;
                        Group.Left = n.Data.Left; Group.Up = n.Data.Up; Group.Right = n.Data.Right; Group.Down = n.Data.Down;
                        while (t <= Group.Count)
                        {
                            if (n.Data.Right > Group.Right) Group.Right = n.Data.Right;
                            if (n.Data.Down > Group.Down) Group.Down = n.Data.Down;
                            if (n.Data.Left < Group.Left) Group.Left = n.Data.Left;
                            if (n.Data.Up < Group.Up) Group.Up = n.Data.Up;
                            t++; n = n.Next;
                        }
                        t = 1; n = Group.Head;
                        Group.X = Group.Left + (Group.Right - Group.Left) / 2;
                        Group.Y = Group.Up + (Group.Down - Group.Up) / 2;
                        if (Group.X - Group.Left >= Group.Y - Group.Up)
                        {
                            Group.R = Group.X - Group.Left;
                        }
                        else Group.R = Group.Y - Group.Up;
                        Keys key = Keys.G;
                        Command command = commands[key];
                        Command newcommand = command.Clone();
                        newcommand.Execute(Group);
                        history.Push(newcommand);
                        PaintImage.Refresh();
                        //figures.DeleteChosen();
                        figuresChanged();
                        PaintImage.Refresh();
                    }
                }
                
            }
           
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (figures.Count != 0)
                {
                    string filename = saveFileDialog1.FileName;

                    FileStream file = new FileStream(filename, FileMode.Create);
                    int t = 1;
                    Node n = figures.Head;
                    string info = "classname:" + figures.GetClassName() + " " + "count:" + figures.Count.ToString() + " \r\n";
                    byte[] array = Encoding.Default.GetBytes(info);
                    file.Write(array, 0, array.Length);
                    while (t <= figures.Count)
                    {
                         n.Data.Save(file);
                        t++;n = n.Next;
                    }
                    file.Close();
                }

                }
            }

        private void загрузитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filename = openFileDialog1.FileName;
                FileStream file = new FileStream(filename, FileMode.Open);
                while (figures.Count != 0)
                {
                    figures.Delete();
                }
                
                figures.Load(file);
                figuresChanged();
                ColorBtn.BackColor = figures.Current.Data.pen.Color;
                PaintImage.Refresh();
                file.Close();
            }
        }

        private void SizeNumUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (figures.Current.Data.R < (float)SizeNumUpDown.Value)
            {
                float left = figures.Current.Data.Left;
                float right = figures.Current.Data.Right;
                float up = figures.Current.Data.Up;
                float down = figures.Current.Data.Down;
                if ((right + 1 <= PaintImage.Width) && (left - 1 >= 0) && (down + 1 <= PaintImage.Height) && (up - 1 >= 0))
                {
                    Keys key = Keys.Add;
                    Command command = commands[key];
                    Command newcommand = command.Clone();
                    newcommand.Execute(figures.Current.Data);
                    history.Push(newcommand);
                    PaintImage.Refresh();
                }
            }
            else if(figures.Current.Data.R > (float)SizeNumUpDown.Value)
            {
                if (figures.Current.Data.R - 1 >= 15)
                {
                    Keys key = Keys.Subtract;
                    Command command = commands[key];
                    Command newcommand = command.Clone();
                    newcommand.Execute(figures.Current.Data);
                    history.Push(newcommand);
                    PaintImage.Refresh();
                }
                
            }
        }
    }
}
