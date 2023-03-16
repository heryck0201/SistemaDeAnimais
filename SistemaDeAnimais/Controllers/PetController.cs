using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using SistemaDeAnimais.Entidades;
using SistemaDeAnimais.Repositorio.IRepositorios;

namespace SistemaDeAnimais.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetController : ControllerBase
    {
        private readonly IPetRepositorio _petRepositorio;

        public PetController(IPetRepositorio petRepositorio)
        {
            _petRepositorio = petRepositorio;
        }

        [Authorize("Bearer")]
        [HttpGet]
        public async Task<ActionResult<List<Pet>>> BuscarTodosUsuarios()
        {
            List<Pet> usuario = await _petRepositorio.BuscarTodosPet();

            return Ok();
        }

        [Authorize("Bearer")]
        [HttpGet("{id}")]
        public async Task<ActionResult<Pet>> BuscarId(int id)
        {
            Pet pet = await _petRepositorio.BuscarPorId(id);

            return Ok(pet);
        }

        [Authorize("Bearer")]
        [HttpPost]
        public async Task<ActionResult<Pet>> Cadastrar([FromBody] Pet pet)
        {
            Pet petId = await _petRepositorio.Adicionar(pet);

            return Ok(petId);
        }

        [Authorize("Bearer")]
        [HttpPut("{id}")]
        public async Task<ActionResult<Usuario>> Atualizar([FromBody] Pet pet, int id)
        {
            pet.Id = id;
            Pet petId = await _petRepositorio.Atualizar(pet, id);

            return Ok(petId);
        }

        [Authorize("Bearer")]
        [HttpDelete("{id}")]
        public async Task<ActionResult<Pet>> Apagar(int id)
        {
            bool apagar = await _petRepositorio.Apagar(id);
            return Ok(apagar);
        }
    }
}
