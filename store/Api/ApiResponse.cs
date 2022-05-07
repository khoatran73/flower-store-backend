namespace store.Api;

public class ApiResponse<TResult>
{
    public bool Success { get; set; }
    public string Message { get; set; }
    public TResult Result { get; set; }

}