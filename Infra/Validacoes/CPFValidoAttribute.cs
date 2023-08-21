using System.ComponentModel.DataAnnotations;

namespace Infra.Validacoes
{
    public class CPFValidoAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            string _cpf = value.ToString();

            if (_cpf == string.Empty)
            {
                return new ValidationResult("CPF não informado");
            }
            if (_cpf.Length != 11)
            {
                return new ValidationResult("CPF deve conter 11 digitos");
            }

            int[] _primeiroConjuntoMultiplicadores = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] _segundoConjuntoMultiplicadores = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string _cpfSemDigitosVerificadores;
            string _digito;
            int _soma;
            int _resto;

            _cpfSemDigitosVerificadores = _cpf.Substring(0, 9);
            _soma = 0;

            for (int i = 0; i < 9; i++)
            {
                _soma += int.Parse(_cpfSemDigitosVerificadores[i].ToString()) * _primeiroConjuntoMultiplicadores[i];
            }
            _resto = _soma % 11;

            if (_resto < 2)
            {
                _resto = 0;
            }
            else
            {
                _resto = 11 - _resto;
            }
            _digito = _resto.ToString();
            _cpfSemDigitosVerificadores = _cpfSemDigitosVerificadores + _digito;
            _soma = 0;
         
            for (int i = 0; i < 10; i++)
            {
                _soma += int.Parse(_cpfSemDigitosVerificadores[i].ToString()) * _segundoConjuntoMultiplicadores[i];
            }
            _resto = _soma % 11;

            if (_resto < 2)
            {
                _resto = 0;
            }
            else
            {
                _resto = 11 - _resto;
            }
            _digito = _digito + _resto.ToString();


            if ((!_cpf.EndsWith(_digito)) || _cpf.Distinct().Count() == 1)
            {
                return new ValidationResult("CPF informado é invalido");
            }
            return ValidationResult.Success;

        }
    }

}