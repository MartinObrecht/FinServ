# Sistema de Gestão de Portfólio de Investimentos

Desenvolvimento backend para um sistema de gestão de portfólio de investimentos.

## 🔌 Tomada de Decisão

- **Padrão CQRS (Command Query Responsibility Segregation):**
    - Optei pelo padrão CQRS porque acredito que a separação de responsabilidades entre operações de leitura e escrita facilita a manutenção e evolução do sistema. Além disso, permite escalabilidade.
    - Para a implementação do CQRS, estou utilizando a biblioteca MediatR, que simplifica o gerenciamento de comandos e queries. Ela também oferece suporte a injeção de dependências nos handlers e notificações de eventos.

- **Abordagem Code First para o Banco de Dados:**
    - Escolhi a abordagem Code First para a criação do banco de dados. Ela facilita a evolução do modelo de dados e permite a criação de scripts de migração para versionamento.
    - Utilizo o Entity Framework Core para migrações de banco de dados e mapeamento de entidades.

- **Deploy no Azure:**
    - Realizei o deploy da aplicação no Azure usando os serviços Web App Services via Docker e Azure SQL.
    - Minha próxima etapa é criar uma Azure Function para processar notificações de eventos e utilizar o Azure Service Bus para comunicação entre os microserviços.

- **Pipeline de CI/CD no GitHub Actions:**
    - Configurei um pipeline de CI/CD no GitHub Actions para realizar o build, atualizar a imagem no Docker Hub e fazer o deploy do projeto a cada push na branch master.

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
   
```
docker container run --rm -p 8088:80 -e ConnectionStrings__DefaultConnection="ccc" martinobrecht/fin-serv-api:latest
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

