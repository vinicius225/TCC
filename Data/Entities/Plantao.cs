using System.ComponentModel.DataAnnotations.Schema;
using static Infra.Helpers.EnumerablesTips;

namespace Data.Entities
{
    [Table("plantao")]
    public class Plantao : IEntityBase
    {
        public int id_unidade { get; set; }
        public int id_medico { get; set; }

        public int id_especialidade { get; set; }
        public string horarioinicio { get; set; }
        public string horariofim { get; set; }
        public DiasSemana dia_semana { get; set; }

        [ForeignKey("id_unidade")]
        public virtual UnidadeSaude UnidadeSaudes { get; set; }

        [ForeignKey("id_medico")]

        public virtual Medico Medicos { get; set; }
        [ForeignKey("id_especialidade")]
        public virtual Especialidade Especialidades { get; set; }
    }
}
