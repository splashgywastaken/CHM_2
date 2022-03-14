using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FirstLabWindowsFormsApp.Services;

internal class Functions
{
    public delegate double Function(double x, IReadOnlyList<double> coefficients);

    private Function _function;

    public Functions(int functionIndex)
    {
        SetFunction(functionIndex);
    }

    private static double LinearFunction(double x, IReadOnlyList<double> coefficients)
        => coefficients[0] * x + coefficients[1];

    private static double QuadraticFunction(double x, IReadOnlyList<double> coefficients)
        => coefficients[0] * x * x + coefficients[1] * 2 * x + coefficients[2];

    private static double CubicFunction(double x, IReadOnlyList<double> coefficients)
        => Math.Pow(x, 3) * coefficients[0] + Math.Pow(x, 2) * coefficients[1] + x * coefficients[2] + coefficients[0];

    private static double SinFunction(double x, IReadOnlyList<double> coefficients)
        => coefficients[0] * Math.Sin(coefficients[1] * x);

    private void SetFunction(int functionIndex)
    {
        _function = functionIndex switch
        {
            0 => SinFunction,
            1 => LinearFunction,
            2 => QuadraticFunction,
            3 => CubicFunction,
            _ => _function
        };
    }

    public Function GetFunction() => _function;
}