using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace ConnectCD_NetCoreWebApi
{
    public class Program
    {
        public static void Main(string[] args) =>

             new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseStartup<Startup>().UseUrls("http://0.0.0.0:5050")
                .UseApplicationInsights()
                .Build().Run();              
    } 
}
