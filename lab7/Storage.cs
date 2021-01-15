using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace lab7
{
    class Node:Shape
    {
        public Node Next { get; set; }
        public Node Prev { get; set; }
        public Shape Data { get; set; }
        public bool Chosen { get; set; } = false;
        //public int Number { get; set; }
        public Node() { } 
        public Node(Shape data)
        {
            Data = data;
            Next = null;
            Prev = null;
            //Console.WriteLine(Data);
        }
       
        public Node(Shape value, Node node)
        {
            Data = value;
            node.Next = this;
            Prev = node;
        }
    }

    class Storage: Shape
    {
        //public float Left, Right, Down, Up;
        public Node Head { get; set; }
        public Node End { get; set; }
        public Node Current { get; set; }
        public int Count { get; set; } = 0;
        //public int Count { get; private set; }
        public override float GetCount()
        {
            return Count;
        }
        public override string GetClassName()
        {
            return "Storage";
        }
        public override void Save(FileStream file)
        {
            if (Count != 0)
            {
                string info = "classname:" + GetClassName() + " "+"count:"+Count.ToString()+" \r\n";
                byte[] array = Encoding.Default.GetBytes(info);
                file.Write(array, 0, array.Length);
                int t = 1;Node node = Head;
                while (t <= Count)
                {
                    node.Data.Save(file);
                    t++;node = node.Next;
                }
            }
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
            int index = info.IndexOf("count:") + 6;
            int spaceKey = info.IndexOf(' ', index);
            char[] count=new char[30];
            info.CopyTo(index, count, 0, spaceKey - index);
            string tmp = "";
            for (int i = 0; i < count.Length; i++) tmp += count[i];
            Count =Int32.Parse(tmp);
            int t = 1;
            Console.WriteLine(Count);
            while (t <= Count)
            {
                info = "";
                c = (char)file.ReadByte();
                Console.WriteLine("0");
                while (c != ' ')
                {
                   
                    info += c;
                    c = (char)file.ReadByte();
                }
                Console.WriteLine("1");
                string classname = "";
                index = info.IndexOf("classname:") + 10;
                spaceKey = info.IndexOf(' ', index);
                classname = info.Substring(index);
                var ext = createShape(classname);
                Console.WriteLine(classname);
                Add(ext);
                Count--;
                ext.Load(file);
                Console.WriteLine(t);
                t++;
                
            }
            Console.WriteLine("загрузка");
            t = 1;
            Node n = Head;
            Left = n.Data.Left; Up = n.Data.Up; Right = n.Data.Right; Down = n.Data.Down;
            while (t <= Count)
            {
                if (n.Data.Right > Right) Right = n.Data.Right;
                if (n.Data.Down > Down) Down = n.Data.Down;
                if (n.Data.Left < Left) Left = n.Data.Left;
                if (n.Data.Up < Up) Up = n.Data.Up;
                t++; n = n.Next;
            }
            X = Left + (Right - Left) / 2;
            Y = Up + (Down - Up) / 2;
            if (X - Left >= Y - Up)
            {
                R = X - Left;
            }
            else R = Y - Up;
        }
        public Shape createShape(string classname)
        {
            Shape shape=null;
            switch (classname)
            {
                case "Circle":
                    Circle circle = new Circle(0, 0, 0);
                    //circle.Load(file);
                    shape = circle;
                    break;
                case "Storage":
                    Storage storage = new Storage();
                    //storage.Load(file);
                    shape = storage;
                    break;
                case "Star":
                    Star star = new Star(0, 0, 0, 0, 0);
                    //star.Load(file);
                    shape = star;
                    break;
                case "Polygon":
                    Polygon polygon = new Polygon(0, 0, 0, 0, 0);
                    //polygon.Load(file);
                    shape = polygon;
                    break;
            }
            return shape;
        }
        public override Node GetHead()
        {
            return Head;
        }
        public override void Add(Shape value)
        {
            if (Head == null)
            {
                Head = new Node(value);
                End = Head;
                End.Next = Head;
                End.Prev = Head;
                Head.Prev = End;
                Head.Next = End;
                Current = End;
            }
            else
            {
                End = new Node(value, End);
                End.Next = Head;
                Head.Prev = End;
                Current = End;
            }

            Count++;

        }
        public override void Delete()
        {
            if (Count != 0)
            {
                if (Count == 1) { Head = End = null; Count--; }
                else
                {
                    if (Current == End)
                    {
                        End.Prev.Next = Head;
                        Head.Prev = End.Prev;
                        End = Head.Prev;
                        Current = Head;
                        Count--;
                    }
                    else if (Current == Head)
                    {

                        Head.Next.Prev = End;
                        End.Next = Head.Next;
                        Current = End.Next;
                        Head = End.Next;
                        Count--;
                    }
                    else
                    {
                        Node node = Current;
                        Current.Prev.Next = node.Next;
                        Current.Next.Prev = node.Prev;
                        Count--;
                        Current = node.Next;
                        node = null;
                    }

                }
            }

        }
        public override void Delete(Shape obj)
        {
            
            if (Count != 0)
            {
                Node n = Head;
                int t = 1;
                while (t <= Count)
                {
                    if (n.Data == obj)
                    {
                        if (n == Current)
                        {
                            Delete();
                        }
                        else if (n == Head)
                        {
                            Head.Next.Prev = End;
                            End.Next = Head.Next;
                            Head = End.Next;
                            Count--;
                        }
                        else if (n == End)
                        {
                            End.Prev.Next = Head;
                            Head.Prev = End.Prev;
                            End = Head.Prev;
                            Count--;
                        }
                        else
                        {
                            Node tmp = n;
                            n.Prev.Next = tmp.Next;
                            n.Next.Prev = tmp.Prev;
                            tmp = null;
                            Count--;
                        }
                    }
                    t++;n = n.Next;
                }
            }
        }
        public void DeleteChosen()
        {
            if (Count != 0)
            {
                int k = 0;
                Node node = Head;
                while (node != End)
                {
                    Node tmp = node.Next;
                    if (node.Chosen == true)
                    {
                        k++;
                        if (node == Current)
                        {
                            Delete();
                        }
                        else if (node == Head)
                        {
                            Head.Next.Prev = End;
                            End.Next = Head.Next;
                            Head = End.Next;
                            Count--;
                        }
                        else
                        {
                            Node n = node;
                            node.Prev.Next = n.Next;
                            node.Next.Prev = n.Prev;
                            n = null;
                            Count--;
                        }
                    }
                    node = tmp;
                    tmp = null;
                }
                if (End.Chosen == true)
                {
                    k++;
                    if (End == Current)
                    {
                        Delete();
                    }
                    else
                    {
                        End.Prev.Next = Head;
                        Head.Prev = End.Prev;
                        End = Head.Prev;
                        Count--;
                    }
                }
                if (k == 0)
                {
                    Delete();
                }
            }
        }
        public void ChooseNext()
        {
            Current = Current.Next;
        }
        public void ChoosePrev()
        {
            Current = Current.Prev;
        }
        public override void Rotate(float angle)
        {
            if (Count != 0)
            {
                int t = 1;
                Node n = Head;
                while (t <= Count)
                {
                    n.Data.Rotate(angle);
                    t++;n = n.Next;
                }
                t = 1;
                n = Head;
                Left = n.Data.Left; Up = n.Data.Up; Right = n.Data.Right; Down = n.Data.Down;
                while (t <= Count)
                {
                    if (n.Data.Right > Right) Right = n.Data.Right;
                    if (n.Data.Down > Down) Down = n.Data.Down;
                    if (n.Data.Left < Left) Left = n.Data.Left;
                    if (n.Data.Up < Up) Up = n.Data.Up;
                    t++; n = n.Next;
                }
            }

        }
        public override void Move(float dx, float dy)
        {
            if (Count != 0)
            {
                int t = 1;
                Node n = Head;
                while (t <= Count)
                {
                    n.Data.Move(dx, dy);
                    t++; n = n.Next;
                }
                X = X + dx;
                Y = Y + dy;
                t = 1;
                n = Head;
                Left = n.Data.Left; Up = n.Data.Up; Right = n.Data.Right; Down = n.Data.Down;
                while (t <= Count)
                {
                    if (n.Data.Right > Right) Right = n.Data.Right;
                    if (n.Data.Down > Down) Down = n.Data.Down;
                    if (n.Data.Left < Left) Left = n.Data.Left;
                    if (n.Data.Up < Up) Up = n.Data.Up;
                    t++; n = n.Next;
                }
            }
        }
        public void Insert(Node p, Shape obj)
        {
            if (p == null)
            {
                Add(obj);
            }
            else if (p == End)
            {
                AddToBegin(obj);
            }
            else
            {
                int t = 1;
                Node node = Head;
                while (t < Count)
                {
                    if (node == p)
                    {
                        Node inserted = new Node(obj);
                        inserted.Prev = p;
                        inserted.Next = p.Next;
                        p.Next.Prev = inserted;
                        p.Next = inserted;
                        Count++;
                    }
                    t++;node = node.Next;
                }
            }
        }
        public void AddToBegin(Shape value)
        {
            if (Head == null)
            {
                Head = new Node(value);
                End = Head;
                End.Next = Head;
                End.Prev = Head;
                Head.Prev = End;
                Head.Next = End;
                Current = Head;
            }
            else
            {
                Node tmp = new Node(value);
                tmp.Next = Head;
                tmp.Prev = End;
                End.Next = tmp;
                Head.Prev = tmp;
                Head = tmp;
                Current = Head;
            }

            Count++;
        }
        public override void Draw(Graphics g)
        {

            int t = 1;
            Node n = Head;
            
            Left = n.Data.Left; Up = n.Data.Up; Right = n.Data.Right; Down = n.Data.Down;
            while (t <= Count)
            {
                if (n.Data.Right > Right) Right = n.Data.Right;
                if (n.Data.Down > Down) Down = n.Data.Down;
                if (n.Data.Left < Left) Left = n.Data.Left;
                if (n.Data.Up < Up) Up = n.Data.Up;
                t++; n = n.Next;
            }
            t = 1;
            n = Head;
            while (t <= Count)
            {
                n.Data.pen.Width = pen.Width;
                if (pen.Color != Color.White) n.Data.pen.Color = pen.Color;
                n.Data.Draw(g);
                n = n.Next;
                t++;
            }
            Pen rectangle = new Pen(Brushes.Black, 1);
            rectangle.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            g.DrawRectangle(rectangle, Left, Up, Right - Left, Down - Up);
        }
        public override Node GetEnd()
        {
            return End;
        }
        public override Node GetCurrent()
        {
            return Current;
        }
        public override void SizeMinus()
        {
            int t = 1;
            int k = 0;
            Node n = Head;
            while (t <= Count)
            {
                if (n.Data.R - 1 < 15) k++;
                n = n.Next;
                t++;
            }
            if (k == 0)
            {
                t = 1;
                n = Head;
                while (t <= Count)
                {
                    n.Data.SizeMinus();
                    n = n.Next;
                    t++;
                }
            }
           t = 1;
             n = Head;
            Left = n.Data.Left; Up = n.Data.Up; Right = n.Data.Right; Down = n.Data.Down;
            while (t <= Count)
            {
                if (n.Data.Right > Right) Right = n.Data.Right;
                if (n.Data.Down > Down) Down = n.Data.Down;
                if (n.Data.Left < Left) Left = n.Data.Left;
                if (n.Data.Up < Up) Up = n.Data.Up;
                t++; n = n.Next;
            }
            
        }
        public override void SizePlus()
        {
            int t = 1;
            Node n = Head;
            while (t <= Count)
            {
                n.Data.SizePlus();
                n = n.Next;
                t++;
            }
            t = 1;
            n = Head;
            Left = n.Data.Left; Up = n.Data.Up; Right = n.Data.Right; Down = n.Data.Down;
            while (t <= Count)
            {
                if (n.Data.Right > Right) Right = n.Data.Right;
                if (n.Data.Down > Down) Down = n.Data.Down;
                if (n.Data.Left < Left) Left = n.Data.Left;
                if (n.Data.Up < Up) Up = n.Data.Up;
                t++; n = n.Next;
            }
        }
    }


}
