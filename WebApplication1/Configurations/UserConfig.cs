using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication1.Models;

namespace WebApplication1.Configurations
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("IU SỜ"); // ĐẶT TÊN BẢNG
            //builder.HasNoKey();//không khóa
            builder.HasKey(x => x.Id);
            // builder.HasKey(p => new { p.Id, p.Name });
            //Khóa chính composite key ( 1 khóa chính gồm nhiều côt)


            //thiết lâp thuộc tính cho cột 
            builder.Property(x => x.Name).HasColumnName("Tên")
                .HasColumnType("nvarchar(50)");
            builder.Property(x => x.Name).IsRequired();// xét not null

            builder.Property(d => d.Address).HasColumnName("Địa chỉ")
                .HasMaxLength(100).IsFixedLength().IsUnicode(true); // nvarchar(100)
        }
    }
}
