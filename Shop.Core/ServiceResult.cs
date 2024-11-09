namespace Shop.Core
{
    public class ServiceResult
    {
        public bool Status { get; }
        public string Error { get; }

        public ServiceResult(bool status, string error = null) 
        {
            Status = status;
            Error = error;
        }        
    }
}
