using System;
using System.Collections.Generic;
using System.Text;

namespace HeartDisease.Predictors
{
    public class DummyPredictor : IPredictor
    {
        public double Predict(double x)
        {
            double y = 150 * x / 63;
            return y;
        }

        public double[] Predict(double[] x)
        {
            int n = x.Length;
            double[] y = new double[n];
            for (int i = 0; i < n; i++)
            {
                y[i] = Predict(x[i]);
            }
            return y;
        }
    }
}
