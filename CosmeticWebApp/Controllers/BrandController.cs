using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CosmeticWebApp.BLL.Svc;
using CosmeticWebApp.Common.Req;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CosmeticWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        //Khởi tạo đối tượng service
        private readonly BrandSvc _svc;
        //Phương thức khởi tạo
        public BrandController()
        {
            _svc = new BrandSvc();
        }
        [Authorize]
        [HttpPost("createBrand")]
        public IActionResult CreateBrand(BrandReq req)
        {
            var result = _svc.CreateBrand(req);
            return Ok(result);
        }
        [HttpGet("searchBrand/{size},{page}")]
        public IActionResult SearchBrand(int size, int page, String keyWord)
        {
            var result = _svc.SearchBrand(size, page, keyWord);
            return Ok(result);
        }
        [Authorize]
        [HttpPut("updateBrandPut/{id}")]
        public IActionResult UpdateBrandPut(String id, BrandReq req)
        {
            var result = _svc.UpdateBrand(id, req);
            return Ok(result);
        }
        [Authorize]
        [HttpPatch("updateBrandPatch/{id}")]
        public IActionResult UpdateBrandPatch(String id, BrandReq req)
        {
            var result = _svc.UpdateBrand(id, req);
            return Ok(result);
        }
        [Authorize]
        [HttpDelete("deleteBrand/{id}")]
        public IActionResult DeleteBrand(String id)
        {
            var result = _svc.DeleteBrand(id);
            return Ok(result);
        }
    }
}