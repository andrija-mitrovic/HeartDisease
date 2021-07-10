using HeartDisease.Constants;
using HeartDisease.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HeartDisease.Data
{
    public class DataService
    {
        private const int TRAINING_DATASET = 60; //%
        private const int TEST_DATASET = 40; //%
                                             
        public void SetTrainingAndTestDataset(Person[] persons)
        {
            if (persons != null && persons.Length > 0)
            {
                Person[] trimPersons = new Person[persons.Length];
                ExtractPersonsFromOneArrayToAnother(persons, trimPersons);

                //spliting data
                Person[] training = new Person[persons.Length * TRAINING_DATASET / 100 + 1];
                Person[] test = new Person[persons.Length * TEST_DATASET / 100 + 1];
                SplitData(trimPersons, training, test);

                //Saving data into two distict csv files
                IOUtil.SaveOutput(test, DataConstants.TEST_DATA_FILE_PATH);
                IOUtil.SaveOutput(training, DataConstants.TRAINING_DATA_FILE_PATH);

                Messages.PrintSplitingMessage();
            }
        }

        private static void ExtractPersonsFromOneArrayToAnother(Person[] persons, Person[] trimPersons)
        {
            int j = 0;
            for (int i = 0; i < persons.Length && persons[i] != null; i++)
            {
                //detecting and removing invalid data
                if ((persons[i].GetType() != typeof(Male) || persons[i].GetType() != typeof(Female)) ||
                    (persons[i].Age < 0 && persons[i].Age > 200) || (persons[i].MaxHeartRateAchieved < 0))
                {
                    trimPersons[j] = persons[i];
                    j++;
                }
            }
        }

        private static void SplitData(Person[] trimPersons, Person[] training, Person[] test)
        {
            int k = 0, l = 0;

            for (int i = 0; i < trimPersons.Length; i++)
            {
                if (i < trimPersons.Length * TRAINING_DATASET / 100)
                {
                    training[k] = trimPersons[i]; // 60% TRAINING DATASET
                    k++;
                }
                else
                {
                    test[l] = trimPersons[i]; // 40% TEST DATASET
                    l++;
                }
            }
        }
    }
}
