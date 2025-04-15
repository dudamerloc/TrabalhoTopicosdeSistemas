// Contexto do banco de dados. Ele vai dizer ao Entity Framework como armazenar essas classes no banco de dados.

using Microsoft.EntityFrameworkCore;
using API.Models;

public class AppDataContext : DbContext{
    public DbSet<Hospede> Hospedes { get; set; } 
    public DbSet<Quarto> Quartos { get; set; } 
    public DbSet<Reserva> Reservas { get; set; } 

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){ //onConfiguring: método que configura o banco de dados
        optionsBuilder.UseSqlite("Data Source=hoteldm.db"); // Usando SQLite como banco de dados
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder){
    
        modelBuilder.Entity<Quarto>().HasData(
            new Quarto() { Id = 1, Tipo = "Simples", PrecoPorDia = 100, Disponivel = true },
            new Quarto() { Id = 2, Tipo = "Duplo", PrecoPorDia = 180, Disponivel = true },
            new Quarto() { Id = 3, Tipo = "Suíte", PrecoPorDia = 250, Disponivel = true }
        );
    }
}
