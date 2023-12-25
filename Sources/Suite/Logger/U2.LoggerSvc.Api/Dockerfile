#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 41001
EXPOSE 42001

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["U2.Logger/U2.Logger.Api/U2.Logger.Api.csproj", "U2.Logger/U2.Logger.Api/"]
RUN dotnet restore "U2.Logger/U2.Logger.Api/U2.Logger.Api.csproj"
COPY . .
WORKDIR "/src/U2.Logger/U2.Logger.Api"
RUN dotnet build "U2.Logger.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "U2.Logger.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "U2.Logger.Api.dll"]