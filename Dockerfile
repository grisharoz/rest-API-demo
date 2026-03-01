# Stage 1: Build Stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /src

# restore
COPY ["src/TodoApi/TodoApi.csproj", "TodoApi/"]
RUN dotnet restore 'TodoApi/TodoApi.csproj'

# build
COPY ["src/TodoApi", "TodoApi/"]
WORKDIR /src/TodoApi
RUN dotnet build 'TodoApi.csproj' -c Release -o /app/build


# Stage 2: Publish Stage
FROM build AS publish
RUN dotnet publish 'TodoApi.csproj' -c Release -o /app/publish

# Stage 3: Run Stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0

ENV ASPNETCORE_URLS=https://+:443;http://+:5004
ENV ASPNETCORE_Kestrel__Certificates__Default__Path=/https/origin.pfx
ENV ASPNETCORE_Kestrel__Certificates__Default__Password=yourpassword

EXPOSE 5004
EXPOSE 443

WORKDIR /app
COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "TodoApi.dll"]