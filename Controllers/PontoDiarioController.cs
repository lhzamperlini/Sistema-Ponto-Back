using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Sistema_Ponto_Back.Dtos.PontoDiario;
using Sistema_Ponto_Back.Interfaces.Services;
using Sistema_Ponto_Back.Models;

namespace Sistema_Ponto_Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PontoDiarioController : Controller
    {
        private readonly IPontoDiarioService _pontoDiarioService;

        public PontoDiarioController(IPontoDiarioService pontoDiarioService)
        {
            _pontoDiarioService = pontoDiarioService;
        }


        [HttpPost]
        public async Task<IActionResult> AddPontoDiario([FromBody] PontoDiarioDTO pontoDiarioDTO)
        {
            try {
                await _pontoDiarioService.AddPontoDiario(pontoDiarioDTO);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }            
        }
        [HttpGet]
        public async Task<IActionResult> GetPontos()
        {
            var pontos = await _pontoDiarioService.GetPontos();
            return Ok(pontos);
        }
        [HttpPut]
        public async Task<IActionResult> UpdatePonto([FromBody]PontoDiarioDTO pontoDiario)
        {
            await _pontoDiarioService.UpdatePontoDiario(pontoDiario);
            return Ok();
        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeletePonto([FromRoute] Guid Id)
        {
            await _pontoDiarioService.DeletePontoDiario(Id);
            return Ok();
        }
    }
}
