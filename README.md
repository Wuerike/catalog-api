
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
- The application is configured through the .Net secret manager. The secrets-example.json is a model for the needed configuration,you should:
  - Duplicate the **secrets-example.json** renaming to **secrets.json**
  - Add your local configurations / variables 
  - Execute `cat secrets.json | dotnet user-secrets set`

### Building and Running via Visual Studio Code

With the API folder opened at VS Code, hit F5 button to run the application in debug mode.

## Availables Endpoints

Being the default base URL `https://localhost:5001`:

- GET **/swagger**: Auto generated swagger webpag documentation
- GET **/health/live**: Check if the API is alive
- GET **/health/ready**: Check if the API is ready for requests
- POST **/items**: Add a new item with name and price
- GET **/items**: Get all previous inserted items
- GET **/items/{id}**: Get specific item by its UUID ID
- PUT **/items/{id}**: Update specific item by its UUID ID
- PATCH **/items/{id}**: Delete specific item by its UUID ID
