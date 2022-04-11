using System;
using System.Collections.Generic;
using System.Linq;

namespace NumericalMethodsLab2Part1
{
    internal class RungeKuttaMethod
    {
        private Func<double, double, double> CurrentFunc { get; set; }   // Заданная фукнция f(x,y(x)) 
        private double Func0 { get; set; }                               // Значение функции в точке A
        public double A { get; private set; }                                   // Левая граница отрезка [a;b]
        public double B { get; }                                   // Правая граница отрезка [a;b]
        private int N0 { get; }                                     // Начальное количество узлов разбиения интервала [a;b]
        private static int P => 3;                                              // Порядок метода Рунге - Кутта
        private double Epsilon0 { get; }                            // Погрешность, заданная пользователем
        private double MinimalH { get; }

        public double[] GridN { get; private set; }                             // Равномерная сетка размера n
        public double HN { get; set; }                                  // Погрешность для сетки размера n
        private double[] Grid2N { get; set; }                            // Равномерная сетка размера 2n
        private double H2N { get; set; }                                 // Погрешность для сетки размера 2n
        public double[] ResultN { get; private set; }                           // Результирующий вектор размера n
        private double[] Result2N { get; set; }                          // Результирующий вектор размера 2n
        public Queue<double[]> ResultLast2Iterations { get; }

        public RungeKuttaMethod(
            double a,
            double b,
            int n0,
            double epsilon0,
            int funcIndex,
            double y0
        )
        {
            MinimalH = FindMinimalH();

            B = b;
            N0 = n0;
            Epsilon0 = epsilon0;
            SetFunction(funcIndex, y0, a);

            GridN = new double[N0];
            ResultN = new double[N0];
            Result2N = new double[2 * N0];
            Grid2N = new double[2 * N0];

            ResultLast2Iterations = new Queue<double[]>();
        }

        private void SetFunction(int index, double y0, double leftCondition)
        {
            switch (index)
            {
                case 0:
                {
                    CurrentFunc = FirstFunction;
                    Func0 = 2.1;
                    A = 1.2;
                } break;
                case 1:
                {
                    CurrentFunc = SecondFunction;
                    Func0 = y0;
                    A = leftCondition;
                } break;
            }
        }

        public int GetResult()
        {
            // Значения текущей погрешности и предыдущей для проверки на уменьшении погрешности при уменьшении шага
            double currentError = 10;
            // Решаемо ли уравнение методом Рунге-Кутта или нет
            // Размерности
            var n = N0;
            var n2 = 2 * N0;

            double tempH = 0;
            double temp2H = 0;

            do
            {
                // Задаём равномерную сетку
                GridN = BuildGrid(n, ref tempH);
                Grid2N = BuildGrid(n2, ref temp2H);

                HN = tempH;
                H2N = temp2H;

                var previousError = currentError;

                ResultN = SolveCauchy(n, GridN, HN);
                Result2N = SolveCauchy(n2, Grid2N, H2N);

                var isSolved = ResultN.Length != 0 || Result2N.Length != 0;
                
                ResultLast2Iterations.Enqueue(ResultN);
                while (ResultLast2Iterations.Count > 3)
                {
                    ResultLast2Iterations.Dequeue();
                }

                currentError = FindError();

                // Удваиваем количество точек на сетке
                n *= 2;
                n2 *= 2;

                // Процесс решения прекращен, т.к. шаг стал меньше возможного
                if (MinimalH > HN) return 2; 
                // Процесс решения прекращен, т.к. с уменьшением шага погрешность не уменьшается
                if (currentError > previousError) return 1;
                // Решение не получено, двухсторонний метод Рунге-Кутта с данным начальным шагом не применим
                if (!isSolved) return 4;

            } while (currentError > Epsilon0);

            // Завершение в соответствии с назначенным условием о достижении заданной точности
            return 0;
        }

        // Метод для построения равномерной сетки с количеством подотрезков n
        private double[] BuildGrid(int n, ref double h)
        {
            return
                Distribution.EvenNodes(A, B, n, ref h);
        }

        // Получение решения задачи Коши методом Рунге-Кутта порядка p
        private double[] SolveCauchy(int n, IReadOnlyList<double> x, double h)
        {
            var y = new double[n];
            y[0] = Func0;

            for (var index = 1; index < n; index++)
            {
                var k1 = K1(x[index - 1], y[index - 1], h);
                var k2 = K2(x[index - 1], y[index - 1], h, k1);
                var k3 = K3(x[index - 1], y[index - 1], h, k2);
                
                y[index] = y[index - 1] + 1.0 / 4.0 * (k1 + 3.0 * k3);
            }

            return y;
        }

        // Функции для условий задачи:
        private static double FirstFunction(double x, double y) => x + y / 8;
        private static double SecondFunction(double x, double y) => Math.Cos(y) / (2 + x) - 0.3 * y * y;

        // K1
        private double K1(double x, double y, double h)
            => h * CurrentFunc(x, y);
        // К2
        private double K2(double x, double y, double h, double k1)
            => h * CurrentFunc(x + 1.0 / 3 * h, y + 1.0 / 3 * k1);
        // K3
        private double K3(double x, double y, double h, double k2)
            => h * CurrentFunc(x + 2.0 / 3 * h, y + 2.0 / 3 * k2);

        // Поиск погрешности
        public double FindError()
        {
            return Math.Abs(ResultN.Last() - Result2N.Last()) / (Math.Pow(2, P) - 1);
        }

        private double FindMinimalH()
        {
            var r = 1.0;

            while (1.0 + r > 1.0)
            {
                r /= 2.0;
            }

            return r * 2.0;
        }
    }

    #region DISTRIBUTION

    public static class Distribution
    {
        public static double[] EvenNodes(double a, double b, int n)
        {

            var XDoubles = new double[n];

            XDoubles[0] = a;
            var h = (b - a) / (n - 1);
            for (var i = 1; i < n; i++)
            {
                XDoubles[i] = XDoubles[i - 1] + h;
            }

            return XDoubles;

        }

        public static double[] EvenNodes(double a, double b, int n, ref double h)
        {

            var XDoubles = new double[n];

            XDoubles[0] = a;
            h = (b - a) / (n - 1);
            for (var i = 1; i < n; i++)
            {
                XDoubles[i] = XDoubles[i - 1] + h;
            }

            return XDoubles;

        }

    }

    #endregion
}
