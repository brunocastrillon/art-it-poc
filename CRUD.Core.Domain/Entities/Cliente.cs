using CRUD.Core.Domain.Validations;

namespace CRUD.Core.Domain.Entities
{
    public sealed class Cliente : BaseEntity
    {
        public int CodigoCliente { get; set; }  // PK

        public string RazaoSocial { get; private set; } = string.Empty;

        public string NomeFantasia { get; private set; } = string.Empty;

        public string TipoPessoa { get; private set; } = string.Empty;

        public string Documento { get; private set; } = string.Empty;

        public string Endereco { get; private set; } = string.Empty;

        public string Complemento { get; private set; } = string.Empty;

        public string Bairro { get; private set; } = string.Empty;

        public string Cidade { get; private set; } = string.Empty;

        public string CEP { get; private set; } = string.Empty;

        public string UF { get; private set; } = string.Empty;

        public ICollection<Telefone> Telefones { get; set; } = new List<Telefone>();

        public Cliente()
        {
                
        }

        public Cliente(int codigoCliente, string razaoSocial, string nomeFantasia, string tipoPessoa, string documento, string endereco, string complemento, string bairro, string cidade, string cep, string uf)
        {
            ValidateId(codigoCliente);
            ValidateDomain(razaoSocial, nomeFantasia, tipoPessoa, documento, endereco, complemento, bairro, cidade, cep, uf);
        }

        public Cliente(string razaoSocial, string nomeFantasia, string tipoPessoa, string documento, string endereco, string complemento, string bairro, string cidade, string cep, string uf)
        {
            ValidateDomain(razaoSocial, nomeFantasia, tipoPessoa, documento, endereco, complemento, bairro, cidade, cep, uf);
        }

        public void AdicionarTelefone(Telefone novoTelefone)
        {
            DomainValidationException.When(novoTelefone is null, "dados do telefone são necessários");
            Telefones = new List<Telefone>
            {
                novoTelefone
            };
        }

        private void ValidateDomain(string razaoSocial, string nomeFantasia, string tipoPessoa, string documento, string endereco, string complemento, string bairro, string cidade, string cep, string uf)
        {
            DomainValidationException.When(string.IsNullOrEmpty(razaoSocial), "Razão Social é obrigatório");
            DomainValidationException.When(string.IsNullOrEmpty(nomeFantasia), "Nome Fantasia é obrigatório");
            DomainValidationException.When(string.IsNullOrEmpty(tipoPessoa), "Tipo de Pessoa é obrigatório");
            DomainValidationException.When(string.IsNullOrEmpty(documento), "Documento é obrigatório");
            DomainValidationException.When(string.IsNullOrEmpty(endereco), "Endereço é obrigatório");
            DomainValidationException.When(string.IsNullOrEmpty(complemento), "Complemento é obrigatório");
            DomainValidationException.When(string.IsNullOrEmpty(bairro), "Bairro é obrigatório");
            DomainValidationException.When(string.IsNullOrEmpty(cidade), "Cidade é obrigatório");
            DomainValidationException.When(string.IsNullOrEmpty(cep), "CEP é obrigatório");
            DomainValidationException.When(string.IsNullOrEmpty(uf), "UF é obrigatório");

            RazaoSocial = razaoSocial;
            NomeFantasia = nomeFantasia;
            TipoPessoa = tipoPessoa;
            Documento = documento;
            Endereco = endereco;
            Complemento = complemento;
            Bairro = bairro;
            Cidade = cidade;
            CEP = cep;
            UF = uf;

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