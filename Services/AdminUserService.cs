using MongoDB.Driver;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;
using System.Reflection.Emit;
using System.Reflection;
using System.Security.Cryptography;
using MVC_WebApplication.Models;


namespace MVC_WebApplication.Services
{
    public class AdminUserService : IAdminUserService
    {

        private readonly IMongoCollection<AdminUser> _Admin;

        public AdminUserService(IAssessment2DatabaseSetting settings)
        {
            var mongoClient = new MongoClient(settings.ConnectionString/*"mongodb://localhost:27017"*/);
            var database = mongoClient.GetDatabase(settings.DatabaseName/*"Assessment2"*/);
            _Admin = database.GetCollection<AdminUser>(settings.AdminUserCollection/*"AdminUser"*/);
        }

        public List<AdminUser> GetAll()
        {
            return _Admin.Find(user => true).ToList();
        }
    }
}
