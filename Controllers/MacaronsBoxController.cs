using DonMacaron.DTOs.MacaronsBoxDto;
using DonMacaron.Services.MacaronsBoxService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DonMacaron.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MacaronsBoxController(IMacaronBoxService service) : ControllerBase
    {
        public readonly IMacaronBoxService _service = service;

        [HttpGet]
        public async Task<IActionResult> GetMacarons()
        {
            var macaronsBoxes = await _service.GetMacaronsBoxes();
            return Ok(macaronsBoxes);
        }

        [HttpPost]
        [Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> CreateMacaronBox(CreateMacaronsBoxDto createMacaronsBoxDto)
        {
            try
            {
                var newMacaronsBox = await _service.CreateMacaronsBox(createMacaronsBoxDto);
                return Ok(newMacaronsBox);
            }
            catch (DuplicateWaitObjectException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (NullReferenceException ex){
                return BadRequest(ex.Message);
            }
            catch (ArgumentOutOfRangeException ex){
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                return StatusCode(500, new { message = "An unexpected error occurred." });
            }
        }

        [HttpPut]
        [Route("{id}")]
        [Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> UpdateMacaron(Guid id, CreateMacaronsBoxDto createMacaronsBoxDto)
        {
            try
            {
                var macaron = await _service.UpdateMacaronsBox(id, createMacaronsBoxDto);
                return Ok(macaron);
            }
            catch (DuplicateWaitObjectException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (NullReferenceException ex){
                return BadRequest(ex.Message);
            }
            catch (ArgumentOutOfRangeException ex){
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                return StatusCode(500, new { message = "An unexpected error occurred." });
            }

        }

    }
}
