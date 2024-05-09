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

    public List<UsuarioDTO> GetAllUsuarios()
    {
        var usuarios = _context.Usuarios.Include(u => u.Transacciones).Include(u => u.Rol).ToList();

        var usuarioDTOs = usuarios.Select(u => new UsuarioDTO
        {
            IdUsuario = u.IdUsuario,
            IdRol = u.IdRol,
            FotoPerfil = u.FotoPerfil,
            Nombre = u.Nombre,
            Correo = u.Correo,
            Direccion = u.Direccion,
            CodigoPostal = u.CodigoPostal,
            SaldoActual = u.SaldoActual
        }).ToList();

        return usuarioDTOs;
    }

    //Read
    public UsuarioDTO GetIdUsuario(int idUsuario)
    {
        var usuario = _context.Usuarios.FirstOrDefault(r => r.IdUsuario == idUsuario);

        if (usuario is null)
        {
            throw new Exception($"No se encontro el Usuario con el ID: {idUsuario}");
        }

        var usuarioDTO = new UsuarioDTO
        {
            IdUsuario = usuario.IdUsuario,
            IdRol = usuario.IdRol,
            FotoPerfil = usuario.FotoPerfil,
            Nombre = usuario.Nombre,
            Correo = usuario.Correo,
            Direccion = usuario.Direccion,
            CodigoPostal = usuario.CodigoPostal,
            SaldoActual = usuario.SaldoActual
        };

        return usuarioDTO;
    }

    public Usuario LoginUsuario(UsuarioLoginDTO loginDTO)
    {
        if (string.IsNullOrWhiteSpace(loginDTO.Correo))
        {
            throw new ArgumentException("El correo electrónico no puede estar vacío", nameof(loginDTO.Correo));
        }

        if (string.IsNullOrWhiteSpace(loginDTO.Contraseña))
        {
            throw new ArgumentException("La contraseña no puede estar vacía", nameof(loginDTO.Contraseña));
        }

        var usuario = _context.Usuarios.Include(u => u.Rol).FirstOrDefault(u => u.Correo == loginDTO.Correo && u.Contraseña == loginDTO.Contraseña);

        if (usuario is null)
        {
            throw new InvalidOperationException("Usuario o Correo Incorrecto");
        }


        return usuario;
    }

    //Create
    public Usuario CreateUsuario(UsuarioCreateDTO usuario)
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

        var newUsuario = new Usuario
        {
            IdRol = 1,
            Nombre = usuario.Nombre,
            Correo = usuario.Correo,
            Contraseña = usuario.Contraseña
        };

        var nombreRol = _context.Roles.FirstOrDefault(r => r.IdRol == newUsuario.IdRol);

        newUsuario.Rol = nombreRol;

        _context.Usuarios.Add(newUsuario);
        SaveChanges();

        return newUsuario;
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

    public void UpdateRolUsuario(UsuarioUpdateDTO usuario)
    {
        var existingUser = _context.Usuarios.Find(usuario.IdUsuario);
        if (existingUser == null)
        {
            throw new KeyNotFoundException("No se encontró el Usuario a actualizar.");
        }

        var existingRol = _context.Roles.Find(usuario.IdRol);
        if (existingRol == null)
        {
            throw new KeyNotFoundException("El rol especificado no existe.");
        }

        existingUser.IdRol = usuario.IdRol;
        existingUser.Rol = existingRol;

        _context.Usuarios.Update(existingUser);
        SaveChanges();
    }

    public void UpdateDireccionUsuario(UsuarioDireccionDTO usuario)
    {
        var existingUser = _context.Usuarios.Find(usuario.IdUsuario);
        if (existingUser == null)
        {
            throw new KeyNotFoundException("No se encontró el Usuario a actualizar.");
        }

        existingUser.Direccion = usuario.Direccion;
        existingUser.CodigoPostal = usuario.CodigoPostal;

        _context.Usuarios.Update(existingUser);
        SaveChanges();
    }

    public void UpdateInfoUsuario(UsuarioInfoDTO usuario)
    {
        var existingUser = _context.Usuarios.Find(usuario.IdUsuario);
        if (existingUser == null)
        {
            throw new KeyNotFoundException("No se encontró el Usuario a actualizar.");
        }

        existingUser.Nombre = usuario.Nombre;

        _context.Usuarios.Update(existingUser);
        SaveChanges();
    }

    public void UpdateFotoUsuario(UsuarioFotoDTO usuario)
    {
        var existingUser = _context.Usuarios.Find(usuario.IdUsuario);
        if (existingUser == null)
        {
            throw new KeyNotFoundException("No se encontró el Usuario a actualizar.");
        }

        existingUser.FotoPerfil = usuario.FotoPerfil;

        _context.Usuarios.Update(existingUser);
        SaveChanges();
    }

    //Delete
    public void DeleteUsuario(int idUsuario)
    {
        var usuario = _context.Usuarios.FirstOrDefault(r => r.IdUsuario == idUsuario);

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
