using System;
using System.Collections.Generic;
using System.Text;

namespace CosmeticWebApp.Common.Req
{
    public class ProductReq
    {
        public String ProductId { get; set; }
        public String Name { get; set; }
        public String Price { get; set; }
        public String BrandId { get; set; }
        public String CategoryId { get; set; }
        public DateTime CreatedDate { get; set; }
        public String Unit { get; set; }
        public int UnitsInStock { get; set; }
        public int Discount { get; set; }
        public String Description { get; set; }
        public String Picture { get; set; }
        public String Note { get; set; }
    }
}
