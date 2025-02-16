using Budget_APP.Models.DataBase;
using Budget_APP.Repositories;
using Budget_APP.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Budget_APP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenderController : ControllerBase
    {
        private readonly IGenderRepositories _genderRepositories;

        public GenderController(IGenderRepositories BaseRepositories)
        {
            _genderRepositories = BaseRepositories;
        }

        [HttpGet]
        [Route("GetGenders")]
        public async Task<ActionResult<Gender>> GetGender(int id)
        {
            var Genderid = await _genderRepositories.GetGenderByIdAsync(id);
            if (Genderid == null)
            {
                return NotFound();
            }
            return Ok(Genderid);
        }

        [HttpPost]
        [Route("AddGender")]
        public async Task<ActionResult<Gender>> AddGender(Gender gender)
        {
            await _genderRepositories.AddGenderAsync(gender);
            return CreatedAtAction("GetGender", new {id = gender.GenderId, gender});

        }

        [HttpPut]
        [Route("PutGender")]
        public async Task<ActionResult<Gender>> PutGender(int id, Gender gender)
        {
            if (id != gender.GenderId)
            {
                return BadRequest();
            }
            try
            {
                await _genderRepositories.UpdateGenderAsync(gender);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (await _genderRepositories.GetGenderByIdAsync(id) == null)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }

        [HttpDelete]
        [Route("DeleteGender")]
        public async Task<ActionResult<Gender>> DeleteGender(int id)
        {
            var Gender = await _genderRepositories.DeleteGenderAsync(id);
            if (Gender == null)
            {
                return NotFound();
            }
            return Ok(Gender);

        }
    }
}