namespace WebApplication1.Models
{
    public class User
    {
        public Guid     Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address {  get; set; }
        //ICollection<HoaDon> thực hiện 1 user có nhiêu hóa đơn
        //còn đc sử dụng để là Navigation để trỏ đến khi cần
        public virtual ICollection<HoaDon> HoaDons { get; set; }
    }
}
