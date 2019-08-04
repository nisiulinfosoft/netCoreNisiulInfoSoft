FROM microsoft/dotnet:2.2-aspnetcore-runtime
WORKDIR /app

COPY ./bin/Release/netcoreapp2.2/publish/ /app

ENV ASPNETCORE_URLS=http://+:8080
ENV CUSTOMER_NAME="netcorenisiulinfosoft"
ENV BusUrl="Endpoint=sb://busgalaxylema.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=nMmVHcnIqrHgD6e1P/RPGHtMyGBtPKysZkbNMqz3JMY="
ENV BusTopic="enviapedido"
ENV Urlidentity="http://40.122.34.119:8081/"
ENV ApiName="api1"

EXPOSE 8080

ENTRYPOINT ["dotnet", "/app/NisiulInfoSoft.Publisher.dll"]