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
    private double A { get; set; }
    private double B { get; set; }
    private int N { get; set; }

    public double[] XDoubles { get; private set; }
    public double[] FDoubles { get; private set; }
    public double[] PhiDoubles { get; private set; }
    private double[] CoefficientsDoubles { get; set; }
    
    private IDistribution Distribution { get; set; }

    public Approximation(
        double a,
        double b,
        int n,
        double[] coefficientsDoubles
        )
    {
        A = a;
        B = b;
        N = n;
        
        Distribution = new UniformDistribution();
        CoefficientsDoubles = coefficientsDoubles;

        GenerateXDoubles();

    }

    public void GenerateXDoubles()
    {

        Distribution.Distribute(A, B, N);

    }

    public void GenerateFDoubles()
    {
        for (var index = 0; index < N; index++)
        {
            FDoubles[index] = Function(XDoubles[index], new double[] {0.0});
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
        => coefficients[0] * coefficients[0] + (coefficients[1] * coefficients[1]) / (x * x);

}