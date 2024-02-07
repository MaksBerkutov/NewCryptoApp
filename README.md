# Проект "CryptoAPP"

___

## Реализованный функционал
- Отображение топ N валют (количество регулируеться).
- Логику многостраничного приложения с навигацией.
- MVVM 
- Поиск (Монеты, Обмены, Нфт)
- ToDo
## Структура проекта
```
|---Image/                         // Изображения для проекта
|---Core/
    |---API/                       // Основные классы и функции для работы с API
    |   |---CoinGesko/             // Папка с классом для работы с API CoinGesko
        |   |---Model/             // DTO модели для API CoinGesko
    |   |---APIException/          // Папка для классов веб исключений 
    |   |   |---ApiExtentions.cs   // Класс который описует веб исключения
    |   |---BaseAPI.cs             // Базовый класс для упрощения работы с API
    |   |---Respones.cs            // Базовый класс для упрощения работы с API
    |---MVVM/                      // Файлы MVVM Паттерна
    |   |---Model/                 // Модели MVVM Паттерна
    |   |---View/                  // Представления MVVM Паттерна
    |   |---ViewModel/             // Отображения MVVM Паттерна
    |---Logger.cs                  // Класс отвечающий за запись ошибок в лог файл
    |---Navigate.cs                // Класс отвечающий за переходы между формами
    |---Convert.cs                 // Конвертер для XAML нужный в оснновном для корректной настройки WrapPanel на некоторых страниц
```
## Классы
### BaseApi
Класс который был создан для упрощения работы с функциями API.
Как бы выглядело без него: 
```cs
class ModelDTO {
    public int id {get; set;}
    public string name {get; set;}
}
class ExpampleApi{
    public readonly string ServerUrl = "https/example.com/api";
    
    public async Task<ModelDTO> GetData()
    {
        using (HttpClient client = new HttpClient())
        {
            try
            {
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, $"{ServerUrl}/data");
                HttpResponseMessage response = await client.SendAsync(request);
    
                if (!response.IsSuccessStatusCode) return null;
                string content = await response.Content.ReadAsStringAsync();
                var resultData = JsonConvert.DeserializeObject<ModelDTO>(content);

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
-  [x] Логированние.
-  [x] Выполнение и получение данных.
-  [x] Обработка исключений.

Вот как прошлий пример будет выглядить с нми:
```cs
class ModelDTO {
    public int id {get; set;}
    public string name {get; set;}
}
class ExpampleApi{
    private readonly BaseApi instance = new BaseApi("https/example.com/api",nameof(ExpampleApi));
    public  ExpampleApi(){
        
    }
    
    public async Task<ModelDTO> GetData()
    {
        return await instance.StandartHandler<FindDTO>("example");
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
Не чего особенного просто класс расширяющий стандартный Exeption.
### Navigate
Статичиский класс отвечающий за переходы. 
Для начала нужно зарегистрировать страницу с помощью `RegisterPage`

Пример:
```cs
Navigate.RegisterPage<MainPageView>();
```

Дальше в VM страници нужно прибиндить контент к фрему, и реализовать обработчик события для обновления. 

Пример:
```cs
    // MV
    public MainWindowViewModel()
	{
        Navigate.RegisterPage<MainPageView>(); //Регестрируем страници
        ...
        Navigate.OnOpenPage += Navigate_OnOpenPage;// Создаём обработчик 
    }

    private void Navigate_OnOpenPage(object content)
    {
        Content = content;
    }

    private object content;

	public object Content {...}
```

Биндим:
```xaml
 <Frame  Content="{Binding Content,Mode=TwoWay}" .../>
Navigate.RegisterFrame(ref MainFrame);
```

Ну и остаеться перейти на вашу форму из любого уголка программы с помощью методов `GoTo` `GoToAsync`.

Также данные методы перегружены и имеют возможность перейти на форму с конструктором, полезнно если нужно например отобразить форму которая должна отображать подробную информацию о выбранном товаре.
В этом проекте функция с прараметрами использовалась для перехода с главной формы на InfoPage в которую нужно передать выбранный элемент.

```cs
  //MainPageViewModel.cs
  private CoinsDTO selectedCoin = null;
  public CoinsDTO SelectedCoin
  {
      get => selectedCoin;
      set => SetProperty(ref selectedCoin, value, nameof(SelectedCoin)); 
       
  }

  public async void GoToGraphics(object obj = null)
  {
      await Navigate.GoToAsync(nameof(InfoPageView), SelectedCoin);
  }
  ...

  //InfoView.cs
  public InfoPageView(CoinsDTO selcted)
  {
      InitializeComponent();
      ((InfoPageViewModel)DataContext).SelectedDto = selcted;
  }
  ...

  //InfoViewModel.cs
  public CoinsDTO SelectedDto {  get; set; }
  ...

```
