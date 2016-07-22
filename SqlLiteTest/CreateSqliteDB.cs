using System;
using System.Data.SQLite;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlLiteTest
{
    public class CreateSqliteDB
    {
        public void createDemoDB()
        {
            //Create Database if does not exist
            //string filePath = (Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)).ToString() + "\\SqlLiteTest";
            //string dbName = "sqlite.db";
            //string fullPath = $"{filePath}\\{dbName}";

            Utility utility = new Utility();
            List<string> fileAndDirectoryInfo = utility.generateFileAndDirectoryInfo("SqlLiteTest", "sqlite.db");
            string filePath = fileAndDirectoryInfo[0];
            string dbName = fileAndDirectoryInfo[1];
            string fullPath = fileAndDirectoryInfo[2];

            sqliteCreation createSqliteDB = new sqliteCreation();
            createSqliteDB.createDBIfNotExist(filePath, dbName);
            SQLiteConnection dbConnection = new SQLiteConnection($"Data Source = {fullPath};Version=3;");
            dbConnection.Open();

            //Create table 'userInfo' with 2 differenet colulmns
            Dictionary<string, string> userInfoColumns = new Dictionary<string, string>();
            userInfoColumns.Add("int", "UniqueID");
            userInfoColumns.Add("text", "Username");
            Dictionary<string, Dictionary<string, string>> userInfoTable = new Dictionary<string, Dictionary<string, string>>();
            userInfoTable.Add("userInfo", userInfoColumns);

            createSqliteDB.generateTables(userInfoTable, dbConnection);

            //Create table 'passWords' with 2 differenet colulmns
            Dictionary<string, string> passWordsColumns = new Dictionary<string, string>();
            passWordsColumns.Add("int", "UniqueID");
            passWordsColumns.Add("text", "Password");
            Dictionary<string, Dictionary<string, string>> passWordsTable = new Dictionary<string, Dictionary<string, string>>();
            passWordsTable.Add("passWords", passWordsColumns);

            createSqliteDB.generateTables(passWordsTable, dbConnection);

            //Close the database connection
            dbConnection.Close();
        }

        public void createRealDB()
        {

        }
    }
}
