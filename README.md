# AvonaleSimplificado

## Como rodar o projeto (localmente)

### Requisitos
- Nodejs 20
- .NET 8

### Banco de dados e API
Inicialmente iria rodar tudo com o docker-compose. Porém admito que nunca tentei
rodar migrations dessa forma e perdi muito tempo com isso. Portanto o docker-compose
executa apenas a api e um banco postgres

Basta ter o docker instalado e, na raiz do projeto, rodar:
```sh
$ docker compose up
```

Isso inicia o banco de dados e a API. Para rodar as migrações é necessário
fazer isso "externamente", seja por CLI, Visual Studio, etc.

### Frontend

Na pasta src/webapp, basta rodar:
```sh
$ npm i
$ npm run dev
```

Tanto no docker-compose.yml, appsettings.json ou no frontend, todas as urls estão
hardcoded. A api roda na porta 5002, o BD na 5432 e o front busca a api no localhost:5002
