using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculoConsumo.Dominio
{
    public class Cobranca
    {
        public string CPF { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataVencimento { get; set;}
    }
}
