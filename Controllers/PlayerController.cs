using Microsoft.AspNetCore.Mvc;
using MVC_WebApplication.Models;
using MVC_WebApplication.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MVC_WebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : Controller
    {
        private readonly IPlayersServices playersServices;
        private readonly ICharactersServices characterServices;
        public PlayerController(IPlayersServices playersServices, ICharactersServices characterServices)
        {
            this.playersServices=playersServices;
            this.characterServices=characterServices;
        }


       [HttpGet("GetPlayers")]
        public ActionResult Players()
        {
            
            return View(playersServices.Get_Player_Rank());

        }
        //[HttpPost("GetCreatePost")]
        public ActionResult PlayersCreate()
        {

            return View();
        }

        // POST api/<PlayerController>
        [HttpPost("CreatePost")]
        public ActionResult CreatePost([FromForm] Players players)
        {
            Players existingPlayer = playersServices.Get_with_ID(players.Id);
            List<Characters> characterList = characterServices.GetAll();
            Characters characterName = characterList.Find((character => character.Name == players.Primary_Character));
            Characters characterName2 = characterList.Find((character => character.Name == players.Secondary_Character));
            if (existingPlayer != null)
            {

                return NotFound("Players with the id = "+ players.Id +"  already exists");

            }

            if (players.Rank.Equals(0))
            {
                return NotFound($"Players with rank = 0 cannot be made");
            }
            if (characterName is null)
            {
                return NotFound($"That Primary Character does not exist");
            }
            if (characterName2 is null)
            {
                return NotFound($"That Secondary Character does not exist");
            }
            playersServices.Create(players);
            playersServices.PlayerRanker(players);

            return RedirectToAction("Players");

        }

        [HttpGet("GetEditPost")]
        public ActionResult PlayersEdit(int Id)
        {
            var players = playersServices.Get_with_ID(Id);


            return View(players);
        }

        [HttpPost("EditPost")]
        public ActionResult EditPost([FromForm] Players players)
        {
            int id = players.Id;
            var existingPlayer = playersServices.Get_with_ID(id);
            List<Characters> characterList = characterServices.GetAll();
            Characters characterName = characterList.Find((character => character.Name == players.Primary_Character));
            Characters characterName2 = characterList.Find((character => character.Name == players.Secondary_Character));
            if (existingPlayer.Rank.Equals(0))
            {
                return NotFound($"Players with rank = 0 cannot be made");
            }
            if (characterName is null)
            {
                return NotFound($"That Primary Character does not exist");
            }
            if (characterName2 is null)
            {
                return NotFound($"That Secondary Character does not exist");
            }
            playersServices.Update_with_ID(id, players);
            playersServices.PlayerRanker(players);
            return RedirectToAction("Players");
        }

        [HttpGet("PlayerDetails")]
        public ActionResult PlayersDetails(int Id)
        {
            var players = playersServices.Get_with_ID(Id);
            return View(players);
        }

        [HttpGet("GetDeletePost")]
        public ActionResult PlayersDelete(int id)
        {
            var players = playersServices.Get_with_ID(id);

            return View(players);
        }

        [HttpPost("DeletePost")]
        public ActionResult DeletePost([FromForm] Players players)
        {
            int id = players.Id;
            playersServices.Delete_with_ID(id);
            return RedirectToAction("Players");
        }

    }
}
