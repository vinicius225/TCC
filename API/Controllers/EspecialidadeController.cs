
using AutoMapper;
using Data.DTOs;
using Data.Entities;
using Data.Repositories;
using Data.Repositories.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.WebSockets;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class EspecialidadeController : ControllerBase
    {
        private readonly IEspecialidadeRepository _especialidadeRepository;

        public EspecialidadeController(IEspecialidadeRepository especialidadeRepository)
        {
            _especialidadeRepository = especialidadeRepository;
        }


        // GET: api/<EspecialidadeController>
        [HttpGet]
        public ActionResult<List<EspecialidadeDTO>> Get()
        {
            var especialidadesBD = _especialidadeRepository.GetAll();

            List<EspecialidadeDTO> result = new List<EspecialidadeDTO>();

            foreach (var especialidade in especialidadesBD)
            {
                var temp_especialidade = new EspecialidadeDTO();
                temp_especialidade.Get(especialidade);
                result.Add(temp_especialidade);
            }

            return Ok(result);

        }

        // GET api/<EspecialidadeController>/5
        [HttpGet("{id}")]
        public ActionResult<EspecialidadeDTO> Get(int id)
        {
            var especialidade = _especialidadeRepository.Get(id);
            if(especialidade == null) {
                return BadRequest();
            }else
            {
                var especialidadeDTO = new EspecialidadeDTO();
                especialidadeDTO.Get(especialidade);

                return especialidadeDTO;
            }
        }

        // POST api/<EspecialidadeController>
        [HttpPost]
        public ActionResult<EspecialidadeDTO> Post([FromBody] EspecialidadeDTO especialidadeDTO)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = new Especialidade();
            especialidadeDTO.Set(result);
            _especialidadeRepository.Add(result);
            return Ok(especialidadeDTO);
        }

        [HttpPost("busca-especializada")]
        public ActionResult<MedicoDTO> BuscaEspecializada([FromBody] PesquisaEspecializadaDTO busca)
        {
           var medicos = _especialidadeRepository.GetMedicosPorBuscaEspecialidade(busca.busca);

            var medicosDto = new List<MedicoDTO>();

            foreach(var item in medicos)
            {
                var temp = new MedicoDTO();
                temp.Get(item);
                medicosDto.Add(temp);
            }

            return Ok(medicosDto);

        } 


        // PUT api/<EspecialidadeController>/5
        [HttpPut("{id}")]
        public ActionResult<EspecialidadeDTO> Put(int id, [FromBody] EspecialidadeDTO especialidadeDTO)
        {

            var especialidade = _especialidadeRepository.Get(id);
            if (!ModelState.IsValid || especialidade == null)
            {
                return BadRequest(ModelState);
            }
            especialidadeDTO.Set(especialidade);
            _especialidadeRepository.Update(especialidade);
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
