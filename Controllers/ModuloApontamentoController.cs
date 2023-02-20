using Microsoft.AspNetCore.Mvc;
using Sistema_Ponto_Back.Dtos.ModuloApontamento;
using Sistema_Ponto_Back.Interfaces.Services;

namespace Sistema_Ponto_Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModuloApontamentoController : Controller
    {
        private readonly IModuloApontamentoService _moduloApontamentoService;

        public ModuloApontamentoController(IModuloApontamentoService moduloApontamentoService)
        {
            _moduloApontamentoService = moduloApontamentoService;
        }


        [HttpPost]
        public async Task<IActionResult> AddModuloApontamento([FromBody] ModuloApontamentoDTO moduloApontamento)
        {
            try
            {
                await _moduloApontamentoService.AddModuloApontamento(moduloApontamento);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetPontos()
        {
            var pontos = await _moduloApontamentoService.GetModulos();
            return Ok(pontos);
        }
        [HttpPut]
        public async Task<IActionResult> UpdatePonto([FromBody] ModuloApontamentoDTO moduloApontamento)
        {
            await _moduloApontamentoService.UpdateModuloApontamento(moduloApontamento);
            return Ok();
        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteModuloApontamento([FromRoute] Guid Id)
        {
            await _moduloApontamentoService.DeleteModuloApontamento(Id);
            return Ok();
        }

    }
}
