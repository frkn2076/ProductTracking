# ProductTracking

## Setup

* Install Docker
* Install .Net 8 SDK

## Initiate Dependency Instances on Docker:

* ***ElasticSearch:*** docker run --rm --name elasticsearch_container -p 9200:9200 -p 9300:9300 -e "discovery.type=single-node" --memory=256m elasticsearch:7.17.20
* ***Postgres:*** docker run -p 5432:5432 -e POSTGRES_USER=postgres -e POSTGRES_PASSWORD=example -e POSTGRES_DB=productdb -d postgres:13-alpine
* ***RabbitMQ:*** docker run -it --rm --name rabbitmq -p 5672:5672 -p 15672:15672 rabbitmq:3-management

## Run

* **CMD:**
  * set ASPNETCORE_ENVIRONMENT=Development
  * dotnet run
 
* **VS:**
  * Run

## Technologies:

* .Net 8, EF, Postgres, ElasticSearch, RabbitMQ

***You can use swagger documentation or [Prepared Http file](https://github.com/frkn2076/ProductTracking/blob/develop/ProductTracking.API/ProductTracking.API.http) to use samples about calling API***
