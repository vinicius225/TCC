using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    [Table("unidade_saude")]

    public class UnidadeSaude : IEntityBase
    {
        public string nome { get; set; }
        public string cnpj { get; set; }
        public string endereco { get; set; }
        public string numero { get; set; }
        public string telefone { get; set; }
        [ForeignKey("id_medico")]

        public virtual ICollection<Medico> Medicos { get; set; }
        [ForeignKey("id_plantao")]
        public virtual ICollection<Plantao> Plantao { get; set; }


    }
}
