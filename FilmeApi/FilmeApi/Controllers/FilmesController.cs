using FilmeApi.Model;
using FilmeApi.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FilmeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmesController : ControllerBase
    {
        private readonly IFilmeRepo _filmeRepo;

        public FilmesController(IFilmeRepo filmeRepo)
        {
            _filmeRepo = filmeRepo;
        }

        [HttpGet]
        public async Task<ActionResult<List<Filmes>>> BuscaFilmes()
        {
            List<Filmes> filmes = await _filmeRepo.BuscarFilmes();
            return Ok(filmes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Filmes>> BuscaId(int id)
        {
            Filmes ids = await _filmeRepo.BuscarId(id);
            return Ok(ids);
        }

        [HttpPost]
        public async Task<ActionResult<Filmes>> AddFilme([FromBody] Filmes filmes)
        {
            Filmes filme = await _filmeRepo.AddFilme(filmes);
            return Ok(filme);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Filmes>> UpFilmes([FromBody] Filmes filmes, int id)
        {
            filmes.IdFilme = id;

            Filmes filme = await _filmeRepo.UpFilmes(filmes, id);
            return Ok(filme);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Filmes>> DelFilmes(int id)
        {
            bool deletar = await _filmeRepo.DelFilmes(id);
            return Ok(deletar);
        }
    }
}
