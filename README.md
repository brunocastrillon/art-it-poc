
# CRUD MVC com ASP.NET Core 6

Aplicação de exemplo para cadastro de **Clientes**, **Telefones** e **Tipos de Telefone**, utilizando ASP.NET Core 6 com MVC, API REST, banco SQLite e front-end Razor Pages com interações AJAX.

---

## 🧩 Estrutura do Projeto

A solução `CRUD.sln` compreende seis projetos organizados por camada:

```
Core/
├─ CRUD.Core.Application    → Lógica de negócios + DTOs + serviços e AutoMapper
└─ CRUD.Core.Domain         → Entidades e interfaces do domínio baseadas em DDD

Infra/
├─ CRUD.Infra.Data         → Implementação com EF Core, contexto, repositórios
└─ CRUD.Infra.IoC          → Configuração de injeção de dependências

Interfaces/
├─ CRUD.Interfaces.API     → Controllers REST via API, entrada de dados JSON
└─ CRUD.Interfaces.WebApp  → Front-end MVC + Razor com chamadas AJAX
```

---

## ✨ Principais Tecnologias e Padrões

- **.NET 6 / C# 10 / ASP.NET Core MVC & Web API**
- **Entity Framework Core** com **SQLite** — fácil migração e portabilidade
- **Clean Architecture** e separação de responsabilidades
- **SOLID**:  
  - _Single Responsibility_ via projetos e serviços  
  - _Dependency Inversion_ com injeção via IoC  
  - _Interface Segregation_ nos repositórios e serviços por entidade
- **Clean Code**:  
  - _DTOs_ para decoupling entre camadas  
  - _AutoMapper_ para manter mapeamentos simples e consistentes  
  - _Repository Pattern_ para abstração do acesso a dados
- **Front-end MVC** com Razor & jQuery:  
  - Formulários com validação, modais para CRUD de telefone, máscaras de input e feedback visual
  - Uso de AJAX para comunicação REST sem recarregar a página

---

## 📥 Como rodar o projeto localmente

### Pré-requisitos
- [.NET 6 SDK](https://dotnet.microsoft.com/)
- Visual Studio 2022 (ou equivalente)
- Terminal (CLI .NET) ou VS 2022

### Passos

Clone o repositório:

```bash
git clone https://github.com/brunocastrillon/art-it-poc.git
cd art-it-poc
```

No diretório raiz da solução:

1. Aplique migrations & crie o banco:
```bash
dotnet ef database update --project ./CRUD.Infra.Data --startup-project ./CRUD.Interfaces.API
```

2. Execute a API:
```bash
dotnet run --project ./CRUD.Interfaces.API
```

3. Execute o WebApp:
```bash
dotnet run --project ./CRUD.Interfaces.WebApp
```

4. Acesse no navegador:
```
API:     https://localhost:7294/swagger
WebApp:  https://localhost:7035/Cliente
```

---

## 🛠️ Funcionalidades

- CRUD completo para **Clientes** (inclui múltiplos Telefones)
- CRUD para **Telefone** via API
- CRUD para **Tipos de Telefone** via modal no front
- Máscaras de entrada (CEP, UF, Telefone)
- Tratamento AJAX com validade visual e mensagens
- Mapeamentos entre DTOs e entidades, integridade referencial (EF Core)

---

## ✅ Boas Práticas e Padrões

- **Abstração e modulação**: separação clara entre camada de domínio, dados e apresentação
- **Injeção de dependência** usando `CRUD.Infra.IoC`
- **Mapeamento único através do AutoMapper**, reduz duplicação e erros
- **Repositório genérico + específicos** asseguram consistência e organização no acesso a dados
- **Clean Architecture**: a camada `Core` independe de infra e UI; facilita testes e evolução

---

## 🧩 Próximos Passos

- Implementar **autenticação/autorização** (Identity, JWT)
- Adicionar **paginação, filtros e busca** via API e MVC
- Melhorar interface com feedback visual (toasts, loaders)
- Testes unitários e integração (xUnit, Moq, EF InMemory)
- Hospedar no **Azure App Service** ou **Heroku**

---

## 📫 Contato & Portfolio

Desenvolvido por **Bruno Castrillon**
- Medium: https://medium.com/@brunocastrillon  
- Linkedin: https://www.linkedin.com/in/brunocastrillon/  
