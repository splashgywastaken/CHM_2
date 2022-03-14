using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Text;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Schema;
using FirstLabWindowsFormsApp.Services;
using FirstLabWindowsFormsApp.Strategies.Distribution;

namespace FirstLabWindowsFormsApp.Main;

public class Interpolation
{
    private Functions _functions;

    public Interpolation(
        IDistribution distribution,
        double a,
        double b,
        int n,
        double[] coefficients,
        int functionNumber
        )
    {
        A = a;
        B = b;
        N = n;

        Distribution = distribution;

        SetFunctionAndCoefficients(functionNumber, coefficients);
    }

    public double[] XDoubles { get; private set; }

    public double[] YDoubles { get; private set; }

    public double[] PDoubles { get; private set; }

    public double[] ErrorDoubles { get; private set; }

    private double[] CoefficientsDoubles { get; set; }

    public double A { get; set; }

    public double B { get; set; }

    public int N { get; set; }

    public IDistribution Distribution { get; set; }

    public void GenerateData()
    {
        XDoubles = new double[N];
        YDoubles = new double[N];
        PDoubles = new double[N];
        ErrorDoubles = new double[N];

        XDoubles = Distribution.Distribute(A, B, N);
        GenerateYDoubles();
        GeneratePDoubles();

        GetErrors();
    }

    private void GeneratePDoubles()
    {

        var newtonPolynomial = CreateNewtonPolynomial(XDoubles, YDoubles);

        for (var index = 0; index < N; index++)
        {
            PDoubles[index] = newtonPolynomial(XDoubles[index]);
        }

    }

    private static double CalculateDividedDifferences(
        IReadOnlyList<double> x,
        IReadOnlyList<double> y, 
        int k
        )
    {
        double result = 0;
        for (var j = 0; j <= k; j++)
        {
            double mul = 1;
            for (var i = 0; i <= k; i++)
            {
                if (j != i)
                {
                    mul *= (x[j] - x[i]);
                }
            }
            result += y[j] / mul;
        }
        return result;
    }

    private static Func<double, double> CreateNewtonPolynomial(double[] x, double[] y)
    {
        var divDiff = new double[x.Length - 1];
        for (var index = 1; index < x.Length; index++)
        {
            divDiff[index - 1] = CalculateDividedDifferences(x, y, index);
        }

        double NewtonPolynomial(double xVal)
        {
            var result = y[0];
            for (var index = 1; index < x.Length; index++)
            {
                double mul = 1;
                for (var innerIndex = 0; innerIndex < index; innerIndex++)
                {
                    mul *= (xVal - x[innerIndex]);
                }

                result += divDiff[index - 1] * mul;
            }

            return result;
        }

        return NewtonPolynomial;
    }

    private void GenerateYDoubles()
    {

        var function = _functions.GetFunction();

        for (var index = 0; index < N; index++)
        {
            try
            {

                YDoubles[index] = function(XDoubles[index], CoefficientsDoubles);

            }
            catch (System.IndexOutOfRangeException ex)
            {
                Console.WriteLine("Index out of range: {0}", index);
            }
        }
    }

    private void GetErrors()
    {

        for (var i = 0; i < N; i++)
        {
            ErrorDoubles[i] = Math.Abs(YDoubles[i] - PDoubles[i]);
        }

    }

    public double GetMaxAbsoluteError() => ErrorDoubles.Max();

    public void SetFunctionAndCoefficients(int selectedIndex, double[] coefficients)
    {
        CoefficientsDoubles = coefficients;
        _functions = new Functions(selectedIndex);
    }
}