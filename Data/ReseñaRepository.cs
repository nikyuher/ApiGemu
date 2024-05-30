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

    public List<Reseña> GetAllReseñasPendientes()
    {
        var reseñas = _context.Reseñas.Where(r=> r.Solicitud == "pendiente").ToList();

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
    public void CreateReseñaProducto(ReseñaAddProducto reseña)
    {
        var existingUser = _context.Usuarios.FirstOrDefault(u => u.IdUsuario == reseña.IdUsuario);
        var existingProduct = _context.Productos.FirstOrDefault(u => u.IdProducto == reseña.IdProducto);

        if (existingUser is null)
        {
            throw new Exception($"No se existe ningun usuario con el ID: {reseña.IdUsuario}.");
        }
        if (existingProduct is null)
        {
            throw new Exception($"No se existe ningun producto con el ID: {reseña.IdProducto}.");
        }

        var newReseña = new Reseña
        {
            IdUsuario = reseña.IdUsuario,
            IdProducto = reseña.IdProducto,
            NombreUsuario = existingUser.Nombre,
            Comentario = reseña.Comentario,
            Solicitud = "pendiente",
            Calificacion = reseña.Calificacion,
            Fecha = DateTime.Today
        };
        _context.Reseñas.Add(newReseña);
        SaveChanges();
    }

    public void CreateReseñaJuego(ReseñaAddJuego reseña)
    {
        var existingUser = _context.Usuarios.FirstOrDefault(u => u.IdUsuario == reseña.IdUsuario);
        var existingJuego = _context.Juegos.FirstOrDefault(u => u.IdJuego == reseña.IdJuego);

        if (existingUser is null)
        {
            throw new Exception($"No se existe ningun usuario con el ID: {reseña.IdUsuario}.");
        }
        if (existingJuego is null)
        {
            throw new Exception($"No se existe ningun producto con el ID: {reseña.IdJuego}.");
        }



        var newReseña = new Reseña
        {
            IdUsuario = reseña.IdUsuario,
            IdJuego = reseña.IdJuego,
            NombreUsuario = existingUser.Nombre,
            Comentario = reseña.Comentario,
            Solicitud = "pendiente",
            Calificacion = reseña.Calificacion,
            Fecha = DateTime.Today
        };
        _context.Reseñas.Add(newReseña);
        SaveChanges();
    }

    //Update
    public void UpdateReseña(AprobarReseñaDTO reseña)
    {
        var newReseña = _context.Reseñas.FirstOrDefault(r => r.IdReseña == reseña.IdReseña);

        if (newReseña is null)
        {
            throw new Exception($"No se encontro el Reseña con el ID: {reseña.IdReseña}");
        }

        newReseña.Solicitud = reseña.Solicitud;
        _context.Update(newReseña);
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
