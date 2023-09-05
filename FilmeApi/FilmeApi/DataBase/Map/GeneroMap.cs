using FilmeApi.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FilmeApi.DataBase.Map
{
    public class GeneroMap : IEntityTypeConfiguration<Generos>
    {
        public void Configure(EntityTypeBuilder<Generos> builder)
        {
            builder.HasKey(x => x.IdGenero);
            builder.Property(x => x.NomeGenero).IsRequired().HasMaxLength(200);
        }
    }
}
