# Модули решения

| Модуль | Ответственность | От чего зависит | Почему |
|---|---|---|---|
| Support.Domain | Сущности и бизнес-правила | Ни от одного проекта решения | Предметная логика не зависит от технологий |
| Support.Application | Прикладные сценарии и контракты | Support.Domain | Использует предметную модель |
| Support.Infrastructure | Технические реализации | Support.Application, Support.Domain | Реализует контракты и использует сущности |
| Support.WebApi | HTTP-интерфейс | Support.Application, Support.Infrastructure | Принимает запросы и вызывает прикладной код |
| Support.UnitTests | Модульные тесты | Support.Domain, Support.Application | Проверяет правила и прикладную логику |
