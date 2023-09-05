using FilmeApi.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FilmeApi.DataBase.Map
{
    public class AtoresMap : IEntityTypeConfiguration<Atores>
    {
        public void Configure(EntityTypeBuilder<Atores> builder)
        {
            builder.HasKey(x => x.IdAtor);
            builder.Property(x => x.NomeAtor).IsRequired().HasMaxLength(200);
            builder.Property(x => x.ObraTrab).IsRequired().HasMaxLength(200);
        }
    }
}
