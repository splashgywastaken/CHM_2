using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using FirstLabWindowsFormsApp.Services;
using FirstLabWindowsFormsApp.Strategies.Distribution;

namespace FirstLabWindowsFormsApp.Main;

//  Вариант 3
//  функция phi(x) = a + b/x 

class Approximation
{
    public double A { get; set; }
    public double B { get; set; }
    public double SquaredError { get; set; }

    public int N { get; set; }

    public double[] XDoubles { get; private set; }

    public double[] FDoubles { get; private set; }
    public double[] FTableDoubles { get; private set; }
    public double[] PhiDoubles { get; private set; }

    private double[] ExperimentalCoefficients { get; set; }
    public double[] ApproximationCoefficients { get; private set; }

    private IDistribution Distribution { get; set; }

    public Approximation(
        double a,
        double b,
        int n,
        double[] experimentalCoefficients,
        IDistribution distribution
        )
    {
        A = a;
        B = b;
        N = n;
        
        Distribution = distribution;
        ExperimentalCoefficients = experimentalCoefficients;
        ApproximationCoefficients = new double[2];
    }

    public void GenerateData()
    {
        // Генерирование векторов значений для X, экспериментальной функции F
        // и таблично заданной функции FTable
        GenerateXDoubles();
        GenerateFDoubles();
        GenerateFTableDoubles();

        //Поиск коэффициентов аппроксимации и генерирование вектора функции аппроксимации
        CoefficientsCalculation();
        GeneratePhiDoubles();

        //var h = FDoubles[0] - PhiDoubles[0];
        //for (var index = 0; index < N; index++)
        //{
        //    PhiDoubles[index] += h;
        //}

        FindSquaredError();
    }

    private void CoefficientsCalculation()
    {
        const int n = 2;

        var a = new double[n, n];
        var f = new double[n];
        var x = new double[n];
        double function = 0;
        double functionSquared = 0;
        double y = 0;
        double functionY = 0;

        var k = N / 2;

        //TODO: Составить систему на подобии той, что сохранил и дифференцировав решить 
        for (var index = 0; index < k; index++)
        {
            var tmp = Function(XDoubles[index], ExperimentalCoefficients);
            function += tmp;
            functionSquared += tmp * tmp;
            functionY += FTableDoubles[index] * tmp;
            y += FTableDoubles[index];
        }

        a[0, 0] = k;
        a[0, 1] = a[1, 0] = function;
        a[1, 1] = functionSquared;
        f[0] = y;
        f[1] = functionY;

        SolveSystem(a, f, ref x);

        ApproximationCoefficients = new double[2];
        ApproximationCoefficients[0] = x[0];
        ApproximationCoefficients[1] = x[1];
    }

    private static void SolveSystem(double[,] a, IList<double> f, ref double[] x)
    {
        var n = f.Count;
        for (var i = 0; i < n; i++)
        {
            var R = 1 / a[i, i];
            a[i, i] = 1;
            f[i] *= R;
            for (var j = i + 1; j < n; j++)
            {
                a[i, j] *= R;
            }
            for (var k = 0; k < n; k++)
                if (k != i)
                {
                    R = a[k, i];
                    f[k] -= R * f[i];
                    for (var j = i + 1; j < n; j++)
                        a[k, j] -= R * a[i, j];
                }
        }

        for (var i = 0; i < n; i++)
            x[i] = f[i];
    }

    private void GenerateXDoubles()
    {

        XDoubles = Distribution.Distribute(A, B, N);

    }

    private void GenerateFDoubles()
    {

        FDoubles = new double[N];

        for (var index = 0; index < N; index++)
        {
            FDoubles[index] = Function(XDoubles[index], ExperimentalCoefficients);
        }
    }

    private void GeneratePhiDoubles()
    {
        PhiDoubles = new double[N];

        for (var index = 0; index < N; index++)
        {
            PhiDoubles[index] = Function(XDoubles[index], ApproximationCoefficients);
        }
    }

    private void GenerateFTableDoubles()
    {
        FTableDoubles = new double[N];

        var d = 0.2 * FDoubles.Max();
        var minValue = -d / 2;
        var maxValue = d / 2;

        var random = new Random();

        for (var index = 0; index < N; index++)
        {
            FTableDoubles[index] =     //(phi doubles)[i]
                FDoubles[index] + random.NextDouble() * (maxValue - minValue) + minValue;
        }
    }

    private void FindSquaredError()
    {
        double result = 0;

        for (var index = 0; index < N; index++)
        {
            result += Math.Pow( FDoubles[index] - PhiDoubles[index], 2);
        }
        
        SquaredError = result / N;
    }

    private static double Function(double x, IReadOnlyList<double> coefficients)
        => coefficients[0] + coefficients[1] / x;
}