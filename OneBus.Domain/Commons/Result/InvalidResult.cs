namespace OneBus.Domain.Commons.Result
{
    public class InvalidResult<T> : Result<T>
    {
        private InvalidResult(IEnumerable<Error> errors) : base(default, success: false)
        {
            Errors = errors;
        }

        private InvalidResult(Error error) : this([error]) { }

        public IEnumerable<Error> Errors { get; }

        public static InvalidResult<T> Create(IEnumerable<Error> errors)
        {
            return new InvalidResult<T>(errors);
        }

        public static InvalidResult<T> Create(Error error)
        {
            return new InvalidResult<T>(error);
        }
    }
}
