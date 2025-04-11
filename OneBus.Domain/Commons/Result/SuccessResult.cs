namespace OneBus.Domain.Commons.Result
{
    public class SuccessResult<T> : Result<T>
    {
        private SuccessResult(T? value) : base(value, success: true) { }

        public static SuccessResult<T> Create(T? value)
        {
            return new SuccessResult<T>(value);
        } 
    }
}
