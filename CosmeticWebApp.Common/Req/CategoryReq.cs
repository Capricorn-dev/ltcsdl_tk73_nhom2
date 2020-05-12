using System;
using System.Collections.Generic;
using System.Text;

namespace CosmeticWebApp.Common.Req
{
    public class CategoryReq
    {
        public String CategoryId { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public String Note { get; set; }
    }
}
