
using Data.Entities;
using Data.Repositories.Interfaces;
using System.Data.Entity;
using System.Data.Entity.Core.Mapping;

namespace Data.Repositories
{
    public class UsuarioRepository : RepositoryBase<Usuario>, IUsuarioRepository
    {
        private readonly AppDbContext _appDbContext;
        public UsuarioRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public List<Usuario> GetAllUsuarioPerfil()
        {
            var usuarios = _appDbContext.Usuario.ToList();
            foreach (var item in usuarios)
            {
                item.Perfil = _appDbContext.Perfil.Where(a => a.id == item.id_perfil).FirstOrDefault();
            }
            return usuarios;
        }

        public Usuario GetUsuarioPerfil(int id)
        {
            var usuario = _appDbContext.Usuario.Include(a => a.Perfil).Where(b => b.id == id).FirstOrDefault();
            usuario.Perfil = _appDbContext.Perfil.Where(a => a.id == usuario.id_perfil).FirstOrDefault();
            return usuario;
        }
    }
}
