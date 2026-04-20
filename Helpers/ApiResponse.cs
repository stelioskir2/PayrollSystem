namespace PayrollSystem.Helpers
{
    public class ApiResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public int StatusCode { get; set; }
        public object Data { get; set; }

        public static ApiResponse Ok(object data)
        {
            return new ApiResponse 
            {   
                Success = true,
                StatusCode = 200,
                Message = "OK",
                Data = data 
            };
        }
        public static ApiResponse NotFound(string message)
        {
            return new ApiResponse
            {
                Success = false,
                StatusCode = 404,
                Message = message,
                Data = null
            };
        }
    }
}