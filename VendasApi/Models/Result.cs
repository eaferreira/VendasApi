using Microsoft.Net.Http.Headers;
using VendasApi.Utils;

namespace VendasApi.Models
{
    public class Result
    {
        public object Value { get; set; }
        public string ErrorMessage { get; set; }
        public bool IsError 
        { 
            get 
            {
                return !ErrorMessage.IsNullOrEmpty();
            } 
        }

        public Result()
        {
            
        }

        public Result(object value)
        {
            Value = value;
        }
        public Result(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }
        public Result(object value, string errorMessage)
        {
            Value = value;
            ErrorMessage = errorMessage;
        }
    }
}
