using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace library_for_lab10
{
    public class ElectricTool : HandTool
    {
        protected Random rndS = new Random();
        protected Random rndT = new Random();

        protected string source;
        public string PowerSource //источник питания
        {
            get => source;
            set
            {
                source = value;
            }
        }

        protected double time;
        public double BatteryTime
        {
            get => time;
            set
            {
                if (PowerSource != "аккамулятор")
                    time = 0;
                else
                    time = value;
            }
        }

        public ElectricTool() : base()
        {
            time = 0;
            source = "без источника";
        }

        public ElectricTool(string name, string material, string source, double time, int number) : base(name, material, number)
        {
            PowerSource = source;
            BatteryTime = time;
        }

        public override bool Equals(object obj)
        {
            ElectricTool tool = obj as ElectricTool;
            if (tool != null)
                return this.Name == tool.Name && this.Material == tool.Material && this.PowerSource == tool.PowerSource && this.BatteryTime == tool.BatteryTime;
            else
                return false;
        }

        public override string ToString()
        {
            return base.ToString() + $", источник питания: {PowerSource}, время работы: {BatteryTime}";
        }

        public override void Init()
        {
            base.Init();
            Console.WriteLine("введите время в минутах:");

            try
            {
                BatteryTime = Double.Parse(Console.ReadLine());
            }
            catch
            {
                BatteryTime = 0;
            }
            Console.WriteLine("Какой источник?");
            try
            {
                PowerSource = Console.ReadLine();
            }
            catch
            {
                PowerSource = "аккумулятор";
            }
        }

        public virtual void RandomInit()
        {
            base.RandomInit();
            BatteryTime = rndT.Next(1, 60);
            string[] sources = new string[] { "аккумулятор", "электрический генератор", "гальвонический элемент", "сварочный трансформатор", "тиристорный выпрямиель", "фотоэлемент", "электрофорная машина" };
            int i = rnd.Next(sources.Length);
            PowerSource = sources[i];
        }

        public override void VirtualPrint()
        {
            Console.WriteLine($"ElectricTool: Название: {Name}, материал: {Material}, источник питания: {PowerSource}, время работы от аккумулятора {BatteryTime}мин.");
        }
        public new void Print()
        {
            base.Print();
            Console.WriteLine($", материал: {Material}, источник питания: {PowerSource}, время работы от аккумулятора {BatteryTime}мин.");
        }
    }
}
