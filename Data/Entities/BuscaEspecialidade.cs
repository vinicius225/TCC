using Data.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    [Table("busca_especialidade")]
    public class BuscaEspecialidade : IEntityBase
    {
        public int id_especialidade { get; set; }
        public string descricao { get; set; }

        public Especialidade Especialidade { get; set; }
    }
}
