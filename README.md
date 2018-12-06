# simple-api-netcore-mongo
Simple API with .NET Core, MongoDB, Docker 

[![Build status](https://ci.appveyor.com/api/projects/status/a7ps20uwgpsfdwj0?retina=true)](https://ci.appveyor.com/project/hoangnguyen1983/simple-api-netcore-mongo)

# Intro

There are many ways to run a Web API on servers, among it there are plenty of cloud platformn solution such as AWS (Amazon Web Services).

This is a simple example with:

 - [.NET Core](https://docs.microsoft.com/en-us/dotnet/core/) 
 - [Docker](https://docs.docker.com/engine/examples/dotnetcore/) 
 -  [MongoDB](https://www.mongodb.com/what-is-mongodb)
 -  [AWS (Amazon Web Services)](https://aws.amazon.com/)

# Create a simple API with .NET Core
Here are the complete guide by Microsoft: https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-web-api?view=aspnetcore-2.2

## Documentation: 
You can add also the living documentation with [Swagger](https://swagger.io/): https://docs.microsoft.com/en-us/aspnet/core/tutorials/getting-started-with-swashbuckle?view=aspnetcore-2.2&tabs=visual-studio

## Test 
![](https://martinfowler.com/bliki/images/testPyramid/test-pyramid.png)
For any solution, testing is mandarory and also the hardest part. We need to define an intellient strategy for your tests and try to automation it as much as possible. You can find more [here](https://martinfowler.com/bliki/TestPyramid.html) about Test Pyramid.

Microsoft provide a nice tool to do the integration test with .NET Core 
https://docs.microsoft.com/en-us/aspnet/core/test/integration-tests

## Continuous Integration

In this example, I use AppVeyor to build CI. Please find here a good tutorial to do it: https://dotnetcore.gaprogman.com/2017/06/08/continuous-integration-and-appveyor/

# Packaging
Dockerize a .NET Core application: https://docs.docker.com/engine/examples/dotnetcore/

You can create a complet Dockerfile with two steps: Build & Pack or you can also separate these two steps into two steps in CI pipeline.

Here are an example for a complete Dockerfile:

    FROM microsoft/dotnet:sdk AS build-env
    WORKDIR /app    
    # Copy csproj and restore as distinct layers
    COPY *.csproj ./
    RUN dotnet restore    
    # Copy everything else and build
    COPY . ./
    RUN dotnet publish -c Release -o out    
    #Build runtime image
    FROM microsoft/dotnet:aspnetcore-runtime
    WORKDIR /app
    COPY --from=build-env /app/out .
    ENTRYPOINT ["dotnet", "aspnetapp.dll"]

And an example for two separate steps:

##### Build 

    dotnet publish --configuration Release --output bin/Docker/publish

#### Pack

    FROM microsoft/dotnet:2.1-aspnetcore-runtime
    ENV PATH /usr/local/bin:$PATH
    ENV ASPNETCORE_URLS="http://*:80"
    EXPOSE 80
    COPY bin/Docker/publish/ /app/
    WORKDIR /app
    ENTRYPOINT ["dotnet", "Simple.Api.dll"]


# Deploy to AWS
For a solution multi-dockers, you can deploy as a [docker-compose](https://docs.docker.com/compose/aspnet-mssql-compose/) or separate into multi-deploy a single container.

(To be continued)
 

