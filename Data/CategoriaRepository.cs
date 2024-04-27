using Gemu.Models;

namespace Gemu.Data;
public class CategoriaRepository : ICategoriaRepository
{
    private readonly GemuContext _context;

    public CategoriaRepository(GemuContext context)
    {
        _context = context;
    }
    
    public List<Categoria> GetAllCategorias()
    {
        var categoria = _context.Categorias.ToList();

        return categoria;
    }

    //Read
    public Categoria GetIdCategoria(int idCategoria)
    {
        var categoria = _context.Categorias.FirstOrDefault(r => r.IdCategoria == idCategoria);

        if (categoria is null)
        {
            throw new Exception($"No se encontro el Categoria con el ID: {idCategoria}");
        }

        return categoria;
    }

    //Create
    public void CreateCategoria(Categoria categoria)
    {
        _context.Categorias.Add(categoria);
        SaveChanges();
    }

    //Update
    public void UpdateCategoria(Categoria categoria)
    {
        var existingCategoria = _context.Categorias.Find(categoria.IdCategoria);
        if (existingCategoria == null)
        {
            throw new KeyNotFoundException("No se encontró el Categoria a actualizar.");
        }

        _context.Entry(existingCategoria).CurrentValues.SetValues(categoria);
        SaveChanges();
    }

    //Delete
    public void DeleteCategoria(int idCategoria)
    {
        var categoria = GetIdCategoria(idCategoria);

        if (categoria is null)
        {
            throw new Exception($"No se encontro el Categoria con el ID: {idCategoria}");
        }

        _context.Categorias.Remove(categoria);
        SaveChanges();
    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }
}
