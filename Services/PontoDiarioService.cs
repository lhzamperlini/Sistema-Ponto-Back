using Microsoft.EntityFrameworkCore;
using Sistema_Ponto_Back.Dtos.PontoDiario;
using Sistema_Ponto_Back.Interfaces.Services;
using Sistema_Ponto_Back.Models;

namespace Sistema_Ponto_Back.Services
{
    public class PontoDiarioService : IPontoDiarioService
    {
        private readonly ApplicationDbContext _context;

        public PontoDiarioService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddPontoDiario(PontoDiarioDTO pontoDiario)
        {
            try
            {
                var pontoDiarioDB = new PontoDiario();

                pontoDiarioDB.Id = Guid.NewGuid();
                pontoDiarioDB.DataApontamento = pontoDiario.DataApontamento;
                pontoDiarioDB.ModuloApontamento = pontoDiario.ModuloApontamento;
                pontoDiarioDB.Minutos = pontoDiario.Minutos;
                pontoDiarioDB.Horas = pontoDiario.Horas;
                pontoDiarioDB.Descricao = pontoDiario.Descricao;

                await _context.PontosDiarios.AddAsync(pontoDiarioDB);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Algo de errado aconteceu, tente novamente.");
            }
        }

        public async Task<List<PontoDiarioDTO>> GetPontos()
        {
            var pontosDTO = new List<PontoDiarioDTO>();
            var pontos = await _context.PontosDiarios.Include(m => m.ModuloApontamento).ToListAsync();
            foreach(PontoDiario ponto in pontos)
            {
               var pontoDTO = new PontoDiarioDTO(ponto.Id, ponto.ModuloApontamento, ponto.DataApontamento, ponto.Horas, ponto.Minutos, ponto.Descricao);
               pontosDTO.Add(pontoDTO);
            }
            return pontosDTO;
        }

        public async Task UpdatePontoDiario(PontoDiarioDTO pontoDiario)
        {
            var pontoDiarioUpdate = await _context.PontosDiarios.Include(m => m.ModuloApontamento).FirstOrDefaultAsync(p => p.Id.Equals(pontoDiario.Id));
            pontoDiarioUpdate.ModuloApontamento = pontoDiario.ModuloApontamento;
            pontoDiarioUpdate.Descricao = pontoDiario.Descricao;
            pontoDiarioUpdate.Minutos = pontoDiario.Minutos;
            pontoDiarioUpdate.Horas = pontoDiario.Horas;
            pontoDiarioUpdate.DataApontamento = pontoDiario.DataApontamento;

            await _context.SaveChangesAsync();
        }

        public async Task DeletePontoDiario(Guid Id)
        { 
                var ponto = _context.PontosDiarios.Where(p => p.Id.Equals(Id)).First();
                _context.PontosDiarios.Remove(ponto);
                await _context.SaveChangesAsync();
        }
    }
}
