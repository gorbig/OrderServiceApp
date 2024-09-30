<!DOCTYPE html>
<html lang="ru">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
</head>
<body>

<h1>Order Service API</h1>

<h2>Описание проекта</h2>

<p>Этот проект представляет собой базовый микросервис управления заказами (Order Service) на платформе ASP.NET Core. Сервис предоставляет REST API для выполнения CRUD-операций над заказами, используя Entity Framework Core для работы с базой данных PostgreSQL.</p>

<h2>Сильные стороны проекта</h2>

<ul>
    <li><span class="strong">ASP.NET Core</span>: Использование современного и производительного фреймворка для разработки веб-приложений.</li>
    <li><span class="strong">Entity Framework Core</span>: Интеграция с ORM для упрощения работы с базой данных.</li>
    <li><span class="strong">REST API</span>: Реализация стандартных HTTP методов (GET, POST, PUT, DELETE) для выполнения CRUD-операций.</li>
    <li><span class="strong">Миграции</span>: Использование миграций для управления схемой базы данных, что упрощает развертывание и поддержку проекта.</li>
    <li><span class="strong">PostgreSQL</span>: Поддержка реляционной базы данных PostgreSQL для хранения данных о заказах.</li>
    <li><span class="strong">DTO (Data Transfer Object)</span>: Использование DTO для передачи данных между слоями приложения, что улучшает безопасность и упрощает управление данными.</li>
    <li><span class="strong">Валидация</span>: Реализация валидации данных с использованием атрибутов и Fluent Validation, что обеспечивает целостность данных и предотвращает ошибки.</li>
    <li><span class="strong">Архитектура</span>: Использование чистой архитектуры (Clean Architecture) с разделением на слои (Controllers, Services, Repositories), что улучшает тестируемость и поддерживаемость кода.</li>
</ul>

<h2>Требования</h2>

<ul>
    <li>.NET 8 SDK</li>
    <li>PostgreSQL</li>
    <li>Postman (для тестирования API)</li>
</ul>

<h2>Установка и запуск</h2>

<ol>
    <li><span class="strong">Клонирование репозитория:</span>
        <pre><code>git clone https://github.com/yourusername/OrderServiceApp.git
cd OrderServiceApp</code></pre>
    </li>
    <li><span class="strong">Настройка базы данных:</span>
        <ul>
            <li>Убедитесь, что PostgreSQL установлен и запущен.</li>
            <li>Создайте базу данных для проекта.</li>
            <li>Обновите строку подключения в файле <code>appsettings.json</code>:</li>
        </ul>
        <pre><code>"ConnectionStrings": {
  "DefaultConnection": "Host=localhost;Database=yourdbname;Username=yourusername;Password=yourpassword"
}</code></pre>
    </li>
    <li><span class="strong">Применение миграций:</span>
        <pre><code>dotnet ef database update</code></pre>
    </li>
    <li><span class="strong">Запуск приложения:</span>
        <pre><code>dotnet run</code></pre>
        Приложение будет доступно по адресу <code>http://localhost:5001</code>.
    </li>
</ol>

<h2>Тестирование API с помощью Postman</h2>

<h3>1. Создание заказа (POST)</h3>

<ul>
    <li><span class="strong">URL</span>: <code>http://localhost:5001/api/orders</code></li>
    <li><span class="strong">Метод</span>: <code>POST</code></li>
    <li><span class="strong">Тело запроса</span>:</li>
</ul>

<pre><code>{
  "customerName": "Alice Johnson",
  "totalAmount": 150.75
}</code></pre>

<ul>
    <li><span class="strong">Ответ</span>:</li>
</ul>

<pre><code>{
  "id": 1,
  "customerName": "Alice Johnson",
  "totalAmount": 150.75
}</code></pre>

<h3>2. Получение списка заказов (GET)</h3>

<ul>
    <li><span class="strong">URL</span>: <code>http://localhost:5001/api/orders</code></li>
    <li><span class="strong">Метод</span>: <code>GET</code></li>
    <li><span class="strong">Ответ</span>:</li>
</ul>

<pre><code>[
  {
    "id": 1,
    "customerName": "Alice Johnson",
    "totalAmount": 150.75
  },
  {
    "id": 2,
    "customerName": "Bob Smith",
    "totalAmount": 200.00
  }
]</code></pre>

<h3>3. Получение информации о конкретном заказе (GET)</h3>

<ul>
    <li><span class="strong">URL</span>: <code>http://localhost:5001/api/orders/{id}</code></li>
    <li><span class="strong">Метод</span>: <code>GET</code></li>
    <li><span class="strong">Пример URL</span>: <code>http://localhost:5001/api/orders/1</code></li>
    <li><span class="strong">Ответ</span>:</li>
</ul>

<pre><code>{
  "id": 1,
  "customerName": "Alice Johnson",
  "totalAmount": 150.75
}</code></pre>

<h3>4. Обновление заказа (PUT)</h3>

<ul>
    <li><span class="strong">URL</span>: <code>http://localhost:5001/api/orders/{id}</code></li>
    <li><span class="strong">Метод</span>: <code>PUT</code></li>
    <li><span class="strong">Пример URL</span>: <code>http://localhost:5001/api/orders/1</code></li>
    <li><span class="strong">Тело запроса</span>:</li>
</ul>

<pre><code>{
  "id": 1,
  "customerName": "Alice Johnson Updated",
  "totalAmount": 175.50
}</code></pre>

<ul>
    <li><span class="strong">Ответ</span>: <code>204 No Content</code></li>
</ul>

<h3>5. Удаление заказа (DELETE)</h3>

<ul>
    <li><span class="strong">URL</span>: <code>http://localhost:5001/api/orders/{id}</code></li>
    <li><span class="strong">Метод</span>: <code>DELETE</code></li>
    <li><span class="strong">Пример URL</span>: <code>http://localhost:5001/api/orders/1</code></li>
    <li><span class="strong">Ответ</span>: <code>204 No Content</code></li>
</ul>

<h2>Заключение</h2>

<p>Этот проект демонстрирует базовые принципы разработки REST API с использованием ASP.NET Core и Entity Framework Core. Он предоставляет возможность создавать, читать, обновлять и удалять заказы, а также управлять схемой базы данных с помощью миграций. Проект может быть расширен и улучшен для более сложных сценариев использования.</p>

</body>
</html>
