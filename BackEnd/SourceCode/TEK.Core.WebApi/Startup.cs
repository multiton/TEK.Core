using System;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Microsoft.EntityFrameworkCore;
using TEK.Core.ResourceAccess.EF;

namespace TEK.Core.WebApi
{
    public class Startup
    {
		readonly string AllowSpecificOrigins = "AllowSpecificOrigins";

		public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
			Configuration =	configuration ??
				throw new ArgumentException("NULL configuration is not allowed.");
		}

        public void ConfigureServices(IServiceCollection services)
        {
			services.AddCors(options =>
			{
				options.AddPolicy(name: AllowSpecificOrigins, builder =>
				{
					builder.WithOrigins("http://localhost:4200");
				});
			});

			services.AddControllers();

			services.AddDbContext<DataContext>(options =>
				options.UseSqlServer(Configuration.GetConnectionString("TEK.Core")));
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();	

			app.UseRouting();

			app.UseCors(AllowSpecificOrigins);

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}