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
        // Relación entre Usuario y Rol
        modelBuilder.Entity<Usuario>()
            .HasOne(u => u.Rol)
            .WithMany(r => r.Usuarios)
            .HasForeignKey(u => u.IdRol);
        // Relación entre Usuario y Transaccion
        modelBuilder.Entity<Usuario>()
            .HasMany(u => u.Transacciones)
            .WithOne(t => t.Usuario)
            .HasForeignKey(t => t.IdUsuario);

        // Relación entre Usuario y Anuncio
        modelBuilder.Entity<Usuario>()
            .HasMany(u => u.Anuncios)
            .WithOne(a => a.Usuario)
            .HasForeignKey(a => a.IdUsuario);

        // Relación entre Usuario y Reseña
        modelBuilder.Entity<Usuario>()
            .HasMany(u => u.Reseñas)
            .WithOne(r => r.Usuario)
            .HasForeignKey(r => r.IdUsuario);

        // Relación entre Usuario y Carrito
        modelBuilder.Entity<Usuario>()
            .HasOne(u => u.Carrito)
            .WithOne(c => c.Usuario)
            .HasForeignKey<Carrito>(c => c.IdUsuario);

        // Relación entre Usuario y Biblioteca
        modelBuilder.Entity<Usuario>()
            .HasOne(u => u.Biblioteca)
            .WithOne(b => b.Usuario)
            .HasForeignKey<Biblioteca>(b => b.IdUsuario);

        // Relación entre Juego y Biblioteca
        modelBuilder.Entity<BibliotecaJuego>()
            .HasKey(pc => pc.BibliotecaJuegoId);

        modelBuilder.Entity<BibliotecaJuego>()
            .HasOne(pc => pc.Biblioteca)
            .WithMany(p => p.BibliotecaJuegos)
            .HasForeignKey(pc => pc.BibliotecaId);

        modelBuilder.Entity<BibliotecaJuego>()
            .HasOne(pc => pc.Juego)
            .WithMany(c => c.BibliotecaJuegos)
            .HasForeignKey(pc => pc.JuegoId);

        // Relación entre Producto y Biblioteca
        modelBuilder.Entity<BibliotecaProducto>()
            .HasKey(pc => pc.BibliotecaProductoId);

        modelBuilder.Entity<BibliotecaProducto>()
            .HasOne(pc => pc.Biblioteca)
            .WithMany(p => p.BibliotecaProductos)
            .HasForeignKey(pc => pc.BibliotecaId);

        modelBuilder.Entity<BibliotecaProducto>()
            .HasOne(pc => pc.Producto)
            .WithMany(c => c.BibliotecaProductos)
            .HasForeignKey(pc => pc.ProductoId);

        // Relación entre Producto y Anuncio
        modelBuilder.Entity<Producto>()
            .HasOne(p => p.Anuncio)
            .WithOne(a => a.Producto)
            .HasForeignKey<Anuncio>(a => a.IdProducto);

        // Relación entre Producto y Carrito
        modelBuilder.Entity<CarritoProducto>()
            .HasKey(pc => pc.CarritoProductoId);

        modelBuilder.Entity<CarritoProducto>()
            .HasOne(pc => pc.Carrito)
            .WithMany(p => p.CarritoProductos)
            .HasForeignKey(pc => pc.CarritoId);

        modelBuilder.Entity<CarritoProducto>()
            .HasOne(pc => pc.Producto)
            .WithMany(c => c.CarritoProductos)
            .HasForeignKey(pc => pc.ProductoId);

        // Relación entre Carrito y Juego
        modelBuilder.Entity<CarritoJuego>()
            .HasKey(cj => cj.CarritoJuegoId);

        modelBuilder.Entity<CarritoJuego>()
            .HasOne(cj => cj.Carrito)
            .WithMany(c => c.CarritoJuegos)
            .HasForeignKey(cj => cj.CarritoId);

        modelBuilder.Entity<CarritoJuego>()
            .HasOne(cj => cj.Juego)
            .WithMany(j => j.CarritoJuegos)
            .HasForeignKey(cj => cj.JuegoId);

        // Relación entre Producto y Reseña
        modelBuilder.Entity<Producto>()
            .HasMany(p => p.Reseñas)
            .WithOne(r => r.Producto)
            .HasForeignKey(r => r.IdProducto);

        // Relación entre Juego y Reseña
        modelBuilder.Entity<Juego>()
            .HasMany(j => j.Reseñas)
            .WithOne(r => r.Juego)
            .HasForeignKey(r => r.IdJuego);

        // Relación entre Producto y Categoria
        modelBuilder.Entity<ProductoCategoria>()
            .HasKey(pc => new { pc.ProductoId, pc.CategoriaId });

        modelBuilder.Entity<ProductoCategoria>()
            .HasOne(pc => pc.Producto)
            .WithMany(p => p.ProductoCategorias)
            .HasForeignKey(pc => pc.ProductoId);

        modelBuilder.Entity<ProductoCategoria>()
            .HasOne(pc => pc.Categoria)
            .WithMany(c => c.ProductoCategorias)
            .HasForeignKey(pc => pc.CategoriaId);

        // Relación entre Juego y Categoria
        modelBuilder.Entity<JuegoCategoria>()
            .HasKey(jc => new { jc.JuegoId, jc.CategoriaId });

        modelBuilder.Entity<JuegoCategoria>()
            .HasOne(jc => jc.Juego)
            .WithMany(j => j.JuegoCategorias)
            .HasForeignKey(jc => jc.JuegoId);

        modelBuilder.Entity<JuegoCategoria>()
            .HasOne(jc => jc.Categoria)
            .WithMany(c => c.JuegoCategorias)
            .HasForeignKey(jc => jc.CategoriaId);

        // Relacion entre juegos. producto e imagenes
        modelBuilder.Entity<Juego>()
                .HasMany(p => p.ImgsJuego)
                .WithOne(i => i.Juego)
                .HasForeignKey(i => i.JuegoId)
                .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Producto>()
            .HasMany(p => p.ImgsProducto)
            .WithOne(i => i.Producto)
            .HasForeignKey(i => i.ProductoId)
            .OnDelete(DeleteBehavior.Cascade);

        // Relación entre Imagen y Producto
        modelBuilder.Entity<Imagen>()
            .HasOne(i => i.Producto)
            .WithMany(p => p.ImgsProducto)
            .HasForeignKey(i => i.ProductoId);
        // Relación entre Imagen y Juego
        modelBuilder.Entity<Imagen>()
            .HasOne(i => i.Juego)
            .WithMany(p => p.ImgsJuego)
            .HasForeignKey(i => i.JuegoId);

        modelBuilder.Entity<Rol>().HasData(
        new Rol { IdRol = 1, Nombre = "Usuario" },
        new Rol { IdRol = 2, Nombre = "Admin" }
        );

        modelBuilder.Entity<Usuario>().HasData(
            new Usuario { IdUsuario = 1, IdRol = 2, Nombre = "Admin", Correo = "admin@gmail.com", Contraseña = "ADMINcontraseña123@" }
        );

    }

    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Juego> Juegos { get; set; }
    public DbSet<Transaccion> Transacciones { get; set; }
    public DbSet<Producto> Productos { get; set; }
    public DbSet<Reseña> Reseñas { get; set; }
    public DbSet<Carrito> Carritos { get; set; }
    public DbSet<Biblioteca> Bibliotecas { get; set; }
    public DbSet<Anuncio> Anuncios { get; set; }
    public DbSet<Imagen> Imagenes { get; set; }
    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Rol> Roles { get; set; }
    public DbSet<BibliotecaProducto> BibliotecaProductos { get; set; }
    public DbSet<BibliotecaJuego> BibliotecaJuegos { get; set; }
    public DbSet<CarritoProducto> CarritoProducto { get; set; }
    public DbSet<CarritoJuego> CarritoJuego { get; set; }
    public DbSet<JuegoCategoria> juegoCategorias { get; set; }
    public DbSet<ProductoCategoria> ProductoCategorias { get; set; }
}