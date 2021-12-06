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
  - The usage of this file will depend on how you gonna run the app

### Unit tests

Execute `make test` on your terminal to run the unit tests

### Running Methods

#### .Net CLI

By executing `make local-run` the makefile will handle the exportation of the .env file and will run the app with the .Net CLI.

- This method requires you to set up your own MongoDB instance

#### Docker

By executing `make docker-build` the makefile will build a docker image for this application and with `make docker-run` it will handle the executing of this image while passing the .env as environment variables.

- This method requires you to set up your own MongoDB instance

#### Docker-compose

By executing `docker-compose up --build` docker compose will raise conteiners for both application and MongoDB.

#### Deploy on Kubernetes

If you have a local setup for kubernetes, like [Minikube](https://minikube.sigs.k8s.io/docs/start/), you can deploy this application by executing `make kube-deploy` and will be raised pods for both application and MongoDB.
- Its important you to guarantee your local kubernetes cluster can expose **LoadBalancer** service type, on Minikube it can be done with [minikube tunnel](https://minikube.sigs.k8s.io/docs/handbook/accessing/#loadbalancer-access).

## Availables Endpoints

The default base URL is `https://localhost:5000`, and when running with kubernets the base URL and port can be found by executing `kubectl get svc`.

- GET **/swagger**: Auto generated swagger webpag documentation
- GET **/health/live**: Check if the API is alive
- GET **/health/ready**: Check if the API is ready for requests
- POST **/items**: Add a new item with name and price
- GET **/items**: Get all previous inserted items
- GET **/items/{id}**: Get specific item by its UUID ID
- PUT **/items/{id}**: Update specific item by its UUID ID
- PATCH **/items/{id}**: Delete specific item by its UUID ID
