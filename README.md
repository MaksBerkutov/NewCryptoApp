# ������ "CryptoAPP"

___
## �����������
- Newtonsoft json
- Scott Plot v5+

!!! ����� ������������ ��� �������� ��� `CryptoCompare`, ��� ��� ��� ��������� �������������� � ��������� �� ���, ����, ������.
������ ��������� ������ �� �������������� ��� `GetChartPoint` � `CoinCap`.
� CoinGesko OHLC ������������� � ���� ������� ������� `/coins/{id}/ohcl`.

## ������������� ����������
- ����������� ��� N ����� (���������� �������������).
- ���������������� ����������.
- ���������
- MVVM 
- ����� (������, ������, ���)
- ��������� ���������� (�������, ����������, ���)
- ������ � 3 API
    - CoinCap
    - CoinGesko
    - CryptoCompare
- �������
  - ��������� ��������� ����������� ��������
     - Candlestick
     - OHLC
     - Scatter
     - Signal
  - ����������� ������ ������ �� ��������� �������
- ��������� ��������� ���������
- �������� �����
- ����� �����

## ��������� �������
```
|---Image/                              // ����������� ��� �������
|---Core/
|   |---API/                            // �������� ������ � ������� ��� ������ � API
|   |   |---Example/                    // ����� � ������� ����� ���� ��� ������ � ���������� �������
|   |   |   |---Model/                  // DTO ������
|   |   |   |   |   |---Name/           // ���� DTO ��������� ������ ����� ���������� ������������ �������� �� ��� ����� ��������� � ��������� �����
|   |   |   |   |   |   |---Auxiliary/  //��� ����� �� ����� "������������ ������������ ��������"
|   |   |---APIException/               // ����� ��� ������� ��� ���������� 
|   |   |   |---ApiExtentions.cs        // ����� ������� ������� ��� ����������
|   |   |---BaseAPI.cs                  // ������� ����� ������� ������������ ������������ ������
|   |---MVVM/                           // ����� MVVM ��������
|   |   |---Model/                      // ������ MVVM ��������
|   |   |---View/                       // ������������� MVVM ��������
|   |   |---ViewModel/                  // ����������� MVVM ��������
|   |---Lang/                           // ����� ��� ����� ����� (����������, � ������� � ����)
|   |---Services/                       // ������� ������� (������ �������������� ���������� � ������ ��������)
|   |---Logger.cs                       // ����� ���������� �� ������ ������ � ��� ����
|   |---Navigate.cs                     // ����� ���������� �� �������� ����� �������
|   |---Convert.cs                      // ������ ��������� ��� XAML , ��� ������� �� Unix timestamp � DateTime  ...
|   |---Store.cs                        // ������� �������� � ���������� ���������� �������
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
��� ������ ����� ���������������� �������� � ������� `RegisterPage`.
���� � ������ ������������ ������� `Back` �� ����� ������� ����������� �������� (�� � ������� ������ ����� �������� � ����� �������).
�������� ����������� ����� �� ������ ������������ ����� ������� `RegisterStaticPage`.

������:
```cs
Navigate.RegisterStaticPage<MainPageView>();
Navigate.RegisterPage<Page>();
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
�� ����� ������������ ��������� Store!

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

### Store

���������  ��������� ��������� ��� ������� ������ ����� �����������

��� ���� ��� �� �������� ������ ����� ���������������� ��
```cs
Store.Register(Data);
```
��� ������ ������������ �������������.

��� ��������� ������ ���� ��������� ��������. 
������ ������� `GetOrNull<T>` ������� ����� � ������ �� ���������� ����� ������ null.
������ �� `Get<T>()` ������� ����������.
```cs
var dataOrNull = Store.GetOrNull<DataType>();
var datal = Store.Get<DataType>();
```

��� �� ����� ��������� �������� ��������� ��� ����� ���� ������� `ClearAll`
```cs
Store.ClearAll();
```

