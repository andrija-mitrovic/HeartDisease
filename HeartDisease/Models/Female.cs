using System;
using System.Collections.Generic;
using System.Text;

namespace HeartDisease.Models
{
    public class Female : Person
    {
        public Female(int id) : base(id)
        {

        }

        public override string ToString()
        {
            return $"ID: {Id}, Gender: {typeof(Female).Name}, Age: {Age}, Max Heart Rate Achieved: {MaxHeartRateAchieved}";
        }

        public override string ToWriter()
        {
            return $"{Id},{0},{Age},{MaxHeartRateAchieved}";
        }
    }
}
