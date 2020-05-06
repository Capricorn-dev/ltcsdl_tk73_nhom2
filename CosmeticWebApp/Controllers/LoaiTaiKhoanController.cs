using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CosmeticWebApp.BLL;
using CosmeticWebApp.Common.Req;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CosmeticWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoaiTaiKhoanController : ControllerBase
    {
        //Khởi tạo đối tượng service chỉ đọc
        private readonly LoaiTaiKhoanSvc _svc;
        public LoaiTaiKhoanController()
        {
            _svc = new LoaiTaiKhoanSvc();
        }
        [HttpPost("createLoaiTaiKhoan")]
        public IActionResult CreateLoaiTaiKhoan(LoaiTaiKhoanReq req)
        {
            var result = _svc.CreateLoaiTaiKhoan(req);
            return Ok(result);
        }
        [HttpPost("updateLoaiTaiKhoan")]
        public IActionResult UpdateLoaiTaiKhoan(LoaiTaiKhoanReq req)
        {
            var result = _svc.UpdateLoaiTaiKhoan(req);
            return Ok(result);
        }
    }
}