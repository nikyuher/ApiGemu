namespace Gemu.Data;

using Microsoft.EntityFrameworkCore;
using Gemu.Models;

public class GemuContext : DbContext
{

    public GemuContext(DbContextOptions<GemuContext> options)
    : base(options)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {


    }

    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Juego> Juegos { get; set; }
    public DbSet<Transaccion> Transacciones { get; set; }
    public DbSet<Producto> Productos { get; set; }
    public DbSet<Reseña> Reseñas { get; set; }
    public DbSet<Carrito> Carritos { get; set; }
    public DbSet<Biblioteca> Bibliotecas { get; set; }
    public DbSet<Anuncio> Anuncios { get; set; }
}