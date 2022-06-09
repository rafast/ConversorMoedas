using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace ConversorMoedas
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Bem-vindo ao conversor de moedas!");
            ExchangeRateAPICliente.Config();
            await Run();
        }

        //Implementação do loop de leitura, conversão e resposta da apliação
        private static async Task Run()
        {
            bool fim = false;

            while (!fim)
            {
                Console.Write("Moeda origem: ");
                string moedaOrigem = Console.ReadLine();
                if (string.IsNullOrEmpty(moedaOrigem))
                {
                    fim = true;
                    return;
                }
                Console.Write("Moeda destino: ");
                string moedaDestino = Console.ReadLine();
                Console.Write("Valor: ");
                string valor = Console.ReadLine();
                Console.WriteLine();

                Conversao novaConversao = new Conversao(moedaOrigem, moedaDestino, valor);
                string response = "";
                try
                {
                    response = await ExchangeRateAPICliente.GetExchangeRatesAsync(novaConversao.GetQuery());
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ocorreu um erro durante a conversão: {ex.Message}");
                }

                try
                {
                    var resultadoConversao = JsonSerializer.Deserialize<ConversaoPOCO>(response);
                    novaConversao.ImprimeResultado(resultadoConversao);
                }
                catch (Exception)
                {
                    Console.WriteLine("Erro: moeda origem e/ou moeda destino inválida.");
                }

                Console.WriteLine("Pressione qualquer tecla para iniciar uma nova conversão. Para sair, deixe a moeda origem em branco.");
                Console.ReadKey();
                Console.Clear();

            }
        }
    }
}
