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
// Добавить уплотнение
// Взять для примера экспоненту
// Добавить возможность использовать функцию без искажения при подсчёте коэффициентов
//
// В первой задаче не должна погрешность увеличиваться с увеличением количества узлов
// 
//

class Approximation
{
    public double A { get; set; }
    public double B { get; set; }
    public double SquaredError { get; private set; }

    public int N { get; set; }
    public int PartitionNum { get; set; }

    public double[] XDoubles { get; private set; }

    public double[] FDoubles { get; private set; }
    public double[] FTableDoubles { get; private set; }
    public double[] PhiDoubles { get; private set; }

    public double[] ExperimentalCoefficients { get; set; }
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
        
        FindSquaredError();
    }

    public void Compact()
    {



    }

    private double[] Partition(double[] array)
    {

        var n = array.Count();
        var result = new List<double>(n * (PartitionNum + 1));
        var temp = new double[PartitionNum];
        var distribution = new UniformDistribution();

        for (var i = 0; i < n - 1; i++)
        {
            temp = distribution.Distribute(array[i], array[i + 1], PartitionNum);
            for (var j = 0; j < 3; j++)
                result.Add(temp[j]);
        }

        return result.ToArray();

    }

    private void CoefficientsCalculation()
    {
        const int n = 2;

        var S = new double[n, n];
        var t = new double[n];

        for (var index = 0; index < N; index++)
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