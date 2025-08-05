using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PatientService.Domain.Entities;
using PatientService.Domain.ValueObjects;

namespace PatientService.Infrastructure.Database.EntityConfigurations
{
	internal class PatientEntityConfigurator : IEntityTypeConfiguration<Patient>
	{
		public void Configure(EntityTypeBuilder<Patient> builder)
		{
			builder.HasKey(x => x.Id);

			builder.HasIndex(x => x.BirthDate);

			builder.Property(x => x.Gender)
			   .HasConversion(
				   v => v.ToString(),
				   v => (Gender)Enum.Parse(typeof(Gender), v)
			   );

			builder.OwnsOne(x => x.Name, name =>
			{
				name.OwnsMany(n => n.GivenNames, givenNames =>
				{
					givenNames.WithOwner().HasForeignKey("PatientId");
					givenNames.Property(g => g.Value).HasColumnName("GivenName");
				});
			});
		}
	}
}
