using FilmeApi.Model;
using FilmeApi.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FilmeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenerosController : ControllerBase
    {
        private readonly IGeneroRepo _generoRepo;

        public GenerosController(IGeneroRepo generoRepo)
        {
            _generoRepo = generoRepo;
        }

        [HttpGet]
        public async Task<ActionResult<List<Generos>>> BuscaGeneros()
        {
            List<Generos> generos = await _generoRepo.BuscarGeneros();
            return Ok(generos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Generos>> BuscaId(int id)
        {
            Generos ids = await _generoRepo.BuscarId(id);
            return Ok(ids);
        }

        [HttpPost]
        public async Task<ActionResult<Generos>> AddGenero([FromBody] Generos generos)
        {
            Generos filme = await _generoRepo.AddGenero(generos);
            return Ok(filme);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Generos>> UpGeneros([FromBody] Generos generos, int id)
        {
            generos.IdGenero = id;

            Generos genero = await _generoRepo.UpGeneros(generos, id);
            return Ok(genero);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Generos>> DelGeneros(int id)
        {
            bool deletar = await _generoRepo.DelGeneros(id);
            return Ok(deletar);
        }
    }
}
