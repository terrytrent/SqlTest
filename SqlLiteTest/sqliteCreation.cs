using System;
using System.Data.SQLite;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlLiteTest
{
    public class sqliteCreation
    {
        private bool checkIsvalid(string comparison, string pattern)
        {
            Regex comparisonRegex = new Regex(pattern);
            bool match = comparisonRegex.IsMatch(comparison);
            return match;
        }

        private void notValidThrowException(string objectToBeValidated, bool isObjectValidated, string nameOfObjectToBeValidated)
        {
            if (!isObjectValidated)
            {
                throw new System.Exception($"{nameOfObjectToBeValidated} is not valid: {objectToBeValidated}");
            }
        }

        private void createDirectoryIfNotExist(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }

        public void createDBIfNotExist(string filePath, string dbName)
        {
            string fullPath = $"{filePath}\\{dbName}";

            string filePathRegex = @"^([\w]\:\\|\\\\)([a-zA-z\s\d\\_.-]+)(?:[^\\])$";
            bool filePathIsValid = checkIsvalid(filePath, filePathRegex);
            notValidThrowException(filePath,filePathIsValid, "File Path");

            createDirectoryIfNotExist(filePath);

            string dbNameRegex = @"^([\w\s\d\\_.-]+)+.(db)$";
            bool dbNameIsValid = checkIsvalid(dbName, dbNameRegex);
            notValidThrowException(dbName, dbNameIsValid, "DB Name");
           
            if(!File.Exists(fullPath))
            {
                SQLiteConnection.CreateFile(fullPath);
            }

        }

        private void createNewTable(Dictionary<string, Dictionary<string, string>> tableInfo, SQLiteConnection Connection)
        {
            string newTableQuery = $"";
            SQLiteCommand NewTable = new SQLiteCommand(newTableQuery, Connection);

            foreach (KeyValuePair<string, Dictionary<string, string>> Columns in tableInfo)
            {
                foreach (KeyValuePair<string, string> column in Columns.Value)
                {
                    string addColumnQuery = $"ALTER TABLE {Columns.Key} ADD COLUMN {column.Key} {column.Value};";
                    SQLiteCommand addColumn = new SQLiteCommand(addColumnQuery, Connection);
                }
            }
        }

        public void generateTables(Dictionary<string,Dictionary<string,string>> tableInfo,SQLiteConnection Connection)
        {
            foreach (KeyValuePair<string,Dictionary<string,string>> Columns in tableInfo)
            {
                string getTableQuery = $"SELECT name FROM my_db.sqlite_master WHERE type='table' AND name='{Columns.Key}';";
                SQLiteCommand getTable = new SQLiteCommand(getTableQuery, Connection);
                
                if(getTable != null)
                {
                    foreach (KeyValuePair<string,string> column in Columns.Value)
                    {
                        bool columnsGood = true;
                        int i = 0;
                        do
                        {
                            i++;
                            string getColumnQuery = $"";
                            SQLiteCommand getColumn = new SQLiteCommand(getColumnQuery, Connection);

                            if (getColumn == null)
                            {
                                columnsGood = false;
                            }
                        }
                        while (columnsGood && i <= (Columns.Value).Count);

                        if(!columnsGood)
                        {
                            string deleteTableQuery = $"";
                            SQLiteCommand deleteTable = new SQLiteCommand(deleteTableQuery, Connection);

                            newTable(tableInfo);
                            
                        }
                    }
                }
                else
                {
                    newTable(TableInfo);
                }
            }
            
        }

    }
}
