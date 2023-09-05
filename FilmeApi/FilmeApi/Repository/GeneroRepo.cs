using FilmeApi.DataBase;
using FilmeApi.Model;
using FilmeApi.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace FilmeApi.Repository
{
    public class GeneroRepo : IGeneroRepo
    {
        private readonly DBFilmesContext dbContext;

        public GeneroRepo(DBFilmesContext dbFilmesContext)
        {
            dbContext = dbFilmesContext;
        }

        public async Task<Generos> BuscarId(int idGenero)
        {
            return await dbContext.Generos.FirstOrDefaultAsync(x => x.IdGenero == idGenero);
        }

        public async Task<List<Generos>> BuscarGeneros()
        {
            return await dbContext.Generos.ToListAsync();
        }

        public async Task<Generos> AddGenero(Generos generos)
        {
            await dbContext.Generos.AddAsync(generos);
            await dbContext.SaveChangesAsync();

            return generos;
        }

        public async Task<Generos> UpGeneros(Generos generos, int idGenero)
        {
            Generos generosId = await BuscarId(idGenero);

            if (generosId == null)
            {
                throw new Exception($"Gênero {idGenero} não foi encontrado.");
            }

            generosId.NomeGenero = generos.NomeGenero;

            dbContext.Generos.Update(generosId);
            await dbContext.SaveChangesAsync();

            return generosId;
        }

        public async Task<bool> DelGeneros(int idGenro)
        {
            Generos generoId = await BuscarId(idGenro);

            if (generoId == null)
            {
                throw new Exception($"Gênero {idGenro} não foi encontrado.");
            }

            dbContext.Generos.Remove(generoId);
            await dbContext.SaveChangesAsync();

            return true;
        }
    }
}
