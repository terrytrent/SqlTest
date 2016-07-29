using System;
using System.Data.SQLite;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SqlLiteTest
{
    class GetSqliteData
    {
        public static void getDemoData()
        {
            List<string> fileAndDirectoryInfo = Utility.generateFileAndDirectoryInfo("SqlLiteTest", "sqlite.db");
            string fullPath = fileAndDirectoryInfo[2];

            SQLiteConnection dbConnection = new SQLiteConnection($"Data Source = {fullPath};Version=3;");
            dbConnection.Open();

            string getDataQuery = "select * from userInfo";
            SQLiteCommand getData = new SQLiteCommand(getDataQuery, dbConnection);
            SQLiteDataReader getDataResults = getData.ExecuteReader();

            Dictionary<int, string> getDataResultsDictionary = new Dictionary<int, string>();

            int uniqueid = new int();
            string username = null;

            while (getDataResults.Read())
            {
                uniqueid = getDataResults.GetInt16(0);
                username = getDataResults.GetString(1);
                getDataResultsDictionary.Add(uniqueid, username);

                Console.WriteLine($"Username: {username} \nUniqueID: {uniqueid}\n");
                MessageBox.Show($"Username: {username} \nUniqueID: {uniqueid}\n");
            }

            
        }

        public void getRealData()
        {

        }
    }
}
