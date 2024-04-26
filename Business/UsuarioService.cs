using Gemu.Data;

namespace Gemu.Business;
public class UsuarioService : IUsuarioService
{
    private readonly IUsuarioRepository _usuarioRepository;

    public UsuarioService(IUsuarioRepository repository)
    {
        _usuarioRepository = repository;
    }
}
