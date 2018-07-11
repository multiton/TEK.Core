using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.HttpSys;

namespace TEK.Core.WebApi
{
    public class Program
    {
        public static long TotalTime;

        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

		//public static IWebHost BuildWebHost(string[] args) =>
		//	WebHost.CreateDefaultBuilder(args).UseStartup<Startup>().Build();

		public static IWebHost BuildWebHost(string[] args) => WebHost.CreateDefaultBuilder(args)
			.UseStartup<Startup>()
			//.UseHttpSys(options =>
			//{
			//	options.Authentication.Schemes = AuthenticationSchemes.NTLM | AuthenticationSchemes.Negotiate;
			//	options.Authentication.AllowAnonymous = false;
			//})
			.Build();
	}
}