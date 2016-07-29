using System;
using System.Data.SQLite;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlLiteTest
{
    public class PopulateSqliteDB
    {
        public static void demoData()
        {
            List<string> fileAndDirectoryInfo = Utility.generateFileAndDirectoryInfo("SqlLiteTest", "sqlite.db");
            string fullPath = fileAndDirectoryInfo[2];

            SQLiteConnection dbConnection = new SQLiteConnection($"Data Source = {fullPath};Version=3;");
            dbConnection.Open();

            string tableName = "userInfo";

            List<string> columns = new List<string>();
            columns.Add("UniqueID");
            columns.Add("Username");

            List<string> values1 = new List<string>();
            values1.Add("8");
            values1.Add("htrent");

            List<string> values2 = new List<string>();
            values2.Add("9");
            values2.Add("itrent");

            List<string> values3 = new List<string>();
            values3.Add("10");
            values3.Add("jtrent");

            List<string> values4 = new List<string>();
            values4.Add("11");
            values4.Add("ktrent");

            List<string> values5 = new List<string>();
            values5.Add("12");
            values5.Add("ltrent");

            List<List<string>> values = new List<List<string>>();
            values.Add(values1);
            values.Add(values2);
            values.Add(values3);
            values.Add(values4);
            values.Add(values5);

            Dictionary<List<string>, List<List<string>>> dataToInsert = new Dictionary<List<string>, List<List<string>>>();
            dataToInsert.Add(columns, values);

            foreach(KeyValuePair<List<string>,List<List<string>>> dataSet in dataToInsert)
            {
                List<string> columnsFordata = dataSet.Key;

                string columnString = null;
                int i = 0;
                foreach(string columnName in columnsFordata)
                {
                    i++;
                    columnString += $"'{columnName}'";
                    if(i < columnsFordata.Count())
                    {
                        columnString += ",";
                    }
                }

                List<List<string>> valueSets = dataSet.Value;
                
                foreach (List<string> valueSet in valueSets)
                {
                    string valueString = null;
                    i = 0;

                    foreach (string value in valueSet)
                    {
                        i++;
                        valueString += $"'{value}'";
                        if (i < valueSet.Count())
                        {
                            valueString += ",";
                        }
                    }

                    string insertDataQuery = $"insert into {tableName} ({columnString}) values ({valueString})";
                    SQLiteCommand insertData = new SQLiteCommand(insertDataQuery, dbConnection);
                    insertData.ExecuteNonQuery();
                }
            }

            dbConnection.Close();
        }

        public void realData()
        {

        }
    }
}
