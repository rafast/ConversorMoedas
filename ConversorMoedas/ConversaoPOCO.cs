using System;
using System.Text.Json.Serialization;

namespace ConversorMoedas
{
    //Classe para deserializar o JSON recebido da API
    public class ConversaoPOCO
    {
        [JsonPropertyName("info")]
        public Info Info { get; set; }
        [JsonPropertyName("result")]
        public decimal Result { get; set; }

        public ConversaoPOCO()
        {
        }
    }

    public class Info
    {
        [JsonPropertyName("rate")]
        public decimal Rate { get; set; }

        public Info(decimal rate)
        {
            Rate = rate;
        }
        
    }
}
