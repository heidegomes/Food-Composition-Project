# Food Composition Scraper

Este projeto é uma aplicação de web scraping que coleta dados sobre a composição dos alimentos a partir do site [TBCA](https://www.tbca.net.br) e armazena essas informações num Banco de Dados SQLite. A aplicação foi desenvolvida utilizando C# com a biblioteca `HtmlAgilityPack` para extrair dados de tabelas HTML.

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
- **Armazenamento de dados**: Os dados extraídos são armazenados em um objeto `FoodData` num banco de dados SQLite.

## Tecnologias Utilizadas

- **C#**: Linguagem de programação usada para desenvolver a aplicação.
- **HtmlAgilityPack**: Biblioteca utilizada para manipulação e parsing de HTML.
- **ASP.NET Core**: Framework utilizado para a criação da aplicação (se necessário para a execução como um serviço).
- **SQLite**: Banco de dados leve e autônomo utilizado para armazenar e gerenciar os dados extraídos de forma eficiente. Ideal para aplicações que não requerem um servidor de banco de dados completo.

## Pré-Requisitos

Antes de começar, certifique-se de ter os seguintes itens instalados:

- [.NET SDK](https://dotnet.microsoft.com/download) (versão 5 ou superior)
- IDE de sua escolha que suporte C#.

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

2. Usando o Postman, faça uma requisicição GET no endpoint http://localhost:5057/scrape-food para executar o scraper.

3. Os dados extraídos são salvos em um banco de dados e podem ser acessados fazendo uma requisição GET nos endpoints http://localhost:5057/api/food e http://localhost:5057/api/food/{code} 

## Exemplo de Saída
 
"code": "BRC1139B",
    "name": "Cogumelo, assado, s/ óleo, c/ sal (média de diferentes tipos)",
    "scientificName": "",
    "group": "Vegetais e derivados",
    "components": [
        {
            "id": 72311,
            "foodCode": "BRC1139B",
            "component": "Energia",
            "unit": "kJ",
            "valuePer100g": "139",
            "standardDeviation": "-",
            "minimumValue": "-",
            "maximumValue": "-",
            "numberSamples": "-",
            "reference": "-",
            "dataType": "Calculado"
        },
        ...
    ]

## Estrutura do Projeto

food-composition-backend/
│
├── Controllers/
│   └── FoodController.cs     # Controlador para manipulação de dados sobre alimentos
├── Data/
│   └── FoodContext.cs        # Contexto do banco de dados para alimentos
├── Migrations/
│   ├── 20250204023858_InitialCreate.Designer.cs   # Arquivo de migração inicial
│   ├── 20250204023858_InitialCreate.cs            # Arquivo de migração inicial
│   └── FoodContextModelSnapshot.cs                # Snapshot do modelo do banco de dados
├── Models/
│   └── FoodData.cs          # Modelo de dados para os alimentos
├── Properties/
│   └── launchSettings.json  # Arquivo de configurações para o ambiente de desenvolvimento
├── Services/
│   ├── FoodService.cs       # Serviço que lida com a lógica de negócios de alimentos
│   └── WebScraperService.cs # Serviço para web scraping de dados sobre alimentos
└── food-composition-backend.csproj # Arquivo de projeto do .NET


## Contribuindo

Se você deseja contribuir para o projeto, siga os passos abaixo:

1. Faça o fork do repositório.
2. Crie uma nova branch (git checkout -b minha-contribuicao).
3. Faça as modificações necessárias.
4. Commit as alterações (git commit -am 'Adicionei minha contribuição').
5. Envie para o seu repositório (git push origin minha-contribuicao).
6. Abra um pull request.