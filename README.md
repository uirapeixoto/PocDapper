## POC Dapper

Projeto de exemplo de uso simples de dapper, mas completo, com os testes unitários da camada de serviço e de integração.

Interessante abordar a questão de que a arquitetura do aspnetcore não consegue ler a string com o sql passado para o execute ou query do dapper, dessa forma não da pra testar a camada de repositório, então os testes consideraram o percurso entre a camada de serviço e as entradas e saidas das apis.

** Para este projeto foram utilizadas as bibliotecas adicionais **

- Service
    - Dapper (2.0.30)
    - Microsoft.Extensions.Configuration (3.1.2)

- Service.Test
    - Moq
    - XunitXml.TestLogger

- Integration.Test
    - Microsoft.AspNetCore.Mvc.Testing
    - Microsoft.EntityFrameworkCore
    - xunit
