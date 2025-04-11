namespace OneBus.Domain.Commons.Result
{
    public abstract class Result<T>
    {
        protected Result(T? value, bool success)
        {
            Value = value;
            Sucess = success;
        }

        public T? Value { get; }

        public bool Sucess { get; }                
    }
}
