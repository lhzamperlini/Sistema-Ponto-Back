using Sistema_Ponto_Back.Models;

namespace Sistema_Ponto_Back.Dtos.PontoDiario
{
    public record PontoDiarioDTO(Guid Id, ModuloApontamento ModuloApontamento, DateTime DataApontamento, int Horas, int Minutos, string Descricao);
}
