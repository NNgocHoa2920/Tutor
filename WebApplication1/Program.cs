using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

var builder = WebApplication.CreateBuilder(args);//tạo ra 1 ứng dụng web

// Add services to the container.
builder.Services.AddControllersWithViews();// add services
builder.Services.AddDbContext<TutorDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


var app = builder.Build();   // chạy web của mình lên

// Configure the HTTP request pipeline.
//kiểm tra xem có phải môi trường dev hay k
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");   //thiết lâp đường dẫn tung ra ngoại lệ
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();   //cấu hình điều hướng vs https
app.UseStaticFiles();  //sử dụng tài nguyên tĩnh

app.UseRouting(); //cấu hình định tuyến trong mô hình mvc

app.UseAuthorization(); //cơ chế chứng thực
     // sau nà thiết lập theo seesion cokki hay người dùng chỉ định ra thì ì ta thay đổi

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=SanPham}/{action=Index}/{id?}");
 
// https:local.../controler/action/id
//đến trang edit của sanpham   có id là 1
//https: local.../sanpham/edit/1
app.Run();
