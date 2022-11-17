using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class UnidadeSaudeMedico : IEntityBase
    {
        public int id_medidco { get; set; }
        public int id_unidade { get; set; }

        [ForeignKey("id_medidco")]
        public virtual ICollection<Medico> Medico { get; set; }

        [ForeignKey("id_unidade")]
        public virtual ICollection<UnidadeSaude> UnidadeSaude { get; set; }
    }
}
