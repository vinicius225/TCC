using Data.Entities;
using Data.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnidadeSaudeController : ControllerBase
    {
        private readonly IUnidadeRepository _unidadeRepository;

        public UnidadeSaudeController(IUnidadeRepository unidadeRepository)
        {
            _unidadeRepository = unidadeRepository;
        }

        // GET: api/<UnidadeSaudeController>
        [HttpGet]
        public ActionResult<IEnumerable<UnidadeSaude>> Get()
        {
            return Ok(_unidadeRepository.GetAll());
        }

        // GET api/<UnidadeSaudeController>/5
        [HttpGet("{id}")]
        public ActionResult<UnidadeSaude> Get(int id)
        {
            var unidade = _unidadeRepository.Get(id);
            if(unidade == null)
            {
                return BadRequest("Não localizado o ID informado");
            }
            else
            {
                return Ok(unidade); 
            }
        }

        // POST api/<UnidadeSaudeController>
        [HttpPost]
        public ActionResult<UnidadeSaude> Post([FromBody] UnidadeSaude unidadeDTO)
        {
            if(!ModelState.IsValid) {
                return BadRequest(ModelState);
            }
            else
            {
                _unidadeRepository.Add(unidadeDTO);
            }
            return unidadeDTO;
        }

        // PUT api/<UnidadeSaudeController>/5
        [HttpPut("{id}")]
        public ActionResult<UnidadeSaude> Put(int id, [FromBody] UnidadeSaude unidadeDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                _unidadeRepository.Add(unidadeDTO);
            }
            return unidadeDTO;
        }

        // DELETE api/<UnidadeSaudeController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var unidade = _unidadeRepository.Get(id);
            if(unidade == null)
            {
                return BadRequest("Objeto não Encontrado");
            }
            else
            {
                _unidadeRepository.Delete(unidade);
            }
            return Ok(unidade);
        }
    }
}
