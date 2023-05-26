using Microsoft.EntityFrameworkCore;
using SistemaDeAnimais.Data;
using SistemaDeAnimais.Entidades;
using SistemaDeAnimais.Repositorio.IRepositorios;

namespace SistemaDeAnimais.Repositorio
{
    public class PetRepositorio : IPetRepositorio
    {
        private readonly SistemaDeAnimaisContext _context;

        public PetRepositorio(SistemaDeAnimaisContext context)
        {
            _context = context;
        }
        public async Task<Pet> BuscarPorId(int id)
        {
            var petId = await _context.Pets.FirstOrDefaultAsync(x => x.Id == id);

            return petId;
        }

        public async Task<List<Usuario>> BuscarTodosUsuarioDoPet()
        {
            var usuarioPet = await _context.Usuarios.ToListAsync();
            return usuarioPet;
        }

        public async Task<List<Pet>> BuscarTodosPet()
        {
            var pet = await _context.Pets.Include(x => x.Usuario).ToListAsync();
            return pet;
        }

        public async Task<Pet> Adicionar(Pet pet)
        {
            await _context.Pets.AddAsync(pet);
            await _context.SaveChangesAsync();

            return pet;
        }

        public async Task<Pet> Atualizar(Pet pet, int id)
        {
            Pet petId = await BuscarPorId(id);
            if (petId == null)
            {
                throw new Exception($"Usuario o ID:{id} não foi encontrado no banco de dados.");
            }

            petId.Nome = pet.Nome;
            petId.Raca = pet.Raca;
            petId.Cor = pet.Cor;
            petId.Porte = pet.Porte;
            petId.UsuarioId = pet.UsuarioId;

            _context.Pets.Update(petId);
            await _context.SaveChangesAsync();

            return petId;
        }

        public async Task<bool> Apagar(int id)
        {
            Pet petId = await BuscarPorId(id);
            if (petId == null)
            {
                throw new Exception($"Usuario o ID:{id} não foi encontrado no banco de dados.");
            }

            _context.Pets.Remove(petId);
            await _context.SaveChangesAsync();

            return true;
        }
        
    }
}
