# Use the official .NET runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime

WORKDIR /app
COPY bin/Release/net6.0/ ./

# Expose API ports
EXPOSE 7287 5175

ENTRYPOINT ["dotnet", "CIUnitTesting.dll"]
