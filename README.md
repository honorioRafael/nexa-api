# Nexa

A **Nexa** é uma plataforma interna desenvolvida para auxiliar empresas que realizam operações em múltiplas cidades ou países no gerenciamento logístico de seus funcionários e recursos.

O sistema permite que a empresa controle de forma centralizada informações relacionadas à **frota de veículos**, **movimentação de funcionários** e **alojamento das equipes**, garantindo maior organização, rastreabilidade e eficiência operacional.

## Contexto de uso

Imagine uma empresa sediada na Bélgica que executa projetos em diferentes cidades e também em países próximos. Para realizar essas operações, é necessário deslocar funcionários, disponibilizar veículos da frota e organizar locais de hospedagem para as equipes.

A Nexa atua como uma plataforma interna para gerenciar esse cenário, permitindo:

* Registrar quais funcionários estão alocados em cada região
* Controlar quais veículos da frota estão sendo utilizados e por quem
* Gerenciar reservas e ocupação de alojamentos
* Acompanhar a movimentação de equipes entre diferentes locais de operação

Com essas informações centralizadas em um único sistema, a empresa consegue melhorar o planejamento logístico, reduzir conflitos de uso de recursos e manter um histórico confiável das operações realizadas.

A plataforma foi projetada para ser utilizada internamente pela organização, oferecendo uma interface simples e funcionalidades voltadas para o gerenciamento operacional do dia a dia.

---

## Pré-requisitos

* [.NET 10 SDK](https://dotnet.microsoft.com/download)
* [PostgreSQL](https://www.postgresql.org/download/) (versão 18.x)
* [Entity Framework Core CLI](https://learn.microsoft.com/en-us/ef/core/cli/dotnet)

Para instalar a CLI do EF Core globalmente, caso ainda não tenha:
```bash
dotnet tool install --global dotnet-ef
```

---

## Configuração do ambiente

### String de conexão

Antes de iniciar a API, verifique e ajuste a string de conexão com o banco de dados no arquivo `appsettings.Development.json`, localizado na raiz do projeto da API:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Port=5432;Database=nexa_db;Username=seu_usuario;Password=sua_senha"
  }
}
```

Substitua `seu_usuario` e `sua_senha` pelas credenciais do seu PostgreSQL local. Certifique-se também de que o banco de dados informado em `Database` já existe, ou que o usuário tem permissão para criá-lo.

---

## Executando as migrations

Com o banco de dados configurado e acessível, aplique as migrations para criar o schema:
```bash
dotnet ef database update --project src/Nexa.Infrastructure --startup-project src/Nexa.Api
```

Para criar uma nova migration após alterações no domínio:
```bash
dotnet ef migrations add NomeDaMigration --project src/Nexa.Infrastructure --startup-project src/Nexa.Api
```

Para reverter a última migration aplicada:
```bash
dotnet ef database update NomeDaMigrationAnterior --project src/Nexa.Infrastructure --startup-project src/Nexa.Api
```

---

## Inicializando a API

No diretório do projeto da API (`src/Nexa.Api` ou equivalente), execute:
```bash
dotnet run
```

Por padrão, a API sobe no ambiente de desenvolvimento utilizando as configurações do `appsettings.Development.json`. Você pode acessar o Swagger UI em:
```
http://localhost:5000/swagger
```
