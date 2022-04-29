#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
ENV TZ=America/Fortaleza

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Loggy/Loggy.csproj", "Loggy/"]
RUN dotnet restore "Loggy/Loggy.csproj"
COPY . .
WORKDIR "/src/Loggy"
RUN dotnet build "Loggy.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Loggy.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Loggy.dll"]