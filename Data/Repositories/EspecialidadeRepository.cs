using Data.Entities;
using Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class EspecialidadeRepository : RepositoryBase<Especialidade>, IEspecialidadeRepository
    {
        readonly AppDbContext _appDbContext;
        public EspecialidadeRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;

        }

        public List<Medico> GetMedicosPorBuscaEspecialidade(string? busca)
        {
            return _appDbContext.Medico.Where(a => a.nome.Contains(busca)).ToList();
        }
    }
}
