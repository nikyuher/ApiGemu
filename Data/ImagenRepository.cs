using Gemu.Models;

namespace Gemu.Data;
public class ImagenRepository : IImagenRepository
{
    private readonly GemuContext _context;

    public ImagenRepository(GemuContext context)
    {
        _context = context;
    }

    public List<Imagen> GetAllImagenes()
    {
        var imagenes = _context.Imagenes.ToList();

        return imagenes;
    }

    //Read
    public Imagen GetIdImagen(int idImagen)
    {
        var imagen = _context.Imagenes.FirstOrDefault(r => r.Id == idImagen);

        if (imagen is null)
        {
            throw new Exception($"No se encontro el Imagen con el ID: {idImagen}");
        }

        return imagen;
    }

    //Create
    public void CreateImagen(Imagen imagen)
    {
        _context.Imagenes.Add(imagen);
        SaveChanges();
    }

    //Update
    public void UpdateImagen(Imagen imagen)
    {
        var existingImagen = _context.Imagenes.Find(imagen.Id);
        if (existingImagen == null)
        {
            throw new KeyNotFoundException("No se encontró el Imagen a actualizar.");
        }

        _context.Entry(existingImagen).CurrentValues.SetValues(imagen);
        SaveChanges();
    }

    //Delete
    public void DeleteImagen(int idImagen)
    {
        var imagen = GetIdImagen(idImagen);

        if (imagen is null)
        {
            throw new Exception($"No se encontro el Imagen con el ID: {idImagen}");
        }

        _context.Imagenes.Remove(imagen);
        SaveChanges();
    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }

}
