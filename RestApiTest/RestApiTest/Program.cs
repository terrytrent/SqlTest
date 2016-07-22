using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

public enum HttpVerb
{
    GET,
    POST,
    PUT,
    DELETE
}

namespace RestApiTest
{
    class Program
    {
        static void Main(string[] args)
        {

            var url = "http://api.openweathermap.org/data/2.1/find/city?lat=39.0438&lon=77.4874&cnt=10";

            var syncClient = new WebClient();
            var content = syncClient.DownloadString(url);

        }
    }
}
