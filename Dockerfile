# Etapa 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copiar archivos de solución y proyecto para restaurar dependencias
COPY *.sln .
COPY HeladeriaAPI/*.csproj ./HeladeriaAPI/

# Restaurar paquetes
RUN dotnet restore

# Copiar todo el código fuente
COPY . .

# Publicar la app en modo Release
WORKDIR /app/HeladeriaAPI
RUN dotnet publish -c Release -o out

# Etapa 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

# Copiar los archivos publicados desde la etapa de build
COPY --from=build /app/HeladeriaAPI/out .

# Puerto que exponemos (ajustalo si usás otro)
EXPOSE 5000

# Comando para ejecutar la app
ENTRYPOINT ["dotnet", "HeladeriaAPI.dll"]
