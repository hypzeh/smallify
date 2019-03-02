using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Smallify.Authentication
{
	public class Startup
	{
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddSpaStaticFiles(configuration =>
			{
				configuration.RootPath = "wwwroot";
			});
		}

		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			app.UseDefaultFiles();
			app.UseSpaStaticFiles();
			app.UseSpa(spa =>
			{
				spa.Options.SourcePath = ".";
			});
		}
	}
}
