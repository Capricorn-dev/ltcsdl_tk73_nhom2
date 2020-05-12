using System;
using System.Collections.Generic;
using System.Text;

namespace CosmeticWebApp.Common.Req
{
    public class Personal_InformationReq
    {
        public String Account { get; set; }
        public String Pass { get; set; }
        public String LastName { get; set; }
        public String FirstName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public String Gender { get; set; }
        public String Address { get; set; }
        public String PhoneNumber { get; set; }
        public String Email { get; set; }
        public String AccountTypeID { get; set; }
        //public LoaiTaiKhoan LoaiTaiKhoan { get; set; }
        public DateTime CreatedDate { get; set; }
        public String AccountStatus { get; set; }
        public String Note { get; set; }

    }
}
