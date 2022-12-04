using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    [Table("perfil")]
    public class Perfil : IEntityBase
    {
        public string nome { get; set; }
        public string descricao { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
