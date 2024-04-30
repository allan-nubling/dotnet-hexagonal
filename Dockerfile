# Define a imagem base
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env

#Argumenta Token PAT Azure Devops
ARG PAT
ARG SOURCE_NAME

# Define o diretório de trabalho
WORKDIR /app

# Copy everything
COPY . ./

# Restaura as dependência
RUN dotnet nuget update source $SOURCE_NAME -u useless_user -p $PAT --store-password-in-clear-text
RUN dotnet restore ./src/Application/API

# Teste Lint
#RUN dotnet tool install --global dotnet-format
#RUN dotnet format --verify-no-changes

# Teste de Cobertura
#RUN dotnet test /p:CollectCoverage=true /p:CoverletOutputFormat=cobertura

# Copia todo o código-fonte e compila a aplicação
COPY . ./
RUN dotnet publish src/Application/API/API.csproj -c Release -o out


# Define a imagem de runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime-env

# Define o diretório de trabalho
WORKDIR /app

# Copia os arquivos de saída da compilação
COPY --from=build-env /app/out .
RUN ls -ltrh

ENV ASPNETCORE_HTTP_PORTS=5586
# Expõe a porta em que a aplicação irá rodar
EXPOSE 5586

# Define o comando de inicialização da aplicação
ENTRYPOINT ["dotnet", "API.dll"]