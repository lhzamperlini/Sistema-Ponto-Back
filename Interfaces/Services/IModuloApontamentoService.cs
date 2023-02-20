using Sistema_Ponto_Back.Dtos.ModuloApontamento;


namespace Sistema_Ponto_Back.Interfaces.Services
{
    public interface IModuloApontamentoService
    {
        Task AddModuloApontamento(ModuloApontamentoDTO moduloApontamento);
        Task<List<ModuloApontamentoDTO>> GetModulos();
        Task UpdateModuloApontamento(ModuloApontamentoDTO moduloApontamento);
        Task DeleteModuloApontamento(Guid Id);
    }
}
