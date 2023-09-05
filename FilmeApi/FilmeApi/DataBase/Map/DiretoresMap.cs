using FilmeApi.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FilmeApi.DataBase.Map
{
    public class DiretoresMap : IEntityTypeConfiguration<Diretores>
    {
        public void Configure(EntityTypeBuilder<Diretores> builder)
        {
            builder.HasKey(x => x.IdDiretor);
            builder.Property(x => x.NomeDiretor).IsRequired().HasMaxLength(200);
            builder.Property(x => x.MaiorObra).IsRequired().HasMaxLength(200);
        }
    }
}
