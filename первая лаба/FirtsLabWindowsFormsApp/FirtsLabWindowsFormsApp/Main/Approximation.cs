#nullable enable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using FirstLabWindowsFormsApp.Services;
using FirstLabWindowsFormsApp.Strategies.Distribution;

namespace FirstLabWindowsFormsApp.Main;

//  Вариант 3
//  функция phi(x) = a + b/x 
// Добавить уплотнение
// Взять для примера экспоненту
// Добавить возможность использовать функцию без искажения при подсчёте коэффициентов
//
// В первой задаче не должна погрешность увеличиваться с увеличением количества узлов

class Approximation
{
    public bool UseDGeneration { get; set; }

    public double A { get; set; }
    public double B { get; set; }
    public double SquaredError { get; private set; }

    public int N { get; set; }
    public int PartitionNum { get; set; }

    public double[] XDoubles { get; private set; }

    public double[] FDoubles { get; private set; }
    public double[] FTableDoubles { get; private set; }
    public double[] PhiDoubles { get; private set; }
    
    public double[] ApproximationCoefficients { get; private set; }

    public Func<double, double> CurrentFunction { get; private set; }
    private Func<double, double> ApproximationFunction { get; set; }

    private IDistribution Distribution { get; set; }

    public Approximation(
        double a,
        double b,
        int n,
        IDistribution distribution,
        int functionIndex
        )
    {
        A = a;
        B = b;
        N = n;

        UseDGeneration = true;

        Distribution = distribution;
        ApproximationCoefficients = new double[2];
        SetFunction(functionIndex);
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
        
        FindSquaredError();
    }

    public void SetFunction(int functionIndex)
    {
        if (functionIndex == 0)
        {
            CurrentFunction = Function;
            ApproximationFunction = ApproximationFunc;
        }
        else
        {
            CurrentFunction = Exp;
            ApproximationFunction = ApproximationExp;
        }
    }

    public void Condense()
    {
        var newN = 3 * N - 2;
        var tempX = new double[newN];

        //Получение массива X
        for (var index = 0; index < N; index++)
        {
            double h;
            if (index + 1 != N)
                h = (XDoubles[index + 1] - XDoubles[index]) / 3;
            else
                h = (XDoubles[index] - XDoubles[index - 1]) / 3;
            if (!(3 * index - 1 < 0))
                tempX[3 * index - 1] = XDoubles[index] - h;
            tempX[3 * index] = XDoubles[index];
            if (!(3 * index + 1 >= newN))
                tempX[3 * index + 1] = XDoubles[index] + h;
        }

        tempX[0] = XDoubles[0];
        tempX[newN - 1] = XDoubles[N - 1];

        XDoubles = tempX;
        N = newN;

        GenerateFDoubles();
        GenerateFTableDoubles();
        //Поиск коэффициентов аппроксимации и генерирование вектора функции аппроксимации
        CoefficientsCalculation();
        GeneratePhiDoubles();

        FindSquaredError();

    }

    //private double[] Partition(double[] array)
    //{
        
    //}

    private void CoefficientsCalculation()
    {
        const int n = 2;

        var S = new double[n, n];
        var t = new double[n];

        for (var index = 0; index < XDoubles.Length; index++)
        {
            var temp = 1 / XDoubles[index];
            S[0, 1] += temp;
            S[1, 1] += temp * temp;
            t[0] += FDoubles[index];
            t[1] += FDoubles[index] * temp;
        }

        S[0, 0] = N + 1;
        S[1, 0] = S[0, 1];
        
        ApproximationCoefficients = new double[2];
        ApproximationCoefficients[0] = (t[0] * S[1, 1] - S[0, 1] * t[1]) / (S[0, 0] * S[1, 1] - S[0, 1] * S[0, 1]);
        ApproximationCoefficients[1] = (t[1] * S[0, 0] - t[0] * S[0, 1]) / (S[0, 0] * S[1, 1] - S[0, 1] * S[0, 1]);
    }

    private void GenerateXDoubles()
    {

        XDoubles = Distribution.Distribute(A, B, N);

    }

    private void GenerateFDoubles()
    {

        FDoubles = new double[XDoubles.Length];

        for (var index = 0; index < XDoubles.Length; index++)
        {
            FDoubles[index] = CurrentFunction(XDoubles[index]);
        }
    }

    private void GeneratePhiDoubles()
    {
        PhiDoubles = new double[XDoubles.Length];

        for (var index = 0; index < XDoubles.Length; index++)
        {
            PhiDoubles[index] = ApproximationFunction(XDoubles[index]);
        }
    }

    private void GenerateFTableDoubles()
    {
        FTableDoubles = new double[XDoubles.Length];

        if (!UseDGeneration)
        {
            FTableDoubles = FDoubles;
            return;
        }

            
        var d = 0.2 * FDoubles.Max();
        var minValue = -d / 2;
        var maxValue = d / 2;

        var random = new Random();

        for (var index = 0; index < XDoubles.Length; index++)
        {
            FTableDoubles[index] =     //(phi doubles)[i]
                FDoubles[index] + random.NextDouble() * (maxValue - minValue) + minValue;
        }
    }

    private void FindSquaredError()
    {
        double result = 0;

        for (var index = 0; index < XDoubles.Length; index++)
        {
            result += Math.Pow( FDoubles[index] - PhiDoubles[index], 2);
        }
        
        SquaredError = result / XDoubles.Length;
    }

    private static double Function(double x)
        => 1 + 2 / x;

    private double ApproximationFunc(double x)
        => ApproximationCoefficients[0] + ApproximationCoefficients[1] / x;

    private static double Exp(double x)
        => 0 + Math.Exp(1 * x);

    private double ApproximationExp(double x)
        => ApproximationCoefficients[0] + Math.Exp(ApproximationCoefficients[1] * x);
}