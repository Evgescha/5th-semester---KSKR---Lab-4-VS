using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{

    class Program

    {

        static void Main(string[] args)      {
            // создаем переменные для работы
            int n; /* количество уравнений */

            

            Console.Write("Введите количество уравнений ");

            n = Convert.ToInt32(Console.ReadLine());
            double[,] A = new double[n, n]; /* матрица системы */
            double[] b = new double[n]; /* вектор правых частей */
            double[] x = new double[n]; /* вектор решения */

            // заносим в массив числа
            for (int i = 0; i < n; i++)

                for (int j = 0; j < n; j++)

                {
                    // выводим какое число заносим
                    Console.Write("A{0}{1} -> ", i, j);

                    A[i, j] = Convert.ToDouble(Console.ReadLine());

                }
            // заносим правую часть 
            for (int i = 0; i < n; i++)

            {

                Console.Write("b{0} -> ", i);

                b[i] = Convert.ToDouble(Console.ReadLine());

            }

            // если метод возвращает 1 (определитель равен 0), система не имеет решения
            if (SLAU_kramer(n, A, b, x) == 1)

            {

                Console.WriteLine("Система не имеет решение");

                Convert.ToInt32(Console.ReadLine());

                return;

            }
            // если есть ршения, выводим их
            else

                for (int i = 0; i < n; i++)

                    Console.WriteLine("x" + i + " = " + x[i]);

            Console.ReadLine();

        }

        private
        // находим определитель, по количеству строк и матрице
        static double det(int n, double[,] B) //метод вычисляющий определитель матрицы

        {

            if (n == 2)

                return B[0, 0] * B[1, 1] - B[0, 1] * B[1, 0];

            return B[0, 0] * (B[1, 1] * B[2, 2] - B[1, 2] * B[2, 1]) - B[0, 1] * (B[1, 0] * B[2, 2] - B[1, 2] * B[2, 0]) +

            B[0, 2] * (B[1, 0] * B[2, 1] - B[1, 1] * B[2, 0]);

        }



        static void equal(int n, double[,] A, double[,] B) //- метод присваивающий матрицы ( A=B), где n-размерность матриц

        {

            for (int i = 0; i < n; i++)

                for (int j = 0; j < n; j++)

                    A[i, j] = B[i, j];

        }

        static void change(int n, int N, double[,] A, double[] b)

        {

            for (int i = 0; i < n; i++)

                A[i, N] = b[i];

        }

        public

        static int SLAU_kramer(int n, double[,] A, double[] b, double[] x) //метод реализующий метод Крамера

        {
            // создаем пустую матрицу
            double[,] An = new double[3, 3];
            // получаем определитель
            double det1 = det(n, A);
            // если определитель = 0, нет решения
            if (det1 == 0) return 1;
            // если определитель не 0, через цикл по количеству неизвестных
            for (int i = 0; i < n; i++)

            {
                // заполняем новую матрицу старыми значениями
                equal(n, An, A);
                // заменяем столбец решением строк
                change(n, i, An, b);
                // находим одно из решений
                x[i] = det(n, An) / det1;

            }

            return 0;

        }

    }

}