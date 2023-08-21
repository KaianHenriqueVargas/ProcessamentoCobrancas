using APIClientes.Validacoes;
using Infra.Validacoes;
using Infra.Utils;

namespace APIClientes.DTOs
{
    public class PessoaDTO
    {
        private string? _cpf;
        private string? _uf;

        [CPFValido]
        public string? CPF
        {
            get => _cpf;
            set => _cpf = FormatarCPF.RemoverMascara(value);
        }
        [NomeValido]
        public string? Nome { get; set; }
        [EstadoUFValido]
        public string? UF
        {
            get => _uf.ToUpper();
            set => _uf = value.ToUpper();
        }
    }
}
