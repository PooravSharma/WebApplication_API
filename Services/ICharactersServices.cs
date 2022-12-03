﻿using MVC_WebApplication.Models;

namespace MVC_WebApplication.Services
{
    public interface ICharactersServices
    {

        List<Characters> GetAll();
        Characters Get_with_ID(int id);
        Characters Create(Characters character);

        string Update_with_ID(int id, Characters character);

        string Delete_with_ID(int id);

        List<Characters> GetSortedPlayTime();
    }
}
