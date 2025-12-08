# Checkout Project - Clean Architecture Template.


Микросервис построен по принципам Clean Architecture с четким разделением слоев и зависимостей:
- README.md - инструкции по проекту
- Checkout.Api - слой Web Api - зависимости от Application, Infrastructure
- Checkout.Application - бизнес-логика  - зависимости от Domain
- Checkout.Domain - доменные модели - нет зависимостей 
- Checkout.Infrasructure - данные, внешние сервисы - зависимости от Application


### Команды для использования шаблона для создания проекта с использованием шаблона Checkout 

Создать папку src и в ней пустой файл решения, например, `ProjectStore.sln`:
`dotnet new sln -n "ProjectStore"`

В src-папке создать Services-папку и из нее проект, например, Catalog по Checkout-шаблону:
`dotnet new Checkout -n Catalog`

Добавить все проекты в solution:
`dotnet sln add **/*.csproj` (для Mac OS)
`Get-ChildItem -Recurse -Filter *.csproj | ForEach-Object { dotnet sln add $_.FullName }` (для Windows)

Или каждый проект по отдельности:
`dotnet sln add "src/Services/Checkout/Checkout.API/Checkout.API.csproj"`
`dotnet sln add "src/Services/Checkout/Checkout.Application/Checkout.Application.csproj"`
`dotnet sln add "src/Services/Checkout/Checkout.Domain/Checkout.Domain.csproj"`
`dotnet sln add "src/Services/Checkout/Checkout.Infrastructure/Checkout.Infrastructure.csproj"`

Сборка проекта и запуск API
`dotnet build`
`dotnet run --project src/Services/Checkout/Checkout.API`