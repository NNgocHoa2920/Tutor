using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class SanPhamController : Controller
    {
        TutorDbContext _db;

        public SanPhamController(TutorDbContext db)
        {
            _db = db;
        }

        //hiển thị ra list san phẩm
        [HttpGet]
        public IActionResult Index()
        {
            var sanphamList = _db.SanPhams.ToList();
            return View(sanphamList);
        }
        //Thêm 1 san phẩm
        [HttpGet]
        public IActionResult Create() // dùng để khởi tạo 1 form để thêm sp
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(SanPham sanpham)
        {
            _db.SanPhams.Add(sanpham);
            _db.SaveChanges();
            return RedirectToAction("Index"); //trả về trang index
        }

        public IActionResult Detail(Guid? Id)
        {
           var sanphamDetail= _db.SanPhams.FirstOrDefault(x => x.Id == Id);

            return View(sanphamDetail);
        }

        public IActionResult Edit(Guid? Id)
        {
            var sanphamDetail = _db.SanPhams.FirstOrDefault(x => x.Id == Id);

            return View(sanphamDetail);
        }
        [HttpPost]
        public IActionResult Edit(SanPham sp)
        {
            //var sanphamDetail = _db.SanPhams.FirstOrDefault(x => x.Id == sp.Id);
            //sanphamDetail.Name = sp.Name;
            //_db.SanPhams.Update(sanphamDetail);
            //_db.SaveChanges();
            //return RedirectToAction("Index");
            _db.SanPhams.Update(sp);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        //điều hướng đến trang delete của đối tượng
        //public IActionResult Delete(Guid? Id)
        //{
        //    var sanPhamDelete = _db.SanPhams.Find(Id);
        //    //lay ra sanpham can xoa
        //    return View(sanPhamDelete);
        //}
        [HttpGet]
        public IActionResult Delete(Guid? Id)
        {
            var sanPhamDelete = _db.SanPhams.Find(Id);
            //lay ra sanpham can xoa
            _db.SanPhams.Remove(sanPhamDelete);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
