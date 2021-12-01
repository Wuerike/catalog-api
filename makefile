SHELL := /bin/bash

local-run:
	set -a && source .env && set +a && dotnet run

docker-build:
	docker build -t catalog-api:v1 .

docker-run:
	docker run -it --rm --env-file .env --network=host catalog-api:v1
