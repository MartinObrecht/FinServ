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
https://fin-serv-api.azurewebsites.net/api/Cliente/ExtratoAtivos?ClienteId=2
```
