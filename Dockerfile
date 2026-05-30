# Build stage
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# Copiar csproj de ambos proyectos para el restore
COPY ["DPA.SHOPPING.API/DPA.SHOPPING.API.csproj", "DPA.SHOPPING.API/"]
COPY ["DPA.SHOPPING.CORE/DPA.SHOPPING.CORE.csproj", "DPA.SHOPPING.CORE/"]

# Restore
RUN dotnet restore "DPA.SHOPPING.API/DPA.SHOPPING.API.csproj"

# Copiar el resto del código
COPY . .

# Publicar
RUN dotnet publish "DPA.SHOPPING.API/DPA.SHOPPING.API.csproj" -c Release -o /app/publish

# Runtime
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS runtime
WORKDIR /app

ENV ASPNETCORE_URLS=http://+:5248

COPY --from=build /app/publish .

EXPOSE 5248

ENTRYPOINT ["dotnet", "DPA.SHOPPING.API.dll"]
