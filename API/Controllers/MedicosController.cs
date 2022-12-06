
using AutoMapper;
using Data;
using Data.DTOs;
using Data.Entities;
using Data.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using MySqlConnector;
using Newtonsoft.Json.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicosController : ControllerBase
    {
        private readonly IMedicoRepository _medicoRepository;
        public MedicosController(IMedicoRepository medicoRepository)
        {
            _medicoRepository = medicoRepository;
        }

        // GET: api/<MedicosController>
        [HttpGet]
        public async Task<ActionResult<List<MedicoDTO>>> Get()
        {

            var medicosBD =  _medicoRepository.GetAllMedicoEspecialidade();

            List<MedicoDTO> result = new List<MedicoDTO>();

            foreach (var medico in medicosBD)
            {
                var temp_medico = new  MedicoDTO(); 
                temp_medico.Get(medico);
                result.Add(temp_medico);
            }

            return Ok(result);

        }

        // GET api/<MedicosController>/5
        [HttpGet("{id}")]
        public ActionResult<MedicoDTO> Get(int id)
        {
            var medicoDb = _medicoRepository.Get(id);
            if (medicoDb != null)
            {
                var medicoDto = new MedicoDTO();
                medicoDto.Get(medicoDb);
                return Ok(medicoDto);
            }
            else
            {
                return NotFound();
            }
        }

        // POST api/<MedicosController>
        [HttpPost]
        public ActionResult<MedicoDTO> Post([FromBody] MedicoDTO medico)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var medicoBD = new Medico();
                    medico.Set(medicoBD);
                    _medicoRepository.Add(medicoBD);
                    return Ok(medico);
                }

            }
            catch (Exception ex)
            {

            }
            return BadRequest();
        }

        // PUT api/<MedicosController>/5
        [HttpPut("{id}")]
        public ActionResult<MedicoDTO> Put(int id, [FromBody] MedicoDTO medico)
        {
            var medicoBd = _medicoRepository.Get(id);
            if (medico != null)
            {
                medico.Set(medicoBd);
                _medicoRepository.Add(medicoBd);
                return Ok(medico);

            }
            else
            {
                return BadRequest("Dados invalidos;");
            }
        }

        // DELETE api/<MedicosController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

        }
    }
}
