# Use the official .NET image as a parent image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

# Use the SDK image to build the app
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["contact-tracing-api.csproj", "./"]
RUN dotnet restore "contact-tracing-api.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "contact-tracing-api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "contact-tracing-api.csproj" -c Release -o /app/publish

# Copy the build app to the base image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "contact-tracing-api.dll"]