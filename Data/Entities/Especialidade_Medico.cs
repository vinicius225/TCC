using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Especialidade_Medico : IEntityBase
    {
        public int id_medico { get; set; }
        public int id_especialidade { get; set; }

        [ForeignKey("id_medico")]
        public virtual ICollection<Medico> Medico { get; set; }
        [ForeignKey("id_especilalidade")]
        public virtual ICollection<Especialidade> Especialidade { get; set; }
    }
}
