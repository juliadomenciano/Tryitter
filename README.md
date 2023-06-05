# Tryitter 
## Descrição do Projeto
  Tryitter é uma rede social voltada para estudantes da Trybe, onde eles podem se cadastrar, autenticar-se, criar posts, pesquisar outras contas e interagir com a comunidade. Este projeto é implementado em C# usando o framework ASP.NET Core, com banco de dados SQL Server e hospedado no Azure.

## Configuração do Ambiente
<details>
<summary><strong>Pré-requisitos</strong></summary>

  - .NET 5 SDK<br>
  - SQL Server<br>
  - Docker

</details>
<details>
<summary><strong>Configurando o Banco de Dados</strong></summary>

  Abra um terminal no diretório raiz do projeto e execute o seguinte comando para iniciar os contêineres:
  `docker-compose up -d`

</details>
<details>
<summary><strong>Configurando o Projeto</strong></summary>

  Faça o clone deste repositório para o seu ambiente local.
  Abra o projeto no Visual Studio ou em qualquer editor de sua preferência.
  Executando o Projeto
  No terminal, navegue até o diretório raiz do projeto.

  Execute o seguinte comando para restaurar as dependências:
  `dotnet restore`

  Em seguida, execute o comando para iniciar a aplicação:
  `dotnet run`
  Acesse a aplicação em https://localhost:7112/swagger/index.html.

</details>

## Endpoints

A documentação da API está disponível através do Swagger. Para acessar a documentação, inicie o projeto e abra o seguinte link em seu navegador:
`https://localhost:7112/swagger/index.html`

![Endpoints para Student](/images/student.png)
![Endpoints para Post](/images/post.png)
![Endpoints para Module](/images/module.png)