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
    public class CategoryController : ControllerBase
    {
        //Khởi tạo đối tượng service
        private readonly CategorySvc _svc;
        //Phương thức khởi tạo
        public CategoryController()
        {
            _svc = new CategorySvc();
        }
        [HttpPost("createCategory")]
        public IActionResult CreateCategory(CategoryReq req)
        {
            var result = _svc.CreateCategory(req);
            return Ok(result);
        }
        [HttpGet("searchCategory/{size},{page}")] //Nếu muốn để key word trống thì không đưa biến keyWord vào HttpGet
        public IActionResult SearchCategory(int size, int page, String keyWord)
        {
            var result = _svc.SearchCategory(size, page, keyWord);
            return Ok(result);
        }
        [HttpPut("updateCategoryPut/{id}")]
        public IActionResult UpdateCategoryPut(String id, CategoryReq req)
        {
            var result = _svc.UpdateCategory(id, req);
            return Ok(result);
        }
        [HttpPatch("updateCategoryPatch/{id}")]
        public IActionResult UpdateCategoryPatch(String id, CategoryReq req)
        {
            var result = _svc.UpdateCategory(id, req);
            return Ok(result);
        }
       
        [HttpDelete("deleteCategory/{id}")]
        public IActionResult DeleteCategory(String id)
        {
            var result = _svc.DeleteCategory(id);
            return Ok(result);
        }
    }
}