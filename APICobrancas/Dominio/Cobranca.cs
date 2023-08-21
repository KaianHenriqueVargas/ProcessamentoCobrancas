using System.ComponentModel.DataAnnotations;
namespace APICobrancas.Dominio
{
    public class Cobranca
    {
        public int ID { get; set; }
        public string? CPF { get; set; }     
        public decimal Valor { get; set; }
        public DateTime DataVencimento { get; set; }
    }
}
