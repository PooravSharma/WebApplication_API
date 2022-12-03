﻿using Microsoft.AspNetCore.Mvc;
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

        public CharacterController(ICharactersServices characterServices)
        {
            this.characterServices = characterServices;
        }


        // GET: api/<CharacterController>
        [HttpGet("Get all Characters")]
        public ActionResult<List<Characters>> GetAll()
        {
            return characterServices.GetAll();
        }

        // GET api/<CharacterController>/5
        [HttpGet("Get specific Character using {id}")]
        public ActionResult<Characters> Get(int id)
        {
            var character = characterServices.Get_with_ID(id);
            if (character == null)
            {
                return NotFound($"Character with the ID = {id} not found");
            }
            return character;

        }

        // POST api/<CharacterController>
        [HttpPost("Add a Character")]
        public ActionResult<Characters> Post([FromBody] Characters character)
        {
            Characters existingCharacter = characterServices.Get_with_ID(character.Id);
            if (existingCharacter != null)
            {
                return NotFound($"Character with the id = " +existingCharacter.Id+ " already exists");
            }
            characterServices.Create(character);
            return CreatedAtAction(nameof(Get), new { id = character.Id }, character);

        }

        // PUT api/<CharacterController>/5
        [HttpPut("Update using {id}")]
        public ActionResult Put(int id, [FromBody] Characters character)
        {
            var existingPlayer = characterServices.Get_with_ID(id);

            if (existingPlayer == null)
            {
                return NotFound($"Character with Id = {id} not found");
            }

            return NoContent();
        }

        // DELETE api/<CharacterController>/5
        [HttpDelete("Delete using {id}")]
        public ActionResult Delete(int id)
        {
            var character = characterServices.Get_with_ID(id);
            if (character == null)
            {
                return NotFound($"Players with Id = {id} not found");
            }

            characterServices.Delete_with_ID(character.Id);

            return Ok($"Character with Id = {id} deleted");
        }

        // DELETE api/<CharacterController>/5
        [HttpDelete("Delete Multiple")]
        public ActionResult DeleteMultiple(int[] characterIds)
        {
            foreach (var id in characterIds)
            {
                var character = characterServices.Get_with_ID(id);
                if (character == null)
                {
                    return NotFound($"Character with Id = {id} not found");
                }

                characterServices.Delete_with_ID(character.Id);

            }
            return NoContent();
        }

        [HttpGet("Get all Characters Sorted PlayTime")]
        public ActionResult<List<Characters>> GetSortedPlaytimel()
        {
            return characterServices.GetSortedPlayTime();
        }


        public IActionResult Characters()
        {
            return View(characterServices.GetSortedPlayTime());
        }
    }

}
