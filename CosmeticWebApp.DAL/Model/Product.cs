using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CosmeticWebApp.DAL.Model
{
    public class Product
    {
        //Mã sản phẩm
        [Key]
        [MaxLength(10)]
        [Column(TypeName = "nvarchar(10)")]
        [Required]
        public String ProductId { get; set; }
        //Tên sản phẩm
        [MaxLength(30)]
        [Column(TypeName = "nvarchar(30)")]
        [Required]
        public String Name { get; set; }
        //Thương hiệu
        [Column("Brand")]
        [Required]
        [ForeignKey("Brand")] //Tạo khóa ngoại
        public String BrandId { get; set; }
        public Brand Brand { get; set; }
        //Danh mục
        [Column("Category")]
        [Required]
        [ForeignKey("Category")] //Tạo khóa ngoại
        public String CategoryId { get; set; }
        public Category Category { get; set; }
        //Ngày tạo
        [Column(TypeName = "datetime")]
        [Required]
        public DateTime CreatedDate { get; set; }
        //Đon vị
        [Column(TypeName = "nvarchar(10)")]
        [Required]
        public String Unit { get; set; }
        //Đơn vị tồn kho
        [Column(TypeName = "int")]
        [Required]
        public int UnitsInStock { get; set; }
        //Khuyến mãi
        [Column(TypeName = "float")]
        [Required]
        public int Discount { get; set; }
        //Mô tả
        [Column(TypeName = "nvarchar(max)")] //Không giới hạn kí tự
        public String Description { get; set; } //Không bắt buộc nhập
        //Hình ảnh
        [Column(TypeName = "nvarchar(max)")] //Không giới hạn kí tự
        public String Picture { get; set; } //Không bắt buộc nhập
        //Ghi chú
        [MaxLength(50)]
        [Column(TypeName = "nvarchar(50)")]
        public String Note { get; set; }

        public ICollection<OrderDetails> OrderDetails { get; set; } //Được sử dụng bởi chi tiết đơn hàng
    }
}
