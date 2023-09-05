using FilmeApi.DataBase;
using FilmeApi.Model;
using FilmeApi.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace FilmeApi.Repository
{
    public class AtorRepo : IAtorRepo
    {
        private readonly DBFilmesContext dbContext;

        public AtorRepo(DBFilmesContext dbFilmesContext)
        {
            dbContext = dbFilmesContext;
        }

        public async Task<Atores> BuscarId(int idAtor)
        {
            return await dbContext.Atores.FirstOrDefaultAsync(x => x.IdAtor == idAtor);
        }

        public async Task<List<Atores>> BuscarAtores()
        {
            return await dbContext.Atores.ToListAsync();
        }

        public async Task<Atores> AddAtor(Atores atores)
        {
            await dbContext.Atores.AddAsync(atores);
            await dbContext.SaveChangesAsync();

            return atores;
        }

        public async Task<Atores> UpAtores(Atores atores, int idAtor)
        {
            Atores atorId = await BuscarId(idAtor);

            if (atorId == null)
            {
                throw new Exception($"Ator {idAtor} não foi encontrado.");
            }

            atorId.NomeAtor = atores.NomeAtor;
            atorId.ObraTrab = atores.ObraTrab;

            dbContext.Atores.Update(atorId);
            await dbContext.SaveChangesAsync();

            return atorId;
        }

        public async Task<bool> DelAtores(int idAtor)
        {
            Atores atorId = await BuscarId(idAtor);

            if (atorId == null)
            {
                throw new Exception($"Diretor {idAtor} não foi encontrado.");
            }

            dbContext.Atores.Remove(atorId);
            await dbContext.SaveChangesAsync();

            return true;
        }
    }
}
