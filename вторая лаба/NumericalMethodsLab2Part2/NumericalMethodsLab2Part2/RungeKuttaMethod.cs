using System;
using System.Collections.Generic;
using System.Linq;

namespace NumericalMethodsLab2Part2
{
    internal class RungeKuttaMethod
    {
        // Значения которые задаются программно
        public double A { get; }                              // Левая граница отрезка [a;b]
        public double B { get; }                              // Правая граница отрезка [a;b]
        private int N0 { get; }                               // Начальное количество узлов разбиения интервала [a;b]
        private static int P => 4;                            // Порядок метода Рунге - Кутта
        private double Epsilon0 { get; }                      // Погрешность, заданная пользователем
        private double Y0 { get; }                            // Начальное условие 1
        private double Z0 { get; }                            // Начальное условие 2
        private double MinH { get; }                          // Минимальный шаг

        // Значения которые метод генерирует
        public double[] GridN { get; private set; }           // Равномерная сетка размера n 
        private double Hn { get; set; }                       // Погрешность для сетки размера n
        private double[] Grid2N { get; set; }                 // Равномерная сетка размера 2n
        private double H2N { get; set; }                      // Погрешность для сетки размера 2n
        public double[] Yn { get; private set; }              // Результирующий вектор y размера n
        private double[] Y2N { get; set; }                    // Результирующий вектор y размера 2n
        public double YError { get; private set; }                   // Погрешность для вектора Y
        public double[] Zn { get; private set; }              // Результирующий вектор z размера n
        private double[] Z2N { get; set; }                    // Результирующий вектор z размера 2n
        public double ZError { get; private set; }                   // Погрешность для вектора Z
        public Queue<double[]> Last2IterationsY { get; } // Очередь из ответов на задачу (для вывода двух последних)
        public Queue<double[]> Last2IterationsZ { get; } // Очередь из ответов на задачу (для вывода двух последних)

        public RungeKuttaMethod(
            double b,
            int n0,
            double epsilon0
        )
        {
            double FindMinimalH()
            {
                var r = 1.0;

                while (1.0 + r > 1.0)
                {
                    r /= 2.0;
                }

                return r * 2.0;
            }

            MinH = FindMinimalH();

            A = 0;
            B = b;
            N0 = n0;
            Epsilon0 = epsilon0;
            Y0 = 1;
            Z0 = 1;

            GridN = new double[N0];
            Yn = new double[N0];
            Y2N = new double[2 * N0];
            Grid2N = new double[2 * N0];

            Last2IterationsY = new Queue<double[]>();
            Last2IterationsZ = new Queue<double[]>();
        }

        public int GetResult()
        {
            // Значения текущей погрешности и предыдущей для проверки на уменьшении погрешности при уменьшении шага
            double currentErrorY = 10;
            double currentErrorZ = 10;
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

                Hn = tempH;
                H2N = temp2H;

                var previousErrorY = currentErrorY;
                var previousErrorZ = currentErrorZ;

                double[] yn = null;
                double[] zn = null;
                double[] y2N = null;
                double[] z2N = null;

                SolveCauchy(n, GridN, Hn, ref yn, ref zn);
                SolveCauchy(n, Grid2N, H2N, ref y2N, ref z2N);

                Yn = yn;
                Zn = zn;
                Y2N = y2N;
                Z2N = z2N;

                var isSolved = 
                       Yn.Length != 0 
                    || Y2N.Length != 0 
                    || Zn.Length != 0 
                    || Z2N.Length != 0;

                Last2IterationsY.Enqueue(Yn);
                while (Last2IterationsY.Count > 3)
                {
                    Last2IterationsY.Dequeue();
                }
                Last2IterationsZ.Enqueue(Zn);
                while (Last2IterationsZ.Count > 3)
                {
                    Last2IterationsZ.Dequeue();
                }

                YError = currentErrorY = FindError(Yn, Y2N);
                ZError = currentErrorZ = FindError(Zn, Z2N);

                // Удваиваем количество точек на сетке
                n *= 2;
                n2 *= 2;
                // Процесс решения прекращен, т.к. шаг стал меньше возможного
                if (MinH > Hn) return 2;
                // Процесс решения прекращен, т.к. с уменьшением шага погрешность не уменьшается
                if (!(currentErrorY < previousErrorY) && !(currentErrorZ < previousErrorZ)) return 1;
                // Решение не получено, двухсторонний метод Рунге-Кутта с данным начальным шагом не применим
                if (!isSolved) return 4;

            } while (!(currentErrorY < Epsilon0) && !(currentErrorZ < Epsilon0));

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
        private void SolveCauchy(
            int n,
            IReadOnlyList<double> x,
            double h,
            ref double[] y,
            ref double[] z
            )
        {

            y = new double[n];
            y[0] = Y0;
            z = new double[n];
            z[0] = Z0;

            for (var i = 1; i < n; i++)
            {
                var k11 = K11(z[i - 1], h);
                var k12 = K12(x[i - 1], y[i - 1], z[i - 1], h);
                var k21 = K21(x[i - 1], y[i - 1], z[i - 1], h);
                var k22 = K22(x[i - 1], y[i - 1], z[i - 1], h);
                var k31 = K31(x[i - 1], y[i - 1], z[i - 1], h);
                var k32 = K32(x[i - 1], y[i - 1], z[i - 1], h);
                var k41 = K41(x[i - 1], y[i - 1], z[i - 1], h);
                var k42 = K42(x[i - 1], y[i - 1], z[i - 1], h);

                y[i] = y[i - 1] + 1.0 / 8 * (k11 + 3 * k21 + 3 * k31 + k41);
                z[i] = z[i - 1] + 1.0 / 8 * (k12 + 3 * k22 + 3 * k32 + k42);
            }
        }

        //Формулы для K коэффициентов:
        //K11
        private static double K11(double z, 
            double h
            )
            => h * Func1(z);
        //K12
        private static double K12(
            double x,
            double y,
            double z,
            double h
            )
            => h * Func2(x, y, z);
        //K21
        private static double K21(
            double x, 
            double y, 
            double z, 
            double h
            )
            => h * Func1(z * K12(x, y, z, h)
                );
        //K22
        private static double K22(
            double x,
            double y,
            double z, 
            double h
            )
            => h * Func2(
                x + 1.0 / 3 * h, 
                y + 1.0 / 3 * K11(z, h), 
                z * K12(x, y, z, h)
                );
        //K31
        private static double K31(
            double x,
            double y, 
            double z, 
            double h
            )
            => h * Func1(z - 1.0 / 3 * K11(z, h) + K12(x, y, z, h)
                );
        //K32
        private static double K32(
            double x, 
            double y,
            double z, 
            double h
            )
            => h * Func2(
                x + 1.0 / 3 * h,
                y - 1.0 / 3 * K11(z, h) + K21(x, y, z, h),
                z - 1.0 / 3 * K12(x, y, z, h) + K22(x, y, z, h)
            );
        //K41
        private static double K41(
            double x, 
            double y, 
            double z, 
            double h
            )
            => h * Func1(z + K12(x, y, z, h) - K22(x, y, z, h) + K32(x, y, z, h)
                );
        //K42
        private static double K42(
            double x,
            double y,
            double z, 
            double h
            )
            => h * Func2(
                x + h,
                y + K11(z, h) - K21(x, y, z, h) + K31(x, y, z, h),
                z + K12(x, y, z, h) - K22(x, y, z, h) + K32(x, y, z, h)
            );

        // Заданная фукнция f_1( x, y_1(x), y_2(x))
        private static double Func1(double z)
            => z;

        // Заданная фукнция f_2( x, y_1(x), y_2(x))
        private static double Func2(double x, double y, double z)
            => Math.Pow(z, 2) / y - x * z / (Math.Pow(x, 2) + 1);

        // Поиск погрешности
        private static double FindError(IEnumerable<double> n, IEnumerable<double> n2)
        {
            return Math.Abs(n.Last() - n2.Last()) / (Math.Pow(2, P) - 1);
        }
    }

    #region DISTRIBUTION

    public static class Distribution
    {
        public static double[] EvenNodes(double a, double b, int n)
        {

            var xDoubles = new double[n];

            xDoubles[0] = a;
            var h = (b - a) / (n - 1);
            for (var i = 1; i < n; i++)
            {
                xDoubles[i] = xDoubles[i - 1] + h;
            }

            return xDoubles;

        }

        public static double[] EvenNodes(double a, double b, int n, ref double h)
        {

            var xDoubles = new double[n];

            xDoubles[0] = a;
            h = (b - a) / (n - 1);
            for (var i = 1; i < n; i++)
            {
                xDoubles[i] = xDoubles[i - 1] + h;
            }

            return xDoubles;

        }

    }

    #endregion
}
