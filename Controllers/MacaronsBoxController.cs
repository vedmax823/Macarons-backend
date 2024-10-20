using DonMacaron.Services.MacaronsBoxService;
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

    }
}
