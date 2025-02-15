using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Budget_APP.Models.DataBase;
using Budget_APP.Repositories;

namespace Budget_APP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Budge_APPController : ControllerBase
    {
        private readonly IBaseRepositories _BaseRepositories;

        public Budge_APPController(IBaseRepositories BaseRepositories)
        {
            _BaseRepositories = BaseRepositories;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Profile>>> GetProfiles()
        {
            var profiles = await _BaseRepositories.GetallProfilesAsnc();
            return Ok(profiles);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Profile>> GetProfile(int id)
        {
            var profile = await _BaseRepositories.GetProfileByIdAsync(id);
            if (profile == null)
            {
                return NotFound();
            }
            return Ok(profile);
        }
        [HttpPost]
        public async Task<ActionResult<Profile>> PostProfile(Profile profile)
        {
            await _BaseRepositories.AddProfileAsync(profile);
            return CreatedAtAction("GetProfile", new { id = profile.Id }, profile);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Profile>> PutProfile(int id, Profile profile)
        {
            if (id != profile.Id)
            {
                return BadRequest();
            }
            try
            {
                await _BaseRepositories.UpdateProfileAsync(profile);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (await _BaseRepositories.GetProfileByIdAsync(id) == null)
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
        [HttpDelete("{id}")]
        public async Task<ActionResult<Profile>> DeleteProfile(int id)
        {
            var profile = await _BaseRepositories.DeleteProfileAsync(id);
            if (profile == null)
            {
                return NotFound();
            }
            return Ok(profile);
        }
    }
}