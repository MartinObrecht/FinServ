# ☁️ Fluxos da aplicação

## Coleção Postman

A coleção do Postman com os endpoints da aplicação esta disponível através do arquivo: postman_collection.json

## Fluxo de compra de ativos por um cliente

1 - Registrar um cliente

``
https://fin-serv-api.azurewebsites.net/api/Cliente/Registrar
``

```
{
  "nome": "<string>",
  "cpf": "<string>",
  "saldo": "<double>"
}
```

2 - Verificar os produtos disponíveis

```
https://fin-serv-api.azurewebsites.net/api/Produto/Disponiveis
```

3 - Comprar um Ativo

```
https://fin-serv-api.azurewebsites.net/api/Cliente/ComprarAtivo
```

```
{
  "cpf": "<string>",
  "idProduto": "<integer>",
  "quantidade": "<integer>"
}
```

4 - Verificar extrato de ativos do cliente através do cpf

```
https://fin-serv-api.azurewebsites.net//api/Clientes/ExtratoAtivos?Cpf=<string>
```

5 - Verificar os produtos disponíveis atualizados após a compra do cliente

```
https://fin-serv-api.azurewebsites.net/api/Produto/Disponiveis
```

## Fluxo de venda de ativos por um cliente

1 - Verificar extrato de ativos do cliente para consulta de saldo e patrimonio

```
https://fin-serv-api.azurewebsites.net//api/Clientes/ExtratoAtivos?Cpf=<string>
```

2 - Vender um Ativo

```
{{baseUrl}}/api/Clientes/VenderAtivo?Cpf=<string>&AtivoId=<integer>
```

3 - Verificar extrato de ativos do cliente após a venda

```
https://fin-serv-api.azurewebsites.net/api/Cliente/ExtratoAtivos?ClienteId=<Integer>
```

4 - Verificar os produtos disponíveis atualizados após a venda do cliente

```
https://fin-serv-api.azurewebsites.net/api/Produto/Disponiveis
```

## Gestão de produtos

1 - Operações Crud de produtos para o administrador.

```
https://fin-serv-api.azurewebsites.net//api/Produtos
```

2 - Operação de produtos disponívels para o cliente.

```
https://fin-serv-api.azurewebsites.net//api/Produtos/Disponiveis
```

