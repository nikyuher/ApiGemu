namespace Gemu.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
public class Usuario
{
    [Key]
    public int IdUsuario { get; set; }
    public byte[]? FotoPerfil { get; set; }
    [Required]
    public string? Nombre { get; set; }
    [Required]
    public string? Correo { get; set; }
    [Required]
    public string? Contraseña { get; set; }
    public string? Direccion { get; set; }
    public int CodigoPostal { get; set; }
    public decimal SaldoActual { get; set; }
    public List<Transaccion>? Transacciones { get; set; } = new List<Transaccion>();
    public List<Anuncio>? Anuncios { get; set; } = new List<Anuncio>();
    public List<Reseña>? Reseñas { get; set; } = new List<Reseña>();
    public Carrito? Carrito { get; set; }
    public Biblioteca? Biblioteca { get; set; }

    [Required]
    public int IdRol { get; set; }

    // Navegación a Rol
    [JsonIgnore]
    public Rol? Rol { get; set; } 
}
