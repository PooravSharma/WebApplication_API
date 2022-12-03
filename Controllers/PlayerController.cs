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
        // GET: api/<PlayerController>







        [HttpGet("GetPlayers")]
        public ActionResult Players()
        {
            /*   using (var client = new HttpClient())
               {
                   client.BaseAddress = new Uri("http://localhost:61438/api/");
                   //HTTP GET
                   var responseTask = client.GetAsync("student");
                   responseTask.Wait();

                   var result = responseTask.Result;
   */
            return View(playersServices.Get_Player_Rank());

        }
        //[HttpPost("GetCreatePost")]
        public ActionResult PlayersCreate() {

            return View();
        }

        // POST api/<PlayerController>
        [HttpPost("CreatePost")]
        public ActionResult CreatePost([FromForm] Players players)
        {

            playersServices.Create(players);

            return RedirectToAction("Players");

        }

        [HttpGet("GetEditPost")]
        public ActionResult PlayersEdit(int id)
        {
            var players = playersServices.Get_with_ID(id);
            return View(players);
        }

        [HttpPost("EditPost")]
        public ActionResult EditPost(int id, [FromForm] Players players)
        {

            playersServices.Update_with_ID(id, players);
            return RedirectToAction("Players");
        }

        [HttpGet("PlayerDetails")]
        public ActionResult PlayersDetails(int id)
        {
            var players = playersServices.Get_with_ID(id);
            return View(players);
        }

        [HttpGet("GetDeletePost")]
        public ActionResult PlayersDelete(int id)
        {
            var players = playersServices.Get_with_ID(id);
            return View(players);
        }

        [HttpPost("DeletePost")]
        public ActionResult DeletePost(int id)
        {
            playersServices.Delete_with_ID(id);
            return RedirectToAction("Players");
        }

    }
}
