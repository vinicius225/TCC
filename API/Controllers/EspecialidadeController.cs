using API.DTOs;
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
        private readonly IMapper _mapper;

        public EspecialidadeController(IEspecialidadeRepository especialidadeRepository, IMapper autoMapper)
        {
            _especialidadeRepository = especialidadeRepository;
            _mapper = autoMapper;
        }


        // GET: api/<EspecialidadeController>
        [HttpGet]
        public IEnumerable<EspecialidadeDTO> Get()
        {
            var especialidade = _especialidadeRepository.GetAll().ToList();

            List<EspecialidadeDTO> result = new List<EspecialidadeDTO>();
            foreach (var especialidadeDTO in especialidade)
            {
                var espec = new EspecialidadeDTO();
                espec.nome = especialidadeDTO.nome;
                espec.descricao = especialidadeDTO.descricao;

                result.Add(espec);
            }
            return result;
        }

        // GET api/<EspecialidadeController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<EspecialidadeController>
        [HttpPost]
        public void Post([FromBody] EspecialidadeDTO especialidadeDTO)
        {
            var especialidade = _mapper.Map<Especialidade>(especialidadeDTO);
            _especialidadeRepository.Add(especialidade);
        }

        // PUT api/<EspecialidadeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] EspecialidadeDTO especialidadeDTO)
        {

            var especialidade = _especialidadeRepository.Get(id);
            if (ModelState.IsValid)
            {
                especialidade.nome = especialidadeDTO.nome;
                especialidade.descricao = especialidadeDTO.descricao;

                _especialidadeRepository.Update(especialidade);
            }
        }

        // DELETE api/<EspecialidadeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
