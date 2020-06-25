using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CosmeticWebApp.BLL;
using CosmeticWebApp.Common.Req;
using CosmeticWebApp.DAL.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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
        //Session
        //Account type sẽ nhận khi product gọi API gửi session
        [HttpGet("getAccountTypeSession")]
        public IActionResult GetAccountTypeSession()
        {
            var result = JsonConvert.DeserializeObject<AccountType>(HttpContext.Session.GetString("SessionAccountType"));
            return Ok(result);
        }
        //Cookie
        //Create
        [HttpPost("createAccTypeCookie")]
        public IActionResult CreateAccTypeCookie()
        {
            string key = "MyKey"; //Đây là key cookie dùng để truy xuất
            var value = new {
                value1 = "MyValue1",
                value2 = "MyValue2"
            }; //Đây là giá trị của key
            CookieOptions cookieOptions = new CookieOptions(); //Khởi tạo cookie options
            cookieOptions.Expires = DateTime.Now.AddDays(7); //Hạn sử dụng trong 7 ngày
            Response.Cookies.Append(key, value.ToString(), cookieOptions); //Khởi tạo cookie
            return Ok("Success create cookie");
        }
        //Reading
        [HttpGet("getAccTypeCookie")]
        public IActionResult ReadAccTypeCookie()
        {
            string key = "MyKey"; //Đây là key cookie dùng để truy xuất
            var AccTypeCookie = JsonConvert.SerializeObject(Request.Cookies[key]); //Trả về file JSON
            return Ok(AccTypeCookie);
        }
        //Remove cookie
        [HttpPost("removeAccTypeCookie")]
        public IActionResult RemoveAccTypeCookie()
        {
            string key = "MyKey"; //Đây là key cookie dùng để truy xuất
            string value = ""; //Trả về giá trị rỗng khi xóa
            CookieOptions cookieOptions = new CookieOptions(); //Khởi tạo cookie options
            cookieOptions.Expires = DateTime.Now.AddDays(-1); //Không có hạn sử dụng
            Response.Cookies.Append(key, value, cookieOptions); //Khởi tạo cookie
            return Ok("Remove Cookie Success");
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