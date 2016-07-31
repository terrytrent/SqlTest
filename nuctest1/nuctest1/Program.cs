using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nuctest1
{
    class Program
    {
        static void Main(string[] args)
        {
            //NUCAssetComputer Comp1 = new NUCAssetComputer();
            //Comp1.setInfo("123456", "NUCi5", Statuses.Available);
            //Comp1.getInfo();
            //Comp1.storeInfoInDB();

            //NUCAssetStorage HD1 = new NUCAssetStorage();
            //HD1.setInfo("654321", "Seagate", Statuses.Available, AssetTypes.HD, 256);
            //HD1.getInfo();
            //HD1.storeInfoInDB();

            SqlConnection myConnection = new SqlConnection("user id=ttrent;" +
                                       "password=;server=localhost;" +
                                       "Trusted_Connection=yes;" + "database=test;");
            try
            {
                myConnection.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            //string command = "CREATE DATABASE test";
            //SqlCommand sqlCommand = new SqlCommand(command, myConnection);
            //sqlCommand.ExecuteNonQuery();

            //string command = "CREATE TABLE test2 (ID int PRIMARY KEY NOT NULL, Name varchar(25) NOT NULL)";
            //SqlCommand sqlCommand = new SqlCommand(command, myConnection);
            //sqlCommand.ExecuteNonQuery();

            string command = "INSERT INTO test2 (ID,Name) VALUES (1,'ok')";
            SqlCommand sqlCommand = new SqlCommand(command, myConnection);
            sqlCommand.ExecuteNonQuery();

        }
    }
}
