using Gemu.Models;
using Microsoft.EntityFrameworkCore;

namespace Gemu.Data;
public class UsuarioRepository : IUsuarioRepository
{
    private readonly GemuContext _context;

    public UsuarioRepository(GemuContext context)
    {
        _context = context;
    }

    public List<Usuario> GetAllUsuarios()
    {
        var usuarios = _context.Usuarios.Include(r => r.Transacciones).ToList();

        return usuarios;
    }

    //Read
    public Usuario GetIdUsuario(int idUsuario)
    {
        var usuario = _context.Usuarios.FirstOrDefault(r => r.IdUsuario == idUsuario);

        if (usuario is null)
        {
            throw new Exception($"No se encontro el Usuario con el ID: {idUsuario}");
        }

        return usuario;
    }

    //Create
    public void CreateUsuario(Usuario usuario)
    {

        if (_context.Usuarios.Any(u => u.Nombre == usuario.Nombre))
        {
            throw new ArgumentException("El nombre de usuario ya está en uso.");
        }

        if (_context.Usuarios.Any(u => u.Correo == usuario.Correo))
        {
            throw new ArgumentException("El correo electrónico ya está en uso.");
        }

        if (_context.Usuarios.Any(u => u.Contraseña == usuario.Contraseña))
        {
            throw new ArgumentException("La contraseña ya esta en uso.");
        }

        _context.Usuarios.Add(usuario);
        SaveChanges();
    }

    //Update
    public void UpdateUsuario(Usuario usuario)
    {
        var existingUser = _context.Usuarios.Find(usuario.IdUsuario);
        if (existingUser == null)
        {
            throw new KeyNotFoundException("No se encontró el Usuario a actualizar.");
        }

        _context.Entry(existingUser).CurrentValues.SetValues(usuario);
        SaveChanges();
    }

    //Delete
    public void DeleteUsuario(int idUsuario)
    {
        var usuario = GetIdUsuario(idUsuario);

        if (usuario is null)
        {
            throw new Exception($"No se encontro el Usuario con el ID: {idUsuario}");
        }

        _context.Usuarios.Remove(usuario);
        SaveChanges();
    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }
}
