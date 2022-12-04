using Data.DTOs;
using Data.Entities;
using Data.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using MVC.Helper;
using MVC.Helper;
using System.Net.WebSockets;
using System.Security.Cryptography;
using System.Text;

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
            usuarioDTO.senha = GerarHash(usuarioDTO.senha);


            Usuario usuarioBD = new Usuario();
            usuarioDTO.Set(usuarioBD);
            usuarioBD.Perfil = perfil;
            _usuarioRepository.Add(usuarioBD);
            TempData["mensagem"] = Helper.HelperHtml.MessageAlert("Adicionado com sucesso", Helper.Enum.ErrosEnum.Sucesso);

            return RedirectToAction(nameof(Index));
        }
        public IActionResult Edit(int id)
        {
            var usuario = _usuarioRepository.GetUsuarioPerfil(id);
            UsuariositeDTO usuariositeDTO = new UsuariositeDTO();
            usuariositeDTO.Get(usuario);
            return View(usuariositeDTO);
        }
        [HttpPost]
        public IActionResult Edit(UsuariositeDTO usuariositeDTO) 
        {
            usuariositeDTO.senha = GerarHash(usuariositeDTO.senha);
            var usuarioBD = _usuarioRepository.GetUsuarioPerfil(usuariositeDTO.id);
            usuariositeDTO.Set(usuarioBD);
            _usuarioRepository.Update(usuarioBD);
            TempData["mensagem"] = Helper.HelperHtml.MessageAlert("Atualizado com sucesso", Helper.Enum.ErrosEnum.Sucesso);

            return RedirectToAction(nameof(Index));

        }


        private string GerarHash(string senha)
        {

            MD5 md5Hash = MD5.Create();
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(senha));

            StringBuilder sBuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }
    }
}
