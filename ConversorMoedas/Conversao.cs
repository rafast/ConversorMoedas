using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ConversorMoedas
{
    //Classe que representa uma Conversão e sua validação
    public class Conversao
    {
        public string MoedaOrigem { get; set; }
        public string MoedaDestino { get; set; }
        public string Valor { get; set; }
        public Dictionary<string, string> Erros { get; set; } = new Dictionary<string, string>();

        public Conversao(string moedaOrigem, string moedaDestino, string valor)
        {
            MoedaOrigem = moedaOrigem.ToUpper();
            MoedaDestino = moedaDestino.ToUpper();
            Valor = valor;
            IniciaValidacao();
        }

        //Executa a validacao dos campos de acordo com as regras de negócio da aplicação
        public void ValidarDados()
        {
            Erros.Clear();
            if (!IsFormatoMoedaValido(MoedaOrigem))
            {
                Erros.Add("MoedaOrigem", "A moeda de origem deve ter exatamente 3 caracteres.");
            }

            if (!IsFormatoMoedaValido(MoedaDestino) || MoedaDestino.Equals(MoedaOrigem))
            {
                Erros.Add("MoedaDestino", "A moeda de destino deve ter exatamente 3 caracteres e ser diferente da moeda origem.");
            }

            if (!ValidaValor())
            {
                Erros.Add("Valor", "O valor deve ser maior que 0.");
            }
        }

        public bool HasErrors()
        {
            return Erros.Count > 0;
        }

        public void ExibirErros()
        {
            foreach (var erro in Erros)
            {
                Console.WriteLine($"Erro: {erro.Value}");
            }
        }
        //Inicia a releitura dos dados inválidos e faz uma nova validação
        public void IniciaValidacao()
        {
            ValidarDados();
            while (HasErrors())
            {
                ExibirErros();

                string novaLeitura = "";

                foreach (var campoInvalido in Erros)
                {
                    Console.Write($"{campoInvalido.Key} :");
                    novaLeitura = Console.ReadLine();
                    GetType()
                   .GetProperty(campoInvalido.Key)
                   .SetValue(this, novaLeitura.ToUpper());
                }
                ValidarDados();
            }
        }
        //Verifica se o valor é maior que zero
        private bool ValidaValor()
        {
            return decimal.TryParse(Valor, out var value) & value >0;
        }
        //Verifica se uma moeda é composta somente por letras e tamanho igual a 3
        private bool IsFormatoMoedaValido(string moeda)
        {
            string padrao = "^[A-Z]{3}$";
            return Regex.IsMatch(moeda, padrao);
        }
        //Retorna a query para realizar a conversão através da API
        public string GetQuery()
        {
            return $"?from={MoedaOrigem}&to={MoedaDestino}&amount={Valor}";
        }
        //Imprime o resultado da conversão
        public void ImprimeResultado(ConversaoPOCO resultado)
        {
            Console.WriteLine($"{MoedaOrigem} {Valor} => {MoedaDestino} {resultado.Result:C2}");
            Console.WriteLine($"Taxa: {resultado.Info.Rate}");
        }
    }
}
