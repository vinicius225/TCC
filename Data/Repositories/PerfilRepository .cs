
using Data.Entities;
using Data.Repositories.Interfaces;
using System.Data.Entity;
using System.Data.Entity.Core.Mapping;

namespace Data.Repositories
{
    public class PerfilRepository : RepositoryBase<Perfil>, IPerfilRepository
    {

        public PerfilRepository(AppDbContext appDbContext) : base(appDbContext)
        {

        }


    }
}
