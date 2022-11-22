using Data.DTOs;
using Data.Entities;
using Data.Repositories;
using Data.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnidadeSaudeController : ControllerBase
    {
        private readonly IUnidadeSaudeRepository _unidadeRepository;

        public UnidadeSaudeController(IUnidadeSaudeRepository unidadeRepository)
        {
            _unidadeRepository = unidadeRepository;
        }

        // GET: api/<UnidadeSaudeController>
        [HttpGet]
        public ActionResult<List<UnidadeDTO>> Get()
        {
            var UnidadesBD = _unidadeRepository.GetAll();

            List<UnidadeDTO> result = new List<UnidadeDTO>();

            foreach (var unidade in UnidadesBD)
            {
                var temp_unidade = new UnidadeDTO();
                temp_unidade.Get(unidade);
                result.Add(temp_unidade);
            }

            return Ok(result);
        }

        // GET api/<UnidadeSaudeController>/5
        [HttpGet("{id}")]
        public ActionResult<UnidadeDTO> Get(int id)
        {
            var unidade = _unidadeRepository.Get(id);
            if(unidade == null)
            {
                return BadRequest("Não localizado o ID informado");
            }
            else
            {
                var unidadeDTO = new UnidadeDTO();
                unidadeDTO.Get(unidade);
                return Ok(unidadeDTO);
            }
        }

        // POST api/<UnidadeSaudeController>
        [HttpPost("{id}")]
        public ActionResult<UnidadeSaude> Post(int id,[FromBody] UnidadeDTO unidadeDTO)
        {
            if(!ModelState.IsValid ) {
                return BadRequest(ModelState);
            }
            else
            {
                var unidadeBd = new UnidadeSaude();
                unidadeDTO.Set(unidadeBd);
                _unidadeRepository.Update(unidadeBd);
                return Ok(unidadeDTO);
            }
        }

        // PUT api/<UnidadeSaudeController>/5
        [HttpPut("{id}")]
        public ActionResult<UnidadeSaude> Put(int id, [FromBody] UnidadeDTO unidadeDTO)
        {

            var unidadeBd = _unidadeRepository.Get(id);
            if (!ModelState.IsValid || unidadeBd == null)
            {
                return BadRequest(ModelState);
            }
            else
            {
                unidadeDTO.Set(unidadeBd);
                return unidadeBd;

            }
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
