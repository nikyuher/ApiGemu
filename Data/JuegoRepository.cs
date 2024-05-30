using Gemu.Models;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Linq.Expressions;

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

    public async Task<IEnumerable<JuegoSearchDTO>> JuegoSearch(string Titulo)
    {
        var juego =  await _context.Juegos.Include(j => j.ImgsJuego).Where(j => j.Titulo.Contains(Titulo)).ToListAsync();

        var juegoSearchList = juego.Select(j => new JuegoSearchDTO
        {
            IdJuego = j.IdJuego,
            Titulo = j.Titulo,
            Precio = j.Precio,
            Plataforma = j.Plataforma,
            Descuento = j.Descuento,
            ImgsJuego = j.ImgsJuego.Take(1).ToList()
        }).ToList();

        return juegoSearchList;
    }

    public List<Juego> GetJuegosPaginados(int pageNumber, int pageSize)
    {
        return GetFilteredJuegos(pageNumber, pageSize).ToList();
    }

    public List<Juego> GetJuegosPaginadosOfertas(int pageNumber, int pageSize)
    {
        return GetFilteredJuegos(pageNumber, pageSize, j => j.Descuento > 0).ToList();
    }

    public List<Juego> GetJuegosPaginadosBaratos(int pageNumber, int pageSize, int precioBarato)
    {
        return GetFilteredJuegos(pageNumber, pageSize, j => j.Precio <= precioBarato && j.Precio > 0).ToList();
    }

    public List<Juego> GetJuegosPaginadosGratis(int pageNumber, int pageSize)
    {
        return GetFilteredJuegos(pageNumber, pageSize, j => j.Precio == 0).ToList();
    }

    public List<Juego> GetJuegosPaginadosCategoria(int pageNumber, int pageSize, List<int> categoriaIds)
    {
        return GetFilteredJuegos(pageNumber, pageSize, null, categoriaIds).ToList();
    }

    public JuegoDTO GetIdJuego(int idJuego)
    {
        var juego = _context.Juegos.Include(c => c.Reseñas).FirstOrDefault(r => r.IdJuego == idJuego);

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
            Fecha = juego.Fecha
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
    public Juego CreateJuego(JuegoAddDTO juego)
    {

        var newJuego = new Juego
        {
            Titulo = juego.Titulo,
            Precio = juego.Precio,
            Descuento = juego.Descuento,
            Descripcion = juego.Descripcion,
            Plataforma = juego.Plataforma,
            CodigoJuego = GenerateGameCode(),
        };

        _context.Juegos.Add(newJuego);
        SaveChanges();

        return newJuego;
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
    public void UpdateJuego(JuegoAddDTO juego)
    {
        var existingGame = _context.Juegos.Find(juego.IdJuego);
        if (existingGame == null)
        {
            throw new KeyNotFoundException("No se encontró el Juego a actualizar.");
        }

        existingGame.Titulo = juego.Titulo;
        existingGame.Descripcion = juego.Descripcion;
        existingGame.Precio = juego.Precio;
        existingGame.Descuento = juego.Descuento;
        existingGame.Plataforma = juego.Plataforma;

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

    private IQueryable<Juego> GetFilteredJuegos(int pageNumber, int pageSize, Expression<Func<Juego, bool>> filtro = null, List<int> categoriaIds = null)
    {
        var query = _context.Juegos
                            .Include(j => j.JuegoCategorias)
                                .ThenInclude(jc => jc.Categoria)
                            .AsQueryable();

        if (filtro != null)
        {
            query = query.Where(filtro);
        }

        if (categoriaIds != null && categoriaIds.Any())
        {
            query = query
                    .Where(j => j.JuegoCategorias
                    .Count(jc => categoriaIds
                    .Contains(jc.CategoriaId)) == categoriaIds.Count);
        }

        var pagedJuegos = query.Skip((pageNumber - 1) * pageSize).Take(pageSize);

        var juegosConPrimeraImagen = pagedJuegos.Select(j => new Juego
        {
            IdJuego = j.IdJuego,
            Titulo = j.Titulo,
            Descripcion = j.Descripcion,
            Precio = j.Precio,
            Plataforma = j.Plataforma,
            Descuento = j.Descuento,
            ImgsJuego = j.ImgsJuego.Take(1).ToList(),
            JuegoCategorias = j.JuegoCategorias
        });

        return juegosConPrimeraImagen;
    }
}
