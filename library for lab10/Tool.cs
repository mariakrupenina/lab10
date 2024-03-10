using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library_for_lab10
{
    //Инструмент
    public class Tool: IInit, IComparable, ICloneable
    {
        protected Random rnd = new Random();
        protected string name;
        public IdNumber id;
        static string[] Names = { "дрель", "пассатижи", "шуруповёрт", "ключ", "напильник", "паяльник", "угольник", "уровень", "рулетка", "рубанок" };

        public string Name //название
        {
            get => name;
            set
            {
                name = value;
            }
        }

        public IdNumber Id { get; set; }

        public Tool()
        {
            Name = "Без названия";
            id = new IdNumber(1);
        }

        public Tool(string name, int number1)
        {
            Name = name;
            id = new IdNumber(number1);
        }

        public override bool Equals(object obj)
        {
            if (obj is Tool b)
                return this.Name == b.Name;
            return false;
        }

        //public override bool Equals(object obj)
        //{
        //    var other = obj as Tool;
        //    if (other == null)
        //        return false;
        //    return name == other.Name;
        //}

        public override string ToString()
        {
            return $"{id} - Название: {Name}";
        }

        public virtual void Init()
        {
            Console.WriteLine("Введите id:");
            try
            {
                id.id = int.Parse(Console.ReadLine());
            }
            catch
            {
                id.id = 0;
            }
            Console.WriteLine("Введите название инстумента:");
            Name = Console.ReadLine();
        }

        public virtual void RandomInit()
        {
            Name = Names[rnd.Next(Names.Length)];
            id.id = rnd.Next(1, 30);
        }

        public virtual void VirtualPrint()
        {
            Console.WriteLine($"Intrumental: Название = {Name}");
        }
        public void Print()
        {
            Console.WriteLine($"Intrumental: Названине = {Name}");
        }

        //Реализация сортировки по имени
        public int CompareTo(object obj)
        {
            if (obj == null) return -1;
            Tool tool = obj as Tool;
            return String.Compare(this.Name, tool.Name);
        }

        public object Clone()
        {
            return new Tool(Name, id.id);
        }

        public object ShallowCopy()
        {
            return this.MemberwiseClone();
        }


        //ЧАСТЬ 3
        public class IdNumber
        {
            public int id;

            public IdNumber(int num)
            {
                if (num > 0)
                {
                    id = num;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Айди меньше 1");
                }
            }

            public int Id
            {
                get => id;
                set
                {
                    if (value < 0)
                        id = 1;
                    else
                        id = value;
                }
            }

            public override string ToString()
            {
                return id.ToString();
            }

            public override bool Equals(object obj)
            {
                if (obj is IdNumber n)
                    return this.id == n.id;
                else
                    return false;
            }

            //Соритровка по id
            public int Compare(object obj1, object obj2)
            {
                if (obj1 == null || obj2 == null) return 0;

                IdNumber i1 = (IdNumber)obj1;
                IdNumber i2 = (IdNumber)obj2;

                if (i1.Id != i2.Id) return -1;
                if (i1.Id == i2.Id) return 0;
                else
                    return 1;
            }

            public static implicit operator IdNumber(int v)
            {
                throw new NotImplementedException();
            }
        }
    }
}
