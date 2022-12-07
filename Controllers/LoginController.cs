using Microsoft.AspNetCore.Mvc;
using MVC_WebApplication.Models;
using MVC_WebApplication.Services;


namespace MVC_WebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {

        private readonly IAdminUserService adminUserService;

     
        public LoginController(IAdminUserService adminUserService)
        {

            this.adminUserService = adminUserService;
        }

        [HttpGet("login")]
        public ActionResult LoginPage()
        {
            return View();
        }

        [HttpPost("GetAdminPass")]
        public ActionResult Login([FromForm] AdminUser admin)
        {
            List<AdminUser> userList = adminUserService.GetAll();
            string name = admin.Name;
            string password = admin.Password;
            foreach (var user in userList)
            {

                if (user.Name == name && user.Password == password)
                {
                    HttpContext.Response.Cookies.Append("True", "LoggedIn");

                    return RedirectToAction("LoginPage");
                }
            }
            return NotFound("Wrong User Name or Password");
        }



        [HttpGet("GetLogOut")]
        public ActionResult LoginOut()
        {
            return View();
        }

        [HttpPost("PostLogOut")]
        public ActionResult LogOutPost()
        {
            HttpContext.Response.Cookies.Append("True", "LoggedOut");
            return RedirectToAction("LoginPage");
        }
    }
}
