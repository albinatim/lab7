using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
namespace lab7
{
    class Polygon:Circle
    {
        public Polygon()
        {

        }
        public Polygon(float x, float y, int angles, float angle, float r) : base(x, y, r)
        {
            NumOfAngles = angles;
            Angle = angle;
            PointF[] Angles = new PointF[NumOfAngles];
            double alpha = Angle * Math.PI / 180;
            Right = X;
            Down = Y;
            Left = X;
            Up = Y;
            for (int k = 0; k < NumOfAngles; k++)
            {

                Angles[k].X = X + R * (float)Math.Cos(alpha);
                Angles[k].Y = Y + R * (float)Math.Sin(alpha);
                if (Angles[k].X > Right) Right = Angles[k].X;
                if (Angles[k].X < Left) Left = Angles[k].X;
                if (Angles[k].Y > Down) Down = Angles[k].Y;
                if (Angles[k].Y < Up) Up = Angles[k].Y;
                alpha = alpha + 2 * Math.PI / NumOfAngles;
            }
        }
        public override void Draw(Graphics g)
        {
            PointF[] Angles = new PointF[NumOfAngles];
            double alpha = Angle * Math.PI / 180;
            Right = X;
            Down = Y;
            Left = X;
            Up = Y;
            for (int k = 0; k < NumOfAngles; k++)
            {

                Angles[k].X = X + R * (float)Math.Cos(alpha);
                Angles[k].Y = Y + R * (float)Math.Sin(alpha);
                if (Angles[k].X > Right) Right= Angles[k].X;
                if (Angles[k].X < Left) Left= Angles[k].X;
                if (Angles[k].Y > Down) Down = Angles[k].Y;
                if (Angles[k].Y < Up) Up = Angles[k].Y;
                alpha = alpha + 2 * Math.PI / NumOfAngles;
            }
            g.DrawPolygon(pen, Angles);

        }
        public override void Move(float dx, float dy)
        {
            base.Move(dx, dy);
            PointF[] Angles = new PointF[NumOfAngles];
            double alpha = Angle * Math.PI / 180;
            Right = X;
            Down = Y;
            Left = X;
            Up = Y;
            for (int k = 0; k < NumOfAngles; k++)
            {

                Angles[k].X = X + R * (float)Math.Cos(alpha);
                Angles[k].Y = Y + R * (float)Math.Sin(alpha);
                if (Angles[k].X > Right) Right = Angles[k].X;
                if (Angles[k].X < Left) Left = Angles[k].X;
                if (Angles[k].Y > Down) Down = Angles[k].Y;
                if (Angles[k].Y < Up) Up = Angles[k].Y;
                alpha = alpha + 2 * Math.PI / NumOfAngles;
            }
        }
        public override void Rotate(float angle)
        {
            Angle = Angle + angle;
            PointF[] Angles = new PointF[NumOfAngles];
            double alpha = Angle * Math.PI / 180;
            Right = X;
            Down = Y;
            Left = X;
            Up = Y;
            for (int k = 0; k < NumOfAngles; k++)
            {

                Angles[k].X = X + R * (float)Math.Cos(alpha);
                Angles[k].Y = Y + R * (float)Math.Sin(alpha);
                if (Angles[k].X > Right) Right = Angles[k].X;
                if (Angles[k].X < Left) Left = Angles[k].X;
                if (Angles[k].Y > Down) Down = Angles[k].Y;
                if (Angles[k].Y < Up) Up = Angles[k].Y;
                alpha = alpha + 2 * Math.PI / NumOfAngles;
            }
        }
        public override void SizePlus()
        {
            base.SizePlus();
            PointF[] Angles = new PointF[NumOfAngles];
            double alpha = Angle * Math.PI / 180;
            Right = X;
            Down = Y;
            Left = X;
            Up = Y;
            for (int k = 0; k < NumOfAngles; k++)
            {

                Angles[k].X = X + R * (float)Math.Cos(alpha);
                Angles[k].Y = Y + R * (float)Math.Sin(alpha);
                if (Angles[k].X > Right) Right = Angles[k].X;
                if (Angles[k].X < Left) Left = Angles[k].X;
                if (Angles[k].Y > Down) Down = Angles[k].Y;
                if (Angles[k].Y < Up) Up = Angles[k].Y;
                alpha = alpha + 2 * Math.PI / NumOfAngles;
            }
        }
        public override void SizeMinus()
        {
            base.SizeMinus();
            PointF[] Angles = new PointF[NumOfAngles];
            double alpha = Angle * Math.PI / 180;
            Right = X;
            Down = Y;
            Left = X;
            Up = Y;
            for (int k = 0; k < NumOfAngles; k++)
            {

                Angles[k].X = X + R * (float)Math.Cos(alpha);
                Angles[k].Y = Y + R * (float)Math.Sin(alpha);
                if (Angles[k].X > Right) Right = Angles[k].X;
                if (Angles[k].X < Left) Left = Angles[k].X;
                if (Angles[k].Y > Down) Down = Angles[k].Y;
                if (Angles[k].Y < Up) Up = Angles[k].Y;
                alpha = alpha + 2 * Math.PI / NumOfAngles;
            }
        }
        public override string GetClassName()
        {
            return "Polygon";
        }
        public override void Save(FileStream file)
        {
            string info = "classname:" + GetClassName() + " " + "x:" + ((int)X).ToString() + " " + "y:" + ((int)Y).ToString() + " " +
                "radius:" + ((int)R).ToString() + " " + "R:" + pen.Color.R.ToString() + " " +
                "G:" + pen.Color.G.ToString() + " " + "B:" + pen.Color.B.ToString() + " "
                + "angles:" + ((int)Angle).ToString() + " " + "numofangles:" + NumOfAngles.ToString() + " \r\n";
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
            PointF[] Angles = new PointF[NumOfAngles];
            double alpha = Angle * Math.PI / 180;
            Right = X;
            Down = Y;
            Left = X;
            Up = Y;
            for (int k = 0; k < NumOfAngles; k++)
            {

                Angles[k].X = X + R * (float)Math.Cos(alpha);
                Angles[k].Y = Y + R * (float)Math.Sin(alpha);
                if (Angles[k].X > Right) Right = Angles[k].X;
                if (Angles[k].X < Left) Left = Angles[k].X;
                if (Angles[k].Y > Down) Down = Angles[k].Y;
                if (Angles[k].Y < Up) Up = Angles[k].Y;
                alpha = alpha + 2 * Math.PI / NumOfAngles;
            }
        }
    }
}
