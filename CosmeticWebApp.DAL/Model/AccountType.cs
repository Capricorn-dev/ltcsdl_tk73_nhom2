using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CosmeticWebApp.DAL.Model
{
    public class AccountType
    {
        //Mã loại tài khoản
        [Key]
        [MaxLength(10)]
        [Column(TypeName = "nvarchar(10)")]
        [Required]
        public String AccountTypeID { get; set; }
        //Tên loại
        [MaxLength(20)]
        [Column(TypeName = "nvarchar(20)")]
        [Required]
        public String Name { get; set; }
        //Ghi chú
        [MaxLength(50)]
        [Column(TypeName = "nvarchar(50)")] //Ghi chú không bắt buộc
        public String Note { get; set; }

        public ICollection<Personal_Information> Personal_Information { get; set; } //Được sử dụng bởi thông tin cá nhân
    }
}
