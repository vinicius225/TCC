using Data.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public IActionResult Index()
        {
            
            var teste = _usuarioRepository.GetAllUsuarioPerfil();
            return View(_usuarioRepository.GetAllUsuarioPerfil());
        }
    }
}
