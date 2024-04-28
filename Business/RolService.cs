using Gemu.Data;
using Gemu.Models;

namespace Gemu.Business;
public class RolService : IRolService
{
    private readonly IRolRepository _rolRepository;

    public RolService(IRolRepository repository)
    {
        _rolRepository = repository;
    }

    public List<Rol> GetAllRoles()
    {
        return _rolRepository.GetAllRoles();
    }
    public Rol GetIdRol(int idRol)
    {
        return _rolRepository.GetIdRol(idRol);
    }
    public void CreateRol(Rol rol)
    {
        _rolRepository.CreateRol(rol);
    }
    public void UpdateRol(Rol rol)
    {
        _rolRepository.UpdateRol(rol);
    }
    public void UpdateNombreRol(RolUpdateNombreDTO rol)
    {
        _rolRepository.UpdateNombreRol(rol);
    }
    public void DeleteRol(int idRol)
    {
        _rolRepository.DeleteRol(idRol);
    }
}
