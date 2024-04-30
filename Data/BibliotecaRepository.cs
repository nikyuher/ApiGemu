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
    public List<Biblioteca> GetAllBibliotecas()
    {
        var biblioteca = _context.Bibliotecas.ToList();

        return biblioteca;
    }

    //Read
    public Biblioteca GetIdBiblioteca(int idBiblioteca)
    {
        var biblioteca = _context.Bibliotecas.FirstOrDefault(r => r.IdBiblioteca == idBiblioteca);

        if (biblioteca is null)
        {
            throw new Exception($"No se encontro el Biblioteca con el ID: {idBiblioteca}");
        }

        return biblioteca;
    }

    public BibliotecaListaDTO GetBibliotecaUsuario(int idUsuario)
    {
        var biblioteca = _context.Bibliotecas.Include(r => r.Juegos).Include(r => r.Productos).FirstOrDefault(r => r.IdUsuario == idUsuario);

        if (biblioteca is null)
        {
            throw new Exception($"No se encontro el Biblioteca del usuario con el ID: {idUsuario}");
        }

        var newBiblioteca = new BibliotecaListaDTO
        {
            IdUsuario = biblioteca.IdUsuario,
            Productos = biblioteca.Productos.Select(u => new ProductoBibliotecaDTO
            {
                IdProducto = u.IdProducto,
                Nombre = u.Nombre,
                Precio = u.Precio,
                Estado = u.Estado,
                ImgsProducto = u.ImgsProducto,
                Categorias = u.Categorias
            }).ToList(),
            Juegos = biblioteca.Juegos.Select(u => new JuegoBiliotecaDTO
            {
                IdJuego = u.IdJuego,
                Titulo = u.Titulo,
                Precio = u.Precio,
                CodigoJuego = u.CodigoJuego,
                ImgsJuego = u.ImgsJuego,
                Categorias = u.Categorias
            }).ToList(),
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
        var biblioteca = GetIdBiblioteca(idBiblioteca);

        if (biblioteca is null)
        {
            throw new Exception($"No se encontro el Biblioteca con el ID: {idBiblioteca}");
        }

        _context.Bibliotecas.Remove(biblioteca);
        SaveChanges();
    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }
}
