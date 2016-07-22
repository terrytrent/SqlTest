using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlLiteTest
{
    public class Worker
    {
        public Worker()
        {
            Work();
        }

        public void Work()
        {
            CreateSqliteDB createSqliteDB = new CreateSqliteDB();
            //calling createDemoDB method - look at code in CreateSqliteDB.cs to see how to create real database
            createSqliteDB.createDemoDB();

            PopulateSqliteDB populateSqliteDB = new PopulateSqliteDB();
            //calling demoData method - look at code in PopulateSqliteDB to see how to populate real data
            populateSqliteDB.demoData();

            GetSqliteData getsqlitedata = new GetSqliteData();
            //calling getDemoData method - look at code in GetSqlitedata to see how to populate real data
            getsqlitedata.getDemoData();
        }
    }

    
}
