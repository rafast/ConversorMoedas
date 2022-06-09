using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ConversorMoedas
{
    //Classe responsável por fazer a requisição da conversão
    public static class ExchangeRateAPICliente
    {
        private static readonly HttpClient httpCliente = new HttpClient();

        //Configura a URL base e configura o ContentType da requisição
        public static void Config()
        {
            httpCliente.BaseAddress = new Uri("https://api.exchangerate.host/convert");
            httpCliente.DefaultRequestHeaders.Clear();
            httpCliente.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        //Realiza a requisição e torna uma Task do tipo string com o resultado da chamada
        public static async Task<string> GetExchangeRatesAsync(string path)
        {
            var stringTask = await httpCliente.GetStringAsync(path);
            return  stringTask;
        }

    }
}
