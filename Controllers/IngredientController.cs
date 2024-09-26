using DonMacaron.DTOs;
using DonMacaron.DTOs.IngredientsDto;
using DonMacaron.Entities;
using DonMacaron.Services.IngredientService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DonMacaron.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientController(IIngredientService service) : ControllerBase
    {
        private readonly IIngredientService _service = service;
        [HttpGet]
        public async Task<IActionResult> GetIngredients()
        {
            try{
                var ingredients = await _service.GetIngredients();
                return Ok(ingredients);
            }
            catch (Exception){
                return StatusCode(500, new { message = "An unexpected error occurred." });
            }
        }

        [HttpPost]
        [Authorize(Roles = "ADMIN")]
        public async Task<ActionResult<Ingredient>> CreateIngredient(CreateIngredientDto createIngredientDto)
        {
            try{
                var ingredient = await _service.CreateIngredient(createIngredientDto);
                return Ok(ingredient);
            }
            catch (Exception){
                return StatusCode(500, new { message = "An unexpected error occurred." });
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetIngredientById(Guid id)
        {
            try{
                var ingredient = await _service.GetIngredientById(id);
                return Ok(ingredient);
            }
            catch (KeyNotFoundException ex){
                return NotFound(ex.Message);
            }
            catch (Exception){
                return StatusCode(500, new { message = "An unexpected error occurred." });
            }
        }

        [HttpPut]
        [Route("{id}")]
        [Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> UpdateIngredient(Guid id, UpdateIngredientDto updateIngredientDto)
        {
            try{
                var ingredient = await _service.UpdateIngredient(updateIngredientDto, id);
                return Ok(ingredient);

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
