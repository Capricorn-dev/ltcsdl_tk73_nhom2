using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CosmeticWebApp.BLL.Svc;
using CosmeticWebApp.Common.Req;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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
        //Cookie
        //Create
        [HttpPost("createAccountCookie")]
        public IActionResult CreateLoginCookie(AccountReq req)
        {
            String error = "";
            Boolean success = false;
            string key = "MyAccount"; //Đây là key cookie dùng để truy xuất
            var value = new
            {
                account = req.Account,
                password = req.Password
            }; //Đây là giá trị của key
            try
            {
                CookieOptions cookieOptions = new CookieOptions(); //Khởi tạo cookie options
                cookieOptions.Expires = DateTime.Now.AddDays(7); //Hạn sử dụng trong 7 ngày
                Response.Cookies.Append(key, JsonConvert.SerializeObject(value).ToString(), cookieOptions); //Khởi tạo cookie
                success = true;
            }
            catch(Exception ex)
            {
                error = ex.StackTrace; //Xuất lỗi
            }
            var Result = new
            {
                Success = success,
                Error = error
            };
            return Ok(Result);
        }
        //Reading
        [HttpGet("getAccountCookie")]
        public IActionResult ReadAccTypeCookie()
        {
            string key = "MyAccount"; //Đây là key cookie dùng để truy xuất
            var AccTypeCookie = JsonConvert.SerializeObject(Request.Cookies[key]); //Trả về file JSON
            return Ok(AccTypeCookie);
        }
        //Session
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