using Sistema_Ponto_Back.Models;

namespace Sistema_Ponto_Back.Dtos.PontoDiario
{
    public record PontoDiarioDTO(Guid Id, Guid ModuloApontamentoId, DateTime DataApontamento, int Horas, int Minutos, string Descricao);
}
