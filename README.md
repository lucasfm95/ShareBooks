# ShareBooks
API para empréstimos de livros.

### Branch master build status - appveyour:
[![Build status](https://ci.appveyor.com/api/projects/status/gla8qfi839ay5a6o/branch/master?svg=true)](https://ci.appveyor.com/project/lucasfm95/sharebooks/branch/master)

Projeto em ASPNET Core Web API 2.2 de controle de empréstimos de livros, controlando o livro que foi emprestado para o leitor.
Projeto rodando no Azure, na url: https://sharebooks.azurewebsites.net/docs/index.html

### Funcionalidades do sistema:

* O sistema permiti consultar, inserir e alterar um livro. 
* O sistema permiti consultar, inserir e alterar um leitor;
* O sistema permiti consultar, inserir e alterar um empréstimo de livro;

### Instalação:
É necessário ter um banco de dados sql server e rodar o script sql ScriptDataBase.sql (encontra-se na raiz do projeto) para criação das tabelas no banco de dados.

Necessário também ter runtime do ASPNET Core.

### Exemplo de uso:
Para fazer um empréstimo, é necessário ter o livro e o leitor cadastrado.

### Tecnologias utilizadas:

* Swagger - para documentação da API;
* Serialog - para gravação de log em arquivo, somente erros;
* Auto Mapper - para fazer o mapeamento dos modelos para entidades;
* Coverlet - teste de cobertura;
* SQL Server - banco de dados da aplicação;
* MongoDB - banco para log;
