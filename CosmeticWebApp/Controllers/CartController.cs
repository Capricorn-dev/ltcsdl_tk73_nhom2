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
    public class CartController : ControllerBase
    {
        //Khởi tạo đối tượng service
        private readonly CartSvc _svc;
        //Phương thức khởi tạo
        public CartController()
        {
            _svc = new CartSvc();
        }
        [HttpPost("createCart")]
        public IActionResult CreateCart(CartReq req)
        {
            var result = _svc.CreateCart(req);
            return Ok(result);
        }
        [HttpGet("getCustomerCart/{account}")]
        public IActionResult GetCustomerCart(String account)
        {
            var result = _svc.GetCustomerCart(account);
            return Ok(result);
        }
        [HttpPut("updateCartAmountPut/{account},{productId},{amount}")]
        public IActionResult UpdateCartAmountPut(String account, String productId, int amount)
        {
            var result = _svc.UpdateCartAmount(account, productId, amount);
            return Ok(result);
        }
        [HttpPatch("updateCartAmountPatch/{account},{productId},{amount}")]
        public IActionResult UpdateCartAmountPatch(String account, String productId, int amount)
        {
            var result = _svc.UpdateCartAmount(account, productId, amount);
            return Ok(result);
        }
        [HttpDelete("deleteCart/{account},{productId}")]
        public IActionResult DeleteCart(String account, String productId)
        {
            var result = _svc.DeleteCart(account, productId);
            return Ok(result);
        }
    }
}