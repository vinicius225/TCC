
using Data.Entities;
using Data.Repositories.Interfaces;

namespace Data.Repositories
{
    public class UnidadeSaudeRepository : RepositoryBase<UnidadeSaude>, IUnidadeSaudeRepository
    {
        public UnidadeSaudeRepository(AppDbContext appDbContext) : base(appDbContext)
        {

        }
    }
}
