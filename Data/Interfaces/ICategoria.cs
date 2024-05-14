using Gemu.Models;

namespace Gemu.Data;
public interface ICategoriaRepository
{
    public List<Categoria> GetAllCategorias();

    public Categoria GetIdCategoria(int idCategoria);
    public List<Categoria> GetCategoriaSeccion(string seccion);
    void CreateCategoria(Categoria aategoria);
    void UpdateCategoria(Categoria aategoria);
    void DeleteCategoria(int idCategoria);
}