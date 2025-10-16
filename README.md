# Imobiliária API

## 📌 Visão Geral

A **Imobiliária API** é uma aplicação backend construída em **C# .NET 8**, utilizando **Clean Architecture**, com o objetivo de gerenciar o cadastro de imóveis.  
O projeto implementa um **CRUD completo de imóveis**, permitindo criar, consultar, atualizar e deletar registros, com foco em **boa organização de código**, **manutenibilidade** e **testabilidade**.

O banco de dados utilizado é o **MySQL**, garantindo persistência de dados confiável e escalável.

---

## 🏗 Estrutura do Projeto

O projeto segue a arquitetura **Clean Architecture**, separando responsabilidades em camadas:

| Camada | Função |
|--------|--------|
| **Domain** | Contém entidades, enums e interfaces que representam o núcleo da aplicação. Não depende de nenhuma outra camada. |
| **Application** | Contém serviços de aplicação e regras de negócio. Depende apenas de `Domain`. |
| **Infrastructure** | Implementa persistência de dados (MySQL) e integração com serviços externos. Depende de `Application` e `Domain`. |
| **API** | Exposição da aplicação via endpoints HTTP, configura DI, middleware e pipeline. Depende de todas as camadas inferiores. |

---

## ⚙ Tecnologias Utilizadas

- **.NET 8**  
- **C#**  
- **Entity Framework Core**  
- **MySQL**  
- **Clean Architecture**  
- **HttpClient** para integração com API do ViaCEP  
- **Result pattern** para tratamento de erros consistente

---

## 🚀 Funcionalidades

1. **CRUD de Imóveis**
   - Criar um imóvel com endereço, valor de aluguel e status
   - Consultar imóveis por ID ou listar todos
   - Atualizar informações de um imóvel
   - Remover imóvel do sistema

2. **Validação de CEP**
   - Consulta automática de endereço via API externa do **ViaCEP** durante o cadastro de imóveis

3. **Tratamento de erros**
   - Uso de `Result` para retorno consistente de sucesso e falhas

---

## 📈 Boas Práticas Implementadas
- Clean Architecture: separação clara de responsabilidades e dependências unidirecionais
- Injeção de Dependência em todos os serviços e repositórios
- Async/Await para operações de banco e chamadas externas
- Tratamento de erros centralizado via Result pattern
- Validação de entrada usando Data Annotations
- DTOs para transporte de dados entre camadas

---

## 💾 Banco de Dados

- **MySQL** é utilizado para persistir os dados.
- Estrutura do `DbContext` com mapeamento explícito das entidades.
- Uso de **migrations do EF Core** para versionamento do banco de dados.

---

### Pré-requisitos
- .NET 8 SDK
- MySQL Server
- Visual Studio 2022 ou VS Code
