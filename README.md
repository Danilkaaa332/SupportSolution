# SupportSolution

Учебное решение для учета заявок технической поддержки.

## Технологии
- C#
- .NET 9
- xUnit
- Git

## Структура
- `src/Support.Domain` — предметные сущности и правила.
- `src/Support.Application` — контракты и прикладная логика.
- `src/Support.Infrastructure` — технические реализации.
- `src/Support.WebApi` — HTTP-интерфейс.
- `tests/Support.UnitTests` — модульные тесты.
- `docs/modules.md` — описание модулей и зависимостей.

## Сборка
```bash
dotnet build
