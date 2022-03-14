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
    public int N { get; set; }

    public double[] XDoubles { get; private set; }

    public double[] FDoubles { get; private set; }
    private double[] PhiDoubles { get; set; }
    public double[] ExperimentalDoubles { get; private set; }
    public double[] ApproximationDoubles { get; private set; }

    private double[] ExperimentalCoefficients { get; set; }
    private double[] ApproximationCoefficients { get; set; }

    private IDistribution Distribution { get; set; }

    public Approximation(
        double a,
        double b,
        int n,
        double[] experimentalCoefficients,
        double[] approximationCoefficients,
        IDistribution distribution
        )
    {

        FDoubles = new double[N];
        PhiDoubles = new double[N];
        ExperimentalDoubles = new double[N];
        ApproximationDoubles = new double[N];

        A = a;
        B = b;
        N = n;
        
        Distribution = distribution;
        ExperimentalCoefficients = experimentalCoefficients;
        ApproximationCoefficients = approximationCoefficients;

        GenerateXDoubles();

    }

    //TODO:  Реализовать процедуру вычисления коэффициентов аппроксимирующей функции



    //TODO:  Реализовать процедуру вычисления среднеквадратичной погрешности аппроксимации



    public void GenerateXDoubles()
    {

        Distribution.Distribute(A, B, N);

    }

    public void GenerateFDoubles()
    {
        for (var index = 0; index < N; index++)
        {
            FDoubles[index] = Function(XDoubles[index], ExperimentalCoefficients);
        }
    }

    public void GeneratePhiDoubles()
    {
        var d = 0.2 * FDoubles.Max();
        var minValue = -d / 2;
        var maxValue = d / 2;

        var random = new Random();

        for (var index = 0; index < N; index++)
        {
            PhiDoubles[index] =     //(phi doubles)[i]
                FDoubles[index] + random.NextDouble() * (maxValue - minValue) + minValue;
        }
    }

    private static double Function(double x, IReadOnlyList<double> coefficients)
        => x;

    private static double PhiFunction(double x, IReadOnlyList<double> coefficients)
        => coefficients[0] + coefficients[1] / x;

    private static double PhiSquareFunction(double x, IReadOnlyList<double> coefficients)
        => coefficients[0] * coefficients[0] + coefficients[1] * coefficients[1] / (x * x);

}