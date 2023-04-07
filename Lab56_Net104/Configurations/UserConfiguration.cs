using Buoi1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Buoi1.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasColumnType("varchar(256)");
            builder.Property(x => x.Password).HasColumnType("varchar(256)");
            builder.HasOne(p => p.Role).WithMany(p => p.Users).
                HasForeignKey(p => p.IdCv);
            builder.HasAlternateKey(p => p.Name); // Unique
        }
    }
}
