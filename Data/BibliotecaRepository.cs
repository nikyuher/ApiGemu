using Gemu.Models;

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

    //Create
    public void CreateBiblioteca(Biblioteca biblioteca)
    {
        _context.Bibliotecas.Add(biblioteca);
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
