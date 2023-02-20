using Microsoft.EntityFrameworkCore;
using Sistema_Ponto_Back.Dtos.ModuloApontamento;
using Sistema_Ponto_Back.Interfaces.Services;
using Sistema_Ponto_Back.Models;

namespace Sistema_Ponto_Back.Services
{
    public class ModuloApontamentoService : IModuloApontamentoService
    {
        private readonly ApplicationDbContext _context;

        public ModuloApontamentoService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddModuloApontamento(ModuloApontamentoDTO moduloApontamento)
        {
            try
            {
                var moduloApontamentoDb = new ModuloApontamento();

                moduloApontamentoDb.Id = Guid.NewGuid();
                moduloApontamentoDb.Nome = moduloApontamento.Nome;

                await _context.ModulosApontamento.AddAsync(moduloApontamentoDb);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Algo de errado aconteceu, tente novamente.");
            }
        }

        public async Task<List<ModuloApontamentoDTO>> GetModulos()
        {
            var modulosDTO = new List<ModuloApontamentoDTO>();
            var modulos = await _context.ModulosApontamento.ToListAsync();
            foreach (ModuloApontamento modulo in modulos)
            {
                var moduloDTO = new ModuloApontamentoDTO(modulo.Id, modulo.Nome);
                modulosDTO.Add(moduloDTO);
            }
            return modulosDTO;
        }

        public async Task UpdateModuloApontamento(ModuloApontamentoDTO moduloApontamento)
        {
            var modulo = _context.ModulosApontamento.Where(m => m.Id.Equals(moduloApontamento.Id)).First();
            modulo.Nome = moduloApontamento.Nome;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteModuloApontamento(Guid Id)
        {
            var modulo = _context.ModulosApontamento.Where(m => m.Id.Equals(Id)).First();
            _context.ModulosApontamento.Remove(modulo);
            await _context.SaveChangesAsync();
        }
    }
}
