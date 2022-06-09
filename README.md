# ConversorMoedas

Trata-se de uma aplicação de console C# que consome uma API REST para realizar a conversão de moedas.

A API utilizada no projeto foi a https://api.exchangerate.host/convert.

As regras de negócio implementadas na solução são:

- A moeda destino deve ser diferente da moeda origem.
- As moedas origem e destino devem ter exatamente 3 caracteres.
- O valor da conversão deve ser maior que zero.
- A taxa de conversão deve ser apresentada com 6 casas decimais.
- O programa deve terminar quando o usuário digitar string vazia para a moeda de origem.
- Erro na comunicação com a API: deve ser apresentada a mensagem de erro correspondente.
- Problemas na conversão: deve ser apresentada a mensagem de erro correspondente.
