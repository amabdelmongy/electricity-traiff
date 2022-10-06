# Electricity Traiff Analyzer

## Deliverables
- Using the specified REST Endpoint which allows the client to Execute service call for Get.
- Using Docker to run an application
  * run command
``` docker-compose up --build ```
- Using C# language & .Net Core
This API Service is able to work with Json formatted input and it supports HTTP/HTTPS as messaging protocol.

## Technology
- .NET core 6
- Swagger
- NUnit
- Moq
- Docker
- Strategy Design Pattern

## Code Architecture
### Onion architecture
The Onion Architecture is an Architectural Pattern that enables maintainable and evolutionary enterprise systems.

* Api contains
  - [Tariff controller](src/Api/Controller/v1/TariffController.cs)
* Domain layer contains all logic
  - [Aggregate](src/Domain/Aggregate/Tariff.cs)
  - [Service](src/Domain/Service/TariffService.cs)

## Strategy Design Pattern
![](assets/img/Strategy_Design_Pattern.png)
  - Define a family of algorithms, encapsulate each one, and make them interchangeable. Strategy lets the algorithm vary independently from the clients that use it.
  - Capture the abstraction in an interface, put all implementation details in derived classes.

### Unit tests
 It validates if that code results in the expected state (state testing) or executes the expected sequence of events (behavior testing).
 It covers a lot of code areas.


  How to run unit tests
```
    dotnet test "tests/Domain.UnitTest/Domain.UnitTest.csproj"
```
### Integration tests
individual software modules are combined and tested as a group.


How to run integration tests

```
    dotnet test "tests/Api.Integration.Test/Api.Integration.Test.csproj"
```

### Swagger documentation
  - Swagger generate file for last version of api under this link ```/swagger/v1/swagger.json```

##  How to run the code
To start the internal service and its dependencies locally, execute:
the file docker-compose.yml will be under api folder direct.
```
    docker-compose up --build
```
##  How to build the code
```
    dotnet build "src/Api/Api.csproj"
```

## Excute the code
Use BasicAuth name/password: demo/demo


Using API url Get action


  URL
```
   http://localhost:8400/v1/tariff/3500
```
          Http status 200 Ok
```
{
  [
    {
        "consumption": 3500,
        "name": "Packaged tariff",
        "annualCost": 800
    },
    {
        "consumption": 3500,
        "name": "Basic tariff",
        "annualCost": 830
    }
  ]
}
```
Postman print screens
* Http status :-
  - [200](/assets/img/ok_response.PNG)
  - [400](/assets/img/error_400.PNG) 
* [Health](/assets/img/health.PNG) 

## ToDo
1. Add more unit tests and E2E tests
