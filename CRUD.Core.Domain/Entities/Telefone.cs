using CRUD.Core.Domain.Validations;

namespace CRUD.Core.Domain.Entities
{
    public sealed class Telefone : BaseEntity
    {
        public int CodigoCliente { get; set; }  // PK + FK

        public string NumeroTelefone { get; set; } = string.Empty;  // PK

        public int CodigoTipoTelefone { get; set; }  // FK

        public string Operadora { get; set; } = string.Empty;

        public bool Ativo { get; set; }

        public Cliente? Cliente { get; set; }

        public TipoTelefone? TipoTelefone { get; set; }

        public Telefone(int codigoCliente, string numeroTelefone, int codigoTipoTelefone, string operadora, bool ativo)
        {
            ValidateId(codigoCliente);
            ValidateDomain(numeroTelefone, codigoTipoTelefone, operadora, ativo);
        }

        public Telefone(string numeroTelefone, int codigoTipoTelefone, string operadora, bool ativo)
        {
            ValidateDomain(numeroTelefone, codigoTipoTelefone, operadora, ativo);
        }

        private void ValidateDomain(string numeroTelefone, int codigoTipoTelefone, string operadora, bool ativo)
        {
            DomainValidationException.When(string.IsNullOrEmpty(numeroTelefone), "Número do telefone é obrigatório");
            DomainValidationException.When(codigoTipoTelefone < 0, "Tipo de Telefone é obrigatório");
            DomainValidationException.When(string.IsNullOrEmpty(operadora), "Operadora é obrigatório");

            NumeroTelefone = numeroTelefone;
            CodigoTipoTelefone = codigoTipoTelefone;
            Operadora = operadora;
            Ativo = ativo;

            DataInsercao = DateTime.Now;
            UsuarioInsercao = "sys";
        }

        public void ValidateId(int id)
        {
            DomainValidationException.When(id < 0, "invalid id");

            CodigoCliente = id;
        }
    }
}