// Contexto do banco de dados. Ele vai dizer ao Entity Framework como armazenar essas classes no banco de dados.
// appdatacontext.cs (namespace HotelApi.Models)
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelApi.Models
{
    public class AppDataContext : DbContext
    {
        public AppDataContext(DbContextOptions<AppDataContext> options) : base(options) { }

        public DbSet<Hospede> Hospedes { get; set; }
        public DbSet<Quarto> Quartos { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
        public DbSet<Bebida> Cardapio { get; set; }


    }
}
