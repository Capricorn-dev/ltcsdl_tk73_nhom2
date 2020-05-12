using System;
using System.Collections.Generic;
using System.Text;

namespace CosmeticWebApp.Common.Req
{
    public class BrandReq
    {
        public String BrandId { get; set; }
        public String Name { get; set; }
        public String PhoneNumber { get; set; }
        public String Email { get; set; }
        public String Description { get; set; }
        public DateTime StartedDate { get; set; }
        public String Note { get; set; }
    }
}
