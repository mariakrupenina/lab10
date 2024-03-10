using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library_for_lab10
{
    public class MeasuringTool : HandTool
    {
        protected string measurementUnits;
        protected double accuracy;
        protected Random rndA = new Random();
        protected Random rndU = new Random();

        public double Accuracy
        {
            get => accuracy;
            set
            {
                if (value < 0)
                    accuracy = 0;
                else
                    accuracy = value;
            }
        }

        public string MeasurementUnits
        {
            get => measurementUnits;
            set
            {
                measurementUnits = value;
            }
        }

        public MeasuringTool() : base() 
        {
            Accuracy = 0;
            MeasurementUnits = "без единиц измерения";
        }

        public MeasuringTool(string name, string material, string measurementUnits, double accuracy, int number) : base(name, material, number)
        {
            Accuracy = accuracy;
            MeasurementUnits = measurementUnits;
        }

       public override bool Equals(object obj)
        {
            MeasuringTool tool = obj as MeasuringTool;
            if (tool != null)
                return this.Name == tool.Name && this.MeasurementUnits == tool.MeasurementUnits && this.Accuracy == tool.Accuracy;
            else
                return false;
        }

        public double GetAccuracy() { return Accuracy; }

        public override string ToString()
        {
            return base.ToString() + $",  точность: {Accuracy}, единицы измерения: {MeasurementUnits}";
        }

        public override void Init()
        {
            base.Init();
            Console.WriteLine("введите точность:");

            try
            {
                Accuracy = Double.Parse(Console.ReadLine());
            }
            catch
            {
                Accuracy = 1;
            }
            Console.WriteLine("Введите единицы измерения");
            try
            {
                 MeasurementUnits = Console.ReadLine();
            }
            catch
            {
                MeasurementUnits = "см";
            }
        }

        public virtual void RandomInit()
        {
            base.RandomInit();
            Accuracy = rndA.Next(1, 100);
            string[] units = new string[] { "см", "мм", "дм", "м", "га", "см^2", "км" };
            int i = rnd.Next(units.Length);
            MeasurementUnits = units[i];
        }

        public override void VirtualPrint()
        {

            Console.WriteLine($"MeasuringTool: Название: {Name}, точность: {Accuracy}, единицы измерения: {MeasurementUnits}");
        }

        public new void Print()
        {
            base.Print();
            Console.WriteLine($", точность: {Accuracy}, единицы измерения: {MeasurementUnits}");
        }
    }
}
