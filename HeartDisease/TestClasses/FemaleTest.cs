using HeartDisease.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HeartDisease.TestClasses
{
    public class FemaleTest
    {
        private static Female female = new Female(1);

        public static void Test()
        {
            ToStringTest();
            ToWriterTest();
        }

        public static void ToStringTest()
        {
            female.ToString();
        }

        public static void ToWriterTest()
        {
            female.ToWriter();
        }
    }
}
