using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library_for_lab10
{
    //Ручной инструмень
    public class HandTool : Tool
    {
        protected string material;
        protected Random rndM = new Random();

        public string Material //материал
        {
            get => material;
            set
            {
                material = value;
            }

        }

        public HandTool() : base()
        {
            Material = "материал не определён";
        }

        public HandTool(string name, string material, int number) : base(name, number)
        {
            Material = material;
        }

        public string GetMaterial() { return Material; }

        public override bool Equals(object obj)
        {
            HandTool tool = obj as HandTool;
            if (tool != null)
                return this.Name == tool.Name && this.Material == tool.Material;
            else
                return false;
        }

        public override string ToString()
        {
            return base.ToString() + $", материал: {Material}";
        }

        public override void Init()
        {
            base.Init();
            Console.WriteLine("какой материал?:");
            Material = Console.ReadLine();
        }

        public virtual void RandomInit()
        {
            string[] materials = new string[] { "дерево", "железо", "быстрорежущая сталь", "легированная инструментальная сталь", "металлокерамика", "минералокерамика", "твёрдый сплав" };
            base.RandomInit();
            int i = rnd.Next(materials.Length);
            Material = materials[i];
        }

        public override void VirtualPrint()
        {
            Console.WriteLine($"HandTool: Название: {Name}, материал: {Material}");
        }

        public new void Print()
        {
            base.Print();
            Console.WriteLine($", материал: {Material}");
        }
    }
}
