using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    [Table("medico")]
    public class Medico : IEntityBase
    {
        public string nome { get; set; }
        public string crm { get; set; }
        public string estado_crm { get; set; }
        [ForeignKey("id_medico")]

        public virtual ICollection<Especialidade> Especialidade { get;set; }




    }
}
