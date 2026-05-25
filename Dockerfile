FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

COPY ["ClyvoDayApiDocker.csproj", "./"]
RUN dotnet restore "ClyvoDayApiDocker.csproj"

COPY . .
RUN dotnet publish "ClyvoDayApiDocker.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app

RUN useradd -m appuser
USER appuser

COPY --from=build /app/publish .

ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

ENTRYPOINT ["dotnet", "ClyvoDayApiDocker.dll"]