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
    public class OrderController : ControllerBase
    {
        //Khởi tạo đối tượng service
        private readonly OrderSvc _svc;
        //Phương thức khởi tạo
        public OrderController()
        {
            _svc = new OrderSvc();
        }
        [HttpPost("createOrder")]
        public IActionResult CreateBrand(OrderReq req)
        {
            var result = _svc.CreateOrder(req);
            return Ok(result);
        }
        [HttpGet("searchOrder/{size},{page}")]
        public IActionResult SearchOrder(int size, int page, String keyWord)
        {
            var result = _svc.SearchOrder(size, page, keyWord);
            return Ok(result);
        }
        [HttpPut("updateOrderPut/{id}")]
        public IActionResult UpdateBrandPut(int id, OrderReq req)
        {
            var result = _svc.UpdateOrder(id, req);
            return Ok(result);
        }
        [HttpPatch("updateOrderPatch/{id}")]
        public IActionResult UpdateBrandPatch(int id, OrderReq req)
        {
            var result = _svc.UpdateOrder(id, req);
            return Ok(result);
        }
        [HttpDelete("deleteOrder/{id}")]
        public IActionResult DeleteOrder(int id)
        {
            var result = _svc.DeleteOrder(id);
            return Ok(result);
        }
    }
}