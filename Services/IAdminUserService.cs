using MVC_WebApplication.Models;

namespace MVC_WebApplication.Services
{
    public interface  IAdminUserService
    {
       
        List<AdminUser> GetAll();
    }
}
