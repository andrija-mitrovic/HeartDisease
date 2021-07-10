using System;
using System.Collections.Generic;
using System.Text;

namespace HeartDisease.Constants
{
    public class DataConstants
    {
        private const string DEFAULT_ROOT_BASE = "../../../Data/Csv/";

        public const string INPUT_DATA_FILE_PATH = DEFAULT_ROOT_BASE + "InputFile.csv";
        public const string DEFAULT_OUTPUT_DATA_LOCATION = DEFAULT_ROOT_BASE + "OutputFile.csv";
        public const string TEST_DATA_FILE_PATH = DEFAULT_ROOT_BASE + "TestFile.csv";
        public const string TRAINING_DATA_FILE_PATH = DEFAULT_ROOT_BASE + "TrainingFile.csv";
    }
}
