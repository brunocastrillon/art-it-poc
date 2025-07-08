using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CRUD.Core.Application.DTO
{
    public class TelefoneCreateDTO
    {
        public int CodigoCliente { get; set; } // PK + FK

        [Required(ErrorMessage = "Numero Telefone é obrigatório")]
        [MinLength(11)]
        [MaxLength(13)]
        [DisplayName("Numero Telefone")]
        public string NumeroTelefone { get; set; } = string.Empty; // PK

        [Required(ErrorMessage = "Tipo de Telefone é obrigatório")]
        [DisplayName("Tipo de Telefone")]
        public int CodigoTipoTelefone { get; set; } // FK

        [Required(ErrorMessage = "Operadora é obrigatório")]
        [MinLength(3)]
        [MaxLength(100)]
        [DisplayName("Operadora")]
        public string Operadora { get; set; } = string.Empty;

        public bool Ativo { get; set; }
    }

    public class TelefoneResponseDTO
    {
        public int CodigoCliente { get; set; }
        
        public string NumeroTelefone { get; set; } = string.Empty;
        
        public string TipoTelefoneDesc { get; set; } = string.Empty;
        
        public string Operadora { get; set; } = string.Empty;
        
        public bool Ativo { get; set; }
    }
}