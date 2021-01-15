using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
namespace lab7
{
    class Star:Circle
    {
        public Star()
        {

        }
        public Star(float x,float y,float r,int rays, float angle):base(x,y,r)
        {
            Angle = angle;
            NumOfAngles = rays;
            PointF[] Rays = new PointF[NumOfAngles];
            double alpha = Angle * Math.PI / 180;
            Right = X;
            Down = Y;
            Left = X;
            Up = Y;
            for (int k = 0; k < NumOfAngles; k++)
            {

                Rays[k].X = X + R * (float)Math.Cos(alpha);
                Rays[k].Y = Y + R * (float)Math.Sin(alpha);
                if (Rays[k].X > Right) Right = Rays[k].X;
                if (Rays[k].X < Left) Left = Rays[k].X;
                if (Rays[k].Y > Down) Down = Rays[k].Y;
                if (Rays[k].Y < Up) Up = Rays[k].Y;
                alpha = alpha + 2 * Math.PI / NumOfAngles;
            }
        }
        public override void Draw(Graphics g)
        {
            PointF[] Rays = new PointF[NumOfAngles];
            double alpha = Angle * Math.PI / 180;
            Right = X;
            Down = Y;
            Left = X;
            Up = Y;
            for (int k = 0; k < NumOfAngles; k++)
            {

                Rays[k].X = X + R * (float)Math.Cos(alpha);
                Rays[k].Y = Y + R * (float)Math.Sin(alpha);
                if (Rays[k].X > Right) Right = Rays[k].X;
                if (Rays[k].X < Left) Left = Rays[k].X;
                if (Rays[k].Y > Down) Down = Rays[k].Y;
                if (Rays[k].Y < Up) Up = Rays[k].Y;
                alpha = alpha + 2 * Math.PI / NumOfAngles;
            }
            int i = 0;
            do
            {
                int t = (i + (NumOfAngles / 2)) % NumOfAngles;
                g.DrawLine(pen, Rays[i].X, Rays[i].Y, Rays[t].X, Rays[t].Y);
                i = t;
            }
            while (i != 0);
        }
        public override void Move(float dx, float dy)
        {
            base.Move(dx, dy);
            PointF[] Rays = new PointF[NumOfAngles];
            double alpha = Angle * Math.PI / 180;
            Right = X;
            Down = Y;
            Left = X;
            Up = Y;
            for (int k = 0; k < NumOfAngles; k++)
            {

                Rays[k].X = X + R * (float)Math.Cos(alpha);
                Rays[k].Y = Y + R * (float)Math.Sin(alpha);
                if (Rays[k].X > Right) Right = Rays[k].X;
                if (Rays[k].X < Left) Left = Rays[k].X;
                if (Rays[k].Y > Down) Down = Rays[k].Y;
                if (Rays[k].Y < Up) Up = Rays[k].Y;
                alpha = alpha + 2 * Math.PI / NumOfAngles;
            }

        }
        public override void Rotate(float angle)
        {
            Angle = Angle + angle;
            PointF[] Rays = new PointF[NumOfAngles];
            double alpha = Angle * Math.PI / 180;
            Right = X;
            Down = Y;
            Left = X;
            Up = Y;
            for (int k = 0; k < NumOfAngles; k++)
            {

                Rays[k].X = X + R * (float)Math.Cos(alpha);
                Rays[k].Y = Y + R * (float)Math.Sin(alpha);
                if (Rays[k].X > Right) Right = Rays[k].X;
                if (Rays[k].X < Left) Left = Rays[k].X;
                if (Rays[k].Y > Down) Down = Rays[k].Y;
                if (Rays[k].Y < Up) Up = Rays[k].Y;
                alpha = alpha + 2 * Math.PI / NumOfAngles;
            }
        }
        public override void SizePlus()
        {
            base.SizePlus();
            PointF[] Rays = new PointF[NumOfAngles];
            double alpha = Angle * Math.PI / 180;
            Right = X;
            Down = Y;
            Left = X;
            Up = Y;
            for (int k = 0; k < NumOfAngles; k++)
            {

                Rays[k].X = X + R * (float)Math.Cos(alpha);
                Rays[k].Y = Y + R * (float)Math.Sin(alpha);
                if (Rays[k].X > Right) Right = Rays[k].X;
                if (Rays[k].X < Left) Left = Rays[k].X;
                if (Rays[k].Y > Down) Down = Rays[k].Y;
                if (Rays[k].Y < Up) Up = Rays[k].Y;
                alpha = alpha + 2 * Math.PI / NumOfAngles;
            }
        }
        public override void SizeMinus()
        {
            base.SizeMinus();
            PointF[] Rays = new PointF[NumOfAngles];
            double alpha = Angle * Math.PI / 180;
            Right = X;
            Down = Y;
            Left = X;
            Up = Y;
            for (int k = 0; k < NumOfAngles; k++)
            {

                Rays[k].X = X + R * (float)Math.Cos(alpha);
                Rays[k].Y = Y + R * (float)Math.Sin(alpha);
                if (Rays[k].X > Right) Right = Rays[k].X;
                if (Rays[k].X < Left) Left = Rays[k].X;
                if (Rays[k].Y > Down) Down = Rays[k].Y;
                if (Rays[k].Y < Up) Up = Rays[k].Y;
                alpha = alpha + 2 * Math.PI / NumOfAngles;
            }
        }
        public override string GetClassName()
        {
            return "Star";
        }
        public override void Save(FileStream file)
        {
            string info = "classname:" + GetClassName() + " " + "x:" + ((int)X).ToString() + " " + "y:" + ((int)Y).ToString() + " " +
                "radius:" + ((int)R).ToString() + " " + "R:" + pen.Color.R.ToString() + " " +
                "G:" + pen.Color.G.ToString() + " " + "B:" + pen.Color.B.ToString() + " "
                +"angles:"+((int)Angle).ToString()+" "+"numofangles:"+NumOfAngles.ToString()+" \r\n";
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
            count = null;
            count = new char[30];
            index = info.IndexOf("angles:") + 7;
            spaceKey = info.IndexOf(' ', index);
            info.CopyTo(index, count, 0, spaceKey - index);
            tmp = "";
            for (int i = 0; i < count.Length; i++) tmp += count[i];
            Angle = Int32.Parse(tmp);
            count = null;
            count = new char[30];
            index = info.IndexOf("numofangles:") + 12;
            spaceKey = info.IndexOf(' ', index);
            info.CopyTo(index, count, 0, spaceKey - index);
            tmp = "";
            for (int i = 0; i < count.Length; i++) tmp += count[i];
            NumOfAngles = Int32.Parse(tmp);
            PointF[] Rays = new PointF[NumOfAngles];
            double alpha = Angle * Math.PI / 180;
            Right = X;
            Down = Y;
            Left = X;
            Up = Y;
            for (int k = 0; k < NumOfAngles; k++)
            {

                Rays[k].X = X + R * (float)Math.Cos(alpha);
                Rays[k].Y = Y + R * (float)Math.Sin(alpha);
                if (Rays[k].X > Right) Right = Rays[k].X;
                if (Rays[k].X < Left) Left = Rays[k].X;
                if (Rays[k].Y > Down) Down = Rays[k].Y;
                if (Rays[k].Y < Up) Up = Rays[k].Y;
                alpha = alpha + 2 * Math.PI / NumOfAngles;
            }
        }
    }
}
