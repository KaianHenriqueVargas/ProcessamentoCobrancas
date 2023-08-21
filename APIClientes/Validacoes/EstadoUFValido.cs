using System.ComponentModel.DataAnnotations;

namespace APIClientes.Validacoes
{
    public class EstadoUFValido : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (string.IsNullOrEmpty(value.ToString()))
            {
                return new ValidationResult("Estado/UF não informado");
            }

            if (value.ToString().Length > 100)
            {
                return new ValidationResult("Estado/UF informado não pode ser maior que 2 caracteres");
            }
            return ValidationResult.Success;

        }
    }
}
