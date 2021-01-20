# Desenvolvimento .NET

## Stacks:

- .NET 5;
- SQL Server;
- Entity Framework.

O sistema se consiste em um crud que tem como função: Cadastrar, Listar, Editar e Deletar.

O projeto está hospedado no azure, segue o link:
http://apimovies.azurewebsites.net

Porém, estou enfrentando problemas para fazer ele se conectar com o banco, então ele não trás dados que estão persistentes no SQL Server.
Acredito que seja isso, pois se forço uma rota como: **https://localhost:44344/movies/create** ele consegue entrar na tela do cadastro mas não efetua o cadastro.

## String de conexão do SQL Server:

 "ConnectionStrings": {
        "DefaultConnection": "Integrated Security=SSPI;Persist Security Info=False;User ID=MATHEUS-MENDES\\Matheus;Initial Catalog=movieapi;Data Source=MATHEUS-MENDES\\SQLEXPRESS"
 },

