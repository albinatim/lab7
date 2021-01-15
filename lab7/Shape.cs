using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
namespace lab7
{
    class Shape
    {
        public float Left, Right, Down, Up;
        public float X { get; set; }
        public float Y { get; set; }
        public Pen pen { get; set; } = new Pen(Color.White, 1);
        public float R { get; set; } = 15;
        //public float Rv { get; set; } = 15;
        public float Angle { get; set; } = 0;
        //public int NumOfRays { get; set; } = 5;
        public int NumOfAngles { get; set; } = 3;
        public virtual void Move(float dx, float dy)
        {

        }
        public virtual void Add(Shape obj)
        {

        }
        public virtual void Delete(Shape obj)
        {

        }
        public virtual void Delete()
        {

        }
        public virtual void Rotate(float angle)
        {

        }
        public virtual void Draw(Graphics g)
        {

        }
        public virtual void SizePlus()
        {

        }
        public virtual void SizeMinus()
        {

        }
        public virtual float GetCount()
        {
            return 0;
        }
        public virtual Node GetHead()
        {
            return null;
        }
        public virtual Node GetEnd()
        {
            return null;
        }
        public virtual Node GetCurrent()
        {
            return null;
        }
        public virtual void Save(FileStream file)
        {

        }
        public virtual void Load(FileStream file)
        {
            string info = "";
            char c = (char)file.ReadByte();
            while (c != '\n')
            {
                info += c;
                c = (char)file.ReadByte();
            }
            char[] classname=null;
            int index=info.IndexOf("classname")+9;
            int spaceKey = info.IndexOf(' ');
            info.CopyTo(index + 1, classname, 0, spaceKey - index - 2);
            string cl = classname.ToString();
            
        }
        public virtual string GetClassName()
        {
            return "Shape";
        }
        public virtual string getValue(string presentation, string attribute)
        {
            string value = "";
            int attributeIndex = 0;
            int lastCharacterIndex = -1;
            for (int i = 0; i < presentation.Length; i++)
            {
                if (attributeIndex != attribute.Length)
                {
                    if (presentation[i] == attribute[attributeIndex])
                    {
                        attributeIndex++;
                        lastCharacterIndex = i;
                    }
                    else
                    {
                        attributeIndex = 0;
                        lastCharacterIndex = -1;
                    }
                }
                else
                {
                    break;
                }
            }
            int indexOfNextSpace = -1;
            for (int i = lastCharacterIndex + 2; i < presentation.Length; i++)
            {
                if (presentation[i] == ' ')
                {
                    indexOfNextSpace = i;
                    break;
                }
            }
            value = presentation.Substring(lastCharacterIndex + 2, indexOfNextSpace - lastCharacterIndex - 2);
            return value;
        }
    }       
            
}
