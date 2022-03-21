using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using FirstLabWindowsFormsApp.Services;
using FirstLabWindowsFormsApp.Strategies.Distribution;

namespace FirstLabWindowsFormsApp.Main;

internal class CubicSpline
{
    public double A { get; private set; }
    public double B { get; private set; }

    public int N { get; private set; }

    public double[] XDoubles { get; private set; }
    public double[] CoefficientsDoubles { get; private set; }
    public double[] FDoubles { get; private set; }
    public double[] SDoubles { get; private set; }
    private double[] CDoubles { get; set; }
    private double[] AbsErrors { get; set; }

    public IDistribution Distribution { get; private set; }

    private Functions Functions { get; set; }

    public void GenerateData()
    {
        GenerateXDoubles();
        CalculateFDoubles();
        CalculateSplineCoefficients();
        CalculateCubicSpline();
        
        CalculateMaxAbsErrors();
    }

    private void GenerateXDoubles()
    {
        XDoubles = Distribution.Distribute(A, B, N);
    }

    private void CalculateFDoubles()
    {
        var func = Functions.GetFunction();

        for (var index = 0; index < N; index++)
        {
            FDoubles[index] = func(XDoubles[index], CoefficientsDoubles);
        }
    }

    private void CalculateCubicSpline()
    {

        for (var index = 0; index < N; index++)
        {

            //SDoubles[index] = 

        }

    }

    //TODO: Написать функцию для подсчёта формулы кубического сплайна
    private void CalculateSplineCoefficients()
    {
        var a = new double[N];
        var b = new double[N];
        var c = new double[N];
        var f = new double[N];

        for (var index = 1; index < N-1; index++)
        {

            var hI = XDoubles[index] - XDoubles[index - 1];
            var hIPlus1 = XDoubles[index + 1] - XDoubles[index];

            if (index - 1 >= 0)
                a[index] = hI;
            c[index] = 2 * (hI + hIPlus1);
            b[index] = hIPlus1;

            f[index] = 6 * ((FDoubles[index + 1] - FDoubles[index]) / hIPlus1 - (FDoubles[index] - FDoubles[index - 1]) / hI);
        }

        CDoubles = new double[N];

        SolveWithRunThroughMethod(
            N,
            a,
            c,
            b,
            f
        );
    }

    /**
     *
	 * n - число уравнений (строк матрицы)
	 * b - диагональ, лежащая над главной (нумеруется: [0;n-2])
	 * c - главная диагональ матрицы A (нумеруется: [0;n-1])
	 * a - диагональ, лежащая под главной (нумеруется: [1;n-1])
	 * f - правая часть (столбец)
	 * x - решение, массив x будет содержать ответ
     *
	 */
    private void SolveWithRunThroughMethod(
        int n,
        IReadOnlyList<double> a, 
        IList<double> c, 
        IReadOnlyList<double> b, 
        IList<double> f
        )
    {
        for (var index = 1; index < n; index++)
        {
            var m = a[index] / c[index - 1];
            c[index] = c[index] - m * b[index];
            f[index] = f[index] - m * f[index];
        }

        CDoubles[n - 1] = f[n - 1] / c[n - 1];

        for (var index = n - 2; index >= 0; index--)
        {
            CDoubles[index] = (f[index] - b[index] * CDoubles[index + 1]) / c[index];
        }
    }

    private double GetD(int index)
    {
        if (index > 0 && index <= N)
            return
                (CDoubles[index] - CDoubles[index - 1])
                /
                (XDoubles[index] - XDoubles[index - 1]);

        return 0;
    }

    private double GetB(int index)
    {
        if (!(index > 0 && index <= N))
            return 0;

        var hI = XDoubles[index] - XDoubles[index - 1];

        return
            hI / 2 * CDoubles[index] 
            - hI * hI / 6 * GetD(index) + (FDoubles[index] 
                                             - FDoubles[index - 1]) / hI;
    }

    private void CalculateMaxAbsErrors()
    {
        for (var index = 0; index < N; index++)
        {
            AbsErrors[index] = Math.Abs(FDoubles[index] - SDoubles[index]);
        }
    }

    public void GetMaxAbsError() => AbsErrors.Max();
}