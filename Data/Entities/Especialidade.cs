using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    [Table("especialidade")]

    public class Especialidade : IEntityBase
    {
        public string nome { get; set; }
        public string descricao { get; set; }
    }
}
