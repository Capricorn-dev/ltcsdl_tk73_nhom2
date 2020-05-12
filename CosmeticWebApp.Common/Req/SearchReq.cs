using System;
using System.Collections.Generic;
using System.Text;

namespace CosmeticWebApp.Common.Req
{
    public class SearchReq
    {
        public int Page { get; set; }
        public int Size { get; set; }
        public String KeyWord { get; set; }
    }
}
