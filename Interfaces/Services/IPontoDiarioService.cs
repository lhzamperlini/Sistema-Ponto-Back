using Sistema_Ponto_Back.Dtos.PontoDiario;

namespace Sistema_Ponto_Back.Interfaces.Services
{
    public interface IPontoDiarioService
    {
        Task AddPontoDiario(PontoDiarioDTO pontoDiario);
        Task<List<PontoDiarioDTO>> GetPontos();
        Task UpdatePontoDiario(PontoDiarioDTO pontoDiario);
        Task DeletePontoDiario(Guid Id);
    }
}
