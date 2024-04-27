using Gemu.Models;

namespace Gemu.Data;
public interface ICategoriaRepository
{
    public List<Categoria> GetAllCategorias();
    public Categoria GetIdCategoria(int idCategoria);
    void CreateCategoria(Categoria aategoria);
    void UpdateCategoria(Categoria aategoria);
    void DeleteCategoria(int idCategoria);
}   