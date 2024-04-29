using Gemu.Models;

namespace Gemu.Data;
public interface IUsuarioService
{
    public List<UsuarioDTO> GetAllUsuarios();
    //Read
    public UsuarioDTO GetIdUsuario(int idUsuario);
    public Usuario LoginUsuario(UsuarioLoginDTO loginDTO);
    //Create
    void CreateUsuario(UsuarioCreateDTO usuario);
    //Update
    void UpdateUsuario(Usuario usuario);
    void UpdateRolUsuario(UsuarioUpdateDTO usuario);
    void UpdateDireccionUsuario(UsuarioDireccionDTO usuario);
    void UpdateInfoUsuario(UsuarioInfoDTO usuario);
    //Delete
    void DeleteUsuario(int idUsuario);
}
