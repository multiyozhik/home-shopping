# Catalog Project - Clean Architecture Template.


Микросервис построен по принципам Clean Architecture с четким разделением слоев и зависимостей:
- README.md - инструкции по проекту
- Catalog.Api - слой Web Api - зависимости от Application, Infrastructure
- Catalog.Application - бизнес-логика  - зависимости от Domain
- Catalog.Domain - доменные модели - нет зависимостей 
- Catalog.Infrasructure - данные, внешние сервисы - зависимости от Application


### Команды для использования шаблона для создания проекта с использованием шаблона Catalog 

Создать папку src и в ней пустой файл решения, например, `ProjectStore.sln`:
`dotnet new sln -n "ProjectStore"`

В src-папке создать Services-папку и из нее проект, например, Catalog по Catalog-шаблону:
`dotnet new Catalog -n Catalog`

Добавить все проекты в solution:
`dotnet sln add **/*.csproj` (для Mac OS)
`Get-ChildItem -Recurse -Filter *.csproj | ForEach-Object { dotnet sln add $_.FullName }` (для Windows)

Или каждый проект по отдельности:
`dotnet sln add "src/Services/Catalog/Catalog.API/Catalog.API.csproj"`
`dotnet sln add "src/Services/Catalog/Catalog.Application/Catalog.Application.csproj"`
`dotnet sln add "src/Services/Catalog/Catalog.Domain/Catalog.Domain.csproj"`
`dotnet sln add "src/Services/Catalog/Catalog.Infrastructure/Catalog.Infrastructure.csproj"`

Сборка проекта и запуск API
`dotnet build`
`dotnet run --project src/Services/Catalog/Catalog.API`