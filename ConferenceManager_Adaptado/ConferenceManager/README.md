
# Conference Manager

Projeto desenvolvido para o teste técnico de Desenvolvedor .NET Pleno.

## Tecnologias

- .NET 8
- Clean Architecture
- xUnit
- FluentAssertions

## Estrutura

- ConferenceManager.API
- ConferenceManager.Application
- ConferenceManager.Domain
- ConferenceManager.Tests

## Como executar

```bash
dotnet restore
dotnet build
dotnet build
```

## Endpoint

POST /conference/schedule

## Exemplo de entrada

```json
[
  "Writing Fast Tests Against Enterprise .Net 60min",
  "Python for .Net Developers lightning"
]
```

## Objetivo

Organizar automaticamente palestras em trilhas respeitando:

- sessão da manhã;
- sessão da tarde;
- almoço;
- networking event.
