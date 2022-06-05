FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 5276

ENV ASPNETCORE_URLS=http://+:5276

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Watoocook.Api.csproj", "./"]
RUN dotnet restore "Watoocook.Api.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "Watoocook.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Watoocook.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Watoocook.Api.dll"]
