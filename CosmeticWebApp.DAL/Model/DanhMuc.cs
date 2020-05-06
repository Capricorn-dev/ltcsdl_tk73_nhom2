using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CosmeticWebApp.DAL.Model
{
    public class DanhMuc
    {
        //Mã danh mục
        [Key]
        [MaxLength(10)]
        [Column(TypeName = "char(10)")]
        [Required]
        public String MaDM { get; set; }
        //Tên danh mục
        [MaxLength(30)]
        [Column(TypeName = "nvarchar(30)")]
        [Required]
        public String Ten { get; set; }
        //Mô tả
        [Column(TypeName = "nvarchar(max)")] //Không giới hạn kí tự
        public String MoTa { get; set; } //Không bắt buộc nhập
        //Ngày hợp tác
        [Column(TypeName = "datetime")]
        [Required]
        public DateTime NgayTao { get; set; }
        //Ghi chú
        [MaxLength(50)]
        [Column(TypeName = "nvarchar(50)")]
        public String GhiChu { get; set; }

        public ICollection<SanPham> SanPham { get; set; } //Được sử dụng bởi sản phẩm

    }
}
