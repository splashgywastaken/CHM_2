using System;
using System.Collections.Generic;

namespace FirstLabWindowsFormsApp.Strategies.Distribution;
public class ChebushevDistribution : IDistribution
{
    public double[] Distribute(
        double a,
        double b,
        int n
    )
    {
        var result = new double[n];

        for (var index = 0; index < n; index++)
        {
            try
            {
                result[index] = (a + b) / 2 - (b - a) / 2 * Math.Cos((2.0f * index + 1) / (2 * n + 2) * Math.PI);
            }
            catch (System.IndexOutOfRangeException ex)
            {
                Console.WriteLine("Index is out of range: {0}", index);
                throw;
            }

        }

        return result;

    }
}