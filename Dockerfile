# Build Stage
FROM mcr.microsoft.com/dotnet/sdk:6.0-focal AS build
WORKDIR /source
COPY . .
RUN dotnet restore "./EVRentalService/EVRentalService.csproj" --disable-parallel
RUN dotnet restore "./EVRentalBusiness/EVRentalBusiness.csproj" --disable-parallel
RUN dotnet restore "./EVRentalDAL/EVRentalDAL.csproj" --disable-parallel
RUN dotnet restore "./EVRentalEntity/EVRentalEntity.csproj" --disable-parallel
RUN dotnet publish "./EVRentalDAL/EVRentalService.csproj" -c release -o /app --no-restore

# Serve Stage
FROM mcr.microsoft.com/dotnet/aspnet:6.0-focal
WORKDIR /app
COPY --from=build /app ./

EXPOSE 5000
EXPOSE 5001

ENTRYPOINT ["dotnet", "EVRentalDAL.dll"]
