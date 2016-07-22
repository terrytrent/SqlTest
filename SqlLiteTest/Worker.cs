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
            //PopulateSqliteDB populateSqliteDB = new PopulateSqliteDB();
        }
    }

    
}
