# Sistema de Gestão de Portfólio de Investimentos

Desenvolvimento backend para um sistema de gestão de portfólio de investimentos.


## 🚀 Começando

Essas instruções permitirão que você obtenha uma cópia do projeto em operação na sua máquina local para fins de desenvolvimento e teste.


### 📋 Pré-requisitos

De que coisas você precisa para instalar o software e como instalá-lo?

1. Docker
2. Dotnet sdk 8.0
3. Dotnet Entity Framework CLI

### 🔧 Instalação e execução

Para executar o projeto localmente, execute os comandos a partir da raiz do projeto (pasta que contem o arquivo sln)

Para aplicar as migrations e criar as tabelas no banco de dados:

```
dotnet ef database update --project ./src/FinServ.Infra/FinServ.Infra.csproj --startup-project ./src/FinServ.Api/FinServ.Api.csproj
```

Para executar o projeto local:

```
dotnet run --project ./src/FinServ.Api/FinServ.Api.csproj
```

Para acessar a documentação da API:

```
https://localhost:55449/swagger/index.html

http://localhost:55450/swagger/index.html
```

Para executar o projeto localmente, utilizando Docker, execute os comandos a partir da raiz do projeto (pasta que contem o arquivo sln)


## 📦 Implantação

A implantação do projeto foi realizada no Azure, utilizando os serviços de Web App Services, através de uma imagem Docker, e banco de dados Azure SQL.

Foi configurado um pipeline de CI/CD no Git Hub Actions, que realiza o build, atualiza a imagen no repositório Docker Hub(https://hub.docker.com/repository/docker/martinobrecht/fin-serv-api/general) e deploy do projeto a cada push na branch master.

Os endpoints da API estão hospedados no Azure, e podem ser acessados através dos links:

```
https://finservapi.azurewebsites.net/swagger/index.html
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

