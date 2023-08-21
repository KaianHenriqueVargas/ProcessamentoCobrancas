namespace Infra.Utils
{
    public static class FormatarCPF
    {
        public static string RemoverMascara(string valor)
        {
            return new string(valor.Where(char.IsDigit).ToArray());
        }
    }
}
