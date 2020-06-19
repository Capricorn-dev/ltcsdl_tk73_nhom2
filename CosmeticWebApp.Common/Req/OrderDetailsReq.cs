using System;
using System.Collections.Generic;
using System.Text;

namespace CosmeticWebApp.Common.Req
{
    public class OrderDetailsReq
    {
        public int OrderId { get; set; }
        public String ProductId { get; set; }
        public int Amounts { get; set; }
        public String Note { get; set; }
    }
}
