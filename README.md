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

   ```json
      "ConnectionStrings": {
          "DefaultConnection": "Server=localhost;initial catalog=ProductsApi;Uid=root"
      },
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

## Como Acessar os Endpoints

1. Realize seu registro no endpoint:
   
#### POST /api/auth/user/register

``` json
{
  "userName": "string",
  "email": "string",
  "password": "string",
  "confirmPassword": "string"
}
```

2. Realize o login no endpoint: 
#### POST /api/auth/user/login
``` json
{
  "userName": "string",
  "email": "string",
  "password": "string",
  "confirmPassword": "string"
}
```
3. O token irá ser gerado.
4. Com o Swagger ativado, vá na parte superior "Authorize" e adicione:
Bearer [Seu Token JWT]
5. Endpoint serão liberados.

## Endpoints

## AboutProduct

### GET /api/AboutProduct/

Retorna todos os produtos disponíveis no e-commerce.

Exemplo de resposta:

```json
{
    "id": 1,
    "isAvailableOnFactory": true,
    "product": {
       "id": 0,
       "name": "string",
       "sku": "string",
       "description": "string",
       "size": "string",
       "color": "string",
       "gender": 0,
       "price": 0,
       "categoryId": 1
    }
}
```

### GET /api/AboutProduct/{id}

Retorna um produto específico com base no ID fornecido.

Exemplo de resposta:

```json
{
    "id": 1,
    "isAvailableOnFactory": true,
    "product": {
       "id": 0,
       "name": "string",
       "sku": "string",
       "description": "string",
       "size": "string",
       "color": "string",
       "gender": 0,
       "price": 0,
       "categoryId": 1
    }
}
```

### GET /api/AboutProduct/product/{id}

Retorna o log específico de um produto.

Exemplo de resposta:

```json
{
    "id": 1,
    "isAvailableOnFactory": true,
    "product": {
       "id": 0,
       "name": "string",
       "sku": "string",
       "description": "string",
       "size": "string",
       "color": "string",
       "gender": 0,
       "price": 0,
       "categoryId": 1
    }
}
```

## Product

### GET /api/Product

Retorna todos os produtos.

Exemplo de requisição:

```json
{
    "id": 1,
    "name": "string",
    "sku": "string",
    "description": "string",
    "size": "string",
    "color": "string",
    "gender": 0,
    "price": 0,
    "categoryId": 1
}
```

### GET /api/Product/{id}

Retorna determinado produto através do ID fornecido.

Exemplo de requisição:

```json
{
    "id": 1,
    "name": "string",
    "sku": "string",
    "description": "string",
    "size": "string",
    "color": "string",
    "gender": 0,
    "price": 0,
    "categoryId": 1
}
```

### POST /api/Product/

Realiza a inclusão de um novo produto.

Exemplo de requisição:

```json
{
    "id": 1,
    "name": "string",
    "sku": "string",
    "description": "string",
    "size": "string",
    "color": "string",
    "gender": 0,
    "price": 0,
    "categoryId": 1
}
```

### PUT /api/Product/{id}

Realiza a edição de um produto atravéz do ID fornecido.

Exemplo de requisição:

```json
{
    "id": 1,
    "name": "string",
    "sku": "string",
    "description": "string",
    "size": "string",
    "color": "string",
    "gender": 0,
    "price": 0,
    "categoryId": 0
}
```

### DELETE /api/Product/{id}

Remove um produto específico com base no ID fornecido.

## Category

### GET /api/Category

Retorna todas as categorias.

Exemplo de requisição:

```json
{
    "id": 1,
    "name": "string",
    "description": "string",
    "imageUrl": "string"
}
```

### GET /api/Category/{id}

Retorna determinada categoria através do ID fornecido.

Exemplo de requisição:

```json
{
    "id": 1,
    "name": "string",
    "description": "string",
    "imageUrl": "string"
}
```

### POST /api/Category

Realiza a inclusão de uma nova categoria.

Exemplo de requisição:

```json
{
    "id": 1,
    "name": "string",
    "description": "string",
    "imageUrl": "string"
}
```

### PUT /api/Category/{id}

Realiza a edição de uma categoria atravéz do ID fornecido.

Exemplo de requisição:

```json
{
    "id": 1,
    "name": "string",
    "description": "string",
    "imageUrl": "string"
}
```

### DELETE /api/Category/{id}

Remove uma categoria específica com base no ID fornecido.

## Política de CORS:

#### Dado a configuração, somente URLs/URIs que são de mesma origem terão acesso aos endpoints de persistência.

## Roles privilégios:

#### Terão acesso aos endpoints de persistência os usuários com privilégios de administradores.
#### Demais endpoints são liberados para usuários.

## Como Contribuir

Se você deseja contribuir para este projeto, siga as etapas abaixo:

1. Faça um fork deste repositório e clone-o em sua máquina local.
2. Crie um novo branch para suas alterações: `git checkout -b minha-branch`.
3. Realize as alterações desejadas e commit-as: `git commit -m 'Minhas alterações'`.
4. Envie suas alterações para o branch principal do repositório forkado: `git push origin minha-branch`.
5. Abra um pull request no repositório original, descrevendo as alterações propostas.

## Licença

Este projeto está licenciado sob a **MIT License**.
