
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
        public MedicosController(IMedicoRepository medicoRepository, IMapper mapping)
        {
            _medicoRepository = medicoRepository;
        }

        // GET: api/<MedicosController>
        [HttpGet]
        public async Task<ActionResult<List<Medico>>> Get()
        {

            var medicosBD =  _medicoRepository.GetAll();

            return Ok(medicosBD);

        }

        // GET api/<MedicosController>/5
        [HttpGet("{id}")]
        public ActionResult<Medico> Get(int id)
        {
            var medicoDb = _medicoRepository.Get(id);
            if (medicoDb != null)
            {
                return Ok(medicoDb);
            }
            else
            {
                return NotFound();
            }
        }

        // POST api/<MedicosController>
        [HttpPost]
        public ActionResult<Medico> Post([FromBody] Medico Medico)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _medicoRepository.Add(Medico);
                    return Ok(Medico);
                }

            }
            catch (Exception ex)
            {

            }
            return BadRequest();
        }

        // PUT api/<MedicosController>/5
        [HttpPut("{id}")]
        public ActionResult<Medico> Put(int id, [FromBody] Medico medico)
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
