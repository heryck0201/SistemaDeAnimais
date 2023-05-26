using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SistemaDeAnimais.Entidades;

namespace SistemaDeAnimais.Map
{
    public class PetMap : IEntityTypeConfiguration<Pet>
    {

            public void Configure(EntityTypeBuilder<Pet> builder)
            {
                builder.HasKey(x => x.Id);
                builder.Property(x => x.Nome).IsRequired().HasMaxLength(100);
                builder.Property(x => x.Raca).IsRequired().HasMaxLength(100);
                builder.Property(x => x.Cor).IsRequired().HasMaxLength(100);
                builder.Property(x => x.Porte).IsRequired().HasMaxLength(100);
                builder.HasOne(x => x.Usuario).WithMany(x => x.Pet).HasForeignKey(x => x.UsuarioId);
            }
    }
}