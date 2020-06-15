using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CosmeticWebApp.DAL.Model
{
    public class Cart
    {
        //Mã khách hàng
        [Required]
        //[Key]
        [Column(TypeName = "nvarchar(15)")]
        public String Account { get; set; }
        //[ForeignKey("MaKH")]
        public Personal_Information Personal_Information { get; set; }
        //Mã sản phẩm
        [Required]
        //[Key]
        [Column(TypeName = "nvarchar(10)")]
        public String ProductId { get; set; }
        //[ForeignKey("MaSP")]
        public Product Product { get; set; }
        //Số lượng
        [Column(TypeName = "int")]
        [Required]
        public int Amounts { get; set; }
        //Ghi chú
        [MaxLength(50)]
        [Column(TypeName = "nvarchar(50)")]
        public String Note { get; set; }

    }
}
