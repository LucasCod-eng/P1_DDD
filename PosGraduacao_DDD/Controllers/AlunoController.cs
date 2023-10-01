﻿using DDD.Dominio.SecretariaContext;
using DDD.Infra.SQLServer.Interface;
using Microsoft.AspNetCore.Mvc;

namespace PosGraduacao_DDD.Controllers
{
    public class AlunoController : Controller
    {
        readonly IAlunoRepositorio _alunoRepository;

        public AlunoController(IAlunoRepositorio alunoRepository)
        {
            _alunoRepository = alunoRepository;
        }

        // GET: api/<AlunosController>
        [HttpGet]
        public ActionResult<List<Aluno>> Get()
        {
            return Ok(_alunoRepository.GetAlunos());
        }

        [HttpGet("{id}")]
        public ActionResult<Aluno> GetById(int id)
        {
            return Ok(_alunoRepository.GetAlunoById(id));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Aluno> CreateAluno(Aluno aluno)
        {
            if (aluno.Nome.Length < 3 || aluno.Nome.Length > 30)
            {
                return BadRequest("Nome deve ser maior que 3 e menor que 30 caracteres.");
            }
            _alunoRepository.InsertAluno(aluno);
            return CreatedAtAction(nameof(GetById), new { id = aluno.UserId }, aluno);
        }

        [HttpPut]
        public ActionResult Put([FromBody] Aluno aluno)
        {
            try
            {
                if (aluno == null)
                    return NotFound();

                _alunoRepository.UpdateAluno(aluno);
                return Ok("Aluno Atualizado com sucesso!");
            }
            catch (Exception)
            {

                throw;
            }
        }

        // DELETE api/values/5
        [HttpDelete()]
        public ActionResult Delete([FromBody] Aluno aluno)
        {
            try
            {
                if (aluno == null)
                    return NotFound();

                _alunoRepository.DeleteAluno(aluno);
                return Ok("Aluno Removido com sucesso!");
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
