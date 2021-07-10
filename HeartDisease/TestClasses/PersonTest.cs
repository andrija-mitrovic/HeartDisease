using HeartDisease.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HeartDisease.TestClasses
{
    public class PersonTest
    {
        private static readonly Person person = new Person(1);

        public static void Test()
        {
            ToStringTest();
            ToWriterTest();
        }

        public static void ToStringTest()
        {
            person.ToString();
        }

        public static void ToWriterTest()
        {
            person.ToWriter();
        }
    }
}
