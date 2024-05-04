using Gemu.Models;

namespace Gemu.Data;
public interface IRolService
{
    public List<RolDTO> GetAllRoles();
    public RolDTO GetIdRol(int idRol);
    void CreateRol(Rol rol);
    void UpdateRol(Rol rol);
    void UpdateNombreRol(RolUpdateNombreDTO rol);
    void DeleteRol(int idRol);
}   