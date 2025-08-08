namespace Application.Services
{
    public class ServiceResponse<T>
    {
        public T? Data { get; set; }
        public string Message { get; set; }
        public bool Success { get; set; } = true;
        public ServiceResponse()
        {

        }
        public ServiceResponse(T Data, string Message)
        {

        }
        public ServiceResponse(T Data, bool Success, string Message)
        {

        }

    }
    
}
