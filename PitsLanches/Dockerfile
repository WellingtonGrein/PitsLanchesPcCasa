# Estágio 1: Build da Aplicação
# ALTERADO AQUI para usar o SDK 6.0
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

# Copia o arquivo .csproj e restaura as dependências primeiro
COPY ["PitsLanches.csproj", "./"]
RUN dotnet restore "./PitsLanches.csproj"

# Copia todo o resto do código fonte
COPY . .
WORKDIR "/src/."

# Compila e publica a aplicação em modo Release
RUN dotnet publish "PitsLanches.csproj" -c Release -o /app/publish

# Estágio 2: Imagem Final
# ALTERADO AQUI para usar o runtime 6.0
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

# Define a porta que o contêiner vai expor
EXPOSE 8080

# Comando para iniciar a aplicação quando o contêiner for executado
ENTRYPOINT ["dotnet", "PitsLanches.dll"]