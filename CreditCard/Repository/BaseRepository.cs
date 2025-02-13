using System.Net.Http;
using System.Text;
using System.Text.Json;
using CreditCard.Models.Commons;

public class BaseRepository<T> : IBaseRepository<T>
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly JsonSerializerOptions _jsonOptions;

    public BaseRepository(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
        _jsonOptions = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
    }

    private HttpClient CreateClient()
    {
        return _httpClientFactory.CreateClient("ApiClient"); // Reutiliza instancias
    }

    // Obtener un solo recurso
    public async Task<BaseResponse<T>> GetAsync(string url)
    {
        using var client = CreateClient();
        var response = await client.GetAsync(url);
        return await ProcesarRespuesta<T>(response);
    }

    //Obtener una lista de recursos
    public async Task<BaseResponse<IEnumerable<T>>> GetListAsync(string url)
    {
        using var client = CreateClient();
        var response = await client.GetAsync(url);
        return await ProcesarRespuesta<IEnumerable<T>>(response);
    }


    //Obtener una lista de recursos con parámetros en la URL
    public async Task<BaseResponse<IEnumerable<T>>> GetListWithParamsAsync(string url, Dictionary<string, string> parametros)
    {
        using var client = CreateClient();
        string fullUrl = url;
        if (parametros != null && parametros.Count > 0)
        {
            var queryString = await new FormUrlEncodedContent(parametros).ReadAsStringAsync();
            fullUrl = $"{url}?{queryString}";
        }

        var response = await client.GetAsync(fullUrl);
        return await ProcesarRespuesta<IEnumerable<T>>(response);
    }

    //GET con parámetros en la URL
    public async Task<BaseResponse<T>> GetWithParamsAsync(string url, Dictionary<string, string> parametros)
    {
        using var client = CreateClient();
        var queryString = new FormUrlEncodedContent(parametros).ReadAsStringAsync().Result;
        var fullUrl = $"{url}?{queryString}";
        var response = await client.GetAsync(fullUrl);
        return await ProcesarRespuesta<T>(response);
    }

    //POST con JSON en el body
    public async Task<BaseResponse<T>> PostAsync(string url, object requestData)
    {
        using var client = CreateClient();

        var jsonContent = new StringContent(JsonSerializer.Serialize(requestData, _jsonOptions), Encoding.UTF8, "application/json");
        var response = await client.PostAsync(url, jsonContent);
        return await ProcesarRespuesta<T>(response);
    }

    //Método para procesar respuestas HTTP
    private async Task<BaseResponse<TResponse>> ProcesarRespuesta<TResponse>(HttpResponseMessage response)
    {
        var resultado = new BaseResponse<TResponse> { IsSuccess = response.IsSuccessStatusCode };

        var jsonResponse = await response.Content.ReadAsStringAsync();

        if (response.IsSuccessStatusCode)
        {
            resultado = JsonSerializer.Deserialize<BaseResponse<TResponse>>(jsonResponse, _jsonOptions);
        }
        else
        {
            resultado.Message = $"Error: {response.ReasonPhrase}";
            resultado.Errors["StatusCode"] = response.StatusCode.ToString();
        }

        return resultado;
    }
}
