using System;
using System.Collections.Generic;

namespace FirstLabWindowsFormsApp.Strategies.Distribution;

public class UniformDistribution : IDistribution
{
    public double[] Distribute(
        double a,
        double b,
        int n
    )
    {
        var result = new double[n];
        var temp = 1 / (n - 1);

        for (var index = 0; index < n; index++)
        {
            try
            {
                result[index] = a + (b - a) * temp * index;
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine("[Distribute] Index is out of range: {0}", index);
                throw;
            }
        }

        return result;

    }
}