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

    public double[] XDoubles { get; private set; }

    public double[] HDoubles { get; private set; }

    public double[] YDoubles { get; private set; }

    public double[] PDoubles { get; private set; }

    public double[] ErrorDoubles { get; private set; }

    private double[] CoefficientsDoubles { get; set; }

    public double A { get; set; }

    public double B { get; set; }

    public int N { get; set; }

    public IDistribution Distribution { get; set; }

    public Func<double, double> NewtonPolynomial { get; set; }

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

    public void GenerateData()          
    {
        XDoubles = new double[N + 1];
        YDoubles = new double[N + 1];
        PDoubles = new double[N];
        ErrorDoubles = new double[N];
        HDoubles = new double[N];

        //XDoubles = Distribution.Distribute(A, B, N);
        GenerateXDoubles();
        GenerateYDoubles();
        GeneratePDoubles();

        
        GetErrors();
    }

    private void GenerateXDoubles()
    {
        HDoubles = new double[N];

        if (Distribution.GetType() == typeof(UniformDistribution))
        {
            EvenNodes(A, B, N + 1);
        }
        else
        {
            ChebushevNodes(A, B, N + 1);
        }
    }

    private void EvenNodes(double a, double b, int N)
    {
        XDoubles[0] = a;
        var h = (b - a) / (N - 1);
        for (var i = 1; i < N; i++)
        {
            XDoubles[i] = XDoubles[i - 1] + h;
        }
        for (var i = 0; i < N - 1; i++)
        {
            HDoubles[i] = h;
        }
    }

    private void ChebushevNodes(double a, double b, double N)
    {
        double
            t1 = (a + b) / 2,
            t2 = (b - a) / 2,
            t3 = 1 / (2 * N) * Math.PI;
        for (var i = 0; i < N; i++)
        {
            XDoubles[i] = t1 - t2 * Math.Cos((2 * i + 1) * t3);
        }
        for (var i = 1; i < N - 1; i++)
        {
            HDoubles[i] = XDoubles[i] - XDoubles[i - 1];
        }
    }

    private void GeneratePDoubles()
    {
        NewtonPolynomial = CreateNewtonPolynomial(XDoubles, YDoubles);

        for (var index = 0; index < N; index++)
        {
            PDoubles[index] = NewtonPolynomial(XDoubles[index]);
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
                if (j == i) continue;
                mul *= x[j] - x[i];
            }
            result += y[j] / mul;
        }
        return result;
    }

    private static double CalculateDividedDifferences(
        double h,
        IReadOnlyList<double> y,
        int k
    )
    {
        double result = 0;
        for (var j = 0; j <= k; j++)
        {

            result += 
                Math.Pow(-1, k - j) * y[j] 
                /
                (MathFunctions.Fact(j) * MathFunctions.Fact(k - j) * Math.Pow(h, k));

        }
        return result;
    }

    private static Func<double, double> CreateNewtonPolynomial(double[] x, double[] y)
    {
        var divDiff = new double[x.Length];
        var h = x[1] - x[0];
        for (var index = 0; index < x.Length; index++)
        {
            divDiff[index] = CalculateDividedDifferences(x, y, index);
            //divDiff[index] = CalculateDividedDifferences(h, y, index);
        }

        double NewtonPolynomial(double xVal)
        {
            var result = divDiff[0];
            for (var index = 1; index < x.Length; index++)
            {
                double mul = 1;
                for (var innerIndex = 0; innerIndex < index; innerIndex++)
                {
                    mul *= xVal - x[innerIndex];
                }

                result += divDiff[index] * mul;
            }

            return result;
        }
        return NewtonPolynomial;
    }

    private void GenerateYDoubles()
    {

        var function = _functions.GetFunction();

        for (var index = 0; index < N + 1; index++)
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

    public double GetMaxAbsoluteError()
    {
        return ErrorDoubles.Max();
    }

    public void SetFunctionAndCoefficients(int selectedIndex, double[] coefficients)
    {
        CoefficientsDoubles = coefficients;
        _functions = new Functions(selectedIndex);
    }

    public void GenerateGraphData(
        ref double[] xDoubles,
        ref double[] function,
        ref double[] polynomial,
        ref double[] errors,
        int n
    )
    {

        xDoubles = new double[n];
        var h = (B - A) / n;
        for (var index = 0; index < n; index++)
        {
            xDoubles[index] = A + index * h;
        }

        function = GenerateFunctionGraphData(xDoubles, n);
        polynomial = GeneratePolynomialGraphData(xDoubles, n);

        errors = new double[n];
        for (var index = 0; index < n; index++)
        {
            errors[index] = Math.Abs(polynomial[index] - function[index]);
        }

    }

    private double[] GenerateFunctionGraphData(IReadOnlyList<double> x, int n)
    {

        var result = new double[n];
        var h = (B - A) / n;

        var func = _functions.GetFunction();

        for (var index = 0; index < n; index++)
        {
            result[index] = func(x[index], CoefficientsDoubles);
        }

        return result;

    }

    private double[] GeneratePolynomialGraphData(IReadOnlyList<double> x, int n)
    {

        var result = new double[n];
        var h = (B - A) / n;

        for (var index = 0; index < n; index++)
        {
            result[index] = NewtonPolynomial(x[index]);
        }

        return result;

    }
}