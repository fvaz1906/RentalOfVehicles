# RentalOfVehicles Application

[![Build Status](https://travis-ci.org/joemccann/dillinger.svg?branch=master)](https://travis-ci.org/joemccann/dillinger)

Aplica��o criada para teste da ao3

# Pacotes Utilizados

  - Microsoft.AspNetCore.Identity.EntityFramework
  - Microsoft.AspNetCore.Identity.UI
  - Microsoft.EntityFrameworkCore.Design
  - Microsoft.EntityFrameworkCore.SqlServer
  - Microsoft.EntityFrameworkCore.Tools
  - Microsoft.VisualStudio.Web.CodeGeneration
  - Swashbuckle.AspNetCore
  - Swashbuckle.AspNetCore.Swagger

## Rotas da Aplica��o

  - GET /Vehicles
  - GET /Vehicles/Details/{id}
  - GET /Vehicles/Create
  - GET /Vehicles/Edit
  - GET /Vehicles/Delete/{id}
  - POST /Vehicles/Create
  - POST /Vehicles/Edit
  - POST /Vehicles/Delete
  - GET /VehiclesReservation/Create
  - POST /VehiclesReservation/Create

## Rodando a aplica��o

Obs. Sistema feito com o uso do SQL Server, trocar a connection string em appsettings.json

Rodar os comandos para o Entity Framework no Console de Gerenciador de Pacotes:

```sh
$ update-database -Context RentalOfVehiclesContext
$ update-database -Context DbRentalVehiclesContext
```
Ap�s criar a base, iniciar a aplica��o:

```sh
$ git clone https://github.com/fvaz1906/RentalOfVehicles.git
$ cd RentalOfVehicles
$ dotnet run
```

### Acesso

Foi Criado um SeedindService para adicionar um usu�rio padr�o ao sistema:

login: root
senha: P@ssw0rd