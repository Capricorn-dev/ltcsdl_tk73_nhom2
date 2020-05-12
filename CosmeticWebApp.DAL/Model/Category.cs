using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CosmeticWebApp.DAL.Model
{
    public class Category
    {
        //Mã danh mục
        [Key]
        [MaxLength(10)]
        [Column(TypeName = "nvarchar(10)")]
        [Required]
        public String CategoryId { get; set; }
        //Tên danh mục
        [MaxLength(30)]
        [Column(TypeName = "nvarchar(30)")]
        [Required]
        public String Name { get; set; }
        //Mô tả
        [Column(TypeName = "nvarchar(max)")] //Không giới hạn kí tự
        public String Description { get; set; } //Không bắt buộc nhập
        //Ngày hợp tác
        [Column(TypeName = "datetime")]
        [Required]
        public DateTime CreatedDate { get; set; }
        //Ghi chú
        [MaxLength(50)]
        [Column(TypeName = "nvarchar(50)")]
        public String Note { get; set; }

        public ICollection<Product> Product { get; set; } //Được sử dụng bởi sản phẩm

    }
}
