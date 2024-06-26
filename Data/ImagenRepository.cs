using Gemu.Models;

namespace Gemu.Data;
public class ImagenRepository : IImagenRepository
{
    private readonly GemuContext _context;

    public ImagenRepository(GemuContext context)
    {
        _context = context;
    }


    //Read
    public List<Imagen> GetAllImagenes()
    {
        var imagenes = _context.Imagenes.ToList();

        return imagenes;
    }

    public Imagen GetIdImagen(int idImagen)
    {
        var imagen = _context.Imagenes.FirstOrDefault(r => r.Id == idImagen);

        if (imagen is null)
        {
            throw new Exception($"No se encontro el Imagen con el ID: {idImagen}");
        }

        return imagen;
    }

    public List<ImagenJuegoDTO> GetImagenesJuego(int id)
    {
        var imagen = _context.Imagenes.Where(r => r.JuegoId == id).ToList();

        if (imagen is null)
        {
            throw new Exception($"No se encontro el juego con el ID: {id}");
        }

        var newImagen = imagen.Select(u => new ImagenJuegoDTO
        {

            Id = u.Id,
            JuegoId = u.JuegoId,
            Datos = u.Datos,
            EsPortada = u.EsPortada,
        }).ToList();

        return newImagen;
    }

    public List<ImagenProductoDTO> GetImagenesProducto(int id)
    {
        var imagen = _context.Imagenes.Where(r => r.ProductoId == id).ToList();

        if (imagen is null)
        {
            throw new Exception($"No se encontro el producto con el ID: {id}");
        }

        var newImagen = imagen.Select(u => new ImagenProductoDTO
        {

            Id = u.Id,
            ProductoId = u.ProductoId,
            Datos = u.Datos,
            EsPortada = u.EsPortada,
        }).ToList();

        return newImagen;
    }


    //Create
    public void CreateImagen(Imagen imagen)
    {

        _context.Imagenes.Add(imagen);

        SaveChanges();
    }

    public void CreateImagenJuego(List<ImagenJuegoDTO> Listaimagen)
    {

        foreach (var img in Listaimagen)
        {

            var newImagen = new Imagen
            {
                JuegoId = img.JuegoId,
                Datos = img.Datos,
                EsPortada = img.EsPortada
            };
            _context.Imagenes.Add(newImagen);
        }
        SaveChanges();
    }

    public void CreateImagenProducto(List<ImagenProductoDTO> Listaimagen)
    {
        foreach (var img in Listaimagen)
        {

            var newImagen = new Imagen
            {
                ProductoId = img.ProductoId,
                Datos = img.Datos,
                EsPortada = img.EsPortada
            };
            _context.Imagenes.Add(newImagen);
        }
        SaveChanges();
    }

    //Update
    public void UpdateImagenJuego(List<ImagenJuegoDTO> Listaimagen)
    {
        foreach (var img in Listaimagen)
        {

            var existingImagen = _context.Imagenes.FirstOrDefault(r => r.Id == img.Id);

            if (existingImagen == null)
            {
                throw new KeyNotFoundException($"No se encontró el Imagen a actualizar con el ID : {img.Id}.");
            }

            existingImagen.Datos = img.Datos;
            existingImagen.EsPortada = img.EsPortada;

            _context.Imagenes.Update(existingImagen);
        }
        SaveChanges();
    }

    public void UpdateImagenProducto(List<ImagenProductoDTO> Listaimagen)
    {
        foreach (var img in Listaimagen)
        {

            var existingImagen = _context.Imagenes.FirstOrDefault(r => r.Id == img.Id);

            if (existingImagen == null)
            {
                throw new KeyNotFoundException($"No se encontró el Imagen a actualizar con el ID : {img.Id}.");
            }

            existingImagen.Datos = img.Datos;
            existingImagen.EsPortada = img.EsPortada;

            _context.Imagenes.Update(existingImagen);
        }
        SaveChanges();
    }

    //Delete
    public void DeleteImagenesProducto(int idProducto)
    {

        var producto = _context.Productos.FirstOrDefault(r => r.IdProducto == idProducto);

        if (producto is null)
        {
            throw new Exception($"No existen el producto con el id: {idProducto}");
        }

        var imagenes = _context.Imagenes.Where(r => r.ProductoId == idProducto).ToList();

        // if (imagenes.Count == 0)
        // {
        //     throw new Exception($"No existen imágenes asociadas al producto con ID: {idProducto}");
        // }

        _context.Imagenes.RemoveRange(imagenes);
        SaveChanges();
    }

    public void DeleteImagenesJuego(int idJuego)
    {

        var juego = _context.Juegos.FirstOrDefault(r => r.IdJuego == idJuego);

        if (juego is null)
        {
            throw new Exception($"No existen el juego con el id: {idJuego}");
        }

        var imagenes = _context.Imagenes.Where(r => r.JuegoId == idJuego).ToList();

        // if (imagenes.Count == 0)
        // {
        //     throw new Exception($"No existen imágenes asociadas al producto con ID: {idJuego}");
        // }

        _context.Imagenes.RemoveRange(imagenes);
        SaveChanges();
    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }

}
