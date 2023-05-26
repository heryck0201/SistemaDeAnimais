using SistemaDeAnimais.Entidades;

namespace SistemaDeAnimais.Repositorio.IRepositorios
{
    public interface IPetRepositorio
    {
        Task<List<Usuario>> BuscarTodosUsuarioDoPet();
        Task<List<Pet>> BuscarTodosPet();
        Task<Pet> BuscarPorId(int id);
        Task<Pet> Adicionar(Pet pet);
        Task<Pet> Atualizar(Pet pet, int id);
        Task<bool> Apagar(int id);
    }
}
