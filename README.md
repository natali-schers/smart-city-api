<div align="center">

# 🏙️ Smart City

**Web API para gerenciamento de produtos utilizados em obras e reformas, desenvolvida com ASP.NET Core.**

</div>

---

## 📌 Índice

- [Sobre o projeto](#-sobre-o-projeto)
- [Tecnologias](#-tecnologias)
- [Endpoints da API](#-endpoints-da-api)
- [Estrutura de pastas](#-estrutura-de-pastas)
- [Progresso](#-progresso)
- [Certificado de conclusão de curso](#-certificado-de-conclusão-de-curso)
- [Autor](#-autor)

---

## 📖 Sobre o projeto

O **Smart City** foi desenvolvido para colocar em prática os conhecimentos adquiridos no curso de Desenvolvimento .NET da FIAP. A aplicação é uma **Web API REST** que gerencia o cadastro de produtos utilizados em obras e reformas, permitindo o controle de itens e suas categorias (tipos de produto).

O foco do projeto é praticar boas práticas de back-end com .NET: organização em camadas, modelagem de dados, persistência com Entity Framework e desenho de endpoints RESTful.

---

## 🛠 Tecnologias

- [ASP.NET Core](https://dotnet.microsoft.com/apps/aspnet) — framework para construção da Web API
- [C#](https://learn.microsoft.com/dotnet/csharp/) — linguagem principal
- [SQL Server](https://www.microsoft.com/sql-server) — banco de dados relacional
- [Entity Framework Core](https://learn.microsoft.com/ef/core/) — ORM para persistência de dados

---

## 🔗 Endpoints da API

### Produtos

| Método | Rota | Descrição |
|---|---|---|
| `GET` | `/api/Products` | Lista todos os produtos |
| `GET` | `/api/Products/{id}` | Busca um produto pelo ID |
| `POST` | `/api/Products` | Cadastra um novo produto |
| `PUT` | `/api/Products/{id}` | Atualiza um produto existente |
| `DELETE` | `/api/Products/{id}` | Remove um produto |

### Tipos de Produto

| Método | Rota | Descrição |
|---|---|---|
| `GET` | `/api/ProductTypes` | Lista todos os tipos de produto |
| `GET` | `/api/ProductTypes/{id}` | Busca um tipo pelo ID |
| `POST` | `/api/ProductTypes` | Cadastra um novo tipo |
| `PUT` | `/api/ProductTypes/{id}` | Atualiza um tipo existente |
| `DELETE` | `/api/ProductTypes/{id}` | Remove um tipo |

---

## 📁 Estrutura de pastas

```
smart-city/
├── SmartCity/
│   ├── Controllers/     # Endpoints da API
│   ├── Models/          # Entidades do domínio
│   ├── DTOs/            # Objetos de transferência de dados
│   ├── DAL/             # Acesso ao banco de dados
│   │   Services/        # Responsável pelas regras de negócio
│   └── Program.cs       # Configuração e inicialização
└── README.md
```

---

## ✅ Progresso

- [x] Inicialização do projeto
- [x] Criação do banco de dados
- [x] Criação dos Models e DTOs para requisições da API
- [x] Implementação dos endpoints (GetAll, GetById, Create, Update, Delete) para gerenciar produtos e tipos de produto
- [x] Implementação do Entity Framework
- [x] Criação de interfaces para as services e repositories
- [ ] Adicionar try/catch e melhorar retornos de erro
- [ ] Criação de testes unitários
- [ ] Configuração do CI/CD
- [ ] Publicação da API

---

## 🏆 Certificado de conclusão de curso
- [Nano Course Desenvolvimento .NET](https://on.fiap.com.br/local/nanocourses/gerar_certificado.php?chave=154e96f166b5fb41a8e32c71a4c74c71&action=view)

---

## 👤 Autor

[![LinkedIn](https://img.shields.io/badge/LinkedIn-0077B5?style=flat&logo=linkedin&logoColor=white)](https://linkedin.com/in/natali-schers/)
[![GitHub](https://img.shields.io/badge/GitHub-100000?style=flat&logo=github&logoColor=white)](https://github.com/natali-schers/)
