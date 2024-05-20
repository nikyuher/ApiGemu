using Gemu.Models;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace Gemu.Data;
public class JuegoRepository : IJuegoRepository
{
    private readonly GemuContext _context;

    public JuegoRepository(GemuContext context)
    {
        _context = context;
    }


    //Read
    public List<Juego> GetAllJuegos()
    {
        var juegos = _context.Juegos.ToList();

        return juegos;
    }

    public List<Juego> GetJuegosPaginados(int pageNumber, int pageSize)
    {
        var juegos = _context.Juegos
                             .Include(j => j.ImgsJuego)
                             .Include(j => j.JuegoCategorias)
                                 .ThenInclude(jc => jc.Categoria) 
                             .Skip((pageNumber - 1) * pageSize)
                             .Take(pageSize)
                             .ToList();

        return juegos;
    }

    public JuegoDTO GetIdJuego(int idJuego)
    {
        var juego = _context.Juegos.FirstOrDefault(r => r.IdJuego == idJuego);

        if (juego is null)
        {
            throw new Exception($"No se encontro el Juego con el ID: {idJuego}");
        }

        var newJuego = new JuegoDTO
        {
            IdJuego = juego.IdJuego,
            Titulo = juego.Titulo,
            Descripcion = juego.Descripcion,
            Precio = juego.Precio,
            Plataforma = juego.Plataforma,
            Descuento = juego.Descuento,
            CodigoJuego = juego.CodigoJuego,
            Reseñas = juego.Reseñas,
            Fecha = juego.Fecha,
        };

        return newJuego;
    }

    public JuegoCategoriasDTO GetCategoriasJuego(int idJuego)
    {

        var juego = _context.Juegos
                    .Include(r => r.JuegoCategorias)
                    .ThenInclude(r => r.Categoria)
                    .FirstOrDefault(r => r.IdJuego == idJuego);

        if (juego is null)
        {
            throw new Exception($"No se encontro el juego con el ID: {idJuego}");
        }

        var newJuego = new JuegoCategoriasDTO
        {
            IdJuego = juego.IdJuego,
            Titulo = juego.Titulo,
            JuegoCategorias = juego.JuegoCategorias
        };

        return newJuego;
    }

    public JuegoReseñaDTO GetReseñasJuego(int idJuego)
    {

        var producto = _context.Juegos.Include(r => r.Reseñas).FirstOrDefault(r => r.IdJuego == idJuego);

        if (producto is null)
        {
            throw new Exception($"No se encontro el juego con el ID: {idJuego}");
        }

        var newJuego = new JuegoReseñaDTO
        {
            IdJuego = producto.IdJuego,
            Titulo = producto.Titulo,
            Reseñas = producto.Reseñas
        };

        return newJuego;
    }

    //Create
    public void CreateJuego(JuegoAddDTO juego)
    {

        var newJuego = new Juego
        {
            Titulo = juego.Titulo,
            Precio = juego.Precio,
            Descuento = juego.Descuento,
            Descripcion = juego.Descripcion,
            Plataforma = juego.Plataforma,
            CodigoJuego = GenerateGameCode(),
            Fecha = DateTime.Today
        };

        _context.Juegos.Add(newJuego);
        SaveChanges();
    }

    public void AsignarCategoriasJuego(int idJuego, List<int> ListaIdsCategoria)
    {

        var juego = _context.Juegos.Include(j => j.JuegoCategorias).FirstOrDefault(p => p.IdJuego == idJuego);


        if (juego is null)
        {
            throw new Exception($"No se encontro el juego con el ID: {idJuego}");
        }

        juego.JuegoCategorias.Clear();

        foreach (var item in ListaIdsCategoria)
        {
            var categoria = _context.Categorias.FirstOrDefault(r => r.IdCategoria == item);

            if (categoria is null)
            {
                throw new Exception($"No se encontro la categoria con el ID: {item}");
            }


            var newCategoria = new JuegoCategoria
            {
                JuegoId = juego.IdJuego,
                CategoriaId = categoria.IdCategoria
            };

            juego.JuegoCategorias.Add(newCategoria);
        }
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
        var juego = _context.Juegos.FirstOrDefault(r => r.IdJuego == idJuego);

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

    private string GenerateGameCode()
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        StringBuilder codeBuilder = new StringBuilder();

        Random random = new Random();
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                codeBuilder.Append(chars[random.Next(chars.Length)]);
            }

            if (i < 3)
            {
                codeBuilder.Append('-');
            }
        }

        return codeBuilder.ToString();
    }
}
