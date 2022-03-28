using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using BasicInterpolation;
using MathNet.Numerics.Interpolation;
using NumericalMethodsLab1Part3;

namespace NumericalMethodsLab1Part3
{
    public class NumericalMethodsSolver
    {
        private bool IsUniform { get; set; }

        public int N { get; set; }

        public double[] XDoubles { get; set; }
        public double[] YDoubles { get; set; }
        private double[] HDoubles { get; set; }
        public double[] SDoubles { get; set; }
        public double LeftCondition { get; set; }       //SplineFunction'''(x_0) = LeftCondition
        public double RightCondition { get; set; }      //SplineFunction''(x_n) = RightCondition

        //Коэфициенты кубических сплайнов
        private double[] ADoubles { get; set; }      // a(i)
        private double[] BDoubles { get; set; }      // b(i)
        private double[] CDoubles { get; set; }      // c(i)
        private double[] DDoubles { get; set; }      // d(i)

        private double[] CondensedDoubles { get; set; }     // Узлы для построения графиков
        public double[] ErrorDoubles { get; set; }  // Погрешности
        
        //public Func<double ,double> Spline { get; private set; }
        private Func<double, double> Function { get; set; }

        public NumericalMethodsSolver(
            double a,
            double b, 
            int n, 
            Func<double, double> func,
            double leftCondition,
            double rightCondition,
            bool uniform = true)
        {
            Function = func;
            N = n;
            LeftCondition = leftCondition;
            RightCondition = rightCondition;

            XDoubles = new double[N + 1];
            YDoubles = new double[N + 1];
            SDoubles = new double[N + 1];
            ErrorDoubles = new double[N];
            HDoubles = new double[N];
            ADoubles = new double[N];
            BDoubles = new double[N];
            CDoubles = new double[N];
            DDoubles = new double[N];

            if (uniform)
            {
                XDoubles = Distribution.EvenNodes(a, b, N + 1);
                IsUniform = true;
            }
            else
            {
                XDoubles = Distribution.ChebushevNodes(a, b, N + 1);
                IsUniform = false;
            }

            for (var i = 0; i < N; i++)
            {
                HDoubles[i] = XDoubles[i + 1] - XDoubles[i];
            }

            CalculateYDoubles();
            BuildSpline();
            CalculateErrors();
        }

        //Метод построения сплайна
        public void BuildSpline()
        {
            CalculateSpline();

            for (var i = 0; i < N; i++)
            {
                SDoubles[i] = Spline(XDoubles[i]);
            }

            CalculateErrors();
        }

        public double Spline(double x)
        {
            int BinarySearch()
            {
                int l = 0, r = N - 1;
                int m = 0;
                while (r - l > 1)
                {
                    m = (l + r) / 2;
                    if (x == XDoubles[m])
                        return m;
                    if (x < XDoubles[m])
                        r = m;
                    else
                        l = m;
                }
                return m;
            }

            var j = BinarySearch();
            var t = x - XDoubles[j];
            var res = ADoubles[j] + BDoubles[j] * t + CDoubles[j] * t * t + DDoubles[j] * t * t * t;
            return res;

        }

        //Добавить в отчёт
        private void CalculateSpline()
        {
            // Нижняя диагональ
            var bottomDiagonal = new double[N];
            // Главная диагональ
            var mainDiagonal = new double[N + 1];
            // Верхняя диагональ
            var topDiagonal = new double[N];
            // Правая часть
            var rightPart = new double[N + 1];
            // Результирующий вектор
            var resultVector = new double[N + 1];
            for (var i = 0; i < N; i++)
                bottomDiagonal[i] = topDiagonal[i] = HDoubles[i];
            bottomDiagonal[0] = -1;
            mainDiagonal[0] = 1;
            mainDiagonal[N] = 2 * HDoubles[N - 1];
            for (var i = 1; i < N; i++)
                mainDiagonal[i] = 2 * (HDoubles[i - 1] + HDoubles[i]);
            //левое условие
            rightPart[0] = 3 * HDoubles[0] * LeftCondition;
            //правое условие
            rightPart[N] = 6 * (RightCondition - (YDoubles[N] - YDoubles[N - 1]) / HDoubles[N - 1]);
            for (var i = 1; i < N; i++)
            {
                rightPart[i] =
                    6 * ((YDoubles[i + 1] - YDoubles[i]) / HDoubles[i] -
                         (YDoubles[i] - YDoubles[i - 1]) / HDoubles[i - 1]);
            }

            LinearSystem.ThomasAlgorithm(
                bottomDiagonal,
                mainDiagonal,
                topDiagonal,
                ref resultVector,
                rightPart,
                N + 1
                );
            for (var i = 0; i < N; i++)
            {
                ADoubles[i] = YDoubles[i];
                CDoubles[i] = resultVector[i] / 2;
                BDoubles[i] = 
                    (YDoubles[i + 1] - YDoubles[i]) / HDoubles[i]
                    - HDoubles[i] * CDoubles[i]
                    - HDoubles[i] * (resultVector[i + 1] - resultVector[i]) / 6;
                DDoubles[i] = (resultVector[i + 1] - resultVector[i]) / (6 * HDoubles[i]);
            }
        }
        
        private void CalculateYDoubles()
        {
            for (var i = 0; i <= N; i++)
                YDoubles[i] = Function(XDoubles[i]);
        }

        public void CalculateErrors()
        {
            for (var index = 0; index < N; index++)
            {
                ErrorDoubles[index] = Math.Abs(YDoubles[index] - SDoubles[index]);
            }
        }

        public double GetError() => ErrorDoubles.Max();

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
    
    public static double[] ChebushevNodes(double a, double b, int n)
    {

        var XDoubles = new double[n];

        double
            t1 = (a + b) / 2,
            t2 = (b - a) / 2,
            t3 = 1 / (2 * Convert.ToDouble(n)) * Math.PI;
        for (var i = 0; i < n; i++)
        {
            XDoubles[i] = t1 - t2 * Math.Cos((2 * i + 1) * t3);
        }

        return XDoubles;

    }
}

#endregion

    #region LINEARSYSTEMS

    public class LinearSystem
    {
        //  метод прогонки/Томаса
        public static void ThomasAlgorithm(double[] a, double[] b, double[] c, ref double[] x, double[] d, int n)
        {
            double[] alpha = new double[n];
            double[] betta = new double[n];
            double y00 = 1 / b[0];
            alpha[0] = -c[0] * y00;
            betta[0] = d[0] * y00;
            for (int i = 1; i <= n - 2; i++)
            {
                y00 = 1 / (b[i] + a[i - 1] * alpha[i - 1]);
                alpha[i] = -c[i] * y00;
                betta[i] = (d[i] - a[i - 1] * betta[i - 1]) * y00;
            }
            y00 = 1 / (b[n - 1] + a[n - 2] * alpha[n - 2]);
            betta[n - 1] = (d[n - 1] - a[n - 2] * betta[n - 2]) * y00;

            x[n - 1] = betta[n - 1];
            for (int i = n - 2; i >= 0; i--)
            {
                x[i] = alpha[i] * x[i + 1] + betta[i];
            }

        }
    }

    #endregion

    #region TRIDIAGONAL_MATRIX

    // solves a Tridiagonal Matrix using Thomas algorithm
    public sealed class Tridiagonal
    {
        public static double[] Solve(double[,] matrix, double[] d)
        {
            var rows = matrix.GetLength(0);
            var cols = matrix.GetLength(1);
            var len = d.Length;

            var b = new double[rows];
            var a = new double[rows];
            var c = new double[rows];

            // decompose the matrix into its tri-diagonal components
            for (var i = 0; i < rows; i++)
            {
                for (var j = 0; j < cols; j++)
                {
                    if (i == j)
                        b[i] = matrix[i, j];
                    else if (i == (j - 1))
                        c[i] = matrix[i, j];
                    else if (i == (j + 1))
                        a[i] = matrix[i, j];
                }
            }
            c[0] /= b[0];
            d[0] /= b[0];
    
            for (var i = 1; i < len - 1; i++)
            {
                c[i] /= b[i] - a[i] * c[i - 1];
                d[i] = (d[i] - a[i] * d[i - 1]) / (b[i] - a[i] * c[i - 1]);
            }
            d[len - 1] = (d[len - 1] - a[len - 1] * d[len - 2]) / (b[len - 1] - a[len - 1] * c[len - 2]);

            // back-substitution step
            for (var i = len - 1; i-- > 0;)
            {
                d[i] -= c[i] * d[i + 1];
            }

            return d;
                
            }
        }
    }

#endregion

namespace BasicInterpolation
{
    #region EXTENSIONS
    public static class Extensions
    {
        public static List<T> SortedList<T>(this T[] array)
        {
            List<T> l = array.ToList();
            l.Sort();
            return l;

        }
        
        public static double[] Diff(this double[] array)
        {
            int len = array.Length - 1;
            double[] diffsArray = new double[len];
            for (int i = 1; i <= len; i++)
            {
                diffsArray[i - 1] = array[i] - array[i - 1];
            }
            return diffsArray;
        }
        
        public static double[] Scale(this double[] array, double[] scalor, bool mult = true)
        {
            int len = array.Length;
            double[] scaledArray = new double[len];

            if (mult)
            {
                for (int i = 0; i < len; i++)
                {
                    scaledArray[i] = array[i] * scalor[i];
                }
            }
            else
            {
                for (int i = 0; i < len; i++)
                {
                    if (scalor[i] != 0)
                    {
                        scaledArray[i] = array[i] / scalor[i];
                    }
                    else
                    {
                        // basic fix to prevent division by zero
                        scalor[i] = 0.00001;
                        scaledArray[i] = array[i] / scalor[i];

                    }
                }
            }

            return scaledArray;
        }

        public static double[,] Diagonal(this double[,] matrix, double[] diagonalValues)
        {
            var rows = matrix.GetLength(0);
            var cols = matrix.GetLength(1);

            if (rows == cols)
            {
                var diagonalMatrix = new double[rows, cols];
                var k = 0;
                for (var i = 0; i < rows; i++)
                    for (var j = 0; j < cols; j++)
                    {
                        if (i == j)
                        {
                            diagonalMatrix[i, j] = diagonalValues[k];
                            k++;
                        }
                        else
                        {
                            diagonalMatrix[i, j] = 0;
                        }
                    }
                return diagonalMatrix;
            }
            else
            {
                Console.WriteLine("Diagonal should be used on square matrix only.");
                return null;
            }


        }
    }

    #endregion
    #region FOUNDATION
    internal interface IInterpolate
    {
        double Interpolate(double p);
    }

    internal abstract class Interpolation : IInterpolate
    {
        protected double[] X => x;

        protected double[] Y => y;

        public abstract double Interpolate(double p);

        private double[] x;
        private double[] y;

        protected Interpolation(double[] _x, double[] _y)
        {
            var xLength = _x.Length;
            if (xLength == _y.Length && xLength > 1 && _x.Distinct().Count() == xLength)
            {
                x = _x;
                y = _y;
            }
        }
        
        protected Interpolation(double[] _x, double[] _y, bool checkSorted = true)
        {
            var xLength = _x.Length;
            if (checkSorted)
            {
                if (xLength != _y.Length || xLength <= 1 || _x.Distinct().Count() != xLength ||
                    !Enumerable.SequenceEqual(_x.SortedList(), _x.ToList())) return;
                x = _x;
                y = _y;
            }
            else
            {
                if (xLength == _y.Length && xLength > 1 && _x.Distinct().Count() == xLength)
                {
                    x = _x;
                    y = _y;
                }
            }
        }
    }
    #endregion

    #region  CUBIC_SPLINE
    internal sealed class CubicSplineInterpolation : Interpolation
    {
        private bool baseset = false;
        private int len;
        private List<double> lX;
        private double conditionRightValue;
        private double conditionLeftValue;
        
        public CubicSplineInterpolation(
            double[] _x,
            double[] _y,
            double conditionLeft,
            double conditionRight
            ) 
            : 
            base(_x, _y, true)
        {
            len = X.Length;

            baseset = true;

            lX = X.ToList();

            conditionLeftValue = conditionLeft;
            conditionRightValue = conditionRight;
        }

        public override double Interpolate(double p)
        {
            var N = len - 1;

            var h = X.Diff();
            var D = Y.Diff().Scale(h, false);
            var s = Enumerable.Repeat(3.0, D.Length).ToArray();
            var dD3 = D.Diff().Scale(s);
            var a = Y;
                
            //Генерация квадратной трехдиагональной матрицы
            var H = new double[N - 1, N - 1];
            var diagonalValues = new double[N - 1];
            for (var i = 1; i < N; i++)
            {
                diagonalValues[i - 1] = 2 * (h[i - 1] + h[i]);
            }

            H = H.Diagonal(diagonalValues);
                
            for (var i = 0; i < N - 2; i++)
            {
                H[i, i + 1] = h[i + 1];
                H[i + 1, i] = h[i + 1];
            }

            var c = new double[N + 2];
            c = Enumerable.Repeat(0.0, N + 1).ToArray();
                    
            var solution = Tridiagonal.Solve(H, dD3);

            for (var i = 1; i < N; i++)
            {
                c[i] = solution[i - 1];
            }
            //c[N - 1] = conditionRightValue;

            var b = new double[N];
            var d = new double[N];
            for (var i = 0; i < N; i++)
            {
                b[i] = D[i] - (h[i] * (c[i + 1] + 2.0 * c[i])) / 3.0;
            }

            for (var i = 0; i < N; i++)
            {
                d[i] = (c[i + 1] - c[i]) / (3.0 * h[i]);
            }
            //d[0] = conditionLeftValue;

            double Rx;

            Rx = X.First(m => m >= p);

            var iRx = lX.IndexOf(Rx);

            if (iRx == len - 1 && X[iRx] == p)
                return Y[len - 1];

            if (iRx == 0)
                return Y[0];

            iRx = lX.IndexOf(Rx) - 1;
            Rx = p - X[iRx];
            var result = a[iRx] + Rx * (b[iRx] + Rx * (c[iRx] + Rx * d[iRx]));

            return result;
        }
    }
    #endregion

}
