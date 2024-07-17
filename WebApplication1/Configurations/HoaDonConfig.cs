using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication1.Models;

namespace WebApplication1.Configurations
{
    public class HoaDonConfig : IEntityTypeConfiguration<HoaDon>
    {
        public void Configure(EntityTypeBuilder<HoaDon> builder)
        {
           builder.HasKey(x => x.Id);

            builder.HasOne(p => p.User).WithMany(p => p.HoaDons)
                .HasForeignKey(p => p.UserId).HasConstraintName("FK_User_HD");
            //với 1 user thì có nhiề hóa đơn
            //khóa ngoại là côt useridnoosi s bảng user
            //tên của khóa ngoại fk_user_hđ
        }
    }
}
