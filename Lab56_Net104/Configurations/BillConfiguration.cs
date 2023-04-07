using Buoi1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Buoi1.Configurations
{
    public class BillConfiguration : IEntityTypeConfiguration<Bill>
    {
        public void Configure(EntityTypeBuilder<Bill> builder)
        {
            builder.ToTable("HoaDon"); // Đặt tên bảng
            builder.HasKey(p => p.Id); // Thiết lập khóa chính
            //Thiết lập cho các thuộc tính
            builder.Property(p => p.Status).HasColumnType("int").IsRequired(); // int not null
            builder.HasOne(x => x.User).WithMany(x => x.Bill).HasForeignKey(x => x.UserId).HasConstraintName("FK_User");
        }
    }
}
