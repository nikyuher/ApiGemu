using Gemu.Data;
using Gemu.Models;

namespace Gemu.Business;
public class CategoriaService : ICategoriaService
{
    private readonly ICategoriaRepository _categoriaRepository;

    public CategoriaService(ICategoriaRepository categoria)
    {
        _categoriaRepository = categoria;
    }

    public List<Categoria> GetAllCategorias()
    {
        return _categoriaRepository.GetAllCategorias();
    }
    public Categoria GetIdCategoria(int idCategoria)
    {
        return _categoriaRepository.GetIdCategoria(idCategoria);
    }
    public void CreateCategoria(Categoria categoria)
    {
        _categoriaRepository.CreateCategoria(categoria);
    }
    public void UpdateCategoria(Categoria categoria)
    {
        _categoriaRepository.UpdateCategoria(categoria);
    }
    public void DeleteCategoria(int idCategoria)
    {
        _categoriaRepository.DeleteCategoria(idCategoria);
    }
}
