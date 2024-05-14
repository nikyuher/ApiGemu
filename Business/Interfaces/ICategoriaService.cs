using Gemu.Models;

namespace Gemu.Data;
public interface ICategoriaService
{
    public List<Categoria> GetAllCategorias();
    public Categoria GetIdCategoria(int idCategoria);
    public List<Categoria> GetCategoriaSeccion(string seccion);
    void CreateCategoria(Categoria categoria);
    void UpdateCategoria(Categoria categoria);
    void DeleteCategoria(int idcategoria);
}   