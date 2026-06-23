# Monolito Modular




### Comandos para executar migrations

- Products

```

dotnet ef migrations add InicialProducts -p  .\ModularMonolith.Products\ModularMonolith.Products.csproj -s .\ModularMonolith.Api\ModularMonolith.Api.csproj -o --context ProductsDbContext 'Persistence\Migrations'

dotnet ef database update -p  .\ModularMonolith.Products\ModularMonolith.Products.csproj -s .\ModularMonolith.Api\ModularMonolith.Api.csproj

```


- Financial

```

dotnet ef migrations add InicialFinancial -p  .\ModularMonolith.Financial\ModularMonolith.Financial.csproj -s .\ModularMonolith.Api\ModularMonolith.Api.csproj   --context FinancialDbContext -o 'Persistence\Migrations'


dotnet ef database update -p  .\ModularMonolith.Financial\ModularMonolith.Financial.csproj -s .\ModularMonolith.Api\ModularMonolith.Api.csproj

```

- Delivery


```

dotnet ef migrations add InicialDelivery -p  .\ModularMonolith.Delivery\ModularMonolith.Delivery.csproj -s .\ModularMonolith.Api\ModularMonolith.Api.csproj   --context DeliveryDbContext  -o 'Persistence\Migrations'


dotnet ef database update -p  .\ModularMonolith.Delivery\ModularMonolith.Delivery.csproj -s .\ModularMonolith.Api\ModularMonolith.Api.csproj

```