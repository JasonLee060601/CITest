FROM harbor.sige.la/microsoft/dotnet/aspnet:6.0

RUN apt-get update
RUN apt-get install -y curl

WORKDIR /wwwroot

COPY ./wwwroot /wwwroot

ENTRYPOINT ["dotnet", "CIUnitTesting.dll"]
