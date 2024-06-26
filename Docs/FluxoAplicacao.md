# ☁️ Fluxos da aplicação

## Fluxo de compra de ativos por um cliente

1 - Registrar um cliente

``
https://fin-serv-api.azurewebsites.net/api/Cliente/Registrar
``

```
{
  "nome": "string",
  "cpf": "string"
  "saldo": decimal"
}
```

2 - Verificar os produtos disponíveis

```
https://fin-serv-api.azurewebsites.net/api/Produto/Disponiveis
```

3 - Comprar um Ativo

  Observação: o código do produto é o código externo do produto, não é o IdProduto e é com ele que a compra é realizada.

```
https://fin-serv-api.azurewebsites.net/api/Cliente/ComprarAtivo
```

```
{
  "idCliente": 0,
  "codigoProduto": 0,
  "quantidade": 0
}
```

4 - Verificar extrato de ativos do cliente

```
https://fin-serv-api.azurewebsites.net/api/Cliente/ExtratoAtivos?ClienteId=<Integer>
```

5 - Verificar os produtos disponíveis atualizados após a compra do cliente

```
https://fin-serv-api.azurewebsites.net/api/Produto/Disponiveis
```

## Fluxo de venda de ativos por um cliente

1 - Verificar extrato de ativos do cliente

```
https://fin-serv-api.azurewebsites.net/api/Cliente/ExtratoAtivos?ClienteId=<Integer>
```

2 - Vender um Ativo

```
https://fin-serv-api.azurewebsites.net//api/Clientes/VenderAtivo?AtivoId=<integer>
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

