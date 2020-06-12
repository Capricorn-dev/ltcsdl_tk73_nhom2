using System;
using System.Collections.Generic;
using System.Text;

namespace CosmeticWebApp.Common.Req
{
    public class OrderReq
    {
        public int OrderId { get; set; }
        public String Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public String PhoneNumbOfOrder { get; set; }
        public String Address { get; set; }
        public String Ward { get; set; }
        public String District { get; set; }
        public String City { get; set; }
        public String OrderStatus { get; set; }
        public String Note { get; set; }
        public String CusId { get; set; }
        public String EmpId { get; set; }
    }
}
