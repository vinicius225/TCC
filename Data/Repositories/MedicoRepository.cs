
using Data.Entities;
using Data.Repositories.Interfaces;

namespace Data.Repositories
{
    public class MedicoRepository : RepositoryBase<Medico>, IMedicoRepository
    {
        public MedicoRepository(AppDbContext appDbContext) : base(appDbContext)
        {

        }
    }
}
