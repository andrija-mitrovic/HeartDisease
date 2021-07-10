using HeartDisease.Models;
using HeartDisease.Predictors;
using System;
using System.Collections.Generic;
using System.Text;

namespace HeartDisease.TestClasses
{
    public class Test
    {
        private static IPredictor dummyPredictor = new DummyPredictor();
        private static int[,] x =
            {
                {1, 63, 1, 150}, {2, 37, 1, 187}, {3, 41, 0, 172}, {4, 56, 1, 178}, {5, 57, 0, 163},
                {6, 57, 1, 148}, {7, 56, 0, 153}, {8, 44, 1, 173}, {9, 52, 1, 162}, {10, 57, 1, 162}
            };

        public static void DummyTest()
        {
            Person person1 = new Male(1);
            person1.Age = 57;
            person1.MaxHeartRateAchieved = 142;
            var personGender1 = person1.GetType().Name == typeof(Male).Name ? "Male" : "Female";

            Person person2 = new Female(2);
            person2.Age = 56;
            person2.MaxHeartRateAchieved = 162;
            var personGender2 = person1.GetType().Name == typeof(Female).Name ? "Male" : "Female";


            string status1 = DummyModel(person1.Id, person1.Age, 155);
            string status2 = DummyModel(person2.Id, person2.Age, 155);

            Console.WriteLine("---------------------------------------------------------------");
            Console.WriteLine("Random Data 1: Age: " + person1.Age + ", Gender: " + personGender1 + ", Max Heart Rate Achieved: " +
                              person1.MaxHeartRateAchieved);
            Console.WriteLine("Heart rate status: Beats per Min MHR - " + status1);
            Console.WriteLine("Random Data 2: Age: " + person2.Age + ", Gender: " + personGender2 + ", Max Heart Rate Achieved: " +
                              person2.MaxHeartRateAchieved);
            Console.WriteLine("Heart rate status: Beats per Min MHR - " + status2);
            Console.WriteLine("---------------------------------------------------------------");
        }

        public static string DummyModel(int id, int age, int maxHart)
        {
            if (id <= 0) throw new ArgumentException("Id must be greater than 0");

            return dummyPredictor.Predict(age) > maxHart ? "High" : "Low";
        }

        public static void DummyTableData()
        {
            int errorCount = 0;
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Data " + i + 1 + ": Age: " + x[i, 1] + ", Gender: " + x[i, 2]);
                string result = DummyModel(x[i, 0], x[i, 1], 155);

                string fileCategory = x[i, 3] > 155 ? "High" : "Low";
                Console.WriteLine("File Category: " + fileCategory);
                Console.WriteLine("Dummy Model Cat.: " + result);

                if (fileCategory == result)
                {
                    Console.WriteLine("Error = 0");
                }
                else
                {
                    errorCount++;
                    Console.WriteLine("Error = 1");
                }
            }

            Console.WriteLine("Total error: " + errorCount);
        }

        public static void TableData(double[] xt, double[] yt)
        {
            IPredictor predictor = new OLSPredictor(xt, yt);

            int errorCount = 0;
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Data " + i + 1 + ": Age: " + x[i, 1] + ", Gender: " + x[i, 2]);
                string result = DummyModel(predictor, x[i, 0], x[i, 1], 155);

                string fileCategory = x[i, 3] > 155 ? "High" : "Low";
                Console.WriteLine("File Category: " + fileCategory);
                Console.WriteLine("Dummy Model Cat.: " + result);

                if (fileCategory == result)
                {
                    Console.WriteLine("Error = 0");
                }
                else
                {
                    errorCount++;
                    Console.WriteLine("Error = 1");
                }
            }

            Console.WriteLine("Total error: " + errorCount);
        }

        public static string DummyModel(IPredictor predictor, int id, int age, int maxHart)
        {
            if (id <= 0) throw new ArgumentException("Id must be greater than 0");

            return predictor.Predict(age) > maxHart ? "High" : "Low";
        }
    }
}
