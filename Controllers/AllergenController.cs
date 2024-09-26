using DonMacaron.DTOs;
using DonMacaron.Services.AllergenService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DonMacaron.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class AllergenController(IAllergenService service) : ControllerBase
    {

        private readonly IAllergenService _service = service;
        [HttpGet]
        
        public async Task<IActionResult> GetAllergens()
        {
            var allergens = await _service.GetAllergens();
            return Ok(allergens);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetAllergenById(Guid id)
        {
            try{    
                var allergen = await _service.GetAllergenById(id);
                return Ok(allergen);
            }
            catch (KeyNotFoundException ex){
                return NotFound(ex.Message);
            }
            catch (Exception){
                return StatusCode(500, new { message = "An unexpected error occurred." });
            }
        }

        [HttpPost]
        [Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> CreateAllergen(CreateAllergenDto createAllergenDto)
        {
            try{
                var allergen = await _service.CreateAllergen(createAllergenDto);
                return Ok(allergen);
            }
            catch (Exception){
                return StatusCode(500, new { message = "An unexpected error occurred." });
            }
        }

        [HttpPut]
        [Route("{id}")]
        [Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> UpdateAllergen(Guid id, CreateAllergenDto updateAlergenDto)
        {
            try{
                var allergen = await _service.UpdateAllergen(updateAlergenDto, id);
                return Ok(allergen);
            }
            catch (KeyNotFoundException ex){
                return NotFound(ex.Message);
            }
            catch (Exception){
                return StatusCode(500, new { message = "An unexpected error occurred." });
            }
        }
        
    }


}
