FROM microsoft/dotnet:2.1-aspnetcore-runtime
ENV PATH /usr/local/bin:$PATH
ENV ASPNETCORE_URLS="http://*:80"
EXPOSE 80
COPY bin/Docker/publish/ /app/
WORKDIR /app
ENTRYPOINT ["dotnet", "Simple.Api.dll"]