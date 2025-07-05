using CRUD.Core.Domain.Validations;

namespace CRUD.Core.Domain.Entities
{
    public abstract class BaseEntity
    {
        public DateTime DataInsercao { get; protected set; } = DateTime.Today;

        public string UsuarioInsercao { get; protected set; } = string.Empty;
    }
}