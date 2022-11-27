using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DTOs
{
    public class MedicoDTO : IDTO<Medico>
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string crm { get; set; }
        public string estado_crm { get; set; }
        public List<int> ids_Especialidades { get; set; }

        public void Get(Medico obj)
        {
            this.id = obj.id;
            this.nome = obj.nome;
            this.crm = obj.crm;
            this.estado_crm = obj.estado_crm;
            this.ids_Especialidades = obj.Especialidade.Select(n=> n.id).ToList();
        }

        public void Set(Medico obj)
        {
            obj.id = this.id;
            obj.nome = this.nome;
            obj.crm = this.crm;
            obj.estado_crm = this.estado_crm;

        }
    }
}
