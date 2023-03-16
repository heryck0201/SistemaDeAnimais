using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SistemaDeAnimais.DTOs;
using SistemaDeAnimais.Entidades;
using SistemaDeAnimais.Repositorio.IRepositorios;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SistemaDeAnimais.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        //private readonly IConfiguration _congiguration;

        public UsuarioController(IUsuarioRepositorio usuarioRepositorio/*, IConfiguration congiguration*/)
        {
            _usuarioRepositorio = usuarioRepositorio;
            //_congiguration = congiguration;
        }

        //[Authorize("Bearer")]
        [HttpGet("BuscarTodosUsuarios")]
        public async Task<ActionResult<List<Usuario>>>BuscarTodosUsuarios()
        {
            List<Usuario> usuario = await _usuarioRepositorio.BuscarTodosUsuarios();

            return Ok();
        }

        //[Authorize("Bearer")]
        [HttpGet("BuscarId")]
        public async Task<ActionResult<Usuario>> BuscarId(int id)
        {
            Usuario usuario = await _usuarioRepositorio.BuscarPorId(id);

            return Ok(usuario);
        }

        //[Authorize("Bearer")]
        [HttpPost("CriarUsuario")]
        public async Task<ActionResult<Usuario>> CriarUsuario([FromBody] Usuario usuario)
        {
            Usuario usuarioId = await _usuarioRepositorio.Adicionar(usuario);

            return Ok(usuarioId);
        }

        //[Authorize("Bearer")]
        [HttpPut("Atualizar")]
        public async Task<ActionResult<Usuario>> Atualizar([FromBody] Usuario usuario, int id)
        {
            usuario.Id = id;
            Usuario usarioId = await _usuarioRepositorio.Atualizar(usuario, id);

            return Ok(usarioId);
        }

        //[Authorize("Bearer")]
        [HttpDelete("Apagar")]
        public async Task<ActionResult<Usuario>> Apagar(int id)
        {
            bool apagar = await _usuarioRepositorio.Apagar(id);
            return Ok(apagar);
        }

    }
}
