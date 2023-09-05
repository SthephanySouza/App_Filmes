using FilmeApi.DataBase.Map;
using FilmeApi.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace FilmeApi.DataBase
{
    public class DBFilmesContext : DbContext
    {
        public DBFilmesContext(DbContextOptions<DBFilmesContext> options) : base(options)
        {
        }

        public DbSet<Filmes> Filmes { get; set; }
        public DbSet<Generos> Generos { get; set; }
        public DbSet<Atores> Atores { get; set; }
        public DbSet<Diretores> Diretores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new FilmeMap());
            modelBuilder.ApplyConfiguration(new GeneroMap());
            modelBuilder.ApplyConfiguration(new AtoresMap());
            modelBuilder.ApplyConfiguration(new DiretoresMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
