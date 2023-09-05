using FilmeApi.Model;
using FilmeApi.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FilmeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AtoresController : ControllerBase
    {
        private readonly IAtorRepo _atorRepo;

        public AtoresController(IAtorRepo atorRepo)
        {
            _atorRepo = atorRepo;
        }

        [HttpGet]
        public async Task<ActionResult<List<Atores>>> BuscarAtores()
        {
            List<Atores> atores = await _atorRepo.BuscarAtores();
            return Ok(atores);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Atores>> BuscaId(int id)
        {
            Atores ids = await _atorRepo.BuscarId(id);
            return Ok(ids);
        }

        [HttpPost]
        public async Task<ActionResult<Atores>> AddAtor([FromBody] Atores atores)
        {
            Atores ator = await _atorRepo.AddAtor(atores);
            return Ok(ator);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Atores>> UpAtores([FromBody] Atores atores, int id)
        {
            atores.IdAtor = id;

            Atores ator = await _atorRepo.UpAtores(atores, id);
            return Ok(ator);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Atores>> DelAtores(int id)
        {
            bool deletar = await _atorRepo.DelAtores(id);
            return Ok(deletar);
        }
    }
}
