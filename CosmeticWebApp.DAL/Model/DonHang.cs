using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CosmeticWebApp.DAL.Model
{
    public class DonHang
    {
        //Mã đơn hàng
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //Khóa chính tự động tăng
        [Required]
        public int MaDH { get; set; }
        //Tên đơn hàng
        [MaxLength(30)]
        [Column(TypeName = "nvarchar(30)")]
        [Required]
        public String Ten { get; set; }
        //Ngày tạo
        [Column(TypeName = "datetime")]
        [Required]
        public DateTime NgayTao { get; set; }
        //Số điện thoại đơn hàng
        [MaxLength(10)]
        [Column(TypeName = "char(10)")]
        [Required]
        public String SDTDH { get; set; }
        //Địa chỉ
        [MaxLength(50)]
        [Column(TypeName = "nvarchar(50)")]
        [Required]
        public String DiaChi { get; set; }
        //Phường xã
        [MaxLength(25)]
        [Column(TypeName = "nvarchar(25)")]
        public String PhuongXa { get; set; }
        //Quận huyện
        [MaxLength(25)]
        [Column(TypeName = "nvarchar(25)")]
        public String QuanHuyen { get; set; }
        //Thành phố tỉnh
        [MaxLength(25)]
        [Column(TypeName = "nvarchar(25)")]
        public String ThanhPhoTinh { get; set; }
        //Tình trạng đơn hàng
        [MaxLength(25)]
        [Column(TypeName = "nvarchar(25)")]
        [Required]
        public String TinhTrangDonHang { get; set; }
        //Ghi chú
        [MaxLength(50)]
        [Column(TypeName = "nvarchar(50)")]
        public String GhiChu { get; set; }
        //Nếu lấy 1 bảng có từ 2 foreign key lấy từ cùng 1 bảng trở lên phải xài fluent API. Không xài data annotation
        //Khách hàng trên đơn hàng
        //[Column("MaKH")]
        //[Required]
        //[ForeignKey("MaKH")]
        public String MaKH { get; set; }
        public virtual ThongTinCaNhan KhachHang { get; set; }
        //Nhân viên trên đơn hàng
        //[Column("MaNV")]
        //[Required]
        //[ForeignKey("MaNV")]
        public String MaNV { get; set; }

        public virtual ThongTinCaNhan NhanVien { get; set; }

        public ICollection<ChiTietDonHang> ChiTietDonHang { get; set; } //Được sử dụng bởi chi tiết đơn hàng
    }
}
