using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace PatientService.Infrastructure.Database
{
	internal class DesignTimeAppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
	{
		public AppDbContext CreateDbContext(string[] args)
		{
			// Get environment
			string environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

			// Build config
			IConfiguration config = new ConfigurationBuilder()
				.SetBasePath(Directory.GetCurrentDirectory())
				.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
				.AddJsonFile($"appsettings.{environment}.json", optional: true)
				.AddEnvironmentVariables()
				.Build();

			var builder = new DbContextOptionsBuilder<AppDbContext>();

			var connectionString = config.GetConnectionString("DefaultConnectionString");

			builder.UseSqlServer(connectionString);

			return new AppDbContext(builder.Options);

		}
	}
}
