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

}
