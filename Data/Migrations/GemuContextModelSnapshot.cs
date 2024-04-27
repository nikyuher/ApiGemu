﻿// <auto-generated />
using System;
using Gemu.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Gemu.Data.Migrations
{
    [DbContext(typeof(GemuContext))]
    partial class GemuContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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
                });

            modelBuilder.Entity("Gemu.Models.Categoria", b =>
                {
                    b.Property<int>("IdCategoria")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCategoria"), 1L, 1);

                    b.Property<int?>("IdJuego")
                        .HasColumnType("int");

                    b.Property<int?>("IdProducto")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdCategoria");

                    b.HasIndex("IdJuego");

                    b.HasIndex("IdProducto");

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

                    b.Property<int?>("CategoriaIdCategoria")
                        .HasColumnType("int");

                    b.Property<string>("CodigoJuego")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Descuento")
                        .HasColumnType("int");

                    b.Property<int?>("IdBiblioteca")
                        .HasColumnType("int");

                    b.Property<int?>("IdCarrito")
                        .HasColumnType("int");

                    b.Property<int?>("IdCategoria")
                        .HasColumnType("int");

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

                    b.HasIndex("CategoriaIdCategoria");

                    b.HasIndex("IdBiblioteca");

                    b.HasIndex("IdCarrito");

                    b.HasIndex("ReseñaIdReseña");

                    b.ToTable("Juegos");
                });

            modelBuilder.Entity("Gemu.Models.Producto", b =>
                {
                    b.Property<int>("IdProducto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdProducto"), 1L, 1);

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<int?>("CategoriaIdCategoria")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("IdAnuncio")
                        .HasColumnType("int");

                    b.Property<int?>("IdBiblioteca")
                        .HasColumnType("int");

                    b.Property<int?>("IdCarrito")
                        .HasColumnType("int");

                    b.Property<int?>("IdCategoria")
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

                    b.HasIndex("CategoriaIdCategoria");

                    b.HasIndex("IdBiblioteca");

                    b.HasIndex("IdCarrito");

                    b.HasIndex("ReseñaIdReseña");

                    b.ToTable("Productos");
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

                    b.Property<int?>("IdJuego")
                        .HasColumnType("int");

                    b.Property<int?>("IdProducto")
                        .HasColumnType("int");

                    b.Property<int>("IdUsuario")
                        .HasColumnType("int");

                    b.Property<string>("Solicitud")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdReseña");

                    b.HasIndex("IdJuego");

                    b.HasIndex("IdProducto");

                    b.HasIndex("IdUsuario");

                    b.ToTable("Reseñas");
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

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdUsuario");

                    b.ToTable("Usuarios");
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

            modelBuilder.Entity("Gemu.Models.Carrito", b =>
                {
                    b.HasOne("Gemu.Models.Usuario", "Usuario")
                        .WithOne("Carrito")
                        .HasForeignKey("Gemu.Models.Carrito", "IdUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Gemu.Models.Categoria", b =>
                {
                    b.HasOne("Gemu.Models.Juego", "Juego")
                        .WithMany("Categorias")
                        .HasForeignKey("IdJuego");

                    b.HasOne("Gemu.Models.Producto", "Producto")
                        .WithMany("Categorias")
                        .HasForeignKey("IdProducto");

                    b.Navigation("Juego");

                    b.Navigation("Producto");
                });

            modelBuilder.Entity("Gemu.Models.Imagen", b =>
                {
                    b.HasOne("Gemu.Models.Juego", "Juego")
                        .WithMany("ImgsJuego")
                        .HasForeignKey("JuegoId");

                    b.HasOne("Gemu.Models.Juego", null)
                        .WithOne("Imagen")
                        .HasForeignKey("Gemu.Models.Imagen", "JuegoIdJuego");

                    b.HasOne("Gemu.Models.Producto", "Producto")
                        .WithMany("ImgsProducto")
                        .HasForeignKey("ProductoId");

                    b.Navigation("Juego");

                    b.Navigation("Producto");
                });

            modelBuilder.Entity("Gemu.Models.Juego", b =>
                {
                    b.HasOne("Gemu.Models.Categoria", "Categoria")
                        .WithMany()
                        .HasForeignKey("CategoriaIdCategoria");

                    b.HasOne("Gemu.Models.Biblioteca", "Biblioteca")
                        .WithMany("Juegos")
                        .HasForeignKey("IdBiblioteca");

                    b.HasOne("Gemu.Models.Carrito", "Carrito")
                        .WithMany("Juegos")
                        .HasForeignKey("IdCarrito");

                    b.HasOne("Gemu.Models.Reseña", "Reseña")
                        .WithMany()
                        .HasForeignKey("ReseñaIdReseña");

                    b.Navigation("Biblioteca");

                    b.Navigation("Carrito");

                    b.Navigation("Categoria");

                    b.Navigation("Reseña");
                });

            modelBuilder.Entity("Gemu.Models.Producto", b =>
                {
                    b.HasOne("Gemu.Models.Categoria", "Categoria")
                        .WithMany()
                        .HasForeignKey("CategoriaIdCategoria");

                    b.HasOne("Gemu.Models.Biblioteca", "Biblioteca")
                        .WithMany("Productos")
                        .HasForeignKey("IdBiblioteca");

                    b.HasOne("Gemu.Models.Carrito", "Carrito")
                        .WithMany("Productos")
                        .HasForeignKey("IdCarrito");

                    b.HasOne("Gemu.Models.Reseña", "Reseña")
                        .WithMany()
                        .HasForeignKey("ReseñaIdReseña");

                    b.Navigation("Biblioteca");

                    b.Navigation("Carrito");

                    b.Navigation("Categoria");

                    b.Navigation("Reseña");
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

            modelBuilder.Entity("Gemu.Models.Biblioteca", b =>
                {
                    b.Navigation("Juegos");

                    b.Navigation("Productos");
                });

            modelBuilder.Entity("Gemu.Models.Carrito", b =>
                {
                    b.Navigation("Juegos");

                    b.Navigation("Productos");
                });

            modelBuilder.Entity("Gemu.Models.Juego", b =>
                {
                    b.Navigation("Categorias");

                    b.Navigation("Imagen");

                    b.Navigation("ImgsJuego");

                    b.Navigation("Reseñas");
                });

            modelBuilder.Entity("Gemu.Models.Producto", b =>
                {
                    b.Navigation("Anuncio");

                    b.Navigation("Categorias");

                    b.Navigation("ImgsProducto");

                    b.Navigation("Reseñas");
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
