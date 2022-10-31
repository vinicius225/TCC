using API.DTOs;
using API.DTOs.AutoMapping;
using AutoMapper;
using Data;
using Data.Entities;
using Data.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using MySqlConnector;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicosController : ControllerBase
    {
        private readonly IMedicoRepository _medicoRepository;
        private readonly IMapper _mapping;
        private AppDbContext appDbContext;
        public MedicosController(IMedicoRepository medicoRepository, IMapper mapping)
        {
            _medicoRepository = medicoRepository;
            _mapping = mapping;
        }

        // GET: api/<MedicosController>
        [HttpGet]
        public async Task<ActionResult<List<MedicoDTO>>> Get()
        {

            var medicosBD =  _medicoRepository.GetAll();

            medicosBD = medicosBD.ToList();

            var medicosDTO = _mapping.Map<List<MedicoDTO>>(medicosBD);


            return Ok(medicosDTO);

        }

        // GET api/<MedicosController>/5
        [HttpGet("{id}")]
        public ActionResult<MedicoDTO> Get(int id)
        {
            var medicoDb = _medicoRepository.Get(id);
            if (medicoDb != null)
            {
                return Ok(_mapping.Map<MedicoDTO>(medicoDb));
            }
            else
            {
                return NotFound();
            }
        }

        // POST api/<MedicosController>
        [HttpPost]
        public ActionResult<MedicoDTO> Post([FromBody] MedicoDTO medicoDTO)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _medicoRepository.Add(_mapping.Map<Medico>(medicoDTO));
                    return Ok(medicoDTO);
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
                medicoBd.nome = medico.nome;
                medicoBd.estado_crm = medico.estado_crm;

                _medicoRepository.Update(medicoBd);

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
