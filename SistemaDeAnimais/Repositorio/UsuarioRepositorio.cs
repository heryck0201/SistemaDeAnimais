using Microsoft.EntityFrameworkCore;
using SistemaDeAnimais.Data;
using SistemaDeAnimais.Entidades;
using SistemaDeAnimais.Repositorio.IRepositorios;

namespace SistemaDeAnimais.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly SistemaDeAnimaisContext _context;

        public UsuarioRepositorio(SistemaDeAnimaisContext context)
        {
            _context = context;
        }

        public async Task<Usuario> BuscarPorId(int id)
        {
            var buscarId = await _context.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
            return buscarId;
        }

        public async Task<List<Usuario>> BuscarTodosUsuarios()
        {
            var listaUsuario = await _context.Usuarios.ToListAsync();
            return listaUsuario;
        }

        public async Task<Usuario> Adicionar(Usuario usuario)
        {
           await _context.Usuarios.AddAsync(usuario);
           await _context.SaveChangesAsync();

            return usuario;
        }

        public async Task<Usuario> Atualizar(Usuario usuario, int id)
        {
            Usuario usarioId = await BuscarPorId(id);
            if(usarioId == null)
            {
                throw new Exception($"Usuario o ID:{id} não foi encontrado no banco de dados.");
            }

            usarioId.Nome = usuario.Nome;
            usarioId.Sobrenome= usuario.Sobrenome;
            usarioId.Email= usuario.Email;

             _context.Usuarios.Update(usarioId);
            await _context.SaveChangesAsync();

            return usarioId;

        }

        public async Task<bool> Apagar(int id)
        {
            Usuario usarioId = await BuscarPorId(id);
            if (usarioId == null)
            {
                throw new Exception($"Usuario o ID:{id} não foi encontrado no banco de dados.");
            }

            _context.Usuarios.Remove(usarioId);
            await _context.SaveChangesAsync();

            return true;

        }

    }
}
