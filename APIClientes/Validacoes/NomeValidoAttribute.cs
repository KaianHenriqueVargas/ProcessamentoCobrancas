using System.ComponentModel.DataAnnotations;

namespace APIClientes.Validacoes
{
    public class NomeValidoAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (string.IsNullOrEmpty(value.ToString()))
            {
                return new ValidationResult("Nome não informado");
            }

           if (value.ToString().Length > 100)
            {
                return new ValidationResult("Nome informado não pode ser maior que 100 caracteres");
            }
            return ValidationResult.Success;

        }
    }
}
