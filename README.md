# Catalog API

## Description

*What it does:*
Its a CRUD to manage a catalog of itens stored in a instace of MongoDB, with the following operations:

- Insert item
- Get all items
- Get specific item
- Update specific item
- Delete specific item

## Dependencies/Requirements

- .NET Core 6.0
- MongoDB instance

## Getting Started

### Configuration

- The application secrets are configured through an .env file, to configure the app you should:
  - Duplicate the **example.env** renaming to **.env**
  - Fulfill it with your local variables
  - Execute `source .env`

### Running Method Options

#### Dotnet CLI

Execute `dotnet run` in the terminal

#### Debug mode

With the API folder opened at VS Code, hit F5 button to run the application in debug mode. Similar functionality could be found in others editors / IDEs.

#### Docker

The command to run with docker is inside the makefile, just need execute `make build` and `make run`

#### Docker-compose

With docker-compose the app could be runned by executing `docker-compose up --build`

## Availables Endpoints

Being the default base URL `https://localhost:5000`:

- GET **/swagger**: Auto generated swagger webpag documentation
- GET **/health/live**: Check if the API is alive
- GET **/health/ready**: Check if the API is ready for requests
- POST **/items**: Add a new item with name and price
- GET **/items**: Get all previous inserted items
- GET **/items/{id}**: Get specific item by its UUID ID
- PUT **/items/{id}**: Update specific item by its UUID ID
- PATCH **/items/{id}**: Delete specific item by its UUID ID
