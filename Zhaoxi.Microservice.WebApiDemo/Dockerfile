#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Zhaoxi.Microservice.WebApiDemo/Zhaoxi.Microservice.WebApiDemo.csproj", "Zhaoxi.Microservice.WebApiDemo/"]
COPY ["Zhaoxi.AgilityFramework/Zhaoxi.AgilityFramework.csproj", "Zhaoxi.AgilityFramework/"]
RUN dotnet restore "Zhaoxi.Microservice.WebApiDemo/Zhaoxi.Microservice.WebApiDemo.csproj"
COPY . .
WORKDIR "/src/Zhaoxi.Microservice.WebApiDemo"
RUN dotnet build "Zhaoxi.Microservice.WebApiDemo.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Zhaoxi.Microservice.WebApiDemo.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Zhaoxi.Microservice.WebApiDemo.dll"]