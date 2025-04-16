// Informações de cada quarto no hotel.

namespace API.Models{
    public class Quarto{
        public int Id { get; set; } 
        public string Tipo { get; set; } // Tipo de quarto (solteiro, duplo, suíte)
        public decimal PrecoPorDia { get; set; }
        public bool Disponivel { get; set; } = true;
    }
}