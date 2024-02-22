# Use a imagem SDK do .NET 7.0 como base para a compilação do aplicativo
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app

# Copie os arquivos csproj dos projetos
COPY src/Backend/Adopt.Api/*.csproj ./Adopt.Api/
COPY src/Backend/Adopt.Application/*.csproj ./Adopt.Application/
COPY src/Backend/Adopt.Domain/*.csproj ./Adopt.Domain/
COPY src/Backend/Adopt.Infraestructure/*.csproj ./Adopt.Infraestructure/

# Restaure as dependências para todos os projetos
RUN dotnet restore ./Adopt.Api/Adopt.Api.csproj
RUN dotnet restore ./Adopt.Application/Adopt.Application.csproj
RUN dotnet restore ./Adopt.Domain/Adopt.Domain.csproj
RUN dotnet restore ./Adopt.Infraestructure/Adopt.Infraestructure.csproj

# Copie todo o código-fonte
COPY . .

# Compile o aplicativo
RUN dotnet publish -c Release -o out src/Backend/Adopt.Api/Adopt.Api.csproj

# Construa a imagem final do aplicativo
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime
WORKDIR /app
COPY --from=build /app/out ./
ENTRYPOINT ["dotnet", "Adopt.Api.dll"]
