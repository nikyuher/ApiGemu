using Gemu.Models;

namespace Gemu.Data;
public class UsuarioRepository : IUsuarioRepository
{
    private readonly GemuContext _context;

    public UsuarioRepository(GemuContext context)
    {
        _context = context;
    }

    public List<Usuario> GetAllUsuarios(){
        var usuarios = _context.Usuarios.ToList();

        return usuarios;
    }
}
