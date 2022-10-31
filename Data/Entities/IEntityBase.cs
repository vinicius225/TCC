using System.ComponentModel.DataAnnotations;
using static Infra.Helpers.EnumerablesTips;

namespace Data.Entities
{
    public abstract class IEntityBase
    {
        [Key]
        public int id { get; set; } 
        public DateTime criado { get; set; }
        public DateTime editado { get; set; }
        public situationDefault situacao { get; set; }
    }
}
