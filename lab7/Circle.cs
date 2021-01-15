using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace lab7
{
    class Circle:Shape
    {
       
        public Circle(float x,float y,float r)
        {
            X = x;
            Y = y;
            R = r;
            Left = X - R;Right = X + R;Up = Y - R;Down = Y + R;
        }
        public override void Draw(Graphics g)
        {
            g.DrawEllipse(pen, X - R, Y - R, 2 * R, 2 * R);
        }
        public override void Move(float dx, float dy)
        {
            X = X + dx;
            Y = Y + dy;
            Left = Left + dx;
            Right = Right + dx;
            Down = Down + dy;
            Up = Up + dy;
        }
        public override void SizeMinus()
        {
            R--; Left = X - R; Right = X + R; Up = Y - R; Down = Y + R;
        }
        public override void SizePlus()
        {
            R++; Left = X - R; Right = X + R; Up = Y - R; Down = Y + R;
        }
        
        public Circle()
        {

        }
        public override string GetClassName()
        {
            return "Circle";
        }
        public override void Save(FileStream file)
        {
            string info = "classname:" + GetClassName() + " " + "x:" + ((int)X).ToString() + " " + "y:" + ((int)Y).ToString() + " " + 
                "radius:" + ((int)R).ToString()+" "+"R:"+pen.Color.R.ToString()+" "+
                "G:"+ pen.Color.G.ToString()+" "+"B:"+ pen.Color.B.ToString()+" \r\n";
            byte[] array = Encoding.Default.GetBytes(info);
            file.Write(array, 0, array.Length);
        }
        public override void Load(FileStream file)
        {
            string info = "";
            char c = (char)file.ReadByte();

            while (c != '\n')
            {
                info += c;
                c = (char)file.ReadByte();
            }
            int index = info.IndexOf("x:") + 2;
            int spaceKey = info.IndexOf(' ', index);
            char[] count = new char[30];
            info.CopyTo(index, count, 0, spaceKey - index);
            string tmp = "";
            for (int i = 0; i < count.Length; i++) tmp += count[i];
            X = Int32.Parse(tmp);
            count = null;
            count = new char[30];
            index = info.IndexOf("y:") + 2;
            spaceKey = info.IndexOf(' ', index);
            info.CopyTo(index, count, 0, spaceKey - index);
            tmp = "";
            for (int i = 0; i < count.Length; i++) tmp += count[i];
            Y = Int32.Parse(tmp);
            count = null;
            count = new char[30];
            index = info.IndexOf("radius:") + 7;
            spaceKey = info.IndexOf(' ', index);
            info.CopyTo(index, count, 0, spaceKey - index);
            tmp = "";
            for (int i = 0; i < count.Length; i++) tmp += count[i];
            R = Int32.Parse(tmp);
            int red, green, blue;
            count = null;
            count = new char[30];
            index = info.IndexOf("R:") + 2;
            spaceKey = info.IndexOf(' ', index);
            info.CopyTo(index, count, 0, spaceKey - index);
            tmp = "";
            for (int i = 0; i < count.Length; i++) tmp += count[i];
            red = Int32.Parse(tmp);
            count = null;
            count = new char[30];
            index = info.IndexOf("G:") + 2;
            spaceKey = info.IndexOf(' ', index);
            info.CopyTo(index, count, 0, spaceKey - index);
            tmp = "";
            for (int i = 0; i < count.Length; i++) tmp += count[i];
            green = Int32.Parse(tmp);
            count = null;
            count = new char[30];
            index = info.IndexOf("B:") + 2;
            spaceKey = info.IndexOf(' ', index);
            info.CopyTo(index, count, 0, spaceKey - index);
            tmp = "";
            for (int i = 0; i < count.Length; i++) tmp += count[i];
            blue = Int32.Parse(tmp);
            pen.Color = Color.FromArgb(red, green, blue);
            Left = X - R; Right = X + R; Up = Y - R; Down = Y + R;
        }
    }
}
