using FilmeApi.Model;
using FilmeApi.Repository;
using FilmeApi.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FilmeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiretoresController : ControllerBase
    {
        private readonly IDiretorRepo _diretorRepo;

        public DiretoresController(IDiretorRepo diretorRepo)
        {
            _diretorRepo = diretorRepo;
        }

        [HttpGet]
        public async Task<ActionResult<List<Diretores>>> BuscarDiretores()
        {
            List<Diretores> diretores = await _diretorRepo.BuscarDiretores();
            return Ok(diretores);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Diretores>> BuscaId(int id)
        {
            Diretores ids = await _diretorRepo.BuscarId(id);
            return Ok(ids);
        }

        [HttpPost]
        public async Task<ActionResult<Diretores>> AddDiretor([FromBody] Diretores diretores)
        {
            Diretores diretor = await _diretorRepo.AddDiretor(diretores);
            return Ok(diretor);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Diretores>> UpDiretores([FromBody] Diretores diretores, int id)
        {
            diretores.IdDiretor = id;

            Diretores diretor = await _diretorRepo.UpDiretores(diretores, id);
            return Ok(diretor);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Diretores>> DelDiretores(int id)
        {
            bool deletar = await _diretorRepo.DelDiretores(id);
            return Ok(deletar);
        }
    }
}
