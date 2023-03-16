using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaDeAnimais.Entidades;

namespace SistemaDeAnimais.Map
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        //public void Configure(EntityTypeBuilder<UsuarioMap> builder)
        //{
        //    builder.HasKey(x => x.Id);
        //}

        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Sobrenome).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(100);
        }
    }
}
