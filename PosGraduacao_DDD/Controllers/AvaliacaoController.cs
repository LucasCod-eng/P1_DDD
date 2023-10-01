using DDD.Dominio.SecretariaContext;
using DDD.Infra.SQLServer.Interface;
using Microsoft.AspNetCore.Mvc;

namespace PosGraduacao_DDD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AvaliacaoController : Controller
    {
        readonly IAvaliacaoRepositorio _avaliacaoRepository;

        public AvaliacaoController(IAvaliacaoRepositorio avaliacaoRepository)
        {
            _avaliacaoRepository = avaliacaoRepository;
        }

        // GET: api/<AlunosController>
        [HttpGet]
        public ActionResult<List<Avaliacao>> Get()
        {
            return Ok(_avaliacaoRepository.GetAvaliacaoes());
        }

        [HttpGet("{id}")]
        public ActionResult<Avaliacao> GetById(int id)
        {
            return Ok(_avaliacaoRepository.GetAvaliacaoById(id));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Aluno> CreateDisciplina(Avaliacao avaliacao)
        {
            _avaliacaoRepository.InsertAvaliacoes(avaliacao);
            return CreatedAtAction(nameof(GetById), new { id = avaliacao.AvaliacaoId }, avaliacao);
        }

        [HttpPut]
        public ActionResult Put([FromBody] Avaliacao avaliacao)
        {
            try
            {
                if (avaliacao == null)
                    return NotFound();

                _avaliacaoRepository.UpdateAvaliacoes(avaliacao);
                return Ok("Avaliacao Atualizada com sucesso!");
            }
            catch (Exception)
            {

                throw;
            }
        }

        // DELETE api/values/5
        [HttpDelete()]
        public ActionResult Delete([FromBody] Avaliacao avaliacao)
        {
            try
            {
                if (avaliacao == null)
                    return NotFound();

                _avaliacaoRepository.DeleteAvaliacoes(avaliacao);
                return Ok("Avaliacao Removida com sucesso!");
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
