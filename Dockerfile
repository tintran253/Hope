FROM microsoft/aspnetcore:2.0-nanoserver-sac2016 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0-nanoserver-sac2016 AS build
WORKDIR /src
COPY Hope.sln ./ 
COPY Hope.WebApi/Hope.WebApi.csproj Hope.WebApi/
COPY Hope.Data/Hope.Data.csproj Hope.Data/
COPY Hope.Core/Hope.Core.csproj Hope.Core/
COPY Hope.Services/Hope.Services.csproj Hope.Services/
RUN dotnet restore -nowarn:msb3202,nu1503
COPY . .
WORKDIR /src/Hope.WebApi
RUN dotnet build -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Hope.WebApi.dll"]
