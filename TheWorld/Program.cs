using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;

namespace TheWorld
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Instead of printing helloworld like in a console application,
            //here, we start a web host builder. Kestrel is the name of the web server.
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()  // create a new instance of Startup
                .UseApplicationInsights()
                .Build();

            host.Run();
        }
    }
}
