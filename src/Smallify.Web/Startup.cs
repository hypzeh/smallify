using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Smallify.Web
{
	public class Startup
	{
		public readonly IConfiguration _configuration;

		public Startup(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddSpaStaticFiles(configuration =>
			{
				configuration.RootPath = "./wwwroot/";
			});
		}

		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			app.UseStaticFiles();
			app.UseSpaStaticFiles();
			app.UseSpa(spa =>
			{
				spa.Options.SourcePath = "./";
			});
		}
	}
}
