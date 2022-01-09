using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Class_21
{
    class Program
    {
        const int n = 2; //  строк
        const int m = 10; //  столбиков
        static int[,] path = new int[n,m] { { 1, 2, 0, 50, 5, 0, 1, 2, 6, 10 }, { 1, 2, 3, 10, 5, 20, 2, 3, 6, 1 } };
        static void Main(string[] args)
        {
            // поток
            ThreadStart threadStart = new ThreadStart(Gardner1);
            Thread thread = new Thread(threadStart);
            thread.Start();

            Gardner2(); // этот метод запускаем в Main 

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write($"{path[i, j]} ");
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }

        //садовники это два метода
        static void Gardner1()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (path[i, j] >= 0) // если 2й садовник не побывал,то 1й садовник  ставит метку -1
                    {
                        int delay = path[i, j]; // садовник должен здесь зависнуть 
                        path[i,j] = -1;
                        Thread.Sleep(delay); // задержка
                    }
                }

            }
        }

        static void Gardner2()
        {
            for (int j = m-1; j > 0; j--)
            {
                for (int i = n-1; i > 0; i--)
                {
                    if (path[i, j] >= 0) // если 1й садовник не побывал,то 2й садовник  ставит метку -2
                    {
                        int delay = path[i, j]; // садовник должен здесь зависнуть 
                        path[i, j] = -2;
                        Thread.Sleep(delay); // задержка
                    }
                }

            }
        }

    }
}
