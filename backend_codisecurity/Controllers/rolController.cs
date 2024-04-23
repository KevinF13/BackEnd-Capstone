

using backend_codisecurity.Models;
using backend_codisecurity.Services;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace backend_codisecurity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class rolController : ControllerBase
    {

        private readonly rolService _rolService;

        public rolController(rolService rolService) =>
            _rolService = rolService;

        [HttpGet]
        public async Task<List<Rol>> Get() =>
            await _rolService.GetAsync();

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Rol>> Get(string id)
        {
            var rol = await _rolService.GetAsync(id);

            if (rol is null)
            {
                return NotFound();
            }

            return rol;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Rol nuevoRol)
        {
            await _rolService.CreateAsync(nuevoRol);

            return CreatedAtAction(nameof(Get), new { id = nuevoRol.Id }, nuevoRol);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, Rol updatedRol)
        {
            var rol = await _rolService.GetAsync(id);

            if (rol is null)
            {
                return NotFound();
            }

            updatedRol.Id = rol.Id;

            await _rolService.UpdateAsync(id, updatedRol);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var rol = await _rolService.GetAsync(id);

            if (rol is null)
            {
                return NotFound();
            }

            await _rolService.RemoveAsync(id);

            return NoContent();
        }

    }

}
