namespace apiToDo.Middlewares
{
    public class ErrorResponse
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }


        public ErrorResponse(int statusCode, string message, string details = "")
        {
            StatusCode = statusCode;
            Message = message;

        }
    }
}
