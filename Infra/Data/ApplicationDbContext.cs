using Microsoft.EntityFrameworkCore;
using Sistema_Ponto_Back.Models;

public class ApplicationDbContext: DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){}
    //Aqui Virão as configurações de database
    public DbSet<PontoDiario> PontosDiarios { get; set; }
    public DbSet<ModuloApontamento> ModulosApontamento { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlServer();

    protected override void OnModelCreating(ModelBuilder builder)
    { 
        //FLUENT API - Exemplo de especificação de campo na tabela

        /*builder.Entity<PontoDiario>()
            .Property(p => p.Descricao).HasMaxLength(800);
        builder.Entity<PontoDiario>()
            .Property(p => p.Descricao).IsRequired(false); */
    }

}

