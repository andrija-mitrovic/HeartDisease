using HeartDisease.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HeartDisease.TestClasses
{
    public class MaleTest
    {
        private static readonly Male male = new Male(1);

        public static void Test()
        {
            ToStringTest();
            ToWriterTest();
        }

        public static void ToStringTest()
        {
            male.ToString();
        }

        public static void ToWriterTest()
        {
            male.ToWriter();
        }
    }
}
