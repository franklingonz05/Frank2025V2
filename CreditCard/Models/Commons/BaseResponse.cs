namespace CreditCard.Models.Commons
{
    public class  BaseResponse<T>
    {
        public bool IsSuccess { get; set; }
        public T? Data { get; set; }
        public int? TotalRecords { get; set; }
        public string? Message { get; set; }
        public Dictionary<string, string> Errors { get; set; }

        public BaseResponse()
        {
            Errors = new Dictionary<string, string>();
        }
    }
}
