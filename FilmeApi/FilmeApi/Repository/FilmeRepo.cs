using FilmeApi.DataBase;
using FilmeApi.Model;
using FilmeApi.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace FilmeApi.Repository
{
    public class FilmeRepo : IFilmeRepo
    {
        private readonly DBFilmesContext dbContext;

        public FilmeRepo(DBFilmesContext dbFilmesContext)
        {
            dbContext = dbFilmesContext;
        }

        public async Task<Filmes> BuscarId(int idFilme)
        {
            return await dbContext.Filmes.FirstOrDefaultAsync(x => x.IdFilme == idFilme);
        }

        public async Task<List<Filmes>> BuscarFilmes()
        {
            return await dbContext.Filmes.ToListAsync();
        }

        public async Task<Filmes> AddFilme(Filmes filmes)
        {
            await dbContext.Filmes.AddAsync(filmes);
            await dbContext.SaveChangesAsync();

            return filmes;
        }

        public async Task<Filmes> UpFilmes(Filmes filmes, int idFilme)
        {
            Filmes filmeId = await BuscarId(idFilme);
            
            if(filmeId == null)
            {
                throw new Exception($"Filme {idFilme} não foi encontrado.");
            }

            filmeId.NomeFilme = filmes.NomeFilme;
            filmeId.DataLanc = filmes.DataLanc;
            filmeId.Ator = filmes.Ator;
            filmeId.Classificacao = filmes.Classificacao;
            filmeId.Diretor = filmes.Diretor;

            dbContext.Filmes.Update(filmeId);
            await dbContext.SaveChangesAsync();

            return filmeId;
        }

        public async Task<bool> DelFilmes(int idFilme)
        {
            Filmes filmeId = await BuscarId(idFilme);

            if (filmeId == null)
            {
                throw new Exception($"Filme {idFilme} não foi encontrado.");
            }

            dbContext.Filmes.Remove(filmeId);
            await dbContext.SaveChangesAsync();

            return true;
        }
    }
}
