using API.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IConfiguration _config;

        #region Actions
        public AuthenticationController(UserManager<IdentityUser> usermanager, SignInManager<IdentityUser> signInManager, IConfiguration configuration)
        {
            _signInManager = signInManager;
            _userManager = usermanager;
            _config = configuration;
        }
        [HttpGet]
        public ActionResult<string> Get()
        {
            return $"Authentication - Sistema de Atendimento Medico\n {DateTime.Now}";
        }

        [HttpPost("Register")]
        public async Task<ActionResult> Post([FromBody] UsuarioDto user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var userIdentity = new IdentityUser
            {
                UserName = user.Email,
                Email = user.Email,
                EmailConfirmed = true,
                
            };

            var result = await _userManager.CreateAsync(userIdentity, user.Password);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }
            await _signInManager.SignInAsync(userIdentity, false);

            return Ok(GeraToken(user));
        }
        [HttpPost("login")]
        public async  Task<ActionResult> Login(UsuarioDto usuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values.Select(a=> a.Errors));
            }
            var result = await  _signInManager.PasswordSignInAsync(usuario.Email, usuario.Password, false, false);

            if (result.Succeeded)
            {
                return Ok(GeraToken(usuario));
            }else
            {
                return BadRequest("Login Invalido!");
            }
        }

        #endregion

        #region Methods
        private UsuarioToken GeraToken(UsuarioDto usuarioDto)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, usuarioDto.Email),
                new Claim("meuPet","pipoca"),
                new Claim (JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            //gerar uma chave com base em um algiritimo simetrico
            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_config["Jwt:Key"])
                );
            //gerar assinatura digital do token usando o algoritimo Hmac e a chave privada
            var credenciais = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expiracao = _config["TokenConfiguration:ExpireHours"];
            var expiration = DateTime.UtcNow.AddHours(double.Parse(expiracao));


            //Classe Que representa a autenticação JWT
            JwtSecurityToken token = new JwtSecurityToken(
                issuer: _config["TokenConfiguration:Issuer"],
                audience: _config["TokenConfiguration:Audiance"],
                claims: claims,
                expires: expiration,
                signingCredentials: credenciais

                );

            return new UsuarioToken()
            {
                Authenticated = true,
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = expiration,
                Message = "Token JWT ok"
            };

        }
        #endregion
    }
}

