# Desafio-Uber (.NET)

API ASP.NET Core simples para consultar locações de filmes. Os dados são obtidos de um serviço público em JSON e armazenados em cache de memória para melhorar a performance.

## Estrutura do projeto

- `Program.cs` - configuração do host, DI, clientes HTTP e roteamento.
- `Desafio-Uber.csproj` - arquivo de projeto (.NET SDK Web).
- `API/Controller/MovieLocationController.cs` - controlador REST que expõe endpoints.
- `API/Model/MovieLocationRequest.cs` - DTO usado para deserializar o JSON externo.
- `Application/Service/MovieLocationService.cs` - lógica para chamar o endpoint externo, cache e filtros.
- `Domain/MovieLocation.cs` - model de domínio com validações (não utilizado diretamente).

## Requisitos

- .NET SDK 7.0+ (recomendável 8.0 ou 9.0).
- Conexão com internet para acessar o endpoint externo.

> O projeto atualmente mira `net7.0`; atualize o `<TargetFramework>` no `.csproj` se necessário.

## Como executar

1. Abra um terminal na pasta do projeto.
2. Restaure dependências:
   ```bash
   dotnet restore
   ```
3. Compile:
   ```bash
   dotnet build
   ```
4. Rode a aplicação:
   ```bash
   dotnet run
   ```
5. Observe a URL do Kestrel (algo como `https://localhost:5001`).


## Endpoints disponíveis

| Método | Rota                                | Descrição                                    |
|--------|-------------------------------------|----------------------------------------------|
| GET    | `/api/MovieLocation`                | Retorna todas as locações de filmes.         |
| GET    | `/api/MovieLocation/byname`         | Filtra por nome (query `movieName`).         |
| GET    | `/api/MovieLocation/byyear`         | Filtra por ano (query `year`).               |

> Exemplos:
> ```bash
> curl https://localhost:5001/api/MovieLocation
> curl "https://localhost:5001/api/MovieLocation/byname?movieName=Inception"
> curl "https://localhost:5001/api/MovieLocation/byyear?year=2010"
> ```

## Cache

Os resultados da primeira requisição são armazenados em memória (`IMemoryCache`) por 5 minutos. Evita chamadas repetidas ao serviço externo.

## Observações

- O DTO `MovieLocationRequest` usa propriedades anuláveis para acomodar dados possivelmente ausentes no JSON.
- Caso o framework `net7.0` esteja obsoleto, basta atualizar `Desafio-Uber.csproj`.
- O projeto não implementa persistência própria; todos os dados vêm do serviço externo.

## Licença

Este código serve como exemplo/ajuda para o desafio. Sem licença específica.
