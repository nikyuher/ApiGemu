using Gemu.Models;

namespace Gemu.Data;
public interface IRolRepository
{
    public List<RolDTO> GetAllRoles();
    //Read
    public RolDTO GetIdRol(int idRol);
    //Create
    void CreateRol(Rol rol);
    //Update
    void UpdateRol(Rol rol);
    void UpdateNombreRol(RolUpdateNombreDTO rol);
    //Delete
    void DeleteRol(int idRol);
}   