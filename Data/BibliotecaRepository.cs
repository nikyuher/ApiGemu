using Gemu.Models;
using Microsoft.EntityFrameworkCore;

namespace Gemu.Data;
public class BibliotecaRepository : IBibliotecaRepository
{
    private readonly GemuContext _context;

    public BibliotecaRepository(GemuContext context)
    {
        _context = context;
    }
    public List<BibliotecaListaDTO> GetAllBibliotecas()
    {
        var biblioteca = _context.Bibliotecas
                        .Include(r => r.BibliotecaJuegos)
                        .Include(r => r.BibliotecaProductos)
                        .ToList();

        var newBiblioteca = biblioteca.Select(u => new BibliotecaListaDTO
        {
            IdUsuario = u.IdBiblioteca,
            BibliotecaProductos = u.BibliotecaProductos.ToList(),
            BibliotecaJuegos = u.BibliotecaJuegos.ToList()
        }).ToList();

        return newBiblioteca;
    }

    //Read
    public BibliotecaListaDTO GetIdBiblioteca(int idBiblioteca)
    {
        var biblioteca = _context.Bibliotecas
                        .Include(r => r.BibliotecaJuegos)
                        .ThenInclude(j => j.Juego)
                        .Include(r => r.BibliotecaProductos)
                        .ThenInclude(p => p.Producto)
                        .FirstOrDefault(r => r.IdBiblioteca == idBiblioteca);

        if (biblioteca is null)
        {
            throw new Exception($"No se encontro el Biblioteca con el ID: {idBiblioteca}");
        }

        var newBiblioteca = new BibliotecaListaDTO
        {
            IdUsuario = biblioteca.IdUsuario,
            BibliotecaProductos = biblioteca.BibliotecaProductos.ToList(),
            BibliotecaJuegos = biblioteca.BibliotecaJuegos.ToList()
        };


        return newBiblioteca;
    }

    public BibliotecaListaDTO GetBibliotecaUsuario(int idUsuario)
    {
        var biblioteca = _context.Bibliotecas
                            .Include(r => r.BibliotecaJuegos)
                            .ThenInclude(j => j.Juego)
                            .ThenInclude(j => j.ImgsJuego)
                            .Include(r => r.BibliotecaProductos)
                            .ThenInclude(p => p.Producto)
                            .ThenInclude(p => p.ImgsProducto)
                            .FirstOrDefault(r => r.IdUsuario == idUsuario);

        if (biblioteca is null)
        {
            throw new Exception($"No se encontro la Biblioteca del usuario con el ID: {idUsuario}");
        }

        var newBiblioteca = new BibliotecaListaDTO
        {
            IdBiblioteca = biblioteca.IdBiblioteca,
            IdUsuario = biblioteca.IdUsuario,
            BibliotecaProductos = biblioteca.BibliotecaProductos.ToList(),
            BibliotecaJuegos = biblioteca.BibliotecaJuegos.ToList()
        };

        return newBiblioteca;
    }

    //Create
    public void CreateBibliotecaUsuario(BibliotecaDTO biblioteca)
    {
        var newBiblioteca = new Biblioteca
        {
            IdUsuario = biblioteca.IdUsuario
        };
        _context.Bibliotecas.Add(newBiblioteca);
        SaveChanges();
    }

    public void AñadirJuegoBiblioteca(int idBiblioteca, List<int> ListaIdsJuego)
    {
        foreach (var juego in ListaIdsJuego)
        {
            var existingJuego = _context.Juegos.FirstOrDefault(r => r.IdJuego == juego);

            if (existingJuego is null)
            {
                throw new Exception($"No se encontro el juego  con el ID: {juego}");
            }

            var existingBiblioteca = _context.Bibliotecas.FirstOrDefault(r => r.IdBiblioteca == idBiblioteca);

            if (existingBiblioteca is null)
            {
                throw new Exception($"No se encontro la biblioeca  con el ID: {idBiblioteca}");
            }

            var newjuego = new BibliotecaJuego
            {
                BibliotecaId = existingBiblioteca.IdBiblioteca,
                JuegoId = existingJuego.IdJuego
            };

            existingBiblioteca.BibliotecaJuegos.Add(newjuego);
        }
        SaveChanges();
    }

    public void AñadirProductoBiblioteca(int idBiblioteca, List<int> ListaIdsProducto)
    {
        foreach (var producto in ListaIdsProducto)
        {
            var existingProducto = _context.Productos.FirstOrDefault(r => r.IdProducto == producto);

            if (existingProducto is null)
            {
                throw new Exception($"No se encontro el producto con el ID: {producto}");
            }

            var existingBiblioteca = _context.Bibliotecas.FirstOrDefault(r => r.IdBiblioteca == idBiblioteca);

            if (existingBiblioteca is null)
            {
                throw new Exception($"No se encontro la biblioeca  con el ID: {idBiblioteca}");
            }

            var newProducto = new BibliotecaProducto
            {
                BibliotecaId = existingBiblioteca.IdBiblioteca,
                ProductoId = existingProducto.IdProducto
            };

            existingBiblioteca.BibliotecaProductos.Add(newProducto);
        }
        SaveChanges();
    }

    //Update
    public void UpdateBiblioteca(Biblioteca biblioteca)
    {
        var existingBiblioteca = _context.Bibliotecas.Find(biblioteca.IdBiblioteca);
        if (existingBiblioteca == null)
        {
            throw new KeyNotFoundException("No se encontró el Biblioteca a actualizar.");
        }

        _context.Entry(existingBiblioteca).CurrentValues.SetValues(biblioteca);
        SaveChanges();
    }

    //Delete
    public void DeleteBiblioteca(int idBiblioteca)
    {
        var biblioteca = _context.Bibliotecas.FirstOrDefault(r => r.IdBiblioteca == idBiblioteca);

        if (biblioteca is null)
        {
            throw new Exception($"No se encontro el Biblioteca con el ID: {idBiblioteca}");
        }

        _context.Bibliotecas.Remove(biblioteca);
        SaveChanges();
    }

    public void EliminarProductoBiblioteca(int idBiblioteca, int idProducto)
    {

        var existingProducto = _context.BibliotecaProductos.FirstOrDefault(r => r.BibliotecaProductoId == idProducto);

        if (existingProducto is null)
        {
            throw new Exception($"No se encontro el producto con el ID: {idProducto}");
        }

        var existingBiblioteca = _context.Bibliotecas.FirstOrDefault(r => r.IdBiblioteca == idBiblioteca);

        if (existingBiblioteca is null)
        {
            throw new Exception($"No se encontro la biblioeca  con el ID: {idBiblioteca}");
        }

        existingBiblioteca.BibliotecaProductos.Remove(existingProducto);

        SaveChanges();
    }

    public void EliminarJuegoBiblioteca(int idBiblioteca, int idJuego)
    {
        var existingJuego = _context.BibliotecaJuegos.FirstOrDefault(r => r.BibliotecaJuegoId == idJuego);

        if (existingJuego is null)
        {
            throw new Exception($"No se encontro el juego  con el ID: {idJuego}");
        }

        var existingBiblioteca = _context.Bibliotecas.FirstOrDefault(r => r.IdBiblioteca == idBiblioteca);

        if (existingBiblioteca is null)
        {
            throw new Exception($"No se encontro la biblioeca  con el ID: {idBiblioteca}");
        }

        existingBiblioteca.BibliotecaJuegos.Remove(existingJuego);
        SaveChanges();
    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }
}
