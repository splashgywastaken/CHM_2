using System.Collections.Generic;

namespace FirstLabWindowsFormsApp.Strategies.Distribution;

public interface IDistribution
{
    public double[] Distribute(
        double a,
        double b,
        int n
    );
}