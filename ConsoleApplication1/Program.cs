using System;

namespace ConsoleApplication1
{
    internal class Program
    {
        static void find(int[,] c, int M, int[] curstr, int[] maxstr)
        {
            int l;
            l = curstr[curstr[0]-1]; //{l = последний элемент цепочки}
            for (int j = 1; j < M; j++) //{просмотр строки l}
                if (c[l, j] == 1)
                {
                    curstr[0] = curstr[0] + 1;
                    Array.Resize<int>(ref curstr, curstr[0]);
                    curstr[curstr[0]-1] = j; //{j -> в цепочку}
                    c[l, j] = -1; //{пара использована}
                    find(c, M, curstr, maxstr);
                    c[l, j] = 1; //{пару снова разрешено использовать}
                    curstr[0] = curstr[0] - 1;
                }
            if (curstr[0] > maxstr[0]) //{если нашли более}
            {
                Array.Resize<int>(ref maxstr, curstr.Length);
                maxstr = curstr; //{длинную строку}
            }
        }
 
        static void Main(string[] args)
        {
            int n;
            Console.WriteLine("Vvedite razmernost' N = ");
            n = Convert.ToInt32(Console.ReadLine());
            int[,] matrix = new int[n, n];
            int[,] matrix1 = new int[n, n];
            Random rnd = new Random();
 
            for (int b = 0; b < n; b++)
            {
                for (int v = 0; v < n; v++)
                {
                    matrix[b, v] = rnd.Next(2);
                    matrix1[b, v] = matrix[b, v];
                    Console.Write(matrix[b, v] + "\t");
                }
                Console.WriteLine("\n");
            }
 
            int col = 0;
 
            for (int b = 0; b < n; b++)
            {
                for (int v = 0; v < n; v++)
                {
                    if (matrix1[b, v] == 1)
                    {
                        col++;
                        if (matrix1[v, b] == 1) matrix1[v, b] = 0;
                    }
                }
            }
 
            Console.WriteLine(col);
 
            int M = n;
            int[,] c = new int[n, n];
            c = matrix;
            int[] curstr = new int[n+1];
            int[] maxstr = new int[n+1];
 
            for (int b = 0; b < n; b++)
            {
                maxstr[b] = 0;
            }
 
            int N, E; //{N - число элементов в A}
            N = n;
            E = col;
 
 
            for (int i = 0; i < n; i++)
            {
                curstr[0] = 1; //{поиск цепочки}
                curstr[1] = i; //{начинающейся элементом i}
                find(c, n, curstr, maxstr);
            }
 
            for (int i = 0; i < maxstr[0]; i++)
            {
                Console.Write(maxstr[i]); //{печать максимальной строки}
            }
 
        }
    }
}