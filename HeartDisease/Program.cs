using HeartDisease.Constants;
using HeartDisease.Data;
using HeartDisease.Models;
using HeartDisease.Predictors;
using HeartDisease.TestClasses;
using System;
using System.Collections.Generic;

namespace HeartDisease
{
    class Program
    {
        static void Main(string[] args)
        {
            var projectInfo = new ProjectInfo()
            {
                AuthorFirstName = "Andrija",
                AuthorLastName = "Mitrovic",
                Info = "Regression between age and maximum heart rate achieved",
                MethodUsed = "Ordinary Least Square Regression",
                DatasetName = "Heart Disease",
                DatasetUrl = "https://www.kaggle.com/ronitf/heart-disease-uci"
            };

            Messages.PrintProjectHeadMessage(projectInfo);

            DummyTest();
            HierarchyTest();
            TestClasses();
            ValRefTest();
            
            Messages.PrintLoadingDataMessage("Persons");
            Person[] persons = IOUtil.LoadData(DataConstants.INPUT_DATA_FILE_PATH);
            
            StatisticInfo info = new StatisticInfo();
            info.PrintStatInfo(persons);
            
            DataService dataService = new DataService();
            dataService.SetTrainingAndTestDataset(persons);
            
            Person[] personsTraining = IOUtil.LoadData(DataConstants.TRAINING_DATA_FILE_PATH);
            Person[] personsTest = IOUtil.LoadData(DataConstants.TRAINING_DATA_FILE_PATH);

            double[] ages = new double[personsTraining.Length];
            double[] rates = new double[personsTraining.Length];
            
            for (int i = 0; i < personsTraining.Length - 1; i++)
            {
                ages[i] = personsTraining[i].Age;
                rates[i] = personsTraining[i].MaxHeartRateAchieved;
            }

            double[] agesTest = new double[personsTraining.Length];
            double[] ratesTest = new double[personsTraining.Length];

            for (int i = 0; i < personsTest.Length - 1; i++)
            {
                agesTest[i] = personsTraining[i].Age;
                ratesTest[i] = personsTraining[i].MaxHeartRateAchieved;
            }

            Test.DummyTest();
            Test.TableData(ages, rates);

            try
            {
                IPredictor p = new OLSPredictor(ages, rates);
                double mse = Stat.MSE(ages, rates, p);
                Console.WriteLine("MSE: {0}", mse);
                Console.WriteLine("ME:  {0}", Math.Sqrt(mse));
                Console.WriteLine();

                var predictedRate = p.Predict(agesTest);

                var personOutput = new List<Person>();
                for (int i = 0; i < personsTest.Length - 1; i++)
                {
                    personOutput.Add(new Person(personsTest[i].Id)
                    {
                        Age = personsTest[i].Age,
                        MaxHeartRateAchieved = predictedRate[i]
                    });
                }
                IOUtil.SaveOutput(personOutput.ToArray());
            }
            catch(Exception ex)
            {
                Console.Write(ex.Message);
            }
        }

        private static void DummyTest()
        {
            double[] x = { 63, 37, 41 };
            double[] y = { 150, 187, 172 };          
            
            IPredictor p = new OLSPredictor(x, y);
            double mse = Stat.MSE(x, y, p);
            Console.WriteLine("MSE: {0}", mse);
            Console.WriteLine("ME:  {0}", Math.Sqrt(mse));
        }

        private static void HierarchyTest()
        {
            Male male = new Male(1);
            Female female = new Female(2);

            Console.WriteLine(male.Age);
            Console.WriteLine(female.MaxHeartRateAchieved);

            Console.WriteLine(male.Id);
            Console.WriteLine(female.Id);
        }

        private static void ValRefTest()
        {
            Console.WriteLine("--------------------------------------");
            int a = 5;
            int b = a;
            a = 8;
            Console.WriteLine(a + " " + b);

            var male1 = new Male(1);
            male1.Age = 25;
            var male2 = male1;
            male1.Age = 30;
            Console.WriteLine(male1.Age + " " + male2.Age);
            Console.WriteLine("--------------------------------------");
        }

        private static void TestClasses()
        {
            try
            {
                OrdinaryLeastSquareTest.Test();
                IOUtilTest.Test();
                StateInfoTest.Test();
                DataServiceTest.Test();
                MaleTest.Test();
                FemaleTest.Test();
                PersonTest.Test();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
