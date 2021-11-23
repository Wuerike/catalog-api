build:
	docker build -t catalog-api:v1 .

run:
	docker run -it --rm --network=host catalog-api:v1