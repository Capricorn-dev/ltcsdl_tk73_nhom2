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
    public class AccountTypeController : ControllerBase
    {
        //Khởi tạo đối tượng service chỉ đọc
        private readonly AccountTypeSvc _svc;
        public AccountTypeController()
        {
            _svc = new AccountTypeSvc();
        }
        [HttpPost("createAccountType")]
        public IActionResult CreateAccountType(AccountTypeReq req)
        {
            var result = _svc.CreateAccountType(req);
            return Ok(result);
        }
        [HttpPost("updateAccountType")]
        public IActionResult UpdateAccountType(AccountTypeReq req)
        {
            var result = _svc.UpdateAccountType(req);
            return Ok(result);
        }
    }
}