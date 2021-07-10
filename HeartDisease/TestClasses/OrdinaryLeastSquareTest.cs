using HeartDisease.Methods;
using System;
using System.Collections.Generic;
using System.Text;

namespace HeartDisease.TestClasses
{
    public class OrdinaryLeastSquareTest
    {
        public static void Test()
        {
            AverageTest();
            LikeCovariance();
            Regression();
        }

        private static void AverageTest()
        {
            OrdinaryLeastSquare.Average(null);
            OrdinaryLeastSquare.Average(new double[] { });
        }

        private static void LikeCovariance()
        {
            OrdinaryLeastSquare.LikeCovariance(null, null);
            OrdinaryLeastSquare.LikeCovariance(new double[] { }, new double[] { });
        }

        private static void Regression()
        {
            OrdinaryLeastSquare.Regression(null, null);
            OrdinaryLeastSquare.Regression(new double[] { }, new double[] { });
        }
    }
}
