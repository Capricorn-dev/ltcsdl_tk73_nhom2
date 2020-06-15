using System;
using System.Collections.Generic;
using System.Text;

namespace CosmeticWebApp.Common.Req
{
    public class CartReq
    {
        public String Account { get; set; }
        public String ProductId { get; set; }
        public int Amounts { get; set; }
        public String Note { get; set; }
    }
}
