namespace OneBus.Domain.Commons.Result
{
    public class NotFoundResult<T> : Result<T>
    {
        private NotFoundResult() : base(default, success: false) { }
    
        public static NotFoundResult<T> Create()
        {
            return new NotFoundResult<T>();
        }
    }
}
