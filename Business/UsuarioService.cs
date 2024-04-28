using Gemu.Data;
using Gemu.Models;

namespace Gemu.Business;
public class UsuarioService : IUsuarioService
{
    private readonly IUsuarioRepository _usuarioRepository;

    public UsuarioService(IUsuarioRepository repository)
    {
        _usuarioRepository = repository;
    }

    public List<UsuarioGetAllDTO> GetAllUsuarios()
    {
        return _usuarioRepository.GetAllUsuarios();
    }
    //Read
    public Usuario GetIdUsuario(int idUsuario)
    {
        return _usuarioRepository.GetIdUsuario(idUsuario);
    }
    public Usuario LoginUsuario(UsuarioLoginDTO usuario)
    {
       return _usuarioRepository.LoginUsuario(usuario);
    }
    //Create
    public void CreateUsuario(UsuarioCreateDTO usuario)
    {
        _usuarioRepository.CreateUsuario(usuario);
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
    //Delete
    public void DeleteUsuario(int idUsuario)
    {
        _usuarioRepository.DeleteUsuario(idUsuario);
    }
}
