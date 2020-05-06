using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CosmeticWebApp.DAL.Model
{
    public class LoaiTaiKhoan
    {
        //Mã loại tài khoản
        [Key]
        [MaxLength(10)]
        [Column(TypeName = "char(10)")]
        [Required]
        public String MaLTK { get; set; }
        //Tên loại
        [MaxLength(20)]
        [Column(TypeName = "nvarchar(20)")]
        [Required]
        public String Ten { get; set; }
        //Ghi chú
        [MaxLength(50)]
        [Column(TypeName = "nvarchar(50)")] //Ghi chú không bắt buộc
        public String GhiChu { get; set; }

        public ICollection<ThongTinCaNhan> ThongTinCaNhan { get; set; } //Được sử dụng bởi thông tin cá nhân
    }
}
