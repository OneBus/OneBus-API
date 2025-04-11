namespace OneBus.Domain.Commons.Result
{
    public class ErrorResult<T> : Result<T>
    {
        private ErrorResult(IEnumerable<Error> errors) : base(default, success: false)
        {
            Errors = errors;
        }

        private ErrorResult(Error error) : this([error]) { }

        public IEnumerable<Error> Errors { get; }

        public static ErrorResult<T> Create(IEnumerable<Error> errors)
        {
            return new ErrorResult<T>(errors);
        }
        
        public static ErrorResult<T> Create(Error error)
        {
            return new ErrorResult<T>(error);
        }
    }
}
