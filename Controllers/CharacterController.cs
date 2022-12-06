using Microsoft.AspNetCore.Mvc;
using MVC_WebApplication.Models;
using MVC_WebApplication.Services;



// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MVC_WebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharacterController : Controller
    {


        private readonly ICharactersServices characterServices;
        private readonly IPlayersServices playersServices;

        public CharacterController(ICharactersServices characterServices, IPlayersServices playersServices)
        {
            this.characterServices = characterServices;
            this.playersServices = playersServices;
        }

        [HttpGet("GetCharacters")]
        public ActionResult Characters()
        {
            return View(characterServices.GetSortedPlayTime());
        }

        public ActionResult CharactersCreate()
        {

            return View();
        }

        [HttpPost("CreateCharacter")]
        public ActionResult<Characters> CreatePost([FromForm] Characters character)
        {
            Characters existingCharacter = characterServices.Get_with_ID(character.Id);
            if (existingCharacter != null)
            {
                return NotFound($"Character with the id = " +existingCharacter.Id+ " already exists");
            }
            characterServices.Create(character);
            return RedirectToAction("Characters");

        }

        [HttpGet("GetCharacterEditPost")]
        public ActionResult CharactersEdit(int Id)
        {
            var character = characterServices.Get_with_ID(Id);


            return View(character);
        }

        
        [HttpPost("CharacterEditPost")]
        public ActionResult EditPost([FromForm] Characters character)
        {
            int id = character.Id;
            
            characterServices.Update_with_ID(id, character);
           
            return RedirectToAction("Characters");
        }

        [HttpGet("CharacterDetails")]
        public ActionResult CharactersDetails(int Id)
        {
            var character = characterServices.Get_with_ID(Id);
            return View(character);
        }

        [HttpGet("GetCharacterDeletePost")]
        public ActionResult CharactersDelete(int id)
        {
            var character = characterServices.Get_with_ID(id);

            return View(character);
        }

        [HttpPost("CharacterDeletePost")]
        public ActionResult DeletePost([FromForm] Characters character)
        {
            int id = character.Id;
            var characters = characterServices.Get_with_ID(id); 
            List<Players> playerList = playersServices.GetAll();
            foreach (var player in playerList)
            {
                if (player.Primary_Character == characters.Name)
                {
                    player.Primary_Character = "deleted";
                    player.Primary_Character_PlayTime = 0;

                }
                if (player.Secondary_Character == characters.Name)
                {
                    player.Secondary_Character = "deleted";
                    player.Secondary_Character_PlayTime = 0;

                }
                playersServices.Update_with_ID(player.Id, player);
            }
            characterServices.Delete_with_ID(id);

            return RedirectToAction("Characters");
        }


       


    }

}
