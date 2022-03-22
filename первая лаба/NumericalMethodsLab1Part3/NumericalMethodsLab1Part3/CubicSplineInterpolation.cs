using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumericalMethodsLab1Part3
{
    public class CubicSplineInterpolation
    {
        private bool IsUniform { get; set; }

        public int N { get; set; }

        private Func<double, double> Function { get; set; }

        public double[] XDoubles { get; set; }
        public double[] YDoubles { get; set; }
        public double[] HDoubles { get; private set; }
        public double[] SDoubles { get; private set; }
        private double A1 { get; set; }             //S'''(x_0) = A1
        private double B1 { get; set; }             //S''(x_n) = B1

        //Коэфициенты кубических сплайнов
        private double[] ADoubles { get; set; }      // a(i)
        private double[] BDoubles { get; set; }      // b(i)
        private double[] CDoubles { get; set; }      // c(i)
        private double[] DDoubles { get; set; }      // d(i)

        private int Cnt { get; set; }                // Количество узлов для построения графика
        private double[] CondensedDoubles { get; set; }   // Узлы для построения графиков
        public double[] ErrorDoubles { get; private set; }  // Погрешности

        public CubicSplineInterpolation(
            double a,
            double b, 
            int n, 
            Func<double, double> func,
            int compact,
            double a1,
            double b1,
            bool uniform = true)
        {
            Function = func;
            N = n;
            A1 = a1;
            B1 = b1;
            Cnt = compact;

            XDoubles = new double[N + 1];

            if (!uniform)
            {
                EvenNodes(a, b, N + 1);
                IsUniform = true;
            }
            else
            {
                ChebushevNodes(a, b, N + 1);
                IsUniform = false;
            }

            CompactNodes(Cnt);
            N = XDoubles.Length;
            YDoubles = new double[N];
            HDoubles = new double[N];
            ADoubles = new double[N];
            BDoubles = new double[N];
            CDoubles = new double[N];
            DDoubles = new double[N];

            CalculateYDoubles();
            BuildSpline();
            CalculateSDoubles();
            GetErrors();
        }

        private void EvenNodes(double a, double b, int n)
        {
            XDoubles[0] = a;
            var h = (b - a) / (n - 1);
            for (var i = 1; i < n; i++)
            {
                XDoubles[i] = XDoubles[i - 1] + h;
            }
            for (var i = 0; i < n - 1; i++)
            {
                HDoubles[i] = h;
            }
        }

        private void ChebushevNodes(double a, double b, double n)
        {
            double
                t1 = (a + b) / 2,
                t2 = (b - a) / 2,
                t3 = 1 / (2 * Convert.ToDouble(n)) * Math.PI;
            for (var i = 0; i < n; i++)
            {
                XDoubles[i] = t1 - t2 * Math.Cos((2 * i + 1) * t3);
            }
            for (var i = 0; i < n; i++)
            {
                HDoubles[i] = XDoubles[i + 1] - XDoubles[i];
            }
        }

        //Метод построения сплайна
        private void BuildSpline()
        {
            var a = new double[N];
            var b = new double[N + 1];
            var c = new double[N];
            var d = new double[N + 1];
            var m = new double[N + 1];
            for (var i = 0; i < N; i++)
                a[i] = c[i] = HDoubles[i];
            b[0] = 2 * HDoubles[0];
            b[N] = 2 * HDoubles[N - 1];
            for (var i = 1; i < N; i++)
                b[i] = 2 * (HDoubles[i - 1] + HDoubles[i]);
            d[0] = 6 * ((YDoubles[1] - YDoubles[0]) / HDoubles[0] - A1);
            d[N] = 6 * (B1 - (YDoubles[N] - YDoubles[N - 1]) / HDoubles[N - 1]);
            for (var i = 1; i < N; i++)
                d[i] = 6 * ((YDoubles[i + 1] - YDoubles[i]) / HDoubles[i] - (YDoubles[i] - YDoubles[i - 1]) / HDoubles[i - 1]);

            LinearSystem.ThomasAlgorithm(a, b, c, ref m, d, N + 1);
            for (var i = 0; i < N; i++)
            {
                ADoubles[i] = YDoubles[i];
                CDoubles[i] = m[i] / 2;
                BDoubles[i] = (YDoubles[i + 1] - YDoubles[i]) / HDoubles[i] - HDoubles[i] * CDoubles[i] - HDoubles[i] * (m[i + 1] - m[i]) / 6;
                DDoubles[i] = (m[i + 1] - m[i]) / (6 * HDoubles[i]);
            }
        }

        private double S(double x)
        {
            int FindIndex()
            {
                int l = 0, r = N - 1;
                var m = 0;

                while (r - l > 1)
                {
                    m = (r + l) / 2;
                    if (x == XDoubles[m])
                        return m;
                    if (x < XDoubles[m])
                        r = m;
                    else
                        l = m;
                }

                return m;
            }

            var j = FindIndex();

            var temp = x - XDoubles[j];
            var result = ADoubles[j] + BDoubles[j] * temp + CDoubles[j] * temp * temp + DDoubles[j] * temp * temp * temp;
            return result;
        }

        //Получение уплотненных X для построения графиков
        private void CompactNodes(int compact)
        {
            Cnt = compact * N + 1;
            CondensedDoubles = new double[Cnt];
            var k = 0;
            CondensedDoubles[k] = XDoubles[0];
            for (var i = 1; i <= N; i++)
            {
                var h = (XDoubles[i] - XDoubles[i - 1]) / compact;
                for (var j = 0; j < compact; j++)
                {
                    k++;
                    CondensedDoubles[k] = CondensedDoubles[k - 1] + h;
                }
            }
        }

        private void CalculateSDoubles()
        {
            for (var i = 0; i < CondensedDoubles.Length; i++)
            {
                SDoubles[i] = S(CondensedDoubles[i]);
            }
        }

        private void CalculateYDoubles()
        {
            for (var i = 0; i <= N; i++)
                YDoubles[i] = Function(XDoubles[i]);
        }

        private void GetErrors()
        {
            ErrorDoubles = new double[Cnt];
            for (var i = 0; i < Cnt; i++)
            {
                ErrorDoubles[i] = Math.Abs(Function(CondensedDoubles[i]) - S(CondensedDoubles[i]));
            }
        }

        public double GetError() => ErrorDoubles.Max();

    }

    public static class LinearSystem
    {
        //  метод прогонки/Томаса
        public static void ThomasAlgorithm(
            double[] a,
            double[] b,
            double[] c,
            ref double[] x,
            double[] d,
            int n
            )
        {
            var alpha = new double[n];
            var beta = new double[n];
            var y00 = 1 / b[0];
            alpha[0] = -c[0] * y00;
            beta[0] = d[0] * y00;
            for (var i = 1; i <= n - 2; i++)
            {
                y00 = 1 / (b[i] + a[i - 1] * alpha[i - 1]);
                alpha[i] = -c[i] * y00;
                beta[i] = (d[i] - a[i - 1] * beta[i - 1]) * y00;
            }
            y00 = 1 / (b[n - 1] + a[n - 2] * alpha[n - 2]);
            beta[n - 1] = (d[n - 1] - a[n - 2] * beta[n - 2]) * y00;

            x[n - 1] = beta[n - 1];
            for (var i = n - 2; i >= 0; i--)
            {
                x[i] = alpha[i] * x[i + 1] + beta[i];
            }

        }
    }

}
