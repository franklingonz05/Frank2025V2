using CreditCard.Models.Commons;

public interface IBaseRepository<T>
{
    Task<BaseResponse<T>> GetAsync(string url);
    Task<BaseResponse<IEnumerable<T>>> GetListAsync(string url);
    Task<BaseResponse<IEnumerable<T>>> GetListWithParamsAsync(string url, Dictionary<string, string> parametros);
    Task<BaseResponse<T>> GetWithParamsAsync(string url, Dictionary<string, string> parametros);
    Task<BaseResponse<T>> PostAsync(string url, object requestData);
}