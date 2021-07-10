using HeartDisease.Constants;
using HeartDisease.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace HeartDisease.Data
{
    public class IOUtil
    {
        private const int MALE_SIGN = 1;

        public static Person[] LoadData(string inputFilePath)
        {
            Person[] persons = null;
            try
            {
                var lineNum = File.ReadLines(inputFilePath).Count();
                persons = new Person[lineNum];
                ReadDataFromFile(persons, inputFilePath);
            }
            catch(FileNotFoundException ex)
            {
                Console.WriteLine($"File could not be found:\n {ex.Message}");
            }
            catch(Exception ex)
            {
                Console.WriteLine($"File could not be read:\n {ex.Message}");
            }

            return persons;
        }

        private static void ReadDataFromFile(Person[] persons, string pathFile)
        {
            using (var reader=new StreamReader(pathFile))
            {
                int currentLine = 0;
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    currentLine++;
                    if (currentLine == 1)
                    {
                        // Skip the header
                        continue;
                    }

                    string[] values = line.Split(',');

                    persons[currentLine - 2] = GetTypeOfPerson(Convert.ToInt32(values[1]), currentLine - 1);

                    if (pathFile == DataConstants.INPUT_DATA_FILE_PATH)
                    {
                        persons[currentLine - 2].Age = Convert.ToInt32(values[0]);
                        persons[currentLine - 2].MaxHeartRateAchieved = Convert.ToInt32(values[7]);
                    }
                    else
                    {
                        persons[currentLine - 2].Age = Convert.ToInt32(values[2]);
                        persons[currentLine - 2].MaxHeartRateAchieved = Convert.ToInt32(values[3]);
                    }

                    Messages.PrintPersonInfo(persons[currentLine -2]);
                }
            }
        }

        private static Person GetTypeOfPerson(int sign, int id)
        {
            if (sign == MALE_SIGN)
            {
                return new Male(id);
            }
            else
            {
                return new Female(id);
            }
        }

        public static void SaveOutput(Person[] persons, string outputFilePath = DataConstants.DEFAULT_OUTPUT_DATA_LOCATION)
        {
            try
            {
                if (persons != null)
                {
                    WriteDataToFile(persons, outputFilePath);

                    string fileName = outputFilePath.Substring(outputFilePath.LastIndexOf("/") + 1, outputFilePath.Length - outputFilePath.LastIndexOf("/") - 1);
                    Messages.PrintSuccesfulLoading(fileName);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Data cannot be written to a file:\n {ex.Message}");
            }
        }

        private static void WriteDataToFile(Person[] persons, string filePath)
        {
            using (var writer = new StreamWriter(filePath))
            {
                writer.WriteLine("Id,Age,MaxHeartRateAchieved");
                for (int i = 0; i < persons.Length && persons[i] != null; i++)
                {
                    writer.WriteLine(persons[i].ToWriter());
                }
            }
        }
    }
}
