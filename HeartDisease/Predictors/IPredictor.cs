using System;
using System.Collections.Generic;
using System.Text;

namespace HeartDisease.Predictors
{
    public interface IPredictor
    {
        public double Predict(double x);
        public double[] Predict(double[] x);
    }
}
