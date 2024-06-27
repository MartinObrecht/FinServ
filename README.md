# Sistema de Gestão de Portfólio de Investimentos

Desenvolvimento backend para um sistema de gestão de portfólio de investimentos.

## 🔌 Tomada de Decisão

- **Padrão CQRS (Command Query Responsibility Segregation):**
    - Optei pelo padrão CQRS para a arquitetura porque acredito que a separação de responsabilidades entre operações de leitura e escrita facilita a manutenção e evolução do sistema. Além disso, permite escalabilidade.
    - Para a implementação do CQRS, estou utilizando a biblioteca MediatR, que simplifica o gerenciamento de comandos e queries. Ela também oferece suporte a injeção de dependências nos handlers e notificações de eventos.

- **Abordagem Code First para o Banco de Dados:**
    - Escolhi a abordagem Code First para a criação do banco de dados, visando facilitar a evolução do modelo de dados e a criação de scripts de migração para versionamento.
    - Escolhi o Entity Framework Core como ORM, por ser uma ferramenta robusta e ateder as necessidades do projeto.

- **Deploy no Azure:**
    - Escolhi realizar o deploy da aplicação no Azure para facilitar a escalabilidade e gerenciamento da infraestrutura, além disso visei faciltar o acesso a documentação da API.
    - Optei por utilizar o serviço de Web App Services, que oferece suporte a contêineres Docker e integração com pipelines de CI/CD, e banco de dados Azure SQL.

- **Pipeline de CI/CD no GitHub Actions:**
    - Configurei um pipeline de CI/CD no GitHub Actions para realizar o build, atualizar a imagem no Docker Hub e fazer o deploy do projeto a cada push na branch master, facilitando a integração/entrega contínua e garantindo entrega de novas funcionalidades e correções de bugs de maneira rápida e segura.

## 🚀 Começando

Essas instruções permitirão que você obtenha uma cópia do projeto em operação na sua máquina local para fins de desenvolvimento e teste.


### 📋 Pré-requisitos

De que coisas você precisa para instalar o software e como instalá-lo?

1. Docker
2. Dotnet sdk 8.0
3. Dotnet Entity Framework CLI

### 🔧 Instalação e execução

Para executar o projeto localmente, execute os comandos a partir da raiz do projeto (pasta que contem o arquivo sln)

Para executar o projeto local:

```
dotnet run --project src/FinServ.Api/FinServ.Api.csproj ConnectionStrings:DefaultConnection="ccc"
```

Para executar o projeto local, utilizando docker

Banco de dados
```
docker run --cap-add SYS_PTRACE -e 'ACCEPT_EULA=1' -e 'MSSQL_SA_PASSWORD=Abcd1234%' -e 'MSSQL_PID=Developer' -p 1433:1433 --name azuresqledge -d mcr.microsoft.com/azure-sql-edge:latest
```
Aplicação   
```
docker run --rm -p 8088:80 -e ConnectionStrings__DefaultConnection="Data Source=127.0.0.1,1433;Initial Catalog=FinServ;User Id=sa;Password=Abcd1234%;Integrated Security=False;MultipleActiveResultSets=True;TrustServerCertificate=true;" martinobrecht/fin-serv-api:latest
```

Para acessar a documentação da API:

```
https://localhost:55449/swagger/index.html

http://localhost:55450/swagger/index.html
```

Para executar o projeto localmente, utilizando Docker, execute os comandos a partir da raiz do projeto (pasta que contem o arquivo sln)


## 📦 Implantação

A implantação do projeto foi realizada no Azure, utilizando os serviços de Web App Services, através de uma imagem Docker e banco de dados Azure SQL.

Foi configurado um pipeline de CI/CD no Git Hub Actions, que realiza o build, atualiza a imagen no repositório Docker Hub(https://hub.docker.com/repository/docker/martinobrecht/fin-serv-api/general) e deploy do projeto a cada push na branch master.

Os endpoints da API estão hospedados no Azure, e podem ser acessados através dos links:

```
https://finservapi.azurewebsites.net/swagger/index.html
```

# EntityFramework Commands

```
dotnet tool install --global dotnet-ef
```

```
dotnet ef migrations add InitialMigration -s FinServ.Api -p FinServ.Infra -c FinServ.Infra.Database.Context.FinServContext -v
```

```
dotnet ef database update InitialMigration --startup-project FinServ.Api --project FinServ.Infra --context FinServ.Infra.Database.Context.FinServContext --verbose
```

Connection String

```
Data Source=127.0.0.1,1433;Initial Catalog=FinServ;User Id=sa;Password=Abcd1234%;Integrated Security=False;MultipleActiveResultSets=True;TrustServerCertificate=true;
```


## 🛠️ Construído com

* Dotnet 8.0
* Entity Framework
* Docker
* Serviços Azure

## ✒️ Autores

* **Martin Obrecht** - (https://github.com/MartinObrecht)

## 📄 Licença

Este projeto está sob a licença (sua licença) - veja o arquivo [LICENSE.md](https://github.com/MartinObrecht/FinServ/licenca) para detalhes.

