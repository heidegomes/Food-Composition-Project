# Food Composition Scraper

Este projeto é uma aplicação de web scraping que coleta dados sobre a composição dos alimentos a partir do site [TBCA](https://www.tbca.net.br) e armazena essas informações para análise posterior. A aplicação foi desenvolvida utilizando C# com a biblioteca `HtmlAgilityPack` para extrair dados de tabelas HTML.

## Descrição

O projeto realiza scraping em duas páginas da TBCA:
1. A página inicial que contém uma lista de produtos alimentícios com seus códigos.
2. A página específica de cada produto, onde são extraídas informações detalhadas sobre a composição de cada alimento, como:
   - Componente
   - Unidade de medida
   - Valor por 100g
   - Desvio padrão
   - Valor mínimo e máximo
   - Número de amostras
   - Referência
   - Tipo de dado

## Funcionalidades

- **Scraping inicial**: Extrai uma lista de produtos alimentícios com seus códigos.
- **Scraping detalhado**: Para cada código de produto, realiza uma requisição para obter informações mais detalhadas, como componentes e valores nutricionais.
- **Armazenamento de dados**: Os dados extraídos são armazenados em um objeto `FoodData` para posterior uso e processamento.

## Tecnologias Utilizadas

- **C#**: Linguagem de programação usada para desenvolver a aplicação.
- **HtmlAgilityPack**: Biblioteca utilizada para manipulação e parsing de HTML.
- **ASP.NET Core**: Framework utilizado para a criação da aplicação (se necessário para a execução como um serviço).

## Pré-Requisitos

Antes de começar, certifique-se de ter os seguintes itens instalados:

- [.NET SDK](https://dotnet.microsoft.com/download) (versão 5 ou superior)
- [Visual Studio](https://visualstudio.microsoft.com/) ou qualquer IDE de sua escolha que suporte C#

## Instalação

1. Clone o repositório para sua máquina local:

   ```bash
   git clone https://github.com/seu-usuario/FoodCompositionScraper.git

2. Abra o projeto no Visual Studio ou outra IDE que suporte C#.

3. Instale as dependências do projeto. No terminal, navegue até o diretório do projeto e execute:

  ```bash
  dotnet restore

4. Construa e execute o projeto:

  ```bash
  dotnet run

## Como Usar

1. Execute o projeto com o comando dotnet run no terminal ou a partir da sua IDE.
2. O scraping será iniciado automaticamente, coletando os dados das páginas da TBCA.
3. Os dados extraídos são impressos no console para verificação, ou podem ser armazenados e manipulados conforme a necessidade.

## Exemplo de Saída

Após a execução, os dados extraídos para cada produto serão exibidos no console, como no exemplo abaixo:

  URL: https://www.tbca.net.br/base-dados/int_composicao_estatistica.php?cod_produto=1234
  Component: Proteína
  Unit: g
  ValuePer100g: 10g
  StandardDeviation: 0.5
  MinimumValue: 9g
  MaximumValue: 11g
  NumberSamples: 100
  Reference: Estudo XYZ
  DataType: Média

## Estrutura do Projeto

FoodCompositionScraper/
│
├── Program.cs            # Classe principal que executa o scraping
├── Services/
│   └── WebScraperService.cs # Serviço responsável pelo scraping e extração de dados
├── Models/
│   └── Food.cs       # Modelo que representa os dados dos alimentos
└── FoodCompositionScraper.csproj # Arquivo de projeto do .NET

## Contribuindo

Se você deseja contribuir para o projeto, siga os passos abaixo:

1. Faça o fork do repositório.
2. Crie uma nova branch (git checkout -b minha-contribuicao).
3. Faça as modificações necessárias.
4. Commit as alterações (git commit -am 'Adicionei minha contribuição').
5. Envie para o seu repositório (git push origin minha-contribuicao).
6. Abra um pull request.