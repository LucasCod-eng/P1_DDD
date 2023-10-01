using DDD.Dominio.UserContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Dominio.SecretariaContext
{
    public class Aluno : User
    {
        public List<Avaliacao>? Avaliacoes { get; set; }
    }
}
