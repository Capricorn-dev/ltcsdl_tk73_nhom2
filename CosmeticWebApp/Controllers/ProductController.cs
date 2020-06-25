using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CosmeticWebApp.BLL.Svc;
using CosmeticWebApp.Common.Req;
using CosmeticWebApp.DAL.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CosmeticWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        //Khởi tạo đối tượng service
        private readonly ProductSvc _svc;
        //Phương thức khởi tạo
        public ProductController()
        {
            _svc = new ProductSvc();
        }
        [HttpPost("sendingAccountTypeSession")]
        //Chạy ngay khi load web
        public IActionResult Index()
        {
            var accountType = new AccountType { AccountTypeID = "TEST", Name = "TEST", Note = "TEST" };
            HttpContext.Session.SetString("SessionAccountType", JsonConvert.SerializeObject(accountType)); //Chuyển thành file JSON
            return Ok(accountType);
        }
        [HttpPost("createProduct")]
        public IActionResult CreateProduct(ProductReq req)
        {
            var result = _svc.CreateProduct(req);
            return Ok(result);
        }
        [HttpGet("searchProduct/{size},{page}")]
        public IActionResult SearchProduct(int size, int page, String keyWord)
        {
            var result = _svc.SearchProduct(size, page, keyWord);
            return Ok(result);
        }
        [HttpPut("updateProductPut/{id}")]
        public IActionResult UpdateProductPut(String id, ProductReq req)
        {
            var result = _svc.UpdateProduct(id, req);
            return Ok(result);
        }
        [HttpPatch("updateProductPatch/{id}")]
        public IActionResult UpdateProductPatch(String id, ProductReq req)
        {
            var result = _svc.UpdateProduct(id, req);
            return Ok(result);
        }
        [HttpDelete("deleteProduct/{id}")]
        public IActionResult DeleteProduct(String id)
        {
            var result = _svc.DeleteProduct(id);
            return Ok(result);
        }
    }
}