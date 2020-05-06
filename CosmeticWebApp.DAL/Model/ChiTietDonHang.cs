using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CosmeticWebApp.DAL.Model
{
    public class ChiTietDonHang
    {
        //Mã đơn hàng
        [Required]
        //[Key]
        [Column(TypeName = "int")]
        public int MaDH { get; set; }
        //[ForeignKey("MaDH")]
        public DonHang DonHang { get; set; }
        //Mã sản phẩm
        [Required]
        //[Key]
        [Column(TypeName = "char(10)")]
        public String MaSP { get; set; }
        //[ForeignKey("MaSP")]
        public SanPham SanPham { get; set; }
        //Số lượng
        [Column(TypeName = "int")]
        [Required]
        public int SoLuong { get; set; }
        //Ghi chú
        [MaxLength(50)]
        [Column(TypeName = "nvarchar(50)")]
        public String GhiChu { get; set; }

    }
}
