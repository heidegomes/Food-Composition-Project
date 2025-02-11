# Food Composition Project

Este repositório contém o código para um projeto completo de **composição de alimentos**, com um frontend desenvolvido em **Next.js** e **TailwindCSS** e um backend desenvolvido em **C#** utilizando **ASP.NET Core** para scraping de dados e construção da API.

## Estrutura do Projeto

A estrutura do projeto é organizada da seguinte forma:

## Tecnologias Usadas

### Frontend
- **Next.js** - Framework React para aplicações web.
- **React** - Biblioteca para construção de interfaces de usuário.
- **TailwindCSS** - Framework de CSS utilitário para estilização rápida.
- **TypeScript** - Superset do JavaScript para maior segurança e produtividade no desenvolvimento.
  
### Backend
- **C#** - Linguagem de programação usada para desenvolver o backend.
- **ASP.NET Core** - Framework usado para construir a aplicação web backend.
- **HtmlAgilityPack** - Biblioteca utilizada para scraping de dados das páginas da TBCA.
- **Entity Framework Core** - Para interações com o banco de dados.
- **SQLite**: Banco de dados leve e autônomo utilizado para armazenar e gerenciar os dados extraídos de forma eficiente. Ideal para aplicações que não requerem um servidor de banco de dados completo.
  
## Pré-Requisitos

### Backend
O backend é uma aplicação de **web scraping** que coleta dados sobre a composição de alimentos e os armazena num banco de dados SQLite. Para que o frontend funcione corretamente, o backend precisa estar rodando. Consulte o [README do backend](food-composition-backend/README.md) para instruções de instalação e execução.

### Frontend
O frontend se conecta ao backend para exibir as informações de forma interativa. Certifique-se de que o backend esteja em execução antes de iniciar o frontend.

## Instalação

### Backend

1. Navegue até o diretório `food-composition-backend/`:

   ```bash
   cd food-composition-backend

2. Instale as dependências do backend::

    ```bash
    dotnet restore

3. Execute o projeto backend:

    ```bash
    dotnet run

### Frontend

1. Navegue até o diretório food-composition-frontend/:

    ```bash
    cd food-composition-frontend

2. Instale as dependências do frontend:

    ```bash
    npm install

3. Execute o servidor de desenvolvimento:

    ```bash
    npm run dev
4. O frontend estará disponível em http://localhost:3000.

## Scripts

### Backend

- **dotnet run:** Inicia o servidor do backend.
- **dotnet build:** Compila o projeto backend.
- **dotnet migrate:** Executa as migrações do banco de dados.

### Frontend

- **npm run dev:** Inicia o servidor de desenvolvimento usando o Next.js.
- **npm run build:** Cria uma versão otimizada para produção.
- **npm run start:** Inicia a versão de produção da aplicação.
- **npm run lint:** Executa o ESLint para garantir a qualidade do código.

## Contribuindo
Contribuições são bem-vindas! Siga os passos abaixo para contribuir:

1. Faça o fork deste repositório.
2. Crie uma nova branch (git checkout -b feature/novos-recursos).
3. Faça suas modificações.
4. Envie suas alterações (git commit -am 'Adiciona novos recursos').
5. Envie a branch para o repositório remoto (git push origin feature/novos-recursos).
6. Crie um pull request.


