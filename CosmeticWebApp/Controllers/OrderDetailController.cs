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
    public class OrderDetailController : ControllerBase
    {
        //Khởi tạo đối tượng service
        private readonly OrderDetailSvc _svc;
        //Phương thức khởi tạo
        public OrderDetailController()
        {
            _svc = new OrderDetailSvc();
        }
        [HttpPost("createOrderDetail")]
        public IActionResult CreateOrderDetail(OrderDetailReq req)
        {
            var result = _svc.CreateOrderDetail(req);
            return Ok(result);
        }
    }
}