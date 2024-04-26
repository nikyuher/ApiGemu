namespace Gemu.Models;
using System.ComponentModel.DataAnnotations;
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
     public decimal SaldoActual
    {
        get
        {
            return Transacciones?.Sum(t => t.Cantidad) ?? 0;
        }
    }
    public List<Transaccion> Transacciones { get; set; } = new List<Transaccion>();
    public List<Anuncio> Anuncios { get; set; } = new List<Anuncio>();
    public List<Reseña> Reseñas { get; set; } = new List<Reseña>();
    public List<Carrito> Carrito { get; set; } = new List<Carrito>();
    public List<Biblioteca> Biblioteca { get; set; } = new List<Biblioteca>();

}
