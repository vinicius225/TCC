
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


    }
}
