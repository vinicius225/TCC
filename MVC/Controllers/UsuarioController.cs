using Data.DTOs;
using Data.Entities;
using Data.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using MVC.Helper;

namespace MVC.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IPerfilRepository _perfilRepository;

        public UsuarioController(IUsuarioRepository usuarioRepository, IPerfilRepository perfilRepository)
        {
            _usuarioRepository = usuarioRepository;
            _perfilRepository = perfilRepository;
        }

        public IActionResult Index()
        {
            
            var teste = _usuarioRepository.GetAllUsuarioPerfil();
            return View(_usuarioRepository.GetAllUsuarioPerfil());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(UsuariositeDTO usuarioDTO)
        {

                if (usuarioDTO.senha != usuarioDTO.confima_senha)
                {
                    TempData["mensagem"] = Helper.HelperHtml.MessageAlert("Senhas não conferem", Helper.Enum.ErrosEnum.aviso);
                    return View();

                }

            var perfil = _perfilRepository.Get(usuarioDTO.id_perfil);

            Usuario usuarioBD = new Usuario();
            usuarioDTO.Set(usuarioBD);
            usuarioBD.Perfil = perfil;
            _usuarioRepository.Add(usuarioBD);
            return RedirectToAction(nameof(Index));
        }
    }
}
