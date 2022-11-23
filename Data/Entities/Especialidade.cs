using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Permissions;

namespace Data.Entities
{
    [Table("especialidade")]

    public class Especialidade : IEntityBase
    {
        public string nome { get; set; }
        public string descricao { get; set; }
        [ForeignKey("id_medico")]
        public virtual ICollection<Medico> Medico { get; set; }

    }
}
