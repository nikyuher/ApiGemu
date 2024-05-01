using Gemu.Models;

namespace Gemu.Data;
public class AnuncioRepository : IAnuncioRepository
{
    private readonly GemuContext _context;

    public AnuncioRepository(GemuContext context)
    {
        _context = context;
    }


    //Read
    public List<Anuncio> GetAllAnuncios()
    {
        var anuncios = _context.Anuncios.ToList();

        return anuncios;
    }

    public Anuncio GetIdAnuncio(int idAnuncio)
    {
        var anuncio = _context.Anuncios.FirstOrDefault(r => r.IdAnuncio == idAnuncio);

        if (anuncio is null)
        {
            throw new Exception($"No se encontro el Anuncio con el ID: {idAnuncio}");
        }

        return anuncio;
    }

    public List<AnuncioDTO> GetAnunciosUsuario(int idUsuario)
    {
        var anuncios = _context.Anuncios.Where(r => r.IdUsuario == idUsuario).ToList();

        if (anuncios is null)
        {
            throw new Exception($"No se encontro el Anuncio con el ID: {idUsuario}");
        }

        var newAnuncio = anuncios.Select(r => new AnuncioDTO
        {
            IdUsuario = r.IdUsuario,
            Producto = new ProductoBibliotecaDTO
            {
                Nombre = r.Producto.Nombre,
                Precio = r.Producto.Precio,
                Estado = r.Producto.Estado,
                ImgsProducto = r.Producto.ImgsProducto,
                Categorias = r.Producto.Categorias
            }

        }).ToList();

        return newAnuncio;
    }

    //Create
    public void CreateAnuncio(Anuncio anuncio)
    {
        _context.Anuncios.Add(anuncio);
        SaveChanges();
    }

    //Update
    public void UpdateAnuncio(Anuncio anuncio)
    {
        var existingAnuncio = _context.Anuncios.Find(anuncio.IdAnuncio);
        if (existingAnuncio == null)
        {
            throw new KeyNotFoundException("No se encontró el Anuncio a actualizar.");
        }

        _context.Entry(existingAnuncio).CurrentValues.SetValues(anuncio);
        SaveChanges();
    }

    //Delete
    public void DeleteAnuncio(int idAnuncio)
    {
        var anuncio = GetIdAnuncio(idAnuncio);

        if (anuncio is null)
        {
            throw new Exception($"No se encontro el Anuncio con el ID: {idAnuncio}");
        }

        _context.Anuncios.Remove(anuncio);
        SaveChanges();
    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }
}
