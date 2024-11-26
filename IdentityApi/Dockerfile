# Etapa 1: Imagem base para build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app
COPY . .

# Restaura dependências
RUN dotnet restore "Api/IdentityApi.Api.csproj"

# Compila a aplicação
RUN dotnet publish "Api/IdentityApi.Api.csproj" -c Release -o /app/publish

# Etapa 2: Imagem base para runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "IdentityApi.Api.dll"]
