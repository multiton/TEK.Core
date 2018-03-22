using System;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using TEK.Core.ResourceAccess.EF;

namespace TEK.Core.WebApi
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
			Configuration =	configuration ?? throw new ArgumentException("NULL configuration is not allowed.");
		}

		// This method gets called by the runtime, use it to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

			services.AddCors(o => o.AddPolicy("AllowSpecificOrigin", builder =>
			{
				builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader().AllowCredentials();
			}));

			services.AddDbContext<DataContext>(options => options.UseSqlServer(Configuration.GetConnectionString("TEK.Core")));
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		// Also, see the next thread: https://stackoverflow.com/questions/31942037/how-to-enable-cors-in-asp-net-core
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

            app.UseMvc();
			app.UseCors("AllowSpecificOrigin");
		}
	}
}