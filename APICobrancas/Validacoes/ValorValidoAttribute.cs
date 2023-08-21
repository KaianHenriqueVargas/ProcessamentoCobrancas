using System.ComponentModel.DataAnnotations;

namespace APICobrancas.Validacoes
{
    public class ValorValidoAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            decimal valor = (decimal)value;

            if (valor <= 0)
            {
                return new ValidationResult("Valor informado precisa ser maior que 0");
            }
            return ValidationResult.Success;
        }
    }
}
