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
        [Route("{publicUrl}")]
        public async Task<IActionResult> GetOneMacaron(string publicUrl)
        {
            try
            {
                var macaron = await _service.GetOneByPublicUrl(publicUrl);
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
            try
            {
                var macaron = await _service.CreateMacaron(createMacaronDto);
                return Ok(macaron);
            }
            catch (DuplicateWaitObjectException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, new { message = "An unexpected error occurred." });
            }
        }

        [HttpPut]
        [Route("{id}")]
        [Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> UpdateMacaron(Guid id, CreateMacaronDto createMacaronDto)
        {
            try
            {
                var macaron = await _service.UpdateMacaron(id, createMacaronDto);
                return Ok(macaron);
            }
            catch (DuplicateWaitObjectException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, new { message = "An unexpected error occurred." });
            }

        }

    }
}
