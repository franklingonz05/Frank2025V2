using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCard.Core.Domain.Commons
{
    public class BaseResponse<T>
    {
        public bool IsSuccess { get; set; }
        public T? Data { get; set; }
        public int? TotalRecords { get; set; }
        public string? Message { get; set; }
        public IEnumerable<ValidationFailure>? ValidationFailure { get; set; }

        public Dictionary<string, string> Errors { get; set; }

        public BaseResponse()
        {
            Errors = new Dictionary<string, string>();
        }
    }
}
