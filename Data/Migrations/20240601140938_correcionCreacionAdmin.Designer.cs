﻿// <auto-generated />
using System;
using Gemu.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Gemu.Data.Migrations
{
    [DbContext(typeof(GemuContext))]
    [Migration("20240601140938_correcionCreacionAdmin")]
    partial class correcionCreacionAdmin
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Gemu.Models.Anuncio", b =>
                {
                    b.Property<int>("IdAnuncio")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdAnuncio"), 1L, 1);

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdProducto")
                        .HasColumnType("int");

                    b.Property<int>("IdUsuario")
                        .HasColumnType("int");

                    b.HasKey("IdAnuncio");

                    b.HasIndex("IdProducto")
                        .IsUnique();

                    b.HasIndex("IdUsuario");

                    b.ToTable("Anuncios");
                });

            modelBuilder.Entity("Gemu.Models.Biblioteca", b =>
                {
                    b.Property<int>("IdBiblioteca")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdBiblioteca"), 1L, 1);

                    b.Property<int>("IdUsuario")
                        .HasColumnType("int");

                    b.HasKey("IdBiblioteca");

                    b.HasIndex("IdUsuario")
                        .IsUnique();

                    b.ToTable("Bibliotecas");

                    b.HasData(
                        new
                        {
                            IdBiblioteca = 1,
                            IdUsuario = 1
                        });
                });

            modelBuilder.Entity("Gemu.Models.BibliotecaJuego", b =>
                {
                    b.Property<int>("BibliotecaJuegoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BibliotecaJuegoId"), 1L, 1);

                    b.Property<int>("BibliotecaId")
                        .HasColumnType("int");

                    b.Property<int>("JuegoId")
                        .HasColumnType("int");

                    b.HasKey("BibliotecaJuegoId");

                    b.HasIndex("BibliotecaId");

                    b.HasIndex("JuegoId");

                    b.ToTable("BibliotecaJuegos");
                });

            modelBuilder.Entity("Gemu.Models.BibliotecaProducto", b =>
                {
                    b.Property<int>("BibliotecaProductoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BibliotecaProductoId"), 1L, 1);

                    b.Property<int>("BibliotecaId")
                        .HasColumnType("int");

                    b.Property<int>("ProductoId")
                        .HasColumnType("int");

                    b.HasKey("BibliotecaProductoId");

                    b.HasIndex("BibliotecaId");

                    b.HasIndex("ProductoId");

                    b.ToTable("BibliotecaProductos");
                });

            modelBuilder.Entity("Gemu.Models.Carrito", b =>
                {
                    b.Property<int>("IdCarrito")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCarrito"), 1L, 1);

                    b.Property<int>("IdUsuario")
                        .HasColumnType("int");

                    b.HasKey("IdCarrito");

                    b.HasIndex("IdUsuario")
                        .IsUnique();

                    b.ToTable("Carritos");

                    b.HasData(
                        new
                        {
                            IdCarrito = 1,
                            IdUsuario = 1
                        });
                });

            modelBuilder.Entity("Gemu.Models.CarritoJuego", b =>
                {
                    b.Property<int>("CarritoJuegoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CarritoJuegoId"), 1L, 1);

                    b.Property<int>("CarritoId")
                        .HasColumnType("int");

                    b.Property<int>("JuegoId")
                        .HasColumnType("int");

                    b.HasKey("CarritoJuegoId");

                    b.HasIndex("CarritoId");

                    b.HasIndex("JuegoId");

                    b.ToTable("CarritoJuego");
                });

            modelBuilder.Entity("Gemu.Models.CarritoProducto", b =>
                {
                    b.Property<int>("CarritoProductoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CarritoProductoId"), 1L, 1);

                    b.Property<int>("CarritoId")
                        .HasColumnType("int");

                    b.Property<int>("ProductoId")
                        .HasColumnType("int");

                    b.HasKey("CarritoProductoId");

                    b.HasIndex("CarritoId");

                    b.HasIndex("ProductoId");

                    b.ToTable("CarritoProducto");
                });

            modelBuilder.Entity("Gemu.Models.Categoria", b =>
                {
                    b.Property<int>("IdCategoria")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCategoria"), 1L, 1);

                    b.Property<string>("Icono")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Seccion")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdCategoria");

                    b.ToTable("Categorias");
                });

            modelBuilder.Entity("Gemu.Models.Imagen", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<byte[]>("Datos")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<bool>("EsPortada")
                        .HasColumnType("bit");

                    b.Property<int?>("JuegoId")
                        .HasColumnType("int");

                    b.Property<int?>("JuegoIdJuego")
                        .HasColumnType("int");

                    b.Property<int?>("ProductoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("JuegoId");

                    b.HasIndex("JuegoIdJuego")
                        .IsUnique()
                        .HasFilter("[JuegoIdJuego] IS NOT NULL");

                    b.HasIndex("ProductoId");

                    b.ToTable("Imagenes");
                });

            modelBuilder.Entity("Gemu.Models.Juego", b =>
                {
                    b.Property<int>("IdJuego")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdJuego"), 1L, 1);

                    b.Property<string>("CodigoJuego")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Descuento")
                        .HasColumnType("int");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<int?>("IdImagen")
                        .HasColumnType("int");

                    b.Property<int?>("IdReseña")
                        .HasColumnType("int");

                    b.Property<string>("Plataforma")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Precio")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("ReseñaIdReseña")
                        .HasColumnType("int");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdJuego");

                    b.HasIndex("ReseñaIdReseña");

                    b.ToTable("Juegos");
                });

            modelBuilder.Entity("Gemu.Models.JuegoCategoria", b =>
                {
                    b.Property<int>("JuegoId")
                        .HasColumnType("int");

                    b.Property<int>("CategoriaId")
                        .HasColumnType("int");

                    b.HasKey("JuegoId", "CategoriaId");

                    b.HasIndex("CategoriaId");

                    b.ToTable("juegoCategorias");
                });

            modelBuilder.Entity("Gemu.Models.Producto", b =>
                {
                    b.Property<int>("IdProducto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdProducto"), 1L, 1);

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<int?>("IdAnuncio")
                        .HasColumnType("int");

                    b.Property<int?>("IdReseña")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Precio")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("ReseñaIdReseña")
                        .HasColumnType("int");

                    b.HasKey("IdProducto");

                    b.HasIndex("ReseñaIdReseña");

                    b.ToTable("Productos");
                });

            modelBuilder.Entity("Gemu.Models.ProductoCategoria", b =>
                {
                    b.Property<int>("ProductoId")
                        .HasColumnType("int");

                    b.Property<int>("CategoriaId")
                        .HasColumnType("int");

                    b.HasKey("ProductoId", "CategoriaId");

                    b.HasIndex("CategoriaId");

                    b.ToTable("ProductoCategorias");
                });

            modelBuilder.Entity("Gemu.Models.Reseña", b =>
                {
                    b.Property<int>("IdReseña")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdReseña"), 1L, 1);

                    b.Property<int>("Calificacion")
                        .HasColumnType("int");

                    b.Property<string>("Comentario")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<int?>("IdJuego")
                        .HasColumnType("int");

                    b.Property<int?>("IdProducto")
                        .HasColumnType("int");

                    b.Property<int>("IdUsuario")
                        .HasColumnType("int");

                    b.Property<string>("NombreUsuario")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Solicitud")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdReseña");

                    b.HasIndex("IdJuego");

                    b.HasIndex("IdProducto");

                    b.HasIndex("IdUsuario");

                    b.ToTable("Reseñas");
                });

            modelBuilder.Entity("Gemu.Models.Rol", b =>
                {
                    b.Property<int>("IdRol")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdRol"), 1L, 1);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdRol");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            IdRol = 1,
                            Nombre = "Usuario"
                        },
                        new
                        {
                            IdRol = 2,
                            Nombre = "Admin"
                        });
                });

            modelBuilder.Entity("Gemu.Models.Transaccion", b =>
                {
                    b.Property<int>("IdTransaccion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdTransaccion"), 1L, 1);

                    b.Property<decimal>("Cantidad")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdUsuario")
                        .HasColumnType("int");

                    b.Property<string>("Nota")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("IdTransaccion");

                    b.HasIndex("IdUsuario");

                    b.ToTable("Transacciones");
                });

            modelBuilder.Entity("Gemu.Models.Usuario", b =>
                {
                    b.Property<int>("IdUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdUsuario"), 1L, 1);

                    b.Property<int>("CodigoPostal")
                        .HasColumnType("int");

                    b.Property<string>("Contraseña")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Correo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("FotoPerfil")
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("IdRol")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("SaldoActual")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("IdUsuario");

                    b.HasIndex("IdRol");

                    b.ToTable("Usuarios");

                    b.HasData(
                        new
                        {
                            IdUsuario = 1,
                            CodigoPostal = 0,
                            Contraseña = "ADMINcontraseña123@",
                            Correo = "admin@gmail.com",
                            IdRol = 2,
                            Nombre = "Admin",
                            SaldoActual = 0m
                        });
                });

            modelBuilder.Entity("Gemu.Models.Anuncio", b =>
                {
                    b.HasOne("Gemu.Models.Producto", "Producto")
                        .WithOne("Anuncio")
                        .HasForeignKey("Gemu.Models.Anuncio", "IdProducto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Gemu.Models.Usuario", "Usuario")
                        .WithMany("Anuncios")
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Producto");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Gemu.Models.Biblioteca", b =>
                {
                    b.HasOne("Gemu.Models.Usuario", "Usuario")
                        .WithOne("Biblioteca")
                        .HasForeignKey("Gemu.Models.Biblioteca", "IdUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Gemu.Models.BibliotecaJuego", b =>
                {
                    b.HasOne("Gemu.Models.Biblioteca", "Biblioteca")
                        .WithMany("BibliotecaJuegos")
                        .HasForeignKey("BibliotecaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Gemu.Models.Juego", "Juego")
                        .WithMany("BibliotecaJuegos")
                        .HasForeignKey("JuegoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Biblioteca");

                    b.Navigation("Juego");
                });

            modelBuilder.Entity("Gemu.Models.BibliotecaProducto", b =>
                {
                    b.HasOne("Gemu.Models.Biblioteca", "Biblioteca")
                        .WithMany("BibliotecaProductos")
                        .HasForeignKey("BibliotecaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Gemu.Models.Producto", "Producto")
                        .WithMany("BibliotecaProductos")
                        .HasForeignKey("ProductoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Biblioteca");

                    b.Navigation("Producto");
                });

            modelBuilder.Entity("Gemu.Models.Carrito", b =>
                {
                    b.HasOne("Gemu.Models.Usuario", "Usuario")
                        .WithOne("Carrito")
                        .HasForeignKey("Gemu.Models.Carrito", "IdUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Gemu.Models.CarritoJuego", b =>
                {
                    b.HasOne("Gemu.Models.Carrito", "Carrito")
                        .WithMany("CarritoJuegos")
                        .HasForeignKey("CarritoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Gemu.Models.Juego", "Juego")
                        .WithMany("CarritoJuegos")
                        .HasForeignKey("JuegoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Carrito");

                    b.Navigation("Juego");
                });

            modelBuilder.Entity("Gemu.Models.CarritoProducto", b =>
                {
                    b.HasOne("Gemu.Models.Carrito", "Carrito")
                        .WithMany("CarritoProductos")
                        .HasForeignKey("CarritoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Gemu.Models.Producto", "Producto")
                        .WithMany("CarritoProductos")
                        .HasForeignKey("ProductoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Carrito");

                    b.Navigation("Producto");
                });

            modelBuilder.Entity("Gemu.Models.Imagen", b =>
                {
                    b.HasOne("Gemu.Models.Juego", "Juego")
                        .WithMany("ImgsJuego")
                        .HasForeignKey("JuegoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Gemu.Models.Juego", null)
                        .WithOne("Imagen")
                        .HasForeignKey("Gemu.Models.Imagen", "JuegoIdJuego");

                    b.HasOne("Gemu.Models.Producto", "Producto")
                        .WithMany("ImgsProducto")
                        .HasForeignKey("ProductoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Juego");

                    b.Navigation("Producto");
                });

            modelBuilder.Entity("Gemu.Models.Juego", b =>
                {
                    b.HasOne("Gemu.Models.Reseña", "Reseña")
                        .WithMany()
                        .HasForeignKey("ReseñaIdReseña");

                    b.Navigation("Reseña");
                });

            modelBuilder.Entity("Gemu.Models.JuegoCategoria", b =>
                {
                    b.HasOne("Gemu.Models.Categoria", "Categoria")
                        .WithMany("JuegoCategorias")
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Gemu.Models.Juego", "Juego")
                        .WithMany("JuegoCategorias")
                        .HasForeignKey("JuegoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");

                    b.Navigation("Juego");
                });

            modelBuilder.Entity("Gemu.Models.Producto", b =>
                {
                    b.HasOne("Gemu.Models.Reseña", "Reseña")
                        .WithMany()
                        .HasForeignKey("ReseñaIdReseña");

                    b.Navigation("Reseña");
                });

            modelBuilder.Entity("Gemu.Models.ProductoCategoria", b =>
                {
                    b.HasOne("Gemu.Models.Categoria", "Categoria")
                        .WithMany("ProductoCategorias")
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Gemu.Models.Producto", "Producto")
                        .WithMany("ProductoCategorias")
                        .HasForeignKey("ProductoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");

                    b.Navigation("Producto");
                });

            modelBuilder.Entity("Gemu.Models.Reseña", b =>
                {
                    b.HasOne("Gemu.Models.Juego", "Juego")
                        .WithMany("Reseñas")
                        .HasForeignKey("IdJuego");

                    b.HasOne("Gemu.Models.Producto", "Producto")
                        .WithMany("Reseñas")
                        .HasForeignKey("IdProducto");

                    b.HasOne("Gemu.Models.Usuario", "Usuario")
                        .WithMany("Reseñas")
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Juego");

                    b.Navigation("Producto");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Gemu.Models.Transaccion", b =>
                {
                    b.HasOne("Gemu.Models.Usuario", "Usuario")
                        .WithMany("Transacciones")
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Gemu.Models.Usuario", b =>
                {
                    b.HasOne("Gemu.Models.Rol", "Rol")
                        .WithMany("Usuarios")
                        .HasForeignKey("IdRol")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Rol");
                });

            modelBuilder.Entity("Gemu.Models.Biblioteca", b =>
                {
                    b.Navigation("BibliotecaJuegos");

                    b.Navigation("BibliotecaProductos");
                });

            modelBuilder.Entity("Gemu.Models.Carrito", b =>
                {
                    b.Navigation("CarritoJuegos");

                    b.Navigation("CarritoProductos");
                });

            modelBuilder.Entity("Gemu.Models.Categoria", b =>
                {
                    b.Navigation("JuegoCategorias");

                    b.Navigation("ProductoCategorias");
                });

            modelBuilder.Entity("Gemu.Models.Juego", b =>
                {
                    b.Navigation("BibliotecaJuegos");

                    b.Navigation("CarritoJuegos");

                    b.Navigation("Imagen");

                    b.Navigation("ImgsJuego");

                    b.Navigation("JuegoCategorias");

                    b.Navigation("Reseñas");
                });

            modelBuilder.Entity("Gemu.Models.Producto", b =>
                {
                    b.Navigation("Anuncio");

                    b.Navigation("BibliotecaProductos");

                    b.Navigation("CarritoProductos");

                    b.Navigation("ImgsProducto");

                    b.Navigation("ProductoCategorias");

                    b.Navigation("Reseñas");
                });

            modelBuilder.Entity("Gemu.Models.Rol", b =>
                {
                    b.Navigation("Usuarios");
                });

            modelBuilder.Entity("Gemu.Models.Usuario", b =>
                {
                    b.Navigation("Anuncios");

                    b.Navigation("Biblioteca");

                    b.Navigation("Carrito");

                    b.Navigation("Reseñas");

                    b.Navigation("Transacciones");
                });
#pragma warning restore 612, 618
        }
    }
}