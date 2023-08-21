using APICobrancas.Validacoes;
using Infra.Utils;
using Infra.Validacoes;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace APICobrancas.DTOs
{
    public class CobrancaDTO
    {
        private string _cpf;
        [CPFValido]
        public string? CPF
        {
            get => _cpf;
            set => _cpf = FormatarCPF.RemoverMascara(value);
        }
        [ValorValido]
        public decimal Valor { get; set; }
        public DateTime DataVencimento { get; set; }
    }
}
