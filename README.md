# API RESTful de Gerenciamento de Produtos

Esta é uma API RESTful simples para gerenciamento de produtos, desenvolvida utilizando a nova abordagem Minimal API do .NET Core. A API permite realizar operações básicas de CRUD (Create, Read, Update, Delete) para produtos, armazenando os dados em um banco de dados SQLite por meio do Entity Framework Core. Além disso, a API é documentada utilizando o Swagger para facilitar o entendimento e teste das funcionalidades.

## Funcionalidades Principais

- Cadastrar um novo produto
- Consultar a lista de produtos
- Consultar um produto específico por ID
- Atualizar as informações de um produto existente
- Excluir um produto
## Como Rodar o Projeto

1. Certifique-se de que o SDK do .NET Core 6.0 ou superior esteja instalado.
2. Clone este repositório para o seu ambiente local.
3. Navegue até o diretório do projeto no terminal.
4. Execute o seguinte comando para instalar os pacotes NuGet necessários: dotnet restore
5. Execute o seguinte comando para criar as migrações iniciais do banco de dados: dotnet ef migrations add InitialCreate
6. Em seguida, execute o seguinte comando para aplicar as migrações e criar o banco de dados: dotnet ef database update
7. Agora você pode executar o projeto com o seguinte comando: dotnet run
8. Acesse `https://localhost:5001/swagger` em seu navegador para acessar a documentação da API usando o Swagger.

**Observação**: Antes de executar os comandos acima, certifique-se de que você tenha instalado os seguintes pacotes NuGet:
- Microsoft.EntityFrameworkCore.Sqlite
- Microsoft.EntityFrameworkCore.Design
- Microsoft.EntityFrameworkCore.Tools

Lembre-se de que esta descrição é um exemplo e pode ser personalizada conforme necessário para se adequar ao seu projeto específico.
