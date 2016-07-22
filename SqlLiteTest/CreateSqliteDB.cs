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
        public CreateSqliteDB()
        {
            string filePath = (Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)).ToString() + "\\SqlLiteTest";
            string dbName = "sqlite.dba";
            sqliteCreation createSqliteDB = new sqliteCreation();
            //createSqliteDB.createDBIfNotExist(filePath, dbName);
            SQLiteConnection dbConnection =new SQLiteConnection($"{dbName};Version=3;");
            dbConnection.Open();


            Dictionary<string, string> userInfoColumns = new Dictionary<string, string>();
            userInfoColumns.Add("int", "UniqueID");
            userInfoColumns.Add("text", "Username");
            Dictionary<string, Dictionary<string,string>> userInfoTable = new Dictionary<string, Dictionary<string, string>>();
            userInfoTable.Add("userInfo", userInfoColumns);

            Dictionary<string, string> passWordsColumns = new Dictionary<string, string>();
            passWordsColumns.Add("int", "UniqueID");
            passWordsColumns.Add("text", "Password");
            Dictionary<string, Dictionary<string, string>> passWordsTable = new Dictionary<string, Dictionary<string, string>>();
            userInfoTable.Add("passWords", passWordsColumns);

            createSqliteDB.generateTables(userInfoTable,dbConnection);
            createSqliteDB.generateTables(passWordsTable,dbConnection);

            dbConnection.Close();
        }
    }
}
