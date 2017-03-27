FROM microsoft/dotnet:1.1.1-sdk

COPY . /app
WORKDIR /app

RUN ["dotnet", "restore"]
RUN ["dotnet", "build"]

EXPOSE 40001/tcp
ENV ASPNETCORE_URLS http://*:40001

ENTRYPOINT ["dotnet", "run"]