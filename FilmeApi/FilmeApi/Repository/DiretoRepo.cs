using FilmeApi.DataBase;
using FilmeApi.Model;
using FilmeApi.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace FilmeApi.Repository
{
    public class DiretoRepo : IDiretorRepo
    {
        private readonly DBFilmesContext dbContext;

        public DiretoRepo(DBFilmesContext dbFilmesContext)
        {
            dbContext = dbFilmesContext;
        }

        public async Task<Diretores> BuscarId(int idDiretor)
        {
            return await dbContext.Diretores.FirstOrDefaultAsync(x => x.IdDiretor == idDiretor);
        }

        public async Task<List<Diretores>> BuscarDiretores()
        {
            return await dbContext.Diretores.ToListAsync();
        }

        public async Task<Diretores> AddDiretor(Diretores diretores)
        {
            await dbContext.Diretores.AddAsync(diretores);
            await dbContext.SaveChangesAsync();

            return diretores;
        }

        public async Task<Diretores> UpDiretores(Diretores diretores, int idDiretor)
        {
            Diretores diretorId = await BuscarId(idDiretor);

            if (diretorId == null)
            {
                throw new Exception($"Gênero {idDiretor} não foi encontrado.");
            }

            diretorId.NomeDiretor = diretores.NomeDiretor;
            diretorId.MaiorObra = diretores.MaiorObra;

            dbContext.Diretores.Update(diretorId);
            await dbContext.SaveChangesAsync();

            return diretorId;
        }

        public async Task<bool> DelDiretores(int idDiretor)
        {
            Diretores diretorId = await BuscarId(idDiretor);

            if (diretorId == null)
            {
                throw new Exception($"Diretor {idDiretor} não foi encontrado.");
            }

            dbContext.Diretores.Remove(diretorId);
            await dbContext.SaveChangesAsync();

            return true;
        }
    }
}
