namespace Gemu.Models;
using System.Collections.Generic;

public class RolDTO
{
    public int IdRol { get; set; }
    public string? Nombre { get; set; }
    public List<UsuarioInfoDTO> Usuarios { get; set; } = new List<UsuarioInfoDTO>();
}