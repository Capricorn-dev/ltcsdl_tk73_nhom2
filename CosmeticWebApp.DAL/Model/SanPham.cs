using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CosmeticWebApp.DAL.Model
{
    public class SanPham
    {
        //Mã sản phẩm
        [Key]
        [MaxLength(10)]
        [Column(TypeName = "char(10)")]
        [Required]
        public String MaSP { get; set; }
        //Tên sản phẩm
        [MaxLength(30)]
        [Column(TypeName = "nvarchar(30)")]
        [Required]
        public String Ten { get; set; }
        //Thương hiệu
        [Column("ThuongHieu", TypeName = "char(10)")]
        [Required]
        [ForeignKey("ThuongHieu")] //Tạo khóa ngoại
        public String MaTH { get; set; }
        public ThuongHieu ThuongHieu { get; set; }
        //Danh mục
        [Column("DanhMuc", TypeName = "char(10)")]
        [Required]
        [ForeignKey("DanhMuc")] //Tạo khóa ngoại
        public String MaDM { get; set; }
        public DanhMuc DanhMuc { get; set; }
        //Ngày tạo
        [Column(TypeName = "datetime")]
        [Required]
        public DateTime NgayTao { get; set; }
        //Đon vị
        [Column(TypeName = "nvarchar(10)")]
        [Required]
        public String DonVi { get; set; }
        //Đơn vị tồn kho
        [Column(TypeName = "int")]
        [Required]
        public int DonViTonKho { get; set; }
        //Khuyến mãi
        [Column(TypeName = "float")]
        [Required]
        public int KhuyenMai { get; set; }
        //Mô tả
        [Column(TypeName = "nvarchar(max)")] //Không giới hạn kí tự
        public String MoTa { get; set; } //Không bắt buộc nhập
        //Hình ảnh
        [Column(TypeName = "nvarchar(max)")] //Không giới hạn kí tự
        public String HinhAnh { get; set; } //Không bắt buộc nhập
        //Ghi chú
        [MaxLength(50)]
        [Column(TypeName = "nvarchar(50)")]
        public String GhiChu { get; set; }

        public ICollection<ChiTietDonHang> ChiTietDonHang { get; set; } //Được sử dụng bởi chi tiết đơn hàng
    }
}
