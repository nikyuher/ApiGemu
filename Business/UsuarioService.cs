using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using Gemu.Data;
using Gemu.Models;

namespace Gemu.Business;
public class UsuarioService : IUsuarioService
{
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly IConfiguration _configuration;

    public UsuarioService(IUsuarioRepository repository, IConfiguration configuration)
    {
        _usuarioRepository = repository;
        _configuration = configuration;
    }

    public List<UsuarioDTO> GetAllUsuarios()
    {
        return _usuarioRepository.GetAllUsuarios();
    }
    //Read
    public UsuarioDTO GetIdUsuario(int idUsuario)
    {
        return _usuarioRepository.GetIdUsuario(idUsuario);
    }
    public Usuario LoginUsuario(UsuarioLoginDTO usuario)
    {
        return _usuarioRepository.LoginUsuario(usuario);
    }
    //Create
    public Usuario CreateUsuario(UsuarioCreateDTO usuario)
    {
        return _usuarioRepository.CreateUsuario(usuario);
    }
    //Update
    public void UpdateUsuario(Usuario usuario)
    {
        _usuarioRepository.UpdateUsuario(usuario);
    }
    public void UpdateRolUsuario(UsuarioUpdateDTO usuario)
    {
        _usuarioRepository.UpdateRolUsuario(usuario);
    }
    public void UpdateDireccionUsuario(UsuarioDireccionDTO usuario)
    {
        _usuarioRepository.UpdateDireccionUsuario(usuario);
    }
    public void UpdateInfoUsuario(UsuarioInfoDTO usuario)
    {
        _usuarioRepository.UpdateInfoUsuario(usuario);
    }
    public void UpdateFotoUsuario(UsuarioFotoDTO usuario)
    {
        _usuarioRepository.UpdateFotoUsuario(usuario);
    }
    //Delete
    public void DeleteUsuario(int idUsuario)
    {
        _usuarioRepository.DeleteUsuario(idUsuario);
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
        new Claim(JwtRegisteredClaimNames.Sub, usuario.IdUsuario.ToString()),
        new Claim(JwtRegisteredClaimNames.Email, usuario.Correo),
        new Claim("role", usuario.Rol.Nombre) // El rol del usuario
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
}
