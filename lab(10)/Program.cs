using System;
using System.Threading;
using library_for_lab10;
using Library_for_9_lab;


namespace lab_10_
{
    internal class Program
    {
        static void PrintArray2(IInit[] array2)
        {
            foreach (var item in array2)
            {
                Console.WriteLine(item);
            }
        }

        static void Main(string[] args)
        {
            int countTools = 0;
            int countHandTools = 0;
            int countElectricTools = 0;
            int countMeasuringTools = 0;
            int countCells = 0;
            Random rndArr2 = new Random();


            Console.WriteLine("                              ЧАСТЬ 1");
            //Формирование массива
            Tool[] array = new Tool[20];

            for (int i = 0; i < 10; i++)
            {
                HandTool h = new HandTool();
                h.RandomInit();
                array[i] = h;

            }
            for (int i = 10; i < 15; i++)
            {
                ElectricTool e = new ElectricTool();
                e.RandomInit();
                array[i] = e;

            }
            for (int i = 15; i < 20; i++)
            {
                MeasuringTool m = new MeasuringTool();
                m.RandomInit();
                array[i] = m;

            }
            foreach (Tool item in array)
            {
                item.VirtualPrint();
            }


            Console.WriteLine("Не виртуальный:");
            foreach (Tool item in array)
            {
                item.Print();
            }

            //ЧАСТЬ 2
            Console.WriteLine("                              ЧАСТЬ 2");
            Console.Write("Средняя точность измерительных инструментов:");
            double sum = 0;
            double count = 0;
            double ArangeSum;
            foreach (Tool item in array)
            {
                if (item is MeasuringTool t)
                {
                    sum += t.GetAccuracy();
                    count++;
                }
            }
            ArangeSum = sum/ count;
            Console.WriteLine($"{ArangeSum}");

            Console.WriteLine("Названия деревянных измерительных инструментов, точность которых выше заданной:");
            foreach (Tool item in array)
            {
                if (item is MeasuringTool s)
                    if (s.Material == "дерево" && s.Accuracy > 0)
                        Console.WriteLine(item.Name);
            }

            Console.Write("Максимальное время работы аккумуляторного электрического инструмента:");
            double maxValue = 0;
            foreach (Tool item in array)
            {
                if (item is ElectricTool s)
                    if (s.PowerSource == "аккумулятор" && s.BatteryTime >= maxValue)
                        maxValue = s.BatteryTime;
            }
            if (maxValue != 0)
                Console.WriteLine($"{maxValue}мин.");
            Console.WriteLine("не определена, так как инструментов с такими условиями нет");



            //ЧАСТЬ 3
            Console.WriteLine("                              ЧАСТЬ 3");
            Console.WriteLine("Массив из классов разных иерархий");
            IInit[] array2 = new IInit[30];
            for (int i = 0; i < array2.Length; i++)
            {
                int randomIndex = rndArr2.Next(5);
                if (randomIndex == 0)
                {
                    array2[i] = new Tool();
                    array2[i].RandomInit();
                    countTools++;
                }
                else if (randomIndex == 1)
                {
                    array2[i] = new HandTool();
                    array2[i].RandomInit();
                    countHandTools++;
                }
                else if (randomIndex == 2)
                {
                    array2[i] = new ElectricTool();
                    array2[i].RandomInit();
                    countElectricTools++;
                }
                else if (randomIndex == 3)
                {
                    array2[i] = new MeasuringTool();
                    array2[i].RandomInit();
                    countMeasuringTools++;
                }
                else if (randomIndex == 4)
                {
                    array2[i] = new ChessboardCell();
                    array2[i].RandomInit();
                    countCells++;
                }
            }

            foreach (var item in array2)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine($"Количество инстументов:{countTools}");
            Console.WriteLine($"Количество ручных инстурментов:{countHandTools}");
            Console.WriteLine($"Количество электрических инструментов:{countElectricTools}");
            Console.WriteLine($"Количество измерительных инструментов:{countMeasuringTools}");
            Console.WriteLine($"Количество клеток на шахматной доске:{countCells} \n");


            Console.WriteLine("Сортировка1 'по имени':");
            Array.Sort(array);
            foreach (Tool item in array)
            { Console.WriteLine(item); }

            Console.WriteLine("Бинарный поиск:");
            Tool SearchTool = new Tool();
            SearchTool.Init();
            array[0] = SearchTool; //специальное помещение объекта в массив, чтобы потом осуществить его поиск
            Array.Sort(array); //по имени

            foreach (Tool item in array)
            { Console.WriteLine(item); }

            int position = Array.BinarySearch(array, SearchTool);

            if (position < 0)
                Console.WriteLine("НЕ НАЙДЕН");
            else
                Console.WriteLine($"элемент {SearchTool} на {position + 1} месте");


            Console.WriteLine("Сорировка2 'по номеру':");
            Array.Sort(array, new IdNumber());
            foreach (Tool item in array) { Console.WriteLine(item); }


            Tool a = new Tool();
            a.RandomInit();
            Console.WriteLine(a);
            Tool copy = (Tool)a.ShallowCopy(); //поверхностное копирование
            Console.WriteLine(copy);
            Tool clon = (Tool)a.Clone();
            Console.WriteLine(clon);

            Console.WriteLine("После изменений:");
            copy.Name = "COPY" + "" + a.Name;
            copy.id.id = 100;
            clon.Name = "CLON" + "" + a.Name;
            clon.id.id = 200;
            Console.WriteLine(a);
            Console.WriteLine(copy);
            Console.WriteLine(clon);
        }
    }
}

