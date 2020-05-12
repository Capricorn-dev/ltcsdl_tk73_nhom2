using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CosmeticWebApp.DAL.Model
{
    public class Orders
    {
        //Mã đơn hàng
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //Khóa chính tự động tăng
        [Required]
        public int OrderId { get; set; }
        //Tên đơn hàng
        [MaxLength(30)]
        [Column(TypeName = "nvarchar(30)")]
        [Required]
        public String Name { get; set; }
        //Ngày tạo
        [Column(TypeName = "datetime")]
        [Required]
        public DateTime CreatedDate { get; set; }
        //Số điện thoại đơn hàng
        [MaxLength(10)]
        [Column(TypeName = "nvarchar(10)")]
        [Required]
        public String PhoneNumbOfOrder { get; set; }
        //Địa chỉ
        [MaxLength(50)]
        [Column(TypeName = "nvarchar(50)")]
        [Required]
        public String Address { get; set; }
        //Phường xã
        [MaxLength(25)]
        [Column(TypeName = "nvarchar(25)")]
        public String Ward { get; set; }
        //Quận huyện
        [MaxLength(25)]
        [Column(TypeName = "nvarchar(25)")]
        public String District { get; set; }
        //Thành phố tỉnh
        [MaxLength(25)]
        [Column(TypeName = "nvarchar(25)")]
        public String City { get; set; }
        //Tình trạng đơn hàng
        [MaxLength(25)]
        [Column(TypeName = "nvarchar(25)")]
        [Required]
        public String OrderStatus { get; set; }
        //Ghi chú
        [MaxLength(50)]
        [Column(TypeName = "nvarchar(50)")]
        public String Note { get; set; }
        //Nếu lấy 1 bảng có từ 2 foreign key lấy từ cùng 1 bảng trở lên phải xài fluent API. Không xài data annotation
        //Khách hàng trên đơn hàng
        //[Column("MaKH")]
        //[Required]
        //[ForeignKey("MaKH")]
        public String CusId { get; set; }
        public virtual Personal_Information Customer { get; set; }
        //Nhân viên trên đơn hàng
        //[Column("MaNV")]
        //[Required]
        //[ForeignKey("MaNV")]
        public String EmpId { get; set; }

        public virtual Personal_Information Employee { get; set; }

        public ICollection<OrderDetails> OrderDetails { get; set; } //Được sử dụng bởi chi tiết đơn hàng
    }
}
