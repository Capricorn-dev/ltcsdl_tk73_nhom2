using System;
using System.Collections.Generic;
using System.Text;

namespace CosmeticWebApp.Common.Req
{
    public class UpdateCartReq
    {
        public String Account { get; set; }
        public String[] ProductIdList { get; set; }
        public int[] Amount { get; set; }
    }
}
