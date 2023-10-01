using DDD.Dominio.SecretariaContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Infra.SQLServer.Interface
{
    public interface IAvaliacaoRepositorio
    {

        public List<Avaliacao> GetAvaliacaoes();
        public Avaliacao GetAvaliacaoById(int id);
        public void InsertAvaliacoes(Avaliacao disciplina);
        public void UpdateAvaliacoes(Avaliacao disciplina);
        public void DeleteAvaliacoes(Avaliacao disciplina);
    }
}
