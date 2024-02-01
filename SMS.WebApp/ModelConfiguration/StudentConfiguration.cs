using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SMS.WebApp.Models;

namespace SMS.WebApp.ModelConfiguration;

public class StudentConfiguration : IEntityTypeConfiguration<Studdent>
{
    public void Configure(EntityTypeBuilder<Studdent> builder)
    {
        builder.ToTable(nameof(Studdent));
        //builder.ToTable("Student");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).HasMaxLength(50).IsRequired();
        builder.Property(x => x.Address).HasMaxLength(250).IsRequired();
        builder.Property(x => x.Email).HasMaxLength(50).IsRequired();
        builder.Property(x => x.Phone).HasMaxLength(15).IsRequired();
        builder.Property(x => x.City).HasMaxLength(60).IsRequired();
    }
}
