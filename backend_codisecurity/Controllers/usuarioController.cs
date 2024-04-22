using backend_codisecurity.Models;
using backend_codisecurity.Services;
using Microsoft.AspNetCore.Mvc;

namespace backend_codisecurity.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class usuarioController : ControllerBase
    {

        private readonly usuarioService _usuariosService;

        public usuarioController(usuarioService usuarioService) =>
            _usuariosService = usuarioService;

        [HttpGet]
        public async Task<List<Usuarios>> Get() =>
            await _usuariosService.GetAsync();

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Usuarios>> Get(string id)
        {
            var book = await _usuariosService.GetAsync(id);

            if (book is null)
            {
                return NotFound();
            }

            return book;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Usuarios nuevosUsuarios)
        {
            await _usuariosService.CreateAsync(nuevosUsuarios);

            return CreatedAtAction(nameof(Get), new { id = nuevosUsuarios.Id }, nuevosUsuarios);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, Usuarios updatedUsuarios)
        {
            var book = await _usuariosService.GetAsync(id);

            if (book is null)
            {
                return NotFound();
            }

            updatedUsuarios.Id = book.Id;

            await _usuariosService.UpdateAsync(id, updatedUsuarios);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var book = await _usuariosService.GetAsync(id);

            if (book is null)
            {
                return NotFound();
            }

            await _usuariosService.RemoveAsync(id);

            return NoContent();
        }

    }
}
