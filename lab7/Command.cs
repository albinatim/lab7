using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab7
{
    class Command
    {
        public float DX { get; set; }
        public float DY { get; set; }
        public virtual void Execute(Shape shape)
        {

        }
        public virtual void Unexecute()
        {

        }
        public virtual Command Clone()
        {
            return new Command();
        }
       
    }
    class MoveCommand:Command   //   КОМАНДА ДВИЖЕНИЯ
    {
        Shape Selection { get; set; }
        
        public MoveCommand(float dx,float dy)
        {
            DX = dx;
            DY = dy;
            Selection = null;
        }
        public override void Execute(Shape shape)
        {
            Selection = shape;
            if (Selection != null)
            {
                Selection.Move(DX, DY);
            }
        }
        public override void Unexecute()
        {
            if (Selection != null)
            {
                Selection.Move(-DX, -DY);
            }
        }
        public override Command Clone()
        {
            return new MoveCommand(DX,DY);
        }
    }
    class AddCommand:Command    //  КОМАНДА ДОБАВЛЕНИЯ В КОНЕЦ СПИСКА
    {
        Shape Selection { get; set; }
        Storage strg;
        
        public AddCommand(ref Storage storage)
        {
            Selection = null;
            strg = storage;
        }
        public override void Execute(Shape shape)
        {
            Selection = shape;
            if (Selection != null)
            {
                strg.Add(shape);
            }
        }
        public override void Unexecute()
        {
            if (Selection != null)
            {
                strg.Delete(Selection);
            }
        }
        public override Command Clone()
        {
            return new AddCommand(ref strg);
        }
    }
    class DeleteCommand : Command   //  КОМАНДА УДАЛЕНИЯ
    {
        Shape Selection { get; set; }
        Storage strg;
        public DeleteCommand(ref Storage storage)
        {
            strg = storage;
            Selection = null;
        }
        public override void Execute(Shape shape)
        {
            Selection = shape;
            if(Selection != null)
            {
                strg.Delete();
            }
        }
        public override void Unexecute()
        {
            if (Selection != null)
            {
                    strg.Add(Selection);
            }
        }
        public override Command Clone()
        {
            return new DeleteCommand(ref strg);
        }
    }
    class RotateCommand : Command   //  КОМАНДА ПОВОРОТ ФИГУРЫ
    {
        Shape Selection { get; set; }
        float Angle { get; set; }
        public RotateCommand(float angle)
        {
            Angle = angle;
            Selection = null;
        }
        public override void Execute(Shape shape)
        {
            Selection = shape;
            if (Selection != null)
            {
                Selection.Rotate(Angle);
            }
        }
        public override void Unexecute()
        {
            if (Selection != null)
            {
                Selection.Rotate(-Angle);
            }
        }
        public override Command Clone()
        {
            return new RotateCommand(Angle);
        }
    }
    class SizePlusCommand:Command   //  КОМАНДА УВЕЛИЧЕНИЯ РАДИУСА ФИГУРЫ
    {
        Shape Selection { get; set; }
        public SizePlusCommand()
        {
            Selection = null;
        }
        public override void Execute(Shape shape)
        {
            Selection = shape;
            if (Selection != null)
            {
                Selection.SizePlus();
            }
        }
        public override void Unexecute()
        {
            if (Selection != null)
            {
                Selection.SizeMinus();
            }
        }
        public override Command Clone()
        {
            return new SizePlusCommand();
        }
    }
    class SizeMinusCommand:Command //   КОМАНДА УМЕНЬШЕНИЯ РАДИУСА ФИГУРЫ
    {
        Shape Selection { get; set; }
        public SizeMinusCommand()
        {
            Selection = null;
        }
        public override void Execute(Shape shape)
        {
            Selection = shape;
            if (Selection != null)
            {
                Selection.SizeMinus();
            }
        }
        public override void Unexecute()
        {
            if (Selection != null)
            {
                Selection.SizePlus();
            }
        }
        public override Command Clone()
        {
            return new SizeMinusCommand();
        }
    }
    class ChooseNextCommand : Command   //  КОМАНДА ВЫБОРА СЛЕДУЮЩЕЙ ФИГУРЫ
    {
        Shape Selection { get; set; }
        Storage strg;
        public ChooseNextCommand(ref Storage storage)
        {
            Selection = null;
            strg = storage;
        }
        public override void Execute(Shape shape)
        {
            Selection = shape;
            if (Selection != null)
            {
                strg.ChooseNext();
            }
        }
        public override void Unexecute()
        {
            if (Selection != null)
            {
                strg.ChoosePrev();
            }
        }
        public override Command Clone()
        {
            return new ChooseNextCommand(ref strg);
        }
    }
    class ChoosePrevCommand : Command   //  КОМАНДА ВЫБОРА ПРЕДЫДУЩЕЙ ФИГУРЫ
    {
        Shape Selection { get; set; }
        Storage strg;
        public ChoosePrevCommand(ref Storage storage)
        {
            Selection = null;
            strg = storage;
        }
        public override void Execute(Shape shape)
        {
            Selection = shape;
            if (Selection != null)
            {
                strg.ChoosePrev();
            }
        }
        public override void Unexecute()
        {
            if (Selection != null)
            {
                strg.ChooseNext();
            }
        }
        public override Command Clone()
        {
            return new ChoosePrevCommand(ref strg);
        }

    }
    class ChooseCurrentCommand : Command
    {
        Shape Selection { get; set; }
        Storage strg;
        Node PreviousCurrent;
        public ChooseCurrentCommand(ref Storage storage)
        {
            strg = storage;
            PreviousCurrent = strg.Current;
            Selection = null;
        }
        public override void Execute(Shape shape)
        {
            Selection = shape;
            if (Selection != null)
            {
                Node node = strg.Head;
                int t = 1;
                while (t <= strg.Count)
                {
                    if (node.Data == Selection)
                    {
                        strg.Current = node;
                    }
                    t++;node = node.Next;
                }

            }
        }
        public override void Unexecute()
        {
            strg.Current = PreviousCurrent;
        }
        public override Command Clone()
        {
            return new ChooseCurrentCommand(ref strg);
        }
    }
    class MakeGroupCommand : Command
    {
        Storage strg;
        Shape Selection { get; set; }
        public MakeGroupCommand(ref Storage storage)
        {
            strg = storage;
            Selection = null;
        }
        public override void Execute(Shape shape)
        {
            Selection = shape;
            if (Selection != null)
            {
                strg.AddToBegin(Selection);
                strg.DeleteChosen();
            }
            
        }
        public override void Unexecute()
        {
            if (Selection != null)
            {
                if (Selection.GetCount() > 0)
                {
                    while (Selection.GetCount() > 0)
                    {
                        strg.AddToBegin(Selection.GetCurrent().Data);
                        Selection.Delete();
                    }
                    strg.Current = strg.End;
                    strg.Delete(Selection);
                }
            }
        }
        public override Command Clone()
        {
            return new MakeGroupCommand(ref strg);
        }
    }
    class UngroupCommand:Command
    {
        Storage strg;
        Shape Selection { get; set; }
        public UngroupCommand(ref Storage storage)
        {
            strg = storage;
            Selection = null;
        }
        public override void Execute(Shape shape)
        {
            Selection = shape;
            if (Selection != null)
            {
                if (Selection.GetCount() > 0)
                {
                   while(Selection.GetCount() > 0)
                    {
                        strg.AddToBegin(Selection.GetCurrent().Data);
                        Selection.Delete();
                    }
                    strg.Current = strg.End;
                    strg.Delete(Selection);
                }
            }
        }
        public override Command Clone()
        {
            return new UngroupCommand(ref strg);
        }
    }
}
