using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CRUD.Core.Application.DTO
{
    public class ClienteDTO
    {
        public int CodigoCliente { get; set; }  // PK

        [Required(ErrorMessage = "Razão Social é obrigatório")]
        [MinLength(3)]
        [MaxLength(100)]
        [DisplayName("Razão Social")]
        public string RazaoSocial { get; set; } = string.Empty;

        [Required(ErrorMessage = "Nome Fantasia é obrigatório")]
        [MinLength(3)]
        [MaxLength(100)]
        [DisplayName("Nome Fantasia")]
        public string NomeFantasia { get; set; } = string.Empty;

        [Required(ErrorMessage = "TipoPessoa é obrigatório")]
        [MinLength(3)]
        [MaxLength(100)]
        [DisplayName("TipoPessoa")]
        public string TipoPessoa { get; set; } = string.Empty;

        [Required(ErrorMessage = "Documento é obrigatório")]
        [MinLength(3)]
        [MaxLength(100)]
        [DisplayName("Documento")]
        public string Documento { get; set; } = string.Empty;

        [Required(ErrorMessage = "Endereço é obrigatório")]
        [MinLength(3)]
        [MaxLength(100)]
        [DisplayName("Endereço")]
        public string Endereco { get; set; } = string.Empty;

        [Required(ErrorMessage = "Complemento é obrigatório")]
        [MinLength(3)]
        [MaxLength(100)]
        [DisplayName("Complemento")]
        public string Complemento { get; set; } = string.Empty;

        [Required(ErrorMessage = "Bairro é obrigatório")]
        [MinLength(3)]
        [MaxLength(100)]
        [DisplayName("Bairro")]
        public string Bairro { get; set; } = string.Empty;

        [Required(ErrorMessage = "Cidade é obrigatório")]
        [MinLength(3)]
        [MaxLength(100)]
        [DisplayName("Cidade")]
        public string Cidade { get; set; } = string.Empty;

        [Required(ErrorMessage = "CEP é obrigatório")]
        [MinLength(3)]
        [MaxLength(100)]
        [DisplayName("CEP")]
        public string CEP { get; set; } = string.Empty;

        [Required(ErrorMessage = "UF é obrigatório")]
        [MinLength(3)]
        [MaxLength(100)]
        [DisplayName("UF")]
        public string UF { get; set; } = string.Empty;
    }

    public class ClienteCreateDTO : ClienteDTO
    {
        public List<TelefoneCreateDTO> Telefones { get; set; } = new();
    }

    public class ClienteResponseDTO : ClienteDTO
    {
        public List<TelefoneResponseDTO> Telefones { get; set; } = new();
    }
}