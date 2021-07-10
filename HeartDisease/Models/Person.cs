using System;
using System.Collections.Generic;
using System.Text;

namespace HeartDisease.Models
{
    public class Person
    {
        public int Id { get; private set; }
        public double MaxHeartRateAchieved { get; set; }
        public int Age { get; set; }

        public Person(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Id must greater than 0");
            }

            Id = id;
        }

        public override string ToString()
        {
            return $"ID: {Id}, Age: {Age}, Max Heart Rate Achieved: {MaxHeartRateAchieved}";
        }

        public virtual string ToWriter()
        {
            return $"{Id}, {Age}, {Math.Round(MaxHeartRateAchieved)}";
        }
    }
}
