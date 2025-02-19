# Food Composition Frontend

Este é um projeto front-end desenvolvido com **Next.js** e **TailwindCSS**, que exibe informações sobre a composição dos alimentos. Ele se conecta ao backend para buscar os dados de composição e exibi-los de maneira interativa.

## Tecnologias Usadas

- **Next.js** (v15.1.6) - Framework React para aplicações web.
- **React** (v19.0.0) - Biblioteca para construção de interfaces de usuário.
- **TailwindCSS** (v3.4.17) - Framework de CSS utilitário para estilização rápida.
- **TypeScript** (v5.7.3) - Superset do JavaScript para maior segurança e produtividade no desenvolvimento.
- **PostCSS** - Ferramenta para processar CSS.
- **ESLint** - Ferramenta para linting de código, garantindo consistência e qualidade.

## Pré-Requisitos

Antes de começar, certifique-se de que o backend esteja rodando. O backend é responsável por fornecer os dados de composição dos alimentos e precisa estar disponível para que o front-end funcione corretamente.

### Backend

O backend é uma aplicação de **web scraping** que coleta dados sobre a composição de alimentos e armazena essas informações para análise posterior. Ele foi desenvolvido utilizando **C#** com a biblioteca `HtmlAgilityPack`. Para mais detalhes sobre a instalação e execução do backend, consulte o [README do backend](https://github.com/heidegomes/Food-Composition-Project/blob/main/Backend/FoodCompositionScraper/README.md).

## Instalação (Frontend)

1. Clone o repositório para sua máquina local:
   ```bash
   git clone https://github.com/seu-usuario/food-composition-frontend.git

2. Navegue até o diretório do projeto:
   ```bash
   cd food-composition-frontend 

4. Instale as dependências do projeto:
   ```bash
   npm install

5. Execute o servidor de desenvolvimento:
   ```bash
   npm run dev

  A aplicação estará disponível em http://localhost:3000.

## Scripts

- **npm run dev**: Inicia o servidor de desenvolvimento usando o Next.js com o TurboPack.
- **npm run build**: Cria uma versão otimizada para produção.
- **npm run start**: Inicia a versão de produção da aplicação.
- **npm run lint**: Executa o ESLint para garantir a qualidade do código.

## Estrutura do Projeto

A estrutura de pastas do projeto é organizada da seguinte forma:

      /food-composition-frontend
      ├── /src                  # Contém os arquivos principais do projeto
      │   ├── /app              # Contém as páginas e componentes principais da aplicação
      │   │   ├── /_components  # Componentes reutilizáveis
      │   │   │   ├── FoodCard.tsx  # Componente que exibe informações de um alimento
      │   │   │   ├── Footer.tsx    # Componente do rodapé
      │   │   │   └── Header.tsx    # Componente do cabeçalho
      │   │   ├── /aboutUs        # Página "Sobre Nós"
      │   │   │   └── page.tsx    # Arquivo que contém o conteúdo da página sobre nós
      │   │   ├── /api            # Endpoints de API
      │   │   │   └── /food       # Rota específica para alimentação
      │   │   │       └── route.ts    # Lógica da API relacionada à comida
      │   │   ├── /contact        # Página de Contato
      │   │   │   └── page.tsx    # Arquivo que contém o conteúdo da página de contato
      │   │   ├── /food           # Páginas relacionadas a alimentos
      │   │   │   └── /[code]     # Página específica de um alimento com código
      │   │   │       └── page.tsx  # Arquivo da página detalhada do alimento
      │   │   ├── favicon.ico     # Ícone do site
      │   │   ├── globals.css     # Arquivo de estilos globais
      │   │   ├── layout.tsx      # Layout principal da aplicação
      │   │   ├── page.tsx        # Página inicial (home)
      │   │   └── types.ts        # Tipos TypeScript para a aplicação
      ├── package.json           # Arquivo de dependências e scripts do projeto
      └── tailwind.config.js     # Arquivo de configuração do TailwindCSS



## Personalização

### Estilização

O projeto usa TailwindCSS para estilização. Você pode personalizar as configurações no arquivo `tailwind.config.js` para ajustar as cores, fontes e outros aspectos visuais.

### Fontes

O projeto utiliza fontes personalizadas definidas no layout global para garantir consistência visual e tipográfica.

## Contribuindo

Contribuições são bem-vindas! Sinta-se à vontade para fazer um fork do repositório, criar uma branch e enviar um pull request com suas melhorias.

1. Faça o fork deste repositório.
2. Crie uma nova branch (`git checkout -b feature/novos-recursos`).
3. Faça suas modificações.
4. Envie suas alterações (`git commit -am 'Adiciona novos recursos'`).
5. Envie a branch para o repositório remoto (`git push origin feature/novos-recursos`).
6. Crie um pull request.
