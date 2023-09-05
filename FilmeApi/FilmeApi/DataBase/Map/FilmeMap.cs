using FilmeApi.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FilmeApi.DataBase.Map
{
    public class FilmeMap : IEntityTypeConfiguration<Filmes>
    {
        public void Configure(EntityTypeBuilder<Filmes> builder)
        {
            builder.HasKey(x => x.IdFilme);
            builder.Property(x => x.NomeFilme).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Classificacao).IsRequired();
            builder.Property(x => x.Diretor).IsRequired().HasMaxLength(200);
            builder.Property(x => x.DataLanc).IsRequired();
            builder.Property(x => x.Idioma).IsRequired().HasMaxLength(60);
            builder.Property(x => x.Ator).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Genero).IsRequired().HasMaxLength(100);
        }
    }
}
