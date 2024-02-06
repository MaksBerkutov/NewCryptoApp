# Проект "CryptoAPP"

___

## Реализованный функционал
- ToDo
- ToDo
- ToDo
## Структура проекта
```
|---Core/
    |---API/                       // Основные классы и функции для работы с API
    |   |---APIException/          // Папка для классов веб исключений 
    |   |   |---ApiExtentions.cs   // Класс который описует веб исключения
    |   |---BaseAPI.cs             // Базовый класс для упрощения работы с API
    |   |---Respones.cs            // Базовый класс для упрощения работы с API
    |---Logger/
    |   |---Logger.cs              // Класс отвечающий за запись ошибок в лог файл
```
## Классы
### BaseApi
Класс который был создан для упрощения работы с функциями API.
Как бы выглядело без него: 
```cs
class ExampleResponeData {
    public int id {get; set;}
    public string name {get; set;}
}
class ExpampleApi{
    public readonly string ServerUrl = "https/example.com/api";
    
    public async Task<ExampleResponeData> GetData()
    {
        using (HttpClient client = new HttpClient())
        {
            try
            {
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, $"{ServerUrl}/data");
                HttpResponseMessage response = await client.SendAsync(request);
    
                if (!response.IsSuccessStatusCode) return null;
                string content = await response.Content.ReadAsStringAsync();
                var resultData = JsonConvert.DeserializeObject<ExampleResponeData>(content);

                return resultData;
            }
            catch (Exception ex)
            {
                return null 
            }
        }
    }
    public async Task<string> GetInfo()...
}
```
Как по мне по итогу сильно много дублирующего кода, да без сомнения можно методы получения вынести в отдельный функции.
Но всё будет окей ровно до того момента пока мы работаем с одним API, а если нужно добавить интеграция с ещё одним API?
Ну вот тут и приходит на ум создать класс который будет регулировать эти действия. Это и есть класс BaseApi.
Он решает сразу несколько проблем.
- 1. Логированние.
- 2. Выполнение и получение данных.
- 3. Обработка исключений.
Вот как прошлий пример будет выглядить с нми:
```cs
class ExampleResponeData {
    public int id {get; set;}
    public string name {get; set;}
}
class ExpampleApi{
    public  ExpampleApi():base("https/example.com/api",nameof(ExpampleApi)){
        
    }
    
    public async Task<ExampleResponeData> GetData()
    {
        var respone = await GetAsync<ExampleResponeData>("/data");
        if(!respone.Successful){
            throw respone.Error;
        }
        return respone.Result;
    }
    public async Task<string> GetInfo()...
}
```
Как наглядно видно код стал в разы короче чище и понятнее. Также в сравнении с прошлым вариантом мы получили нормальную обработку ошибок, и логирование.
### Respones

В прошлом пример было видно что функция `GetAsync` возврощяет объект класса `Respones`.
Класс нужен только для того что бы удобно обеспечивать хранение данных. В нём всего три поля:
- `Successful`: Успешен ли был запрос
- `Error`: Информация о ошибках если запрос не успешен 
- `Result`: Результат (DTO Class) если запрос успешен
### ApiException
Не чего особенного просто класс расширяющий 