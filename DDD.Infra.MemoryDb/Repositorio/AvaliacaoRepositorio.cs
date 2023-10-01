using DDD.Dominio.SecretariaContext;
using DDD.Infra.MemoryDb.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Infra.MemoryDb.Repositorio
{
    public class AvaliacaoRepositorio : IAvaliacaoRepositorio
    {

        private readonly ApiContext _context;

        public AvaliacaoRepositorio(ApiContext context)
        {
            _context = context;
        }

        public void DeleteAvaliacoes(Avaliacao avaliacao)
        {
            try
            {
                _context.Set<Avaliacao>().Remove(avaliacao);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Avaliacao GetAvaliacaoById(int id)
        {
            return _context.Avaliacoes.Find(id);
        }

        public List<Avaliacao> GetAvaliacaoes()
        {
            using (var context = new ApiContext())
            {
                var list = context.Avaliacoes.ToList();
                return list;
            }
        }

        public void InsertAvaliacoes(Avaliacao avaliacao)
        {
            try
            {
                _context.Avaliacoes.Add(avaliacao);
                _context.SaveChanges();
            }
            catch (Exception ex)    
            {
                //log exception

            }
        }

        public void UpdateAvaliacoes(Avaliacao avaliacao)
        {
            try
            {
                _context.Entry(avaliacao).State = EntityState.Modified;
                _context.SaveChanges();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
