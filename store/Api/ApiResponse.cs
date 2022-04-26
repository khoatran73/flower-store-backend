namespace store.Api;

public class ApiResponse<TResult> where TResult : class
{
    public bool Success { get; set; }
    public string Message { get; set; }
    public TResult Result { get; set; }

}