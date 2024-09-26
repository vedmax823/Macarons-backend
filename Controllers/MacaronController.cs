using DonMacaron.DTOs;
using DonMacaron.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;



namespace DonMacaron.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MacaronController(IMacaronService service) : ControllerBase
    {
        public readonly IMacaronService _service = service;

        [HttpGet]
        public async Task<IActionResult> GetMacarons()
        {
            var macarons = await _service.GetMacarons();
            return Ok(macarons);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetOneMacaron(Guid id)
        {
            try{
            var macaron = await _service.GetOneById(id);
            return Ok(macaron);
            }
            catch (KeyNotFoundException)
            {
                return NotFound("Macaron wasn't found");
            }
            catch (Exception)
            {
                return StatusCode(500, new { message = "An unexpected error occurred." });
            }
        }

        [HttpPost]
        [Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> CreateMacaron(CreateMacaronDto createMacaronDto)
        {
            var macaron = await _service.CreateMacaron(createMacaronDto);
            return Ok(macaron);
        }

        
    }
}
