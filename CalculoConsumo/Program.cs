using CalculoConsumo.Dominio;
using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Text.Json.Serialization;

class Program
{
    private static readonly HttpClient _apiClientes = new HttpClient();
    private static readonly HttpClient _apiCobrancas = new HttpClient();

    static DateTime GerarDataVencimento()
    {
        DateTime dataInicial = new DateTime(2022, 1, 1);
        DateTime dataFinal = new DateTime(2023, 12, 31);

        Random random = new Random();
        TimeSpan range = dataFinal - dataInicial;
        int randomDays = random.Next(range.Days);

        return dataInicial.AddDays(randomDays);
    }


    static decimal CalcularCobranca(string cpf)
    {
        string valorStr = cpf.Substring(0, 2) + cpf.Substring(9, 2);
        return decimal.Parse(valorStr);
    }


    static async Task<List<Cliente>> ObterClientesAPI()
    {
        HttpResponseMessage response = await _apiClientes.GetAsync("https://localhost:7128/Pessoas");
        if (response.IsSuccessStatusCode)
        {
            string resposta = await response.Content.ReadAsStringAsync();
            List<Cliente> clientes = JsonConvert.DeserializeObject<List<Cliente>>(resposta);
            return clientes;
        }
        return new List<Cliente>();
    }

    static async Task RegistrarCobranca(Cobranca cobranca)
    {
        HttpResponseMessage response = await _apiCobrancas.PostAsJsonAsync("https://localhost:7256/Cobrancas", cobranca);
        if (response.IsSuccessStatusCode)
        {
            Console.WriteLine($"Cobrança registrada..: {cobranca.CPF}, {cobranca.Valor.ToString()}, data vencimento: {cobranca.DataVencimento.ToString()}");
        }
        else
        {
            Console.WriteLine("Erro ao registrar cobrança.");
        }
    }

    static async Task Main(string[] args)
    {
        List<Cliente> clientes = await ObterClientesAPI();

        foreach (Cliente cliente in clientes)
        {
            Cobranca cobranca = new Cobranca();
            cobranca.CPF = cliente.CPF;
            cobranca.Valor = CalcularCobranca(cliente.CPF);
            cobranca.DataVencimento = GerarDataVencimento();

            await RegistrarCobranca(cobranca);

            Console.WriteLine($"Cobrança registrada para o cliente de cpf: {cobranca.CPF}, Valor: {cobranca.Valor.ToString()} Data venc. {cobranca.DataVencimento.ToString()}");
        }
        Console.WriteLine("Processo finalizado");
    }


}