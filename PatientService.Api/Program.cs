
using Microsoft.EntityFrameworkCore;
using PatientService.Api.JsonConverters;
using PatientService.Application.Filters;
using PatientService.Application.Filters.Abstractions;
using PatientService.Application.Interfaces;
using PatientService.Application.UseCases.GetPatients;
using PatientService.Application.UseCases.GetPatients.PatientFilters;
using PatientService.Application.UseCases.GetPatients.PatientFilters.DateSpecifications;
using PatientService.Application.UseCases.GetPatients.PatientFilters.GenderSpecifications;
using PatientService.Domain.Entities;
using PatientService.Infrastructure.Database;
using PatientService.Infrastructure.Database.Repositories;
using System.Text.Json;

namespace PatientService.Api
{
	public class Program
	{
		public static async Task Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			builder.Services.AddControllers()
				.AddJsonOptions(options =>
				{
					options.JsonSerializerOptions.Converters.Add(new GivenNameConverter());
					options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
					options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
				});

			builder.Services.AddOpenApi();

			builder.Services
				.ConfigureDbContext(builder.Configuration)
				.AddMediatrServices()
				.AddFilterServices()
				.AddHealthChecks(builder.Configuration)
				.AddInfrastructureServices();

			var app = builder.Build();

			using (var scope = app.Services.CreateScope())
			{
				var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
				await db.Database.MigrateAsync();
			}

			if (app.Environment.IsDevelopment())
			{
				app.MapOpenApi();
				app.UseSwaggerUI(options =>
				{
					options.SwaggerEndpoint("/openapi/v1.json", "v1");
				});
			}

			app.UseHttpsRedirection();

			app.UseAuthorization();

			app.MapHealthChecks("/health");

			app.MapControllers();

			app.Run();
		}
	}

	public static class Extensions
	{
		public static IServiceCollection ConfigureDbContext(this IServiceCollection services, IConfiguration configuration)
		{
			var connectionString = configuration.GetConnectionString("DefaultConnectionString");

			services.AddDbContext<AppDbContext>(builder =>
			{
				builder.UseSqlServer(connectionString, x => x.MigrationsAssembly(typeof(AppContext).Assembly.FullName));
			});

			return services;
		}

		public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
		{
			services.AddScoped<IPatientRepository, PatientRepository>();

			return services;
		}

		public static IServiceCollection AddMediatrServices(this IServiceCollection services)
		{
			services.AddMediatR(opts =>
			{
				opts.RegisterServicesFromAssemblyContaining<GetPatientsQuery>();
			});

			return services;
		}

		public static IServiceCollection AddFilterServices(this IServiceCollection services)
		{
			services.AddTransient(typeof(IFilterService<,>), typeof(FilterService<,>));

			services.AddTransient<IFilterHandler<Patient, PatientFilterContext>, DateWithTimeFilter>();
			services.AddTransient<IFilterHandler<Patient, PatientFilterContext>, DateWithoutTimeFilter>();
			services.AddTransient<IFilterHandler<Patient, PatientFilterContext>, GenderFilter>();

			return services;
		}

		public static IServiceCollection AddHealthChecks(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddHealthChecks();

			return services;
		}
	}
}
