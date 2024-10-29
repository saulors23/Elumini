# CDB Calculator

Este projeto é uma aplicação Angular e .NET para cálculo de CDB, que permite calcular o valor bruto e líquido de um investimento com base nos dados fornecidos pelo usuário.

## Estrutura do Projeto

- **Frontend**: Angular (Elumini/src/`)
- **Backend**: .NET Core API (Elumini/CDBCalculator/)

## Pré-requisitos

Para executar o projeto, você precisará ter instalados:

- **Node.js** (versão 14 ou superior)
- **Angular CLI** (caso não tenha, instale com `npm install -g @angular/cli`)
- **.NET Core SDK** (versão 6 ou superior)
- **Git** (para versionamento e clonagem do projeto)

## Instruções de Execução

### 1. Clonando o Repositório

Clone o repositório para sua máquina local:

git clone https://github.com/saulors23/Elumini.git
cd Elumini

2. Executando o Backend
No diretório CDBCalculator.WebApp, abra o terminal e execute:

cd CDBCalculator.WebApp
dotnet restore
dotnet build
dotnet run

A API estará acessível em https://localhost:7151/api/investment/calcular

3. Executando o Frontend
Em outro terminal, navegue até o diretório cdb-calculator e execute:

cd cdb-calculator
npm install
ng serve

O frontend estará disponível em http://localhost:4200.

Testando a Solução
Testes de API (Backend)
Para testar a API:

Use uma ferramenta como o Postman para fazer requisições.

Faça um POST para https://localhost:7151/api/investment/calcular com o JSON de exemplo:

{
  "valorInicial": 1000,
  "prazoMeses": 12
}
A resposta deverá conter o valorBruto e valorLiquido do cálculo de CDB.

Testes de Interface (Frontend)

Abra o navegador e acesse http://localhost:4200.
Preencha os campos de valor inicial e prazo e clique em Calcular.
Verifique se os resultados bruto e líquido são exibidos corretamente.
Estrutura de Código e Principais Arquivos
app.module.ts: Configurações e imports do Angular.
cdb-calculator-form.component.ts: Componente principal do formulário de cálculo.
investment.controller.cs: Controlador da API responsável pelo cálculo do CDB.

Para contribuir, siga os passos:

Faça um fork do projeto.
Crie uma branch com a feature: git checkout -b minha-feature.
Commit suas mudanças: git commit -m 'Minha nova feature'.
Push na branch: git push origin minha-feature.
Abra um Pull Request.
Observação: Certifique-se de que o backend está rodando com HTTPS, pois o frontend depende dessa configuração para as requisições API.

Este `README.md` cobre a maioria dos aspectos necessários para ajudar outros desenvolvedores a executar e testar o projeto.
Em caso de dúvida estou aceitando sugestões para melhoras, qualquer dúvida entrar em contato via email saulors@gmail.com ou pelo WhatsApp 81999080095, entrarei em contato o mais breve possível para solucionar qualquer impedimento.
