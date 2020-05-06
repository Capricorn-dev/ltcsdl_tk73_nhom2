using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CosmeticWebApp.DAL.Model
{
    public class ThongTinCaNhan
    {
        //Tài khoản
        [Key]
        [MinLength(6)]
        [MaxLength(15)]
        [Column(TypeName = "char(15)")]
        [Required]
        public String TaiKhoan {get; set;}
        //Mật khẩu
        [MinLength(6)]
        [MaxLength(30)]
        [Column(TypeName = "char(30)")]
        [Required]
        public String MatKhau { get; set; }
        //Họ
        [MaxLength(25)]
        [Column(TypeName = "nvarchar(25)")]
        [Required]
        public String Ho { get; set; }
        //Tên
        [MaxLength(15)]
        [Column(TypeName = "nvarchar(15)")]
        [Required]
        public String Ten { get; set; }
        //Ngày sinh
        [Column(TypeName = "datetime")]
        [Required]
        public DateTime NgaySinh { get; set; }
        //Giới Tính
        [MaxLength(10)]
        [Column(TypeName = "nvarchar(10)")]
        [Required]
        public String GioiTinh { get; set; }
        //Địa chỉ
        [MaxLength(50)]
        [Column(TypeName = "nvarchar(50)")]
        [Required]
        public String DiaChi { get; set; }
        //Số điện thoại
        [MaxLength(10)]
        [Column(TypeName = "char(10)")]
        [Required]
        public String SDT { get; set; }
        //Email
        [Column(TypeName = "nvarchar(50)")]
        public String Email { get; set; } //Email để trống được
        //Loại tài khoản
        [ForeignKey("LoaiTaiKhoan")] //Khóa ngoại lấy theo tên bảng
        [Column("LoaiTaiKhoan")]
        [Required]
        public String MaLTK { get; set; }
        public LoaiTaiKhoan LoaiTaiKhoan { get; set; } //Tạo đối tượng để gán foreign key
        //Ngày sinh
        [Column(TypeName = "datetime")]
        [Required]
        public DateTime NgayTao { get; set; }
        //Tình trạng tài khoản
        [MaxLength(15)]
        [Column(TypeName = "nvarchar(15)")]
        [Required]
        public String TinhTrangTaiKhoan { get; set; }
        //Ghi chú
        //Ghi chú không bắt buộc
        [MaxLength(50)]
        [Column(TypeName = "nvarchar(50)")]
        public String GhiChu { get; set; }

        public virtual ICollection<DonHang> DonHangNhanVien { get; set; } //Được sử dụng bởi đơn hàng
        public virtual ICollection<DonHang> DonHangKhachHang { get; set; } //Được sử dụng bởi đơn hàng
    }
}
