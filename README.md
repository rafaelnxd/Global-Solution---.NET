
## Sumário
1. [Introdução](#introdução)
2. [Visão Geral](#visão-geral)
3. [Tecnologias Utilizadas](#tecnologias-utilizadas)
4. [Pré-requisitos](#pré-requisitos)
5. [Instalação](#instalação)
6. [Configuração do Banco de Dados](#configuração-do-banco-de-dados)
7. [Estrutura do Projeto](#estrutura-do-projeto)
8. [Executando a Aplicação](#executando-a-aplicação)
9. [Endpoints da API](#endpoints-da-api)
 - [Usuários](#usuários)
 - [Dispositivos](#dispositivos)
 - [Consumo de Energia](#consumo-de-energia)
 - [Configurações de Automação](#configurações-de-automação)
 - [Relatórios](#relatórios)
 - [Alertas e Notificações](#alertas-e-notificações)
10. [Data Transfer Objects (DTOs)](#data-transfer-objects-dtos)
11. [Tratamento de Erros](#tratamento-de-erros)
12. [Segurança](#segurança)
13. [Contribuição](#contribuição)
14. [Licença](#licença)
15. [Contato](#contato)

## Introdução

Bem-vindo ao **GlobalSolution**! Este projeto é uma **API RESTful** desenvolvida com **ASP.NET Core**, destinada a gerenciar dados relacionados a usuários, dispositivos, consumo de energia, automações, relatórios e alertas/notificações. A API está integrada a um banco de dados **Oracle** e utiliza práticas modernas de desenvolvimento para garantir eficiência e escalabilidade.

## Visão Geral

**GlobalSolution** permite realizar operações **CRUD** (Criar, Ler, Atualizar, Deletar) em diversas entidades, facilitando o gerenciamento de recursos em um sistema de monitoramento e automação de energia. A API está estruturada para ser facilmente extensível e mantida, utilizando **DTOs** para transferência de dados e padrões de repositório para abstração de acesso ao banco de dados.

## Tecnologias Utilizadas

- **ASP.NET Core 5.0**
- **C#**
- **Entity Framework Core**
- **Oracle Database**
- **Swagger (Swashbuckle)**
- **Visual Studio 2019/2022**
- **.NET 5 SDK**

## Pré-requisitos

Antes de iniciar a configuração do projeto, certifique-se de ter instalado:

- **.NET 5 SDK** ou superior
- **Visual Studio 2019/2022** ou **Visual Studio Code**
- **Oracle Database** (com cliente Oracle instalado, se necessário)
- **Git** (para controle de versão)

## Instalação

### 1. Clonar o Repositório


git clone https://github.com/seuusuario/GlobalSolution.git `

### 2\. Navegar para o Diretório do Projeto



`cd GlobalSolution`

### 3\. Restaurar Pacotes NuGet

Abra o projeto no Visual Studio, e os pacotes NuGet serão restaurados automaticamente. Alternativamente, use a linha de comando:



`dotnet restore`

Configuração do Banco de Dados
------------------------------

Atualize a string de conexão no arquivo `appsettings.json` para apontar para o seu banco de dados Oracle:



`"ConnectionStrings": {
  "DefaultConnection": "User Id=seu_usuario;Password=sua_senha;Data Source=seu_data_source"
}`

### Migrações do Entity Framework

Se estiver utilizando o **Entity Framework Core** com migrações, crie e aplique migrações:



`dotnet ef migrations add InitialCreate
dotnet ef database update`

**Nota:** Certifique-se de que o provedor do Entity Framework para Oracle seja compatível com a sua versão do banco de dados.

Estrutura do Projeto
--------------------

```
`Sorriso_em_Jogo/
├── Application/
│   ├── Services/
│   │   ├── FeedbackService.cs
│   │   ├── HabitoService.cs
│   │   ├── ...
│   └── ViewModels/
│       ├── FeedbackViewModel.cs
│       ├── HabitoViewModel.cs
│       ├── ...
├── Domain/
│   └── Entities/
│       └── Models/
│           ├── Feedback.cs
│           ├── Habito.cs
│           ├── Procedimento.cs
│           ├── ...
├── Infrastructure/
│   ├── Data/
│   │   └── ApplicationDbContext.cs
│   └── Repositories/
│       ├── IFeedbackRepository.cs
│       ├── IHabitoRepository.cs
│       ├── FeedbackRepository.cs
│       ├── HabitoRepository.cs
│       ├── ...
├── Presentation/
│   ├── Controllers/
│   │   ├── HomeController.cs
│   │   ├── FeedbacksController.cs
│   │   ├── HabitosController.cs
│   │   ├── ...
│   ├── Views/
│   │   ├── Home/
│   │   │   └── Index.cshtml
│   │   ├── Feedbacks/
│   │   │   ├── Index.cshtml
│   │   │   ├── Create.cshtml
│   │   │   ├── Edit.cshtml
│   │   │   ├── Delete.cshtml
│   │   │   └── Details.cshtml
│   │   ├── Habitos/
│   │   │   ├── Index.cshtml
│   │   │   ├── Create.cshtml
│   │   │   ├── Edit.cshtml
│   │   │   ├── Delete.cshtml
│   │   │   └── Details.cshtml
│   │   └── Shared/
│   │       ├── _Layout.cshtml
│   │       └── _ValidationScriptsPartial.cshtml
│   └── Properties/
├── wwwroot/
│   ├── css/
│   ├── js/
│   ├── images/
│   └── ...
├── Program.cs
├── Sorriso_em_Jogo.csproj
├── appsettings.Development.json
├── appsettings.json
├── README.md`
```

Executando a Aplicação
----------------------

### Usando o Visual Studio

1.  Abra a solução `GlobalSolution.sln` no Visual Studio.
2.  Defina o projeto de inicialização, se necessário.
3.  Pressione `F5` ou clique em **Run** para iniciar a aplicação.

### Usando a .NET CLI

bash

Copiar código

`dotnet run`

A aplicação será iniciada, e a interface do **Swagger** estará disponível em `https://localhost:{porta}/swagger`.

Endpoints da API
----------------

A API fornece endpoints para gerenciar todas as entidades. A seguir, uma visão geral dos principais endpoints.

### Usuários

-   **GET** `/api/Usuarios`: Recupera todos os usuários.
-   **GET** `/api/Usuarios/{id}`: Recupera um usuário por ID.
-   **POST** `/api/Usuarios`: Cria um novo usuário.
-   **PUT** `/api/Usuarios/{id}`: Atualiza um usuário existente.
-   **DELETE** `/api/Usuarios/{id}`: Deleta um usuário.

### Dispositivos

-   **GET** `/api/Dispositivos`: Recupera todos os dispositivos.
-   **GET** `/api/Dispositivos/{id}`: Recupera um dispositivo por ID.
-   **POST** `/api/Dispositivos`: Cria um novo dispositivo.
-   **PUT** `/api/Dispositivos/{id}`: Atualiza um dispositivo existente.
-   **DELETE** `/api/Dispositivos/{id}`: Deleta um dispositivo.

### Consumo de Energia

-   **GET** `/api/ConsumoEnergia`: Recupera todos os registros de consumo de energia.
-   **GET** `/api/ConsumoEnergia/{id}`: Recupera um registro de consumo por ID.
-   **POST** `/api/ConsumoEnergia`: Cria um novo registro de consumo.
-   **PUT** `/api/ConsumoEnergia/{id}`: Atualiza um registro de consumo existente.
-   **DELETE** `/api/ConsumoEnergia/{id}`: Deleta um registro de consumo.

### Configurações de Automação

-   **GET** `/api/ConfiguracoesAutomacao`: Recupera todas as configurações de automação.
-   **GET** `/api/ConfiguracoesAutomacao/{id}`: Recupera uma configuração por ID.
-   **POST** `/api/ConfiguracoesAutomacao`: Cria uma nova configuração de automação.
-   **PUT** `/api/ConfiguracoesAutomacao/{id}`: Atualiza uma configuração existente.
-   **DELETE** `/api/ConfiguracoesAutomacao/{id}`: Deleta uma configuração.

### Relatórios

-   **GET** `/api/Relatorios`: Recupera todos os relatórios.
-   **GET** `/api/Relatorios/{id}`: Recupera um relatório por ID.
-   **POST** `/api/Relatorios`: Cria um novo relatório.
-   **PUT** `/api/Relatorios/{id}`: Atualiza um relatório existente.
-   **DELETE** `/api/Relatorios/{id}`: Deleta um relatório.

### Alertas e Notificações

-   **GET** `/api/AlertasNotificacoes`: Recupera todos os alertas e notificações.
-   **GET** `/api/AlertasNotificacoes/{id}`: Recupera um alerta por ID.
-   **POST** `/api/AlertasNotificacoes`: Cria um novo alerta/notification.
-   **PUT** `/api/AlertasNotificacoes/{id}`: Atualiza um alerta existente.
-   **DELETE** `/api/AlertasNotificacoes/{id}`: Deleta um alerta.
