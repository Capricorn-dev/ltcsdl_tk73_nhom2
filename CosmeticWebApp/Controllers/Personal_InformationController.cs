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
    public class Personal_InformationController : ControllerBase
    {
        //Khởi tạo đối tượng service
        private readonly Personal_InformationSvc _svc;
        //Phương thức khởi tạo
        public Personal_InformationController()
        {
            _svc = new Personal_InformationSvc();
        }
        //Tạo
        [HttpPost("createPersonal_Information")]
        public IActionResult CreatePersonal_Information(Personal_InformationReq req)
        {
            var result = _svc.CreatePersonal_Information(req);
            return Ok(result);
        }
        //Sửa
        [HttpPut("updatePersonal_Information/{account}")]
        public IActionResult UpdatePersonal_InformationPatch(String account, Personal_InformationReq req)
        {
            var result = _svc.UpdatePersonal_Information(account, req);
            return Ok(result);
        }
        //Kiểm tra đăng nhập
        [HttpPost("checkUserLogin")]
        public IActionResult CheckLogin(AccountReq req)
        {
            var result = _svc.CheckLogin(req);
            return Ok(result);
        }
        [HttpGet("getCustomerByAccount/{account}")]
        public object GetCustomerByAccount(String account)
        {
            return Ok(_svc.GetCustomerByAccount(account));
        }
    }
}