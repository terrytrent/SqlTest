using System;
using System.Data.SQLite;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlLiteTest
{
    public class sqliteCreation
    {
        

        private void createDirectoryIfNotExist(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }

        public void createDBIfNotExist(string filePath, string dbName)
        {
            Utility utility = new Utility();

            string fullPath = $"{filePath}\\{dbName}";

            string filePathRegex = @"^([\w]\:\\|\\\\)([a-zA-z\s\d\\_.-]+)(?:[^\\])$";
            bool filePathIsValid = utility.checkIsvalid(filePath, filePathRegex);
            utility.notValidThrowException(filePath, "is not valid", filePathIsValid, "File Path");


            createDirectoryIfNotExist(filePath);

            string dbNameRegex = @"^([\w\s\d\\_.-]+)+.(db)$";
            bool dbNameIsValid = utility.checkIsvalid(dbName, dbNameRegex);
            utility.notValidThrowException(dbName, "is not valid", dbNameIsValid, "DB Name");
           
            if(!File.Exists(fullPath))
            {
                SQLiteConnection.CreateFile(fullPath);
            }

        }

        private void createNewTable(Dictionary<string, Dictionary<string, string>> tableInfo, SQLiteConnection Connection)
        {
            foreach (KeyValuePair<string, Dictionary<string, string>> Columns in tableInfo)
            {
                string tableName = Columns.Key.ToString();
                string firstColumn = Columns.Value.First().Value;
                string firstType = Columns.Value.First().Key;

                string newTableQuery = $"CREATE TABLE {tableName} ({firstColumn} {firstType})";
                SQLiteCommand NewTable = new SQLiteCommand(newTableQuery, Connection);
                NewTable.ExecuteNonQuery();

                foreach (KeyValuePair<string, string> column in Columns.Value.Skip(1))
                {
                    string columnName = column.Value.ToString();
                    string columnType = column.Key.ToString();

                    string addColumnQuery = $"ALTER TABLE {tableName} ADD COLUMN {columnName} {columnType};";
                    SQLiteCommand addColumn = new SQLiteCommand(addColumnQuery, Connection);
                    addColumn.ExecuteNonQuery();
                }
            }
        }

        public void generateTables(Dictionary<string,Dictionary<string,string>> tableInfo,SQLiteConnection Connection)
        {
            foreach (KeyValuePair<string,Dictionary<string,string>> Columns in tableInfo)
            {
                string tableName = Columns.Key;

                string getTableQuery = $"SELECT name FROM sqlite_master WHERE type='table' AND name='{tableName}';";
                SQLiteCommand getTable = new SQLiteCommand(getTableQuery, Connection);
                SQLiteDataReader tableResult = getTable.ExecuteReader();

                string getColumnQuery = $"PRAGMA table_info({tableName})";
                SQLiteCommand getColumn = new SQLiteCommand(getColumnQuery, Connection);
                SQLiteDataReader columnsResult = getColumn.ExecuteReader();
                List<string> columnsList = new List<string>();

                while(columnsResult.Read())
                {
                    string columnName = columnsResult.GetString(1);
                    columnsList.Add(columnName);
                }

                if (tableResult.Read())
                {
                    bool columnsGood = true;

                    foreach (KeyValuePair<string,string> column in Columns.Value)
                    {
                        string columnName = column.Value;

                        if(!columnsList.Contains(columnName))
                        {
                            columnsGood = false;
                        }
                    }
                    if (!columnsGood)
                    {
                        tableResult.Close();
                        columnsResult.Close();
                        string deleteTableQuery = $"DROP TABLE {tableName}";
                        SQLiteCommand deleteTable = new SQLiteCommand(deleteTableQuery, Connection);
                        deleteTable.ExecuteNonQuery();

                        createNewTable(tableInfo, Connection);
                    }
                }
                else
                {
                    createNewTable(tableInfo, Connection);
                }
            }
        }
    }
}
