using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using FirstLabWindowsFormsApp.Services;
using FirstLabWindowsFormsApp.Strategies.Distribution;
using static FirstLabWindowsFormsApp.Services.MathFunctions;

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

    public double[] BDoubles { get; private set; }

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
        BDoubles = new double[N];
        PDoubles = new double[N];
        ErrorDoubles = new double[N];

        XDoubles = Distribution.Distribute(A, B, N);
        GenerateY();
        GenerateB();
        GenerateP();

        GetErrors();
    }

    private void GenerateB()
    {
        var h = XDoubles[1] - XDoubles[0];

        for (var loopIndex = 0; loopIndex < N; loopIndex++)
        {
            var sum = 0.0;
            for (var sumIndex = 0; sumIndex <= loopIndex; sumIndex++)
            {
                try
                {
                    sum +=
                        Math.Pow(-1, loopIndex - sumIndex) * YDoubles[sumIndex]
                        /
                        (Fact(sumIndex) * Fact(loopIndex - sumIndex) * Math.Pow(h, loopIndex));
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine(
                        "[GetB] Inner index out of range" +
                        "\nsum index: {0}" +
                        "\nindex: {1}",
                        sumIndex,
                        loopIndex
                        );
                }
            }
            BDoubles[loopIndex] = sum;
        }
    }

    private void GenerateP()
    {

        for (var index = 0; index < N; index++)
        {
            PDoubles[index] = BDoubles[0];
        }

        for (var index = 0; index < N; index++)
        {

            var sum = 0.0;

            for (var sumIndex = 1; sumIndex < N; sumIndex++)
            {

                if (sumIndex == index)
                    continue;

                var product = 1.0;
                for (var productIndex = 0; productIndex < N; productIndex++)
                {
                    if (index == productIndex)
                        continue;
                    product *= XDoubles[index] - XDoubles[productIndex];
                }

                sum += product;

            }

            PDoubles[index] = sum;

        }

    }

    private void GenerateY()
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
            ErrorDoubles[i] = Math.Abs(YDoubles[i] - BDoubles[i]);
        }

    }

    public double GetMaxAbsoluteError() => ErrorDoubles.Max();

    public void SetFunctionAndCoefficients(int selectedIndex, double[] coefficients)
    {
        //Реализовать работу функций через отдельный класс
        CoefficientsDoubles = coefficients;
        _functions = new Functions(selectedIndex);
    }
}