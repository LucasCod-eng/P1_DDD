using DDD.Dominio.SecretariaContext;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DDD.Dominio.SecretariaContext
{
    public class Avaliacao
    {
        public int AvaliacaoId { get; set; }   

        public string? NomeAvaliacao { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Nota { get; set; }

        public DateTime DataAvaliacao { get; set; }

        public IList<Aluno>? Alunos { get; set; }
    }
}
