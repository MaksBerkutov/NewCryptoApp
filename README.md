# ������ "CryptoAPP"

___

## ������������� ����������
- ToDo
- ToDo
- ToDo
## ��������� �������
```
|---Core/
    |---API/                       // �������� ������ � ������� ��� ������ � API
    |   |---APIException/          // ����� ��� ������� ��� ���������� 
    |   |   |---ApiExtentions.cs   // ����� ������� ������� ��� ����������
    |   |---BaseAPI.cs             // ������� ����� ��� ��������� ������ � API
    |   |---Respones.cs            // ������� ����� ��� ��������� ������ � API
    |---Logger/
    |   |---Logger.cs              // ����� ���������� �� ������ ������ � ��� ����
```
## ������
### BaseApi
����� ������� ��� ������ ��� ��������� ������ � ��������� API.
��� �� ��������� ��� ����: 
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
��� �� ��� �� ����� ������ ����� ������������ ����, �� ��� �������� ����� ������ ��������� ������� � ��������� �������.
�� �� ����� ���� ����� �� ���� ������� ���� �� �������� � ����� API, � ���� ����� �������� ���������� � ��� ����� API?
�� ��� ��� � �������� �� �� ������� ����� ������� ����� ������������ ��� ��������. ��� � ���� ����� BaseApi.
�� ������ ����� ��������� �������.
- 1. ������������.
- 2. ���������� � ��������� ������.
- 3. ��������� ����������.
��� ��� ������� ������ ����� ��������� � ���:
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
��� �������� ����� ��� ���� � ���� ������ ���� � ��������. ����� � ��������� � ������� ��������� �� �������� ���������� ��������� ������, � �����������.
### Respones

� ������� ������ ���� ����� ��� ������� `GetAsync` ���������� ������ ������ `Respones`.
����� ����� ������ ��� ���� ��� �� ������ ������������ �������� ������. � �� ����� ��� ����:
- `Successful`: ������� �� ��� ������
- `Error`: ���������� � ������� ���� ������ �� ������� 
- `Result`: ��������� (DTO Class) ���� ������ �������
### ApiException
�� ���� ���������� ������ ����� ����������� 