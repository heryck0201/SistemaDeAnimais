using Microsoft.EntityFrameworkCore;
using SistemaDeAnimais.Data;
using SistemaDeAnimais.Entidades;
using SistemaDeAnimais.Repositorio.IRepositorios;

namespace SistemaDeAnimais.Repositorio
{
    public class PetRepositorio : IPetRepositorio
    {
        private readonly SistemaDeAnimaisContext _context;

        public async Task<Pet> BuscarPorId(int id)
        {
            return await _context.Pets.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Pet>> BuscarTodosPet()
        {
            return await _context.Pets.ToListAsync();
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
