using CRUD.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CRUD.Infra.Data.Configurations
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasKey(c => c.CodigoCliente);

            builder.Property(c => c.RazaoSocial).HasMaxLength(300).IsRequired();
            builder.Property(c => c.NomeFantasia).HasMaxLength(300).IsRequired();
            builder.Property(c => c.TipoPessoa).HasMaxLength(300).IsRequired();
            builder.Property(c => c.Documento).HasMaxLength(300).IsRequired();
            builder.Property(c => c.Endereco).HasMaxLength(300).IsRequired();
            builder.Property(c => c.Complemento).HasMaxLength(300).IsRequired();
            builder.Property(c => c.Bairro).HasMaxLength(300).IsRequired();
            builder.Property(c => c.Cidade).HasMaxLength(300).IsRequired();
            builder.Property(c => c.CEP).HasMaxLength(300).IsRequired();
            builder.Property(c => c.UF).HasMaxLength(300).IsRequired();

            builder.Property(c => c.DataInsercao).IsRequired();
            builder.Property(c => c.UsuarioInsercao).IsRequired();

            builder.HasMany(c => c.Telefones).WithOne(t => t.Cliente).HasForeignKey(t => t.CodigoCliente);
        }
    }
}