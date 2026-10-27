# OOP-Zahorovskiy

Навчальні роботи з об’єктно-орієнтованого програмування мовою C#.
Загоровський Ярослав Віталійович, група ІПЗ 3/1, варіант 7.

| Робота | Проєкт | Зміст |
|---|---|---|
| Лабораторна №1 | [lab1v7](lab1v7) | Наявна робота з Phone |
| Лабораторна №2 | [lab2v7](lab2v7) | Конструктори Phone, валідація та фіналізація |
| Самостійна №1 | [IndependentWork1](IndependentWork1) | WaterTank, Parcel, ParkingMeter |
| Самостійна №2 | [IndependentWork2](IndependentWork2) | Дві реалізації кошика |
| Самостійна №3 | [sw3v7](sw3v7) | SerialPortConnection та IDisposable |
| Самостійна №4 | [Samostiina4/IndependentWork2](Samostiina4/IndependentWork2) | Три конструктори Product |
| Лабораторна №3 | [lab3v7](lab3v7) | Життєвий цикл об’єкта та звільнення ресурсів |
| Лабораторна №4 | [lab6v7](lab6v7) | Наслідування та різниця між override і new |
| Лабораторна №5 | [lab8v7](lab8v7) | Поліморфні повідомлення |
| Лабораторна №6 | [lab10v7](lab10v7) | Інтерфейси та абстрактні класи |
| Лабораторна №7 | [lab12v7](lab12v7) | Узагальнений репозиторій та тести |

## Запуск

Потрібен .NET SDK 10.0, як і для наявного lab1v7.
У Visual Studio відкрийте потрібний .csproj через File → Open → Project/Solution і натисніть Ctrl+F5. Кожний проєкт запускається окремо.

Альтернатива — термінал у корені репозиторію:

```powershell
dotnet run --project lab2v7
dotnet run --project IndependentWork1
dotnet run --project IndependentWork2
dotnet run --project sw3v7
dotnet run --project Samostiina4/IndependentWork2
```

Кожна нова робота має README з поясненням і console-output.txt із результатом запуску. Лабораторна №2 додатково має REPORT.md з повним кодом та висновком. Назву IndependentWork2 для роботи №4 збережено відповідно до методички; окрема папка усуває конфлікт назв.

Усі п’ять нових проєктів перевірено компіляцією й запуском у Release. Лабораторна №1 залишена без змін.

## Лабораторні 3–7

Назви проєктів узято з методичок: №3 → lab3v7, №4 → lab6v7, №5 → lab8v7, №6 → lab10v7, №7 → lab12v7. Тести до №7 — lab12v7.Tests. У кожній папці є README зі звітом і відповідями, код та результат роботи. Для лабораторної 3 додано REPORT.md із повним кодом.

```powershell
dotnet run --project lab3v7
dotnet run --project lab6v7
dotnet run --project lab8v7
dotnet run --project lab10v7
dotnet run --project lab12v7
dotnet test lab12v7.Tests
```

Лабораторні 3–7 перевірено збіркою та запуском у Release (.NET SDK 10.0.100): без помилок і попереджень. У lab12v7.Tests пройшли всі 12 тестів.
