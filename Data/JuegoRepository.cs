using Gemu.Models;

namespace Gemu.Data;
public class JuegoRepository : IJuegoRepository
{
    private readonly GemuContext _context;

    public JuegoRepository(GemuContext context)
    {
        _context = context;
    }

    public List<Juego> GetAllJuegos()
    {
        var juegos = _context.Juegos.ToList();

        return juegos;
    }

    //Read
    public Juego GetIdJuego(int idJuego)
    {
        var juego = _context.Juegos.FirstOrDefault(r => r.IdJuego == idJuego);

        if (juego is null)
        {
            throw new Exception($"No se encontro el Juego con el ID: {idJuego}");
        }

        return juego;
    }

    //Create
    public void CreateJuego(Juego juego)
    {
        _context.Juegos.Add(juego);
        SaveChanges();
    }

    //Update
    public void UpdateJuego(Juego juego)
    {
        var existingGame = _context.Juegos.Find(juego.IdJuego);
        if (existingGame == null)
        {
            throw new KeyNotFoundException("No se encontró el Juego a actualizar.");
        }

        _context.Entry(existingGame).CurrentValues.SetValues(juego);
        SaveChanges();
    }

    //Delete
    public void DeleteJuego(int idJuego)
    {
        var juego = GetIdJuego(idJuego);

        if (juego is null)
        {
            throw new Exception($"No se encontro el Juego con el ID: {idJuego}");
        }

        _context.Juegos.Remove(juego);
        SaveChanges();
    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }
}
