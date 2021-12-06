SHELL := /bin/bash

test:
	cd src/CatalogApiTests && dotnet test

local-run:
	set -a && source .env && set +a && cd src/CatalogApi && dotnet run

docker-build:
	docker build -t catalog-api:v1 .

docker-run:
	docker run -it --rm --env-file .env --network=host catalog-api:v1

kube-deploy:
	kubectl delete secret kube-env --ignore-not-found
	kubectl create secret generic kube-env --from-env-file=.env
	kubectl apply -f .kubernetes/catalog-api.yaml
	kubectl apply -f .kubernetes/mongodb.yaml
