using HeartDisease.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace HeartDisease.TestClasses
{
    public class DataServiceTest
    {
        public static void Test()
        {
            SetTrainingAndTestDatasetTest();
        }

        private static void SetTrainingAndTestDatasetTest()
        {
            DataService dataService = new DataService();
            dataService.SetTrainingAndTestDataset(null);
        }
    }
}
