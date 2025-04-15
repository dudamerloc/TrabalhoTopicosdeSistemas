// Hóspede faz uma reserva para um quarto específico.

namespace API.Models{ 
    public class Reserva{ 
        public int Id { get; set; } 
        public int QuartoId { get; set; } 
        public int HospedeId { get; set; } 
        public DateTime DataEntrada { get; set; } 
        public DateTime DataSaida { get; set; } 
    } 
}