namespace RealtyInvest.Common.ServiceResult
{
    public class ServiceResult<T>
    {
        public T Value { get; set; }
        public Status ServiceStatus { get; set; }
        public ServiceResult(T value = default(T), Status status = Status.Error)
        {
            
        }
    }

    public class ServiceResult : ServiceResult<object>
    {
        public ServiceResult(object value = null, Status status = Status.Error)
        {

        }
    }
}
