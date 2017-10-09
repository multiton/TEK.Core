using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace TEK.Core.WebApi
{
    public class Program
    {
        public static long TotalTime;

        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args).UseStartup<Startup>().Build();
    }
}