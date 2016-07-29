using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlLiteTest
{
    public class Utility
    {
        public static bool checkIsvalid(string comparison, string pattern)
        {
            Regex comparisonRegex = new Regex(pattern);
            bool match = comparisonRegex.IsMatch(comparison);
            return match;
        }

        public static void notValidThrowException(string objectToBeValidated, string message, bool isObjectValidated, string nameOfObjectToBeValidated)
        {
            if (!isObjectValidated)
            {
                throw new System.Exception($"{nameOfObjectToBeValidated} {message}: {objectToBeValidated}");
            }
        }

        public static List<string> generateFileAndDirectoryInfo(string projectName,string dbName)
        {
            string filePath = (Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)).ToString() + $"\\{projectName}";
            string fullPath = $"{filePath}\\{dbName}";

            List<string> dataToReturn = new List<string>();
            dataToReturn.Add(filePath);
            dataToReturn.Add(dbName);
            dataToReturn.Add(fullPath);

            return dataToReturn;
        }
    }
}
