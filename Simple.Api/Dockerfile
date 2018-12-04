FROM microsoft/dotnet:2.1-aspnetcore-runtime
ENV PATH /usr/local/bin:$PATH
COPY bin/Docker/publish/ /app/
EXPOSE 80
EXPOSE 443
WORKDIR /app
ENTRYPOINT ["dotnet", "Simple.Api.dll"]