using CRUD.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CRUD.Infra.Data.Configurations
{
    public class TelefoneConfiguration : IEntityTypeConfiguration<Telefone>
    {
        public void Configure(EntityTypeBuilder<Telefone> builder)
        {
            builder.HasKey(t => new { t.CodigoCliente, t.NumeroTelefone });

            builder.Property(t => t.NumeroTelefone).HasMaxLength(300).IsRequired();
            builder.Property(t => t.CodigoTipoTelefone).IsRequired();
            builder.Property(t => t.Operadora).HasMaxLength(300).IsRequired();
            builder.Property(t => t.Ativo).IsRequired();

            builder.Property(t => t.DataInsercao).IsRequired();
            builder.Property(t => t.UsuarioInsercao).IsRequired();

            builder.HasOne(t => t.Cliente).WithMany(c => c.Telefones).HasForeignKey(t => t.CodigoCliente);
            builder.HasOne(t => t.TipoTelefone).WithMany(tt => tt.Telefones).HasForeignKey(t => t.CodigoTipoTelefone);
        }
    }
}