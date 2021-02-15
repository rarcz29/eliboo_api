#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["Eliboo.Api/Eliboo.Api.csproj", "Eliboo.Api/"]
COPY ["Eliboo.Data/Eliboo.Data.csproj", "Eliboo.Data/"]
RUN dotnet restore "Eliboo.Api/Eliboo.Api.csproj"
COPY . .
WORKDIR "/src/Eliboo.Api"
RUN dotnet build "Eliboo.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Eliboo.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Eliboo.Api.dll"]