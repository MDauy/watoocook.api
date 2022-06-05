#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Watoocook.Api/Watoocook.Api.csproj", "Watoocook.Api/"]
COPY ["Watoocook.Domain/Watoocook.Domain.csproj", "Watoocook.Domain/"]
COPY ["Watoocook.Infrastructure/Watoocook.Infrastructure.csproj", "Watoocook.Infrastructure/"]
COPY ["MongoDBWrapper/MongoDBWrapper.csproj", "MongoDBWrapper/"]
RUN dotnet restore "Watoocook.Api/Watoocook.Api.csproj"
COPY . .
WORKDIR "/src/Watoocook.Api"
RUN dotnet build "Watoocook.Api.csproj" -c Release -o /app/build

FROM build AS watch
RUN dotnet watch "Watoocook.Api.csproj"

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Watoocook.Api.dll"]