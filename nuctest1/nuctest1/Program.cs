using System;
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

            NUCAssetStorage HD1 = new NUCAssetStorage();
            HD1.setInfo("654321", "Seagate", Statuses.Available, AssetTypes.HD, 256);
            HD1.getInfo();
            HD1.storeInfoInDB();
        }
    }
}
