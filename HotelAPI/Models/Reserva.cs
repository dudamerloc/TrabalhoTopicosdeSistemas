// Hóspede faz uma reserva para um quarto específico.
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace API.Models
{
    public class Reserva
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O Quarto field é obrigatório.")]
        public int QuartoId { get; set; }

        [Required(ErrorMessage = "O Hospede field é obrigatório.")]
        public int HospedeId { get; set; }

        public Hospede? Hospede { get; set; }
        public Quarto? Quarto { get; set; }
        
        public DateTime DataEntrada { get; set; }
        public DateTime DataSaida { get; set; }
    }
}