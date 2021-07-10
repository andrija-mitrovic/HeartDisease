using HeartDisease.Predictors;
using System;
using System.Collections.Generic;
using System.Text;

namespace HeartDisease
{
    public class Stat
    {
        public static double Mean(double[] m)
        {
            if (m == null) throw new ArgumentNullException();
            if (m.Length == 0) throw new Exception("Array cannot be empty");

            double mv = 0;
            for (int i = 0; i < m.Length; i++)
            {
                mv += m[i];
            }
            mv = mv / m.Length;
            return mv;
        }

        public static double Std(double[] s)
        {
            if (s == null) throw new ArgumentNullException();
            if (s.Length == 0) throw new Exception("Array cannot be empty");

            double mv = Mean(s);
            double sv = 0;
            for (int i = 0; i < s.Length; i++)
            {
                sv += (s[i] - mv) * (s[i] - mv);
            }
            sv = sv / (s.Length - 1);
            return Math.Sqrt(sv);
        }

        public static double Variance(double[] s)
        {
            if (s == null) throw new ArgumentNullException();
            if (s.Length == 0) throw new Exception("Array cannot be empty");

            double sv = Std(s);
            return sv * sv;
        }

        public static double Correlation(double[] v1, double[] v2)
        {
            if (v1 == null || v2 == null) throw new ArgumentNullException();
            if (v1.Length == 0 || v2.Length == 0) throw new Exception("Arrays cannot be empty");

            double mv1 = Mean(v1);
            double mv2 = Mean(v2);
            double r = 0;
            for (int i = 0; i < v1.Length; i++)
            {
                r += (v1[i] - mv1) * (v2[i] - mv2) / (Std(v1) * Std(v2));
            }
            return r / (v1.Length - 1);
        }

        public static double MSE(double[] x, double[] y, IPredictor p)
        {
            if (p == null) throw new ArgumentNullException();
            if (x == null || y == null) throw new ArgumentNullException();
            if (x.Length == 0 || y.Length == 0) throw new Exception("Arrays cannot be empty");

            double[] tilde_y = p.Predict(x);
            double sse = 0;
            for (int i = 0; i < tilde_y.Length; i++)
            {
                sse += Math.Pow(tilde_y[i] - y[i], 2);
            }
            return sse / x.Length;
        }
    }
}
