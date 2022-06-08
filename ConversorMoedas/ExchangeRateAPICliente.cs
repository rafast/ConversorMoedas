using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ConversorMoedas
{
    public static class ExchangeRateAPICliente
    {
        private static readonly HttpClient httpCliente = new HttpClient();

        public static async Task<string> GetExchangeRatesAsync(string path)
        {
            var stringTask = await httpCliente.GetStringAsync(path);
            return  stringTask;
        }

        public static void Config()
        {
            httpCliente.BaseAddress = new Uri("https://api.exchangerate.host/convert");
            httpCliente.DefaultRequestHeaders.Clear();
            httpCliente.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}
