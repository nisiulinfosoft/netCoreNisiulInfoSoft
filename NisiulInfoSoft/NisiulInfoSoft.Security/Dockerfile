FROM microsoft/dotnet:2.2-aspnetcore-runtime
WORKDIR /app

COPY ./bin/Release/netcoreapp2.2/publish/ /app

ENV ASPNETCORE_URLS=http://+:8080
ENV CUSTOMER_NAME="netcorenisiulinfosoft"

EXPOSE 8080

ENTRYPOINT ["dotnet", "/app/NisiulInfoSoft.Security.dll"]