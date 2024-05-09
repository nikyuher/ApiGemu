using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using Gemu.Data;
using Gemu.Models;

namespace Gemu.Business;
public class AuthService : IAuthService
{
    private readonly IConfiguration _configuration;

    public AuthService(IConfiguration configuration)
    {
        _configuration = configuration;
    }


    //Auth

    public string GenerateJwtToken(Usuario usuario)
    {
        // Obtener la clave secreta, el emisor y la audiencia de la configuración
        var key = Encoding.UTF8.GetBytes(_configuration["JWT:SecretKey"]);
        var issuer = _configuration["JWT:ValidIssuer"];
        var audience = _configuration["JWT:ValidAudience"];

        // Crear claims para el token JWT
        var claims = new[]
        {
        new Claim(ClaimTypes.NameIdentifier, usuario.IdUsuario.ToString()),
        new Claim(ClaimTypes.Name, usuario.Nombre),
        new Claim(ClaimTypes.Email, usuario.Correo),
        new Claim(ClaimTypes.Role, usuario.Rol.Nombre) // El rol del usuario
    };

        // Crear credenciales de firma con la clave secreta
        var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);

        // Descripción del token
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddHours(1), // Duración del token
            Issuer = issuer,
            Audience = audience,
            SigningCredentials = signingCredentials
        };

        // Generar el token
        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }

    public bool HasAccessToResource(ClaimsPrincipal user, int resourceOwnerId)
    {
        if (user == null)
        {
            throw new ArgumentNullException(nameof(user), "No se proporciono un usuario autenticado.");
        }

        // Obtener el ID del usuario desde el claim 'nameidentifier'
        var userIdClaim = user.FindFirst(ClaimTypes.NameIdentifier);
        if (userIdClaim == null)
        {
            throw new InvalidOperationException("No se encontro el claim 'nameidentifier' (ID del usuario) en el token JWT.");
        }

        if (!int.TryParse(userIdClaim.Value, out int userId))
        {
            throw new InvalidOperationException("El claim 'nameidentifier' (ID del usuario) no es un numero valido.");
        }

        // Verifica si el usuario es el propietario del recurso
        if (userId == resourceOwnerId)
        {
            return true; 
        }

        // Verifica si el usuario tiene el rol necesario para acceder al recurso
        var roleClaim = user.FindFirst(ClaimTypes.Role);
        if (roleClaim != null && roleClaim.Value == "Admin")
        {
            return true; 
        }

        throw new UnauthorizedAccessException("El usuario no tiene el rol o permisos necesarios para acceder al recurso.");
    }




}
