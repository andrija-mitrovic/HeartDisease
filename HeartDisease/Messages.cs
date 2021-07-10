using HeartDisease.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HeartDisease
{
    public static class Messages
    {
        public static void PrintProjectHeadMessage(ProjectInfo projectInfo)
        {
            Console.WriteLine("==============================================================");
            Console.WriteLine(projectInfo.AuthorFirstName + " " + projectInfo.AuthorLastName);
            Console.WriteLine(projectInfo.Info);
            Console.WriteLine(projectInfo.MethodUsed);
            Console.WriteLine($"Dataset: {projectInfo.DatasetName}");
            Console.WriteLine(projectInfo.DatasetUrl);
            Console.WriteLine("==============================================================");
            Console.WriteLine("\n");
        }

        public static void PrintLoadingDataMessage(string loadingInto)
        {
            Console.WriteLine($"-------------Loading data into {loadingInto}------------------------\n");
        }

        public static void PrintSplitingMessage()
        {
            Console.WriteLine("-------------Spliting clean data into features----------------\n");
        }

        public static void PrintSuccesfulLoading(string name)
        {
            Console.WriteLine($"-------------Data is successfully saved into file: {name}------------\n");
        }

        public static void PrintStatisticMessage(StatisticInfo statisticInfo)
        {
            Console.WriteLine("--------------------------------------------------------------");
            Console.WriteLine($"Feature       Mean                  Std");
            Console.WriteLine("--------------------------------------------------------------");

            statisticInfo.Features.ForEach(delegate (Feature feature)
            {
                Console.WriteLine(feature.Name + "     " + feature.Mean + "    " + feature.Std);
            });

            Console.WriteLine("--------------------------------------------------------------");
            statisticInfo.CorrelationCoefficients.ForEach(delegate (CorrelationCoefficient correlation)
            {
                Console.WriteLine(correlation.Name + "Achieved: " + correlation.Value);
            });
            Console.WriteLine("--------------------------------------------------------------\n");
        }

        public static void PrintPersonInfo(Person person)
        {
            Console.WriteLine(person.ToString());
        }
    }
}
