using Gemu.Models;
using Microsoft.EntityFrameworkCore;

namespace Gemu.Data;
public class RolRepository : IRolRepository
{
    private readonly GemuContext _context;

    public RolRepository(GemuContext context)
    {
        _context = context;
    }

    public List<Rol> GetAllRoles()
    {
        var reseñas = _context.Roles.Include(r => r.Usuarios).ToList();

        return reseñas;
    }

    //Read
    public Rol GetIdRol(int idRol)
    {
        var rol = _context.Roles.FirstOrDefault(r => r.IdRol == idRol);

        if (rol is null)
        {
            throw new Exception($"No se encontro el Rol con el ID: {idRol}");
        }

        return rol;
    }

    //Create
    public void CreateRol(Rol rol)
    {
        _context.Roles.Add(rol);
        SaveChanges();
    }

    //Update
    public void UpdateRol(Rol rol)
    {
        var existingRol = _context.Roles.Find(rol.IdRol);
        if (existingRol == null)
        {
            throw new KeyNotFoundException("No se encontró el Rol a actualizar.");
        }

        _context.Entry(existingRol).CurrentValues.SetValues(rol);
        SaveChanges();
    }

    public void UpdateNombreRol(RolUpdateNombreDTO rol)
    {
        var existingRol = _context.Roles.Find(rol.IdRol);
        if (existingRol == null)
        {
            throw new KeyNotFoundException("No se encontró el Rol a actualizar.");
        }

        existingRol.Nombre = rol.Nombre;

        _context.Roles.Update(existingRol);
        SaveChanges();
    }

    //Delete
    public void DeleteRol(int IdRol)
    {
        var rol = GetIdRol(IdRol);

        if (rol is null)
        {
            throw new Exception($"No se encontro el Rol con el ID: {IdRol}");
        }

        _context.Roles.Remove(rol);
        SaveChanges();
    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }
}
