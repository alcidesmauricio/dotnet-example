## Example.Api

Este projeto foi gerado automaticamente pela StackSpot.

## Execução do projeto criado

Após criar o projeto, acesse o diretório em que foi criado e execute o seguinte comando:

```bash
dotnet restore Example.Api.sln
```

Realize também o build do projeto, através do comando abaixo:

```bash
dotnet build Example.Api.sln
```

Realize a execução dos testes unitários e de integração, através do comando abaixo:

```bash
dotnet test Example.Api.sln
```

Para testar a aplicação, ainda no diretório, execute o seguinte comando:

```bash
dotnet run --project ./src/Example.Api/Example.Api.csproj
```

Em seguida, abra http://localhost:5000 no seu navegador.

### Configuração do Docker

Para que o Docker funcione, você precisará adicionar um certificado SSL temporário e montar um volume para manter esse certificado.
Você pode encontrar no [Microsoft Docs](https://docs.microsoft.com/en-us/aspnet/core/security/docker-https?view=aspnetcore-6.0) que descrevem as etapas necessárias para Windows, macOS e Linux.

Para Windows:
O seguinte precisará ser executado a partir do seu terminal para criar um certificado:

```bash
dotnet dev-certs https -ep %USERPROFILE%\.aspnet\https\aspnetapp.pfx -p Your_password123
dotnet dev-certs https --trust
```

NOTA: Ao usar o PowerShell, substitua %USERPROFILE% por $env:USERPROFILE.

PARA macOS:
```bash
dotnet dev-certs https -ep ${HOME}/.aspnet/https/aspnetapp.pfx -p Your_password123
dotnet dev-certs https --trust
```

PARA Linux:
```bash
dotnet dev-certs https -ep ${HOME}/.aspnet/https/aspnetapp.pfx -p Your_password123
dotnet dev-certs https --trust
```

Para construir e executar os containers docker, execute o comando abaixo na raiz da solução onde você encontra o arquivo docker-compose.yml

 ```bash
 docker-compose -f 'docker-compose.yml' up --build
 ```

 . Você também pode usar "Docker Compose" do Visual Studio para fins de debug. Em seguida, abra http://localhost:5000 no seu navegador.

## Visão Geral

### Example.Domain

Contem todas as entidades, enumerações, exceções, interfaces, tipos e lógicas específicas da camada de domínio.

### Example.Application

Essa camada contém toda a lógica da api. É dependente da camada de domínio, mas não tem dependências de nenhuma outra camada ou projeto. Essa camada define interfaces que são implementadas por camadas externas. Por exemplo, se o aplicativo precisar acessar um serviço de notificação, uma nova interface será adicionada ao aplicativo e uma implementação será criada na infraestrutura.

### Example.Infrastructure

Essa camada contém classes para acessar recursos externos, como sistemas de arquivos, serviços da Web, smtp e assim por diante. Essas classes devem ser baseadas em interfaces definidas na camada de aplicação.

### Example.Api

Essa camada é um aplicativo de ASP.NET Core 5. Essa camada depende das camadas Aplicativo e Infraestrutura, no entanto, a dependência da infraestrutura é apenas para dar suporte à injeção de dependência. Portanto, apenas *Startup.cs* deve fazer referência à infraestrutura.

### Componentes Utilizados

- [AutoMapper](https://automapper.org/)
- [FluentAssertions](https://github.com/fluentassertions/fluentassertions)
- [FluentValidation](https://fluentvalidation.net/)
- [MediatR](https://github.com/jbogard/MediatR)
- [Moq](https://github.com/moq/moq4)
- [Shouldly](https://github.com/shouldly/shouldly)
- [WireMock.Net](https://github.com/WireMock-Net/WireMock.Net)
- [xunit](https://github.com/xunit/xunit)

## Referências
- [Clean Architecture: descubra o que é e onde aplicar Arquitetura Limpa](https://www.zup.com.br/blog/clean-architecture-arquitetura-limpa)
- [Clean Architecture with ASP.NET Core 3.0 • Jason Taylor • GOTO 2019](https://www.youtube.com/watch?v=dK4Yb6-LxAk)