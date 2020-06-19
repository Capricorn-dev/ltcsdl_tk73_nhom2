using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CosmeticWebApp.BLL.Svc;
using CosmeticWebApp.Common.Req;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CosmeticWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsController : ControllerBase
    {
        //Khởi tạo đối tượng service chỉ đọc
        private readonly OrderDetailsSvc _svc;
        public OrderDetailsController()
        {
            _svc = new OrderDetailsSvc();
        }
        [HttpPost("createOrderDetails")]
        public IActionResult CreateOrderDetail(OrderDetailsReq[] reqList)
        {
            var result = _svc.CreateOrderDetail(reqList);
            return Ok(result);
        }
    }
}