namespace E_Comerece_AngularApi.Errors
{
    public class ApiResponse
    {
        public ApiResponse(int statusCode, string message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageByStatusCode(statusCode);
        }

        private string GetDefaultMessageByStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "Bad Request",
                401 => "Not Autherzied",
                404 => "Response Not Found",
                500 => "Server Error Occured",
                //default (_) ==> _
                _ => null
            };

        }

        public int StatusCode { get; set; }
        public string? Message { get; set; }
    }
}
