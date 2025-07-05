using CRUD.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CRUD.Infra.Data.Configurations
{
    public class TipoTelefoneConfiguration : IEntityTypeConfiguration<TipoTelefone>
    {
        public void Configure(EntityTypeBuilder<TipoTelefone> builder)
        {
            builder.HasKey(tt => tt.CodigoTipoTelefone);

            builder.Property(tt => tt.DescricaoTipoTelefone).HasMaxLength(300).IsRequired();

            builder.Property(tt => tt.DataInsercao).IsRequired();
            builder.Property(tt => tt.UsuarioInsercao).IsRequired();

            builder.HasMany(tt => tt.Telefones).WithOne(t => t.TipoTelefone).HasForeignKey(t => t.CodigoTipoTelefone);
        }
    }
}