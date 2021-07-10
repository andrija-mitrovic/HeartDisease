using System;
using System.Collections.Generic;
using System.Text;

namespace HeartDisease.TestClasses
{
    public class StatTest
    {
        public static void Test()
        {
            Mean();
            Std();
            Variance();
            Correlation();
            MSE();
        }

        private static void Mean()
        {
            Stat.Mean(null);
            Stat.Mean(new double[] { });
        }

        private static void Std()
        {
            Stat.Std(null);
            Stat.Std(new double[] { });
        }

        private static void Variance()
        {
            Stat.Variance(null);
            Stat.Variance(new double[] { });
        }

        private static void Correlation()
        {
            Stat.Correlation(null, null);
            Stat.Correlation(new double[] { }, new double[] { });
        }

        private static void MSE()
        {
            Stat.MSE(null, null, null);
            Stat.MSE(new double[] { }, new double[] { }, null);
        }
    }
}
