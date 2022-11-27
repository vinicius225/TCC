
using Data.Entities;
using Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class MedicoRepository : RepositoryBase<Medico>, IMedicoRepository
    {
        readonly AppDbContext _appDbContext;
        public MedicoRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public List<Medico> GetAllMedicoEspecialidade()
        {
            return _appDbContext.Medico.Include(a => a.Especialidade).ToList();
        }

        public Medico GetMedicoEspecialidade(int id)
        {
            return _appDbContext.Medico.Include(a => a.Especialidade).Where(b=> b.id == id).FirstOrDefault();

        }
    }
}
