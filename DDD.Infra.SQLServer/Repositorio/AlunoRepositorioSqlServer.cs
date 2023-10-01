﻿using DDD.Dominio.SecretariaContext;
using DDD.Infra.SQLServer.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Infra.SQLServer.Repositorio
{
    public class AlunoRepositorioSqlServer : IAlunoRepositorio
    {
        private readonly SqlContext _context;

        public AlunoRepositorioSqlServer(SqlContext context)
        {
            _context = context;
        }

        public void DeleteAluno(Aluno aluno)
        {
            try
            {
                _context.Set<Aluno>().Remove(aluno);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Aluno GetAlunoById(int id)
        {
            return _context.Alunos.Find(id);
        }

        public List<Aluno> GetAlunos()
        {
            //return  _context.Alunos.Include(x => x.Disciplinas).ToList();
            return _context.Alunos.ToList();

        }

        public void InsertAluno(Aluno aluno)
        {
            try
            {
                _context.Alunos.Add(aluno);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                //log exception

            }
        }

        public void UpdateAluno(Aluno aluno)
        {
            try
            {
                _context.Entry(aluno).State = EntityState.Modified;
                _context.SaveChanges();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
