using HeartDisease.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HeartDisease.TestClasses
{
    public class StateInfoTest
    {
        public static void Test()
        {
            PrintStatInfoTest();
        }

        private static void PrintStatInfoTest()
        {
            StatisticInfo info = new StatisticInfo();
            info.PrintStatInfo(null);
        }
    }
}
