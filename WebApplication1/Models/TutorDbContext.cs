using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models
{
    public class TutorDbContext : DbContext
    {
        public TutorDbContext(DbContextOptions<TutorDbContext> options) : base(options)
        {
        }
        //dbset dùng để trỏ tới mỗi bảng: 
        public DbSet<User> Users { get; set; }
        public DbSet<SanPham> SanPhams { get; set;}
        public DbSet<HoaDon> HoaDons { get; set; }
    }
}
