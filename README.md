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
