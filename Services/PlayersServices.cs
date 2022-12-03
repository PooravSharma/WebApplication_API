using MVC_WebApplication.Models;
using MongoDB.Driver;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;
using System.Reflection.Emit;
using System.Reflection;
using System.Security.Cryptography;

namespace MVC_WebApplication.Services
{
    public class PlayersServices : IPlayersServices
    {
        private readonly IMongoCollection<Players> _Players;

        public PlayersServices(IAssessment2DatabaseSetting settings)
        {
            var mongoClient = new MongoClient(settings.ConnectionString/*"mongodb://localhost:27017"*/);
            var database = mongoClient.GetDatabase(settings.DatabaseName/*"Assessment2"*/);
            _Players = database.GetCollection<Players>(settings.PlayersCollectionName/*"Players"*/);
        }

        public Players Create(Players player)
        {

            _Players.InsertOne(player);
            return player;

        }

        public void Delete_with_ID(int id)
        {
          
            _Players.DeleteOne(player => player.Id == id);

        }

        public Players Get_with_ID(int id)
        {
            return _Players.Find(player => player.Id == id).FirstOrDefault();
        }
        
        public void Update_with_ID(int id, Players player)
        {
            _Players.ReplaceOne(player => player.Id == id, player);

        }
    public List<Players> Get_Player_Rank()
        {
            var player = _Players.Find(players => true).ToList();
            var sortedplayers = player.OrderBy(player => player.Rank).ToList();
            return sortedplayers;
        }


    }

}
