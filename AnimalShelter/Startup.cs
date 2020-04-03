using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using AnimalShelter.Models;

namespace AnimalShelter
{
  public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddDbContext<AnimalShelterContext>(opt =>
					opt.UseMySql(Configuration.GetConnectionString("DefaultConnection")));
			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

			services.AddSwaggerGen(c =>
			{
					c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
			});

		}

		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
					app.UseDeveloperExceptionPage();
			}
			else
			{
					app.UseHsts();
			}
			
			app.UseStaticFiles();
			app.UseCookiePolicy();
			app.UseSwagger();
			app.UseSwaggerUI(c =>
			{
					c.SwaggerEndpoint("/swagger/v1/swagger.json", "Animal Shelter API V1");
			});

			app.UseMvc();
		}
	}
}