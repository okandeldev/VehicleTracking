namespace Core.Shared
{
    public class ErrorResponse<T>
    { 
        public List<string> Errors { get; set; }
        public int StatusCode { get; set; }
         
        public static ErrorResponse<T> Fail(string error, int statusCode)
        {
            return new ErrorResponse<T> { StatusCode = statusCode, Errors = new List<string> { error } };
        }
        public static ErrorResponse<T> Fail(List<string> errors, int statusCode)
        {
            return new ErrorResponse<T> { StatusCode = statusCode, Errors = errors };
        }
    }
}
