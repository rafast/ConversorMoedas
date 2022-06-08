using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ConversorMoedas
{
    class Program
    {
        private static readonly HttpClient httpCliente = new HttpClient();

        static async Task Main(string[] args)
        {
            Console.WriteLine("Bem-vindo ao conversor de moedas!");
            ExchangeRateAPICliente.Config();
            await Run();

            //HttpResponseMessage response = await httpCliente.GetAsync("https://api.exchangerate.host/convert?from=USD&to=BRL&amount=100.0");

            //var json = await ExchangeRateAPICliente.GetExchangeRates("?from=USD&to=BRL&amount=100.0");
            //var jsonString = JsonSerializer.Deserialize<ConversaoPOCO>(json);
            //Console.WriteLine(jsonString.Info.Rate);
            //Console.WriteLine(jsonString.Result);
        }

        private static async Task Run()
        {
            bool fim = false;

            while (!fim)
            {
                Console.Write("Moeda origem: ");
                string moedaOrigem = Console.ReadLine();
                Console.Write("Moeda destino: ");
                string moedaDestino = Console.ReadLine();
                Console.Write("Valor: ");
                string valor = Console.ReadLine();

                if (string.IsNullOrEmpty(moedaOrigem))
                {
                    fim = true;
                    return;
                }

                Conversao novaConversao = new Conversao(moedaOrigem, moedaDestino, valor);

                var resultado = await ExchangeRateAPICliente.GetExchangeRates(novaConversao.GetQuery());
                var json = JsonSerializer.Deserialize<ConversaoPOCO>(resultado);
                Console.WriteLine();
                Console.WriteLine($"{novaConversao.MoedaOrigem} {novaConversao.Valor} => {novaConversao.MoedaDestino} {json.Result:C2}");
                Console.WriteLine($"Taxa: {json.Info.Rate}");
                Console.ReadKey();


            }
        }
    }
}
