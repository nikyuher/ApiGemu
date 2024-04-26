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

    public List<Usuario> GetAllUsuarios()
    {
        return _usuarioRepository.GetAllUsuarios();
    }
    public Usuario GetIdUsuario(int idUsuario)
    {
        return _usuarioRepository.GetIdUsuario(idUsuario);
    }
    public void CreateUsuario(Usuario usuario)
    {
        _usuarioRepository.CreateUsuario(usuario);
    }
    public void UpdateUsuario(Usuario usuario)
    {
        _usuarioRepository.UpdateUsuario(usuario);
    }
    public void DeleteUsuario(int idUsuario)
    {
        _usuarioRepository.DeleteUsuario(idUsuario);
    }
}
