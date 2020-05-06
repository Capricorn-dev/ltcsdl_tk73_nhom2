using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CosmeticWebApp.DAL.Model
{
    public class ThuongHieu
    {
        //Mã thương hiệu
        [Key]
        [MaxLength(10)]
        [Column(TypeName = "char(10)")]
        [Required]
        public String MaTH { get; set; }
        //Tên thương hiệu
        [MaxLength(30)]
        [Column(TypeName = "nvarchar(30)")]
        [Required]
        public String Ten { get; set; }
        //Số điện thoại
        [MaxLength(10)]
        [Column(TypeName = "char(10)")]
        [Required]
        public String SDT { get; set; }
        //Email
        [MaxLength(50)]
        [Column(TypeName = "nvarchar(50)")]
        public String Email { get; set; } //Email để trống được
        //Mô tả
        [Column(TypeName = "nvarchar(max)")] //Không giới hạn kí tự
        public String MoTa { get; set; } //Không bắt buộc nhập
        //Ngày hợp tác
        [Column(TypeName = "datetime")]
        [Required]
        public DateTime NgayHopTac { get; set; }
        //Ghi chú
        [MaxLength(50)]
        [Column(TypeName = "nvarchar(50)")]
        public String GhiChu { get; set; }

        public ICollection<SanPham> SanPham { get; set; } //Được sử dụng bởi sản phẩm
    }
}
