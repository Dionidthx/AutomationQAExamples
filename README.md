
Для тестування використовується JSONPlaceholder — демонстраційний REST API, на якому можна перевіряти HTTP-запити та роботу з даними.

Що реалізовано

У проєкті є такі тестові сценарії:

- GET-запит — перевірка отримання запису та правильності повернених даних.
- POST-запит — перевірка створення нового запису.
- Data-driven test — перевірка декількох записів за різними ID в одному тестовому методі.
- Negative test — перевірка запиту до запису, якого не існує (404 Not Found).

Загалом реалізовано 4 тестові методи та 6 тестових випадків.

Технології

- C#
- .NET 8
- NUnit 4
- HttpClient
- REST API
- JSON
- Visual Studio Code

Як запустити проєкт

1. Переконайтеся, що встановлений .NET 8 SDK.

2. Завантажте проєкт та відкрийте його папку у VS Code.

3. Відкрийте термінал у папці проєкту.

4. Виконайте команди:

```bash
dotnet restore
dotnet test
```

Після виконання команда `dotnet test` покаже результати тестування.

Результат

На момент останнього запуску всі 6 тестових випадків пройшли успішно:

- Passed: 6
- Failed: 0
- Skipped: 0


The project uses JSONPlaceholder, a public demo REST API.

Implemented test scenarios

- GET request — checks whether a post is returned correctly.
- POST request — checks the creation of a new post.
- Data-driven test — checks multiple posts using different IDs in one test method.
- Negative test — checks the response when requesting a non-existing post (404 Not Found).

The project contains 4 test methods and 6 test cases in total.

Technologies

- C#
- .NET 8
- NUnit 4
- HttpClient
- REST API
- JSON
- Visual Studio Code

How to run

1. Make sure .NET 8 SDK is installed.

2. Download the project and open its folder in VS Code.

3. Open the terminal in the project directory.

4. Run the following commands:

```bash
dotnet restore
dotnet test
```

The test results will be displayed in the terminal.

Test results

At the latest test run, all 6 test cases passed successfully:

- Passed: 6
- Failed: 0
- Skipped: 0