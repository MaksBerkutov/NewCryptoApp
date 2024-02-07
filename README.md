# ������ "CryptoAPP"

___

## ������������� ����������
- ����������� ��� N ����� (���������� �������������).
- ������ ���������������� ���������� � ����������.
- MVVM 
- ����� (������, ������, ���)
- ToDo
## ��������� �������
```
|---Image/                         // ����������� ��� �������
|---Core/
    |---API/                       // �������� ������ � ������� ��� ������ � API
    |   |---CoinGesko/             // ����� � ������� ��� ������ � API CoinGesko
        |   |---Model/             // DTO ������ ��� API CoinGesko
    |   |---APIException/          // ����� ��� ������� ��� ���������� 
    |   |   |---ApiExtentions.cs   // ����� ������� ������� ��� ����������
    |   |---BaseAPI.cs             // ������� ����� ��� ��������� ������ � API
    |   |---Respones.cs            // ������� ����� ��� ��������� ������ � API
    |---MVVM/                      // ����� MVVM ��������
    |   |---Model/                 // ������ MVVM ��������
    |   |---View/                  // ������������� MVVM ��������
    |   |---ViewModel/             // ����������� MVVM ��������
    |---Logger.cs                  // ����� ���������� �� ������ ������ � ��� ����
    |---Navigate.cs                // ����� ���������� �� �������� ����� �������
    |---Convert.cs                 // ��������� ��� XAML ������ � ��������� ��� ���������� ��������� WrapPanel �� ��������� �������
```
## ������
### BaseApi
����� ������� ��� ������ ��� ��������� ������ � ��������� API.
��� �� ��������� ��� ����: 
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
��� �� ��� �� ����� ������ ����� ������������ ����, �� ��� �������� ����� ������ ��������� ������� � ��������� �������.
�� �� ����� ���� ����� �� ���� ������� ���� �� �������� � ����� API, � ���� ����� �������� ���������� � ��� ����� API?
�� ��� ��� � �������� �� �� ������� ����� ������� ����� ������������ ��� ��������. ��� � ���� ����� BaseApi.
�� ������ ����� ��������� �������.
-  [x] ������������.
-  [x] ���������� � ��������� ������.
-  [x] ��������� ����������.

��� ��� ������� ������ ����� ��������� � ���:
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
��� �������� ����� ��� ���� � ���� ������ ���� � ��������. ����� � ��������� � ������� ��������� �� �������� ���������� ��������� ������, � �����������.
### Respones

� ������� ������ ���� ����� ��� ������� `GetAsync` ���������� ������ ������ `Respones`.
����� ����� ������ ��� ���� ��� �� ������ ������������ �������� ������. � �� ����� ��� ����:
- `Successful`: ������� �� ��� ������
- `Error`: ���������� � ������� ���� ������ �� ������� 
- `Result`: ��������� (DTO Class) ���� ������ �������
### ApiException
�� ���� ���������� ������ ����� ����������� ����������� Exeption.
### Navigate
����������� ����� ���������� �� ��������. 
��� ������ ����� ���������������� �������� � ������� `RegisterPage`

������:
```cs
Navigate.RegisterPage<MainPageView>();
```

������ � VM �������� ����� ���������� ������� � �����, � ����������� ���������� ������� ��� ����������. 

������:
```cs
    // MV
    public MainWindowViewModel()
	{
        Navigate.RegisterPage<MainPageView>(); //������������ ��������
        ...
        Navigate.OnOpenPage += Navigate_OnOpenPage;// ������ ���������� 
    }

    private void Navigate_OnOpenPage(object content)
    {
        Content = content;
    }

    private object content;

	public object Content {...}
```

������:
```xaml
 <Frame  Content="{Binding Content,Mode=TwoWay}" .../>
Navigate.RegisterFrame(ref MainFrame);
```

�� � ��������� ������� �� ���� ����� �� ������ ������ ��������� � ������� ������� `GoTo` `GoToAsync`.

����� ������ ������ ����������� � ����� ����������� ������� �� ����� � �������������, �������� ���� ����� �������� ���������� ����� ������� ������ ���������� ��������� ���������� � ��������� ������.
� ���� ������� ������� � ������������ �������������� ��� �������� � ������� ����� �� InfoPage � ������� ����� �������� ��������� �������.

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
