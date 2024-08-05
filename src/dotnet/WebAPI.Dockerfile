# Utiliza a imagem oficial do .NET SDK para a fase de build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copia todos os arquivos .csproj e restaura as dependências
COPY AvonaleSimplificado.sln ./
COPY AvonaleSimplificado.WebAPI/AvonaleSimplificado.WebAPI.csproj ./AvonaleSimplificado.WebAPI/
COPY AvonaleSimplificado.Application/AvonaleSimplificado.Application.csproj ./AvonaleSimplificado.Application/
COPY AvonaleSimplificado.Domain/AvonaleSimplificado.Domain.csproj ./AvonaleSimplificado.Domain/
COPY AvonaleSimplificado.Infrastructure/AvonaleSimplificado.Infrastructure.csproj ./AvonaleSimplificado.Infrastructure/
RUN dotnet restore

# RUN dotnet tool install --global dotnet-ef

# Copia todo o código fonte e publica a aplicação
COPY . .
WORKDIR /app/AvonaleSimplificado.WebAPI


# RUN /root/.dotnet/tools/dotnet-ef database update --project /app/AvonaleSimplificado.Infrastructure/AvonaleSimplificado.Infrastructure.csproj --startup-project /app/AvonaleSimplificado.WebAPI/AvonaleSimplificado.WebAPI.csproj

RUN dotnet publish -c Release -o /app/publish

# Utiliza a imagem oficial do .NET Runtime para a fase de runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "AvonaleSimplificado.WebAPI.dll"]

