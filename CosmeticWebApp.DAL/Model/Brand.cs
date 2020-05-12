using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CosmeticWebApp.DAL.Model
{
    public class Brand
    {
        //Mã thương hiệu
        [Key]
        [MaxLength(10)]
        [Column(TypeName = "nvarchar(10)")]
        [Required]
        public String BrandId { get; set; }
        //Tên thương hiệu
        [MaxLength(30)]
        [Column(TypeName = "nvarchar(30)")]
        [Required]
        public String Name { get; set; }
        //Số điện thoại
        [MaxLength(10)]
        [Column(TypeName = "nvarchar(10)")]
        [Required]
        public String PhoneNumber { get; set; }
        //Email
        [MaxLength(50)]
        [Column(TypeName = "nvarchar(50)")]
        public String Email { get; set; } //Email để trống được
        //Mô tả
        [Column(TypeName = "nvarchar(max)")] //Không giới hạn kí tự
        public String Description { get; set; } //Không bắt buộc nhập
        //Ngày hợp tác
        [Column(TypeName = "datetime")]
        [Required]
        public DateTime StartedDate { get; set; }
        //Ghi chú
        [MaxLength(50)]
        [Column(TypeName = "nvarchar(50)")]
        public String Note { get; set; }

        public ICollection<Product> Product { get; set; } //Được sử dụng bởi sản phẩm
    }
}
