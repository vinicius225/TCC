
using AutoMapper;
using Data.Entities;
using Data.Repositories.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class EspecialidadeController : ControllerBase
    {
        private readonly IEspecialidadeRepository _especialidadeRepository;

        public EspecialidadeController(IEspecialidadeRepository especialidadeRepository, IMapper autoMapper)
        {
            _especialidadeRepository = especialidadeRepository;
        }


        // GET: api/<EspecialidadeController>
        [HttpGet]
        public IEnumerable<Especialidade> Get()
        {
            var especialidade = _especialidadeRepository.GetAll().ToList();

            return especialidade;
        }

        // GET api/<EspecialidadeController>/5
        [HttpGet("{id}")]
        public ActionResult<Especialidade> Get(int id)
        {
            var especialidade = _especialidadeRepository.Get(id);
            if(especialidade == null) {
                return BadRequest();
            }else
            {
                return Ok(especialidade);   
            }
        }

        // POST api/<EspecialidadeController>
        [HttpPost]
        public ActionResult<Especialidade> Post([FromBody] Especialidade especialidadeDTO)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _especialidadeRepository.Add(especialidadeDTO);
            return Ok(especialidadeDTO);
        }

        // PUT api/<EspecialidadeController>/5
        [HttpPut("{id}")]
        public ActionResult<Especialidade> Put(int id, [FromBody] Especialidade especialidadeDTO)
        {

            var especialidade = _especialidadeRepository.Get(id);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _especialidadeRepository.Update(especialidadeDTO);
            return Ok(especialidadeDTO);
        }

        // DELETE api/<EspecialidadeController>/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            var especialidade = _especialidadeRepository.Get(id);
            if (especialidade != null)
            {
                _especialidadeRepository.Delete(especialidade);
                return "Item deletado";
            }else
            {
                return "Item não encontrado";
            }
        }
    }
}
