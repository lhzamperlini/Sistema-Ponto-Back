using Sistema_Ponto_Back.Dtos.PontoDiario;

namespace Sistema_Ponto_Back.Models
{
    public class PontoDiario
    {
        public PontoDiario() { }
        public Guid Id { get; set; }
        public ModuloApontamento ModuloApontamento { get; set; }
        public DateTime DataApontamento { get; set; }
        public int Horas { get; set; }
        public int Minutos { get; set; }
        public string Descricao { get; set; }
    }
}
