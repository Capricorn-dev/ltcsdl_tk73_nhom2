using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CosmeticWebApp.DAL.Model
{
    public class Personal_Information
    {
        //Tài khoản
        [Key]
        [MinLength(6)]
        [MaxLength(15)]
        [Column(TypeName = "nvarchar(15)")]
        [Required]
        public String Account {get; set;}
        //Mật khẩu
        [MinLength(6)]
        [MaxLength(30)]
        [Column(TypeName = "nvarchar(30)")]
        [Required]
        public String Pass { get; set; }
        //Họ
        [MaxLength(25)]
        [Column(TypeName = "nvarchar(25)")]
        [Required]
        public String LastName { get; set; }
        //Tên
        [MaxLength(15)]
        [Column(TypeName = "nvarchar(15)")]
        [Required]
        public String FirstName { get; set; }
        //Ngày sinh
        [Column(TypeName = "datetime")]
        [Required]
        public DateTime DateOfBirth { get; set; }
        //Giới Tính
        [MaxLength(10)]
        [Column(TypeName = "nvarchar(10)")]
        [Required]
        public String Gender { get; set; }
        //Địa chỉ
        [MaxLength(50)]
        [Column(TypeName = "nvarchar(50)")]
        [Required]
        public String Address { get; set; }
        //Số điện thoại
        [MaxLength(10)]
        [Column(TypeName = "nvarchar(10)")]
        [Required]
        public String PhoneNumber { get; set; }
        //Email
        [Column(TypeName = "nvarchar(50)")]
        public String Email { get; set; } //Email để trống được
        //Loại tài khoản
        [ForeignKey("AccountType")] //Khóa ngoại lấy theo tên bảng
        [Column("AccountType")]
        [Required]
        public String AccountTypeID { get; set; }
        public AccountType AccountType { get; set; } //Tạo đối tượng để gán foreign key
        //Ngày sinh
        [Column(TypeName = "datetime")]
        [Required]
        public DateTime CreatedDate { get; set; }
        //Tình trạng tài khoản
        [MaxLength(15)]
        [Column(TypeName = "nvarchar(15)")]
        [Required]
        public String AccountStatus { get; set; }
        //Ghi chú
        //Ghi chú không bắt buộc
        [MaxLength(50)]
        [Column(TypeName = "nvarchar(50)")]
        public String Note { get; set; }

        public virtual ICollection<Orders> OrdersByEmp { get; set; } //Được sử dụng bởi đơn hàng
        public virtual ICollection<Orders> OrdersByCus { get; set; } //Được sử dụng bởi đơn hàng
    }
}
