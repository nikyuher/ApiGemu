using Gemu.Models;

namespace Gemu.Data;
public interface IUsuarioRepository
{
    public List<Usuario> GetAllUsuarios();
    public Usuario GetIdUsuario(int idUsuario);
    void CreateUsuario(Usuario usuario);
    void UpdateUsuario(Usuario usuario);
    void DeleteUsuario(int idUsuario);
}
