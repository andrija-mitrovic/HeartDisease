using HeartDisease.Methods;
using System;
using System.Collections.Generic;
using System.Text;

namespace HeartDisease.Predictors
{
    public class OLSPredictor : IPredictor
    {
        private readonly double[] betas;

        public OLSPredictor(double[] x, double[] y)
        {
            betas = OrdinaryLeastSquare.Regression(x, y);
        }

        public double Predict(double x)
        {
            return betas[0] + betas[1] * x;
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
