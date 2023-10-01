using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Dominio.PicContext
{
    public class Projeto
    {
        public int ProjetoId { get; set; }
        public string ProjetoName { get; set; }
        public string ProjetoDescription { get; set; }
        public int AnosDuracao { get; set; }
    }
}
