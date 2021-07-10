using System;
using System.Collections.Generic;
using System.Text;

namespace HeartDisease.Models
{
    public class StatisticInfo
    {
        public List<double> GendersType { get; set; } = new List<double>();
        public List<double> Ages { get; set; } = new List<double>();
        public List<double> Thalach { get; set; } = new List<double>();
        public List<Feature> Features { get; set; } = new List<Feature>();
        public List<CorrelationCoefficient> CorrelationCoefficients { get; set; } = new List<CorrelationCoefficient>();

        public void PrintStatInfo(Person[] persons)
        {
            if (persons != null)
            {
                for (int i = 0; i < persons.Length && persons[i] != null; i++)
                {
                    GendersType.Add(persons[i].GetType() == typeof(Male) ? 1 : 0);
                    Ages.Add(persons[i].Age);
                    Thalach.Add(persons[i].MaxHeartRateAchieved);
                }

                ConfigureStatisticInfo();
                Messages.PrintStatisticMessage(this);
            }
        }

        private void ConfigureStatisticInfo()
        {
            Features.AddRange(GetFeatures(Ages.ToArray(), GendersType.ToArray(), Thalach.ToArray()));
            CorrelationCoefficients.AddRange(GetCorrelationCoefficients(Ages.ToArray(), GendersType.ToArray(), Thalach.ToArray()));
        }

        private List<Feature> GetFeatures(double[] ages, double[] genders, double[] thalach)
        {
            return new List<Feature>()
            {
                new Feature()
                {
                    Name = "Feature 1",
                    Mean = Stat.Mean(genders),
                    Std = Stat.Std(genders)
                },
                new Feature()
                {
                    Name = "Feature 2",
                    Mean = Stat.Mean(ages),
                    Std = Stat.Std(ages)
                },
                new Feature()
                {
                    Name = "Feature 3",
                    Mean = Stat.Mean(thalach),
                    Std = Stat.Std(thalach)
                }
            };
        }

        private List<CorrelationCoefficient> GetCorrelationCoefficients(double[] ages, double[] genders, double[] thalach)
        {
            return new List<CorrelationCoefficient>()
            {
                new CorrelationCoefficient()
                {
                    Name = "Age & Max Heart Rate",
                    Value = Stat.Correlation(ages, thalach)
                },
                new CorrelationCoefficient()
                {
                    Name = "Gender & Max Heart Rate",
                    Value = Stat.Correlation(genders, thalach)
                }
            };
        }
    }
}
