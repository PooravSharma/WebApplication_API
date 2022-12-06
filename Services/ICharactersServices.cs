using MVC_WebApplication.Models;

namespace MVC_WebApplication.Services
{
    public interface ICharactersServices
    {

        List<Characters> GetAll();
        Characters Get_with_ID(int id);
        Characters Create(Characters character);

        void Update_with_ID(int id, Characters character);

        void Delete_with_ID(int id);

        List<Characters> GetSortedPlayTime();
    }
}
