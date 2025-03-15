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
ENV ASPNETCORE_URLS=http://+:5004;https://+:7024
ENV ASPNETCORE_HTTP_PORTS=5004
ENV ASPNETCORE_HTTPS_PORTS=7024
# Create a cert for HTTPS
RUN apt-get update && apt-get install -y openssl
RUN openssl req -new -x509 -nodes -days 365 -subj "/CN=localhost" -out /etc/ssl/certs/aspnetapp.crt -keyout /etc/ssl/private/aspnetapp.key
ENV ASPNETCORE_Kestrel__Certificates__Default__Path=/etc/ssl/certs/aspnetapp.crt
ENV ASPNETCORE_Kestrel__Certificates__Default__KeyPath=/etc/ssl/private/aspnetapp.key
EXPOSE 5004
EXPOSE 7024
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT [ "dotnet", "TodoApi.dll"]