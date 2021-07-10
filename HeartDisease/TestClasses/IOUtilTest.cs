using HeartDisease.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace HeartDisease.TestClasses
{
    public class IOUtilTest
    {
        public static void Test()
        {
            LoadDataTest();
            SaveOutputTest();
        }

        private static void LoadDataTest()
        {
            IOUtil.LoadData(string.Empty);
        }

        private static void SaveOutputTest()
        {
            IOUtil.SaveOutput(null, string.Empty);
        }
    }
}
