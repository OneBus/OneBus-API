namespace OneBus.Domain.Commons.Result
{
    public class NotFoundResult<T> : Result<T>
    {
        private NotFoundResult(IEnumerable<Error> errors) : base(default, success: false)
        {
            Errors = errors;
        }

        private NotFoundResult(Error error) : this([error]) { }

        public IEnumerable<Error> Errors { get; }

        public static NotFoundResult<T> Create(IEnumerable<Error> errors)
        {
            return new NotFoundResult<T>(errors);
        }

        public static NotFoundResult<T> Create(Error error)
        {
            return new NotFoundResult<T>(error);
        }       
    }
}
