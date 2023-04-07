using Buoi1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Buoi1.Configurations
{
    public class BillDetailConfiguration : IEntityTypeConfiguration<BillDetail>
    {
        public void Configure(EntityTypeBuilder<BillDetail> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(p => p.Quanlity).IsRequired().
                HasColumnType("int");
            // Set khóa ngoại
            builder.HasOne(p => p.Bill).WithMany(p => p.BillDetails).
                HasForeignKey(p => p.IdHD).HasConstraintName("FK_HD");
            builder.HasOne(p => p.Product).WithMany(p => p.BillDetails).
                HasForeignKey(p => p.IdSp).HasConstraintName("FK_SP");
        }
    }
}
