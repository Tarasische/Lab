using System;

namespace ConsoleApplication2
{
    class Point
        {
            protected int Xpos;
            protected int Ypos;

            public Point(int xpos, int ypos)
            {
                Xpos = xpos;
                Ypos = ypos;
            }

            public virtual void Draw()
            {
                Console.WriteLine("Poin in: ({0},{1})", Xpos, Ypos);
            }
        }
        class ColorPoint : Point
        {
            string clr;

            public ColorPoint(int xpos, int ypos, string clr) : base(xpos, ypos)
            {
                this.clr = clr;
            }

            public override void Draw()
            {
                Console.WriteLine("Point in: ({0},{1}) color: {2}", Xpos, Ypos, clr);
            }
        }
        class Line : Point
        {
            protected int Xo;
            protected int Yo;

            public Line(int xpos, int ypos, int xo, int yo) : base(xpos, ypos)
            {
                Xo = xo;
                Yo = yo;
            }

            public override void Draw()
            {
                Console.WriteLine("Line in: Начальная точка : ({0},{1}); конечная точка :({2},{3}); длина : ({4}) ", Xpos, Ypos, Xo, Yo, Math.Sqrt(Math.Abs(Math.Pow(Xpos, 2) - Math.Pow(Xo, 2) + Math.Pow(Ypos, 2) - Math.Pow(Yo, 2))));
            } 
        }
        class ColoredLine : Line
        {
            string clr;
    
            public ColoredLine(int x, int y, int a, int u, string color)
                : base(x, y, a, u)
            {
                Xo = a;
                Yo = u;
                clr = color;
            }
            public override void Draw()
            {
                Console.WriteLine("Line in: Начальная точка : ({0},{1}); конечная точка : ({2},{3}); цвет: {4}; длина : ({5}) ", Xpos, Ypos, Xo, Yo, clr, Math.Sqrt(Math.Abs(Math.Pow(Xpos, 2) - Math.Pow(Xo, 2) + Math.Pow(Ypos, 2) - Math.Pow(Yo, 2))));
            }
        }
        class Program
        {
            static void Main(string[] args)
            {
               
            }
        }
    
        class MyInvalidCastException : InvalidCastException
        {
    
            public MyInvalidCastException()
    
                : base() { }
    
    
    
            public MyInvalidCastException(string message)
    
                : base(message) { }
    
    
    
            public MyInvalidCastException(string format, params object[] args)
    
                : base(string.Format(format, args)) { }
    
    
    
            public MyInvalidCastException(string message, Exception innerException)
    
                : base(message, innerException) { }
    
    
    
            public MyInvalidCastException(string format, Exception innerException, params object[] args)
    
                : base(string.Format(format, args), innerException) { }
        }
    
        public class Picture<T>
    
            where T : class, IComparable<T>
    
        {
            private static void Show_Message(string message)
            {
                Console.WriteLine(message);
            }
    
            public delegate void AddedNewValue(string message);
    
            public event AddedNewValue Added;
    
            private T[] array;
    
            public Picture(int size)
            {
                Added += Show_Message;
                array = new T[size];
            }
    
            public int Length
            {
                get { return array.Length; }
            }
    
            public void OrderBy(bool desc = false)
            {
                if (desc == true)
                    Sort((x, y) => x.CompareTo(y) < 0);
    
                else
                    Sort((x, y) => x.CompareTo(y) > 0);
    
            }
    
            protected void Sort(Func<T, T, bool> func)
            {
                if (Length == 0)
    
                    throw new IndexOutOfRangeException();
    
                for (var i = 0; i < Length - 1; i++)
    
                    for (var j = i + 1; j < Length; j++)
    
                        if (func(array[i], array[j]))
                        {
                            var temp = array[i];
                            array[i] = array[j];
                            array[j] = temp;
                        }
    
            }
            
            public T this[int index]
            {
                get
                {
                    if (index >= Length)   throw new IndexOutOfRangeException();
    
                    return array[index];
                }
    
                set
                {
                    if (Added != null)
                    {
                        if (index >= Length)
    
                            throw new IndexOutOfRangeException();
    
                        Added($"Added value {value} with index {index}");
    
                    }
    
                    array[index] = value;
                }
    
            }
    
            public override string ToString()
            {
                string res = "";
    
                for (var i = 0; i < Length; i++)
    
                    res = string.Concat(res, string.Concat(array[i] + "\n"));
    
                return res;
    
            }
    }
}