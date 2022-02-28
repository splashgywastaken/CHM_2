using System;
using System.Collections.Generic;
using FirstLabWindowsFormsApp.Strategies.Distribution;
using static FirstLabWindowsFormsApp.Services.MathFunctions;

namespace FirstLabWindowsFormsApp.Main
{
    public class Approximation
    {

        private double[] _xDoubles;
        private double[] _yDoubles;
        private double[] _bDoubles;

        private double _a;
        private double _b;
        private int _n;

        private IDistribution _distribution;


        public Approximation(
                IDistribution distribution,
                double a,
                double b,
                int n
            )
        {
            _a = a;
            _b = b;
            _n = n;

            _xDoubles = new double[_n];
            _yDoubles = new double[_n];
            _bDoubles = new double[_n];

            _distribution = distribution;

        }

        public void Deconstruct(out double[] xDoubles, out double[] yDoubles, out double[] bDoubles, out double a, out double b, out int n)
        {
            xDoubles = _xDoubles;
            yDoubles = _yDoubles;
            bDoubles = _bDoubles;
            a = _a;
            b = _b;
            n = _n;
        }

        public double[] XDoubles
        {
            get => _xDoubles;
            set => _xDoubles = value;
        }

        public double[] YDoubles
        {
            get => _yDoubles;
            set => _yDoubles = value;
        }

        public double[] BDoubles
        {
            get => _bDoubles;
            set => _bDoubles = value;
        }

        public double A
        {
            get => _a;
            set => _a = value;
        }

        public double B
        {
            get => _b;
            set => _b = value;
        }

        public int N
        {
            get => _n;
            set => _n = value;
        }

        public IDistribution Distribution
        {
            get => _distribution;
            set => _distribution = value;
        }

        public void SetData()
        {

            _xDoubles = _distribution.Distribute(_a, _b, _n);
            SetY();
            SetB();

        }

        private void SetB()
        {

            var h = _xDoubles[1] - _xDoubles[0];

            for (var index = 0; index < _n; index++)
            {
                var sum = 0.0;
                for (var innerIndex = 0; innerIndex < index; innerIndex++)
                {
                    try
                    {
                        sum +=
                            Math.Pow(-1, index - innerIndex) * _yDoubles[innerIndex]
                            /
                            (Fact(innerIndex) * Fact(index - innerIndex) * Math.Pow(h, index));
                    }
                    catch (System.IndexOutOfRangeException ex)
                    {
                        Console.WriteLine("[GetB] Inner index out of range, index: {0}", innerIndex);
                    }
                }
                _bDoubles[index] = sum;

            }

        }

        private void SetY()
        {

            for (var index = 0; index < _n; index++)
            {

                try
                {
                    _yDoubles[index] = Function(_xDoubles[index]);
                }
                catch (System.IndexOutOfRangeException ex)
                {
                    Console.WriteLine("Index out of range: {0}", index);
                }

            }

        }

        private static double Function(double x)
        {

            return Math.Pow(x, 2) + 2 * x + 3;

        }

    }
}