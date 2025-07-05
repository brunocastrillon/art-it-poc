using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CRUD.Core.Application.DTO
{
    public class TipoTelefoneDTO
    {
        public int CodigoTipoTelefone { get; set; }  // PK

        [Required(ErrorMessage = "Descrição é obrigatório")]
        [MinLength(3)]
        [MaxLength(100)]
        [DisplayName("Descrição")]
        public string DescricaoTipoTelefone { get; set; } = string.Empty;
    }
}