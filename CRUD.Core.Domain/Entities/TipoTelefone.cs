using CRUD.Core.Domain.Validations;

namespace CRUD.Core.Domain.Entities
{
    public sealed class TipoTelefone : BaseEntity
    {
        public int CodigoTipoTelefone { get; set; }  // PK

        public string DescricaoTipoTelefone { get; set; } = string.Empty;

        public ICollection<Telefone> Telefones { get; set; } = new List<Telefone>();

        public TipoTelefone()
        {

        }

        public TipoTelefone(int codigoTipoTelefone, string descricaoTipoTelefone)
        {
            ValidateId(codigoTipoTelefone);
            ValidateDomain(descricaoTipoTelefone);
        }

        public TipoTelefone(string descricaoTipoTelefone)
        {
            ValidateDomain(descricaoTipoTelefone);
        }

        private void ValidateDomain(string descricaoTipoTelefone)
        {
            DomainValidationException.When(string.IsNullOrEmpty(descricaoTipoTelefone), "Descrição do Tipo do telefone é obrigatório");

            DescricaoTipoTelefone = descricaoTipoTelefone;

            DataInsercao = DateTime.Now;
            UsuarioInsercao = "sys";
        }

        public void ValidateId(int id)
        {
            DomainValidationException.When(id < 0, "invalid id");

            CodigoTipoTelefone = id;
        }
    }
}