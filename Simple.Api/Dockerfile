FROM microsoft/dotnet:2.1-aspnetcore-runtime
ENV PATH /usr/local/bin:$PATH
ENV ASPNETCORE_URLS="http://*:5000"
EXPOSE 5000
COPY bin/Docker/publish/ /app/
WORKDIR /app
ENTRYPOINT ["dotnet", "Simple.Api.dll"]