﻿using DDD.Dominio.SecretariaContext;
using DDD.Infra.MemoryDb.Interface;
using DDD.Infra.SQLServer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Infra.MemoryDb.Repositorio
{
    public class AlunoRepositoriSqlServer : IAlunoRepositorio
    {
        private readonly SqlContext _context;

        public AlunoRepositoriSqlServer(SqlContext context)
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
