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
            //calling createDemoDB method - look at code in CreateSqliteDB.cs to see how to create real database
            CreateSqliteDB createSqliteDB = new CreateSqliteDB();
            createSqliteDB.createDemoDB();

            PopulateSqliteDB populateSqliteDB = new PopulateSqliteDB();
            //calling demoData method - look at code in PopulateSqliteDB to see how to populate real data
            populateSqliteDB.demoData();
        }
    }

    
}
