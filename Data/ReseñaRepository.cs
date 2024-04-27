using Gemu.Models;

namespace Gemu.Data;
public class ReseñaRepository : IReseñaRepository
{
    private readonly GemuContext _context;

    public ReseñaRepository(GemuContext context)
    {
        _context = context;
    }

    public List<Reseña> GetAllReseñas()
    {
        var reseñas = _context.Reseñas.ToList();

        return reseñas;
    }

    //Read
    public Reseña GetIdReseña(int idReseña)
    {
        var reseña = _context.Reseñas.FirstOrDefault(r => r.IdReseña == idReseña);

        if (reseña is null)
        {
            throw new Exception($"No se encontro el Reseña con el ID: {idReseña}");
        }

        return reseña;
    }

    //Create
    public void CreateReseña(Reseña reseña)
    {
        _context.Reseñas.Add(reseña);
        SaveChanges();
    }

    //Update
    public void UpdateReseña(Reseña reseña)
    {
        var existingReseña = _context.Reseñas.Find(reseña.IdReseña);
        if (existingReseña == null)
        {
            throw new KeyNotFoundException("No se encontró el Reseña a actualizar.");
        }

        _context.Entry(existingReseña).CurrentValues.SetValues(reseña);
        SaveChanges();
    }

    //Delete
    public void DeleteReseña(int idReseña)
    {
        var reseña = GetIdReseña(idReseña);

        if (reseña is null)
        {
            throw new Exception($"No se encontro el Reseña con el ID: {idReseña}");
        }

        _context.Reseñas.Remove(reseña);
        SaveChanges();
    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }
}
