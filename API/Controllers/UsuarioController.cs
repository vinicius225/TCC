using Data.DTOs;
using Data.Entities;
using Data.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net.WebSockets;
using System.Security.Cryptography;
using System.Text;
using System.Text.Unicode;
using static System.Text.Encoding;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {

        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }


        // POST api/<UsuarioController>
        [HttpPost("cadastrar")]
        public ActionResult<UsuarioDTO> Cadastrar([FromBody] UsuarioDTO usuario)
        {

             usuario.senha = GerarHash(usuario.senha);
            try
            {
                if (ModelState.IsValid)
                {

                    var usuarioExiste = _usuarioRepository.GetAll().Where(a => a.email == usuario.email).ToList();
                    if (usuarioExiste.Count() > 0)
                    {
                        return BadRequest("E-mail já cadastrado");
                    }
                    var usuarioBD = new Usuario();
                    usuario.Set(usuarioBD);
                    usuarioBD.id_perfil = 2;
                    _usuarioRepository.Add(usuarioBD);
                }

            }
            catch (Exception ex)
            {

            }
            return Ok(usuario);
        }

        // PUT api/<UsuarioController>/5
        [HttpPost("Login")]
        public ActionResult Login([FromBody] UsuariosLoginDTO usuarioDTO)
        {
            usuarioDTO.senha = GerarHash(usuarioDTO.senha);
            var usuario = _usuarioRepository.GetAll().Where(b => b.email == usuarioDTO.email && b.senha == usuarioDTO.senha).FirstOrDefault();
            if (usuario == null)
            {
                return NotFound();
            }
            else
            {
                return Ok();
            }
        }

        [HttpGet("listar")]
        public ActionResult ListarUsuarios()
        {
            return Ok(_usuarioRepository.GetAll());
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
