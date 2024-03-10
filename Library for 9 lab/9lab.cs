using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using library_for_lab10;

namespace Library_for_9_lab
{
    public class ChessboardCell : IInit
    {
        private int horizontal; //закрытые атрибуты
        private int vertical;

        protected Random rnd9 = new Random();

        public static int count = 0;

        //свойства атрибутов
        public int Horizontal
        {
            get => horizontal;
            set
            {
                try
                {
                    if (value < 1 || value > 8)
                        throw new ArgumentException("Координата клетки по горизонтали должна быть от 1 до 8");
                    else
                        horizontal = value;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    horizontal = 1;
                }
            }
        }
        public int Vertical
        {
            get => vertical;
            set
            {
                try
                {
                    if (value < 1 || value > 8)
                        throw new ArgumentException("Координата клетки по вертикали должна быть от 1 до 8");
                    else
                        vertical = value;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    vertical = 1;
                }
            }
        }

        public ChessboardCell() //конструктор без параметра
        {
            this.horizontal = 1;
            this.vertical = 1;
            count++;
        }
        public ChessboardCell(int horizontal, int vertical) //конструктор с параметром
        {
            try
            {
                if (horizontal < 1 || horizontal > 8 || vertical < 1 || vertical > 8)
                    throw new ArgumentException("Координаты клетки должнs быть от 1 до 8");
                else
                {
                    this.horizontal = horizontal;
                    this.vertical = vertical;
                }
                count++;
            }

            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                this.horizontal = 1;
                this.vertical = 1;
                count++;
            }
        }
        public ChessboardCell(ChessboardCell cell) //конструктор копирования
        {
            this.horizontal = cell.Horizontal; //в новую контекстную координату горизонтали присваивается через гет значение другой клетки(ту, у которой копируем)
            this.vertical = cell.Vertical;
            count++;
        }

        public static int Count => count;  //=get{ return count; }


        public override bool Equals(object obj)
        {
            ChessboardCell cell = obj as ChessboardCell;
            if (cell != null)
                return this.Horizontal == cell.Horizontal && this.Vertical == cell.Vertical;
            else
                return false;
        }

        public override string ToString()
        {
            return $"Горизонтальная координата: {Horizontal}, Вертикальная координата: {Vertical}";
        }

        public virtual void Init()
        {
            Console.WriteLine("Введите горизонтальную координату:");
            try
            {
                Horizontal = int.Parse(Console.ReadLine());
            }
            catch
            {
                Horizontal = 0;
            }

            Console.WriteLine("Введите вертикальную координату:");

            try
            {
                Vertical = int.Parse(Console.ReadLine());
            }
            catch
            {
                Vertical = 0;
            }
        }

        public virtual void RandomInit()
        {
            Horizontal = rnd9.Next(1, 8);
            Vertical = rnd9.Next(1, 8);
        }
    }
}
