# API Restful de E-commerce

Esta é uma API Restful desenvolvida em .NET Core e MySQL, projetada para fornecer dados relacionados a produtos em um e-commerce.

## Configuração

Certifique-se de ter o [.NET Core SDK](https://dotnet.microsoft.com/download) instalado em sua máquina.

1. Clone este repositório:

   ```
   git clone https://github.com/tallesvini/Api_Products_Ecommerce.git
   ```

2. Acesse o diretório do projeto:

   ```
   cd nome-do-repositorio
   ```

3. Abra o arquivo `program.cs` e configure as informações de conexão com o banco de dados MySQL:

   ```c#
    builder.Services.AddDbContext<ProductDBContext>
      (options => options.UseMySql(
          "Server=_servidor_;initial catalog=_nameDB_;Uid=_id_",
          Microsoft.EntityFrameworkCore.ServerVersion.Parse("_mysql_version_")));
   ```

4. Execute as migrações para criar as tabelas no banco de dados:

   ```
   dotnet ef database update
   ```

5. Inicie o servidor:

   ```
   dotnet run
   ```

A API estará disponível em `http://localhost:5000`.

## Requisitos de Sistema

- .NET Core SDK 3.1 ou superior.

## Endpoints

### AboutProduct

### GET /api/AboutProduct/GetAllAboutProducts

Retorna todos os produtos disponíveis no e-commerce.

Exemplo de resposta:

```json
[
  {
    "id": 1,
    "productId": 1,
    "addProduct": "2023-06-04T23:27:14.767Z",
    "availableOnFactory": true,
    "product": {
      "id": 1,
      "name": "string",
      "description": "string",
      "size": "string",
      "color": "string",
      "gender": 0,
      "price": 0,
      "category": 0,
      "status": 0,
      "amount": 0
    }
  },
      {
      "id": 2,
      "productId": 2,
      "addProduct": "2023-06-04T23:27:14.767Z",
      "availableOnFactory": true,
      "product": {
        "id": 2,
        "name": "string",
        "description": "string",
        "size": "string",
        "color": "string",
        "gender": 0,
        "price": 0,
        "category": 0,
        "status": 0,
        "amount": 0
      }
    }
]
```

### GET /api/AboutProduct/GetAboutProductById/{id}

Retorna um produto específico com base no ID fornecido.

Exemplo de resposta:

```json
{
    "id": 1,
    "productId": 1,
    "addProduct": "2023-06-04T23:27:14.767Z",
    "availableOnFactory": true,
    "product": {
      "id": 1,
      "name": "string",
      "description": "string",
      "size": "string",
      "color": "string",
      "gender": 0,
      "price": 0,
      "category": 0,
      "status": 0,
      "amount": 0
    }
}
```

### Product

### GET /api/Product/GetAllProducts

Retorna todos os produtos.

Exemplo de requisição:

```json
[
  {
    "id": 1,
    "name": "string",
    "description": "string",
    "size": "string",
    "color": "string",
    "gender": 0,
    "price": 0,
    "category": 0,
    "status": 0,
    "amount": 0
  }
]
```

### GET /api/Product/GetProductById/{id}

Retorna determinado produto através do ID fornecido.

Exemplo de requisição:

```json
{
  "id": 1,
  "name": "string",
  "description": "string",
  "size": "string",
  "color": "string",
  "gender": 0,
  "price": 0,
  "category": 0,
  "status": 0,
  "amount": 0
}
```

### POST /api/Product/AddProduct

Realiza a inclusão de um novo produto.

Exemplo de requisição:

```json
{
  "id": 1,
  "name": "string",
  "description": "string",
  "size": "string",
  "color": "string",
  "gender": 0,
  "price": 0,
  "category": 0,
  "status": 0,
  "amount": 0
}
```

### PUT /api/Product/UpdateProduct/{id}

Realiza a edição de um produto atravéz do ID fornecido.

Exemplo de requisição:

```json
{
  "id": 1,
  "name": "string",
  "description": "string",
  "size": "string",
  "color": "string",
  "gender": 0,
  "price": 0,
  "category": 0,
  "status": 0,
  "amount": 0
}
```

### DELETE /api/Product/DeleteProduct/{id}

Remove um produto específico com base no ID fornecido.


## Como Contribuir

Se você deseja contribuir para este projeto, siga as etapas abaixo:

1. Faça um fork deste repositório e clone-o em sua máquina local.
2. Crie um novo branch para suas alterações: `git checkout -b minha-branch`.
3. Realize as alterações desejadas e commit-as: `git commit -m 'Minhas alterações'`.
4. Envie suas alterações para o branch principal do repositório forkado: `git push origin minha-branch`.
5. Abra um pull request no repositório original, descrevendo as alterações propostas.

## Licença

Este projeto está licenciado sob a **MIT License**.
