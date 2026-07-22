# HomeExpenses

Sistema de controle de gastos residenciais desenvolvido para o desafio técnico. Possui uma API ASP.NET Core, interface React com TypeScript e persistência local em SQLite.

## Tecnologias

- ASP.NET Core Web API (.NET 8)
- Entity Framework Core + SQLite
- React + TypeScript + Vite

## Como executar

### API

1. Abra um terminal em `HomeExpenses.Api`.
2. Execute `dotnet restore` e depois `dotnet run`.
3. Acesse o Swagger exibido no terminal (normalmente `/swagger`). O arquivo `homeexpenses.db` é criado automaticamente e mantém os dados após fechar a aplicação.

### Frontend

1. Abra outro terminal em `home-expenses-web`.
2. Execute `npm install` e depois `npm run dev`.
3. Abra o endereço informado, normalmente `http://localhost:5173`.
4. Se a API usar outra porta, inicie o frontend com a variável `VITE_API_URL`, por exemplo: `VITE_API_URL=https://localhost:xxxx/api npm run dev`.

## Regras de negócio implementadas

- Pessoas possuem identificador automático, nome e idade; podem ser criadas, listadas e excluídas.
- A exclusão de uma pessoa remove suas transações por exclusão em cascata no banco de dados.
- Transações possuem identificador automático, descrição, valor, tipo e pessoa existente.
- Menores de 18 anos só podem registrar despesas.
- O resumo mostra receitas, despesas e saldo por pessoa e os totais gerais.

## Endpoints

| Método | Rota | Finalidade |
|---|---|---|
| GET / POST | `/api/people` | Listar e criar pessoas |
| DELETE | `/api/people/{id}` | Excluir pessoa e suas transações |
| GET / POST | `/api/transactions` | Listar e criar transações |
| GET | `/api/summary` | Obter totais por pessoa e gerais |

## Estrutura

`HomeExpenses.Api` concentra controllers, serviços, entidades, DTOs e contexto de dados. As regras de negócio ficam nos serviços, mantendo os controllers pequenos. `home-expenses-web` é a interface consumidora da API.
