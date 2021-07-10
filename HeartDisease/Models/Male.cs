using System;
using System.Collections.Generic;
using System.Text;

namespace HeartDisease.Models
{
    public class Male : Person
    {
        public Male(int id) : base(id) 
        {

        }

        public override string ToString()
        {
            return $"ID: {Id}, Gender: {typeof(Male).Name}, Age: {Age}, Max Heart Rate Achieved: {MaxHeartRateAchieved}";
        }

        public override string ToWriter()
        {
            return $"{Id},{1},{Age},{MaxHeartRateAchieved}";
        }
    }
}
