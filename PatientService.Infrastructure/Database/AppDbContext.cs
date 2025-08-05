using Microsoft.EntityFrameworkCore;
using PatientService.Domain.Entities;
using System.Reflection;

namespace PatientService.Infrastructure.Database
{
	public class AppDbContext : DbContext
	{
		public DbSet<Patient> Patients { get; set; }

		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{ }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			Assembly assemblyWithConfigurations = GetType().Assembly;
			modelBuilder.ApplyConfigurationsFromAssembly(assemblyWithConfigurations);
		}
	}
}
