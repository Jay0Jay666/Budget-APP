using Budget_APP.Models.DataBase;
using Budget_APP.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Budget_APP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly IProfileRepositories _profileRepositories;

        public ProfileController(IProfileRepositories BaseRepositories)
        {
            _profileRepositories = BaseRepositories;
        }

        [HttpGet]
        [Route("GetProfiles")]
        public async Task<ActionResult<IEnumerable<Profile>>> GetProfiles()
        {
            var profiles = await _profileRepositories.GetAllProfilesAsync();
            return Ok(profiles);
        }

        [HttpGet]
        [Route("GetProfileId")]
        public async Task<ActionResult<Profile>> GetProfileId(int id)
        {
            var profile = await _profileRepositories.GetProfileByIdAsync(id);
            if (profile == null)
            {
                return NotFound();
            }
            return Ok(profile);
        }

        [HttpPost]
        [Route("PostProfile")]
        public async Task<ActionResult<Profile>> PostProfile(Profile profile)
        {
            await _profileRepositories.AddProfileAsync(profile);
            return CreatedAtAction("GetProfile", new { id = profile.Id }, profile);
        }

        [HttpPut]
        [Route("PutProfile")]
        public async Task<ActionResult<Profile>> PutProfile(int id, Profile profile)
        {
            if (id != profile.Id)
            {
                return BadRequest();
            }
            try
            {
                await _profileRepositories.UpdateProfileAsync(profile);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (await _profileRepositories.GetProfileByIdAsync(id) == null)
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
        [Route("DeleteProfile")]
        public async Task<ActionResult<Profile>> DeleteProfile(int id)
        {
            var profile = await _profileRepositories.DeleteProfileAsync(id);
            if (profile == null)
            {
                return NotFound();
            }
            return Ok(profile);
        }
    }
}
