using MVC_WebApplication.Models;

namespace MVC_WebApplication.Services
{
    public interface IPlayersServices
    {
       
        Players Get_with_ID(int id);
        Players Create(Players player);

        void Update_with_ID(int id, Players player);

        void Delete_with_ID(int id);

  
        List<Players> Get_Player_Rank();
     
    }
}
