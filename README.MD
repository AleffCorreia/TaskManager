# 📋 TaskManager

Um sistema de gerenciamento de tarefas desenvolvido em **C#** utilizando **.NET 10**, seguindo princípios de arquitetura em camadas, Programação Orientada a Objetos e Entity Framework Core.

O objetivo deste projeto foi praticar conceitos fundamentais do ecossistema .NET, desde a modelagem de domínio até a persistência de dados utilizando SQLite.

---

# 🚀 Tecnologias

- C#
- .NET 10
- Entity Framework Core
- SQLite
- ConsoleTables
- Dependency Injection
- LINQ

---

# 📚 Conceitos aplicados

- Programação Orientada a Objetos (POO)
- SOLID
- Repository Pattern
- Service Layer
- Dependency Injection
- Generic Repository
- Fluent API
- Migrations
- Entity Framework Core
- Relacionamentos 1:N
- Navegação entre entidades
- Tratamento de exceções
- Separação de responsabilidades

---

# 📂 Estrutura do projeto

```
TaskManager
│
├── Data
│   ├── AppDbContext
│   ├── Configurations
│   └── Migrations
│
├── Models
│   ├── User
│   ├── TaskItem
│   └── BaseEntity
│
├── Repositories
│   ├── Repository<T>
│   ├── UserRepository
│   └── TaskItemRepository
│
├── Services
│   ├── IUserService
│   ├── ITaskItemService
│   ├── UserService
│   └── TaskItemService
│
├── Menus
│
├── Interfaces
│
├── Enums
│
└── Program.cs
```

---

# ⚙️ Funcionalidades

## Usuários

- ✅ Criar usuário
- ✅ Atualizar usuário
- ✅ Remover usuário
- ✅ Listar usuários
- ✅ Buscar usuário por Id

---

## Tarefas

- ✅ Criar tarefa
- ✅ Atualizar tarefa
- ✅ Excluir tarefa
- ✅ Listar tarefas
- ✅ Buscar por Id
- ✅ Buscar por usuário
- ✅ Alterar prioridade
- ✅ Alterar status
- ✅ Iniciar tarefa
- ✅ Concluir tarefa
- ✅ Cancelar tarefa
- ✅ Atribuir tarefa a um usuário

---

## Dashboard

O sistema possui um Dashboard contendo:

- Total de usuários
- Total de tarefas
- Pendentes
- Em andamento
- Concluídas
- Canceladas

---

# 🗄️ Banco de dados

Foi utilizado o **SQLite** juntamente com o **Entity Framework Core**.

As tabelas são criadas através de Migrations.

```
Users

Id
Name
Email
CreatedAt
```

```
TaskItems

Id
Title
Description
Priority
Status
CreatedAt
CompletedAt
UserId
```

Relacionamento:

```
User (1)
    │
    ├──────────────
                   │
              TaskItem (N)
```

---

# ▶️ Executando o projeto

Clone o repositório

```bash
git clone https://github.com/AleffCorreia/TaskManager.git
```

Acesse a pasta

```bash
cd TaskManager
```

Restaure os pacotes

```bash
dotnet restore
```

Execute as migrations

```bash
dotnet ef database update
```

Execute o projeto

```bash
dotnet run
```

---

# 💻 Arquitetura

```
Console
      │
      ▼
 Services
      │
      ▼
Repositories
      │
      ▼
Entity Framework Core
      │
      ▼
SQLite
```

---

# 🎯 Objetivos do projeto

Este projeto foi desenvolvido com foco em aprendizado das principais tecnologias utilizadas no desenvolvimento de aplicações .NET.

Durante sua construção foram praticados conceitos como:

- Modelagem de domínio
- Orientação a Objetos
- Entity Framework Core
- Dependency Injection
- Repository Pattern
- Arquitetura em Camadas
- Persistência de dados
- Relacionamentos entre entidades

---

# 📖 Aprendizados

Durante o desenvolvimento deste projeto foram enfrentados diversos desafios técnicos, entre eles:

- Implementação de Generic Repository.
- Uso de herança e polimorfismo (`virtual` e `override`).
- Injeção de Dependência em aplicações Console.
- Configuração do Entity Framework Core.
- Criação e manutenção de Migrations.
- Mapeamento de relacionamentos utilizando Fluent API.
- Carregamento de entidades relacionadas com `Include()`.
- Tratamento de exceções.
- Organização da aplicação em camadas.

# 🔜 Próximos passos

- [ ] API REST com ASP.NET Core
- [ ] Swagger
- [ ] DTOs
- [ ] AutoMapper
- [ ] Validação com FluentValidation
- [ ] JWT Authentication
- [ ] SQL Server
- [ ] Docker
- [ ] Testes Unitários
- [ ] Testes de Integração

---


# 👨‍💻 Autor

Desenvolvido por **Aleff Correia** como projeto de estudos para evolução na plataforma .NET.
