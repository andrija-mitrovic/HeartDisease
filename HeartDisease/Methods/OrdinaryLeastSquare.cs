using System;
using System.Collections.Generic;
using System.Text;

namespace HeartDisease.Methods
{
    public class OrdinaryLeastSquare
    {
        public static double Average(double[] v)
        {
            if (v == null) throw new ArgumentNullException();
            if (v.Length == 0) throw new Exception("Array cannot be empty");

            // What if v is empty?
            double avg = 0;
            for (int i = 0; i < v.Length; i++)
            {
                avg += v[i];
            }
            return avg / v.Length;
        }

        // LC(x,y) = DotProduct(x-barx, y-bary)
        public static double LikeCovariance(double[] x, double[] y)
        {
            if(x == null && y == null) throw new ArgumentNullException();
            if (x.Length == 0 && y.Length == 0) throw new Exception("Arrays cannot be empty");

            double sum = 0;
            double barx = Average(x);
            double bary = Average(y);
            for (int i = 0; i < x.Length; i++)
            {
                sum += ((x[i] - barx) * (y[i] - bary));
            }

            return sum;
        }

        public static double[] Regression(double[] x, double[] y)
        {
            if (x == null && y == null) throw new ArgumentNullException();
            if (x.Length == 0 && y.Length == 0) throw new Exception("Arrays cannot be empty");

            // This was the main
            double barx = Average(x);
            double bary = Average(y);
            double num = LikeCovariance(x, y);
            double den = LikeCovariance(x, x);
            double beta1 = (double)num / (double)den;
            double beta0 = bary - barx * beta1;
            double[] betas = { beta0, beta1 };

            return betas;
        }
    }
}
