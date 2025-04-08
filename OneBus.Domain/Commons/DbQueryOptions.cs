namespace OneBus.Domain.Commons
{
    public class DbQueryOptions
    {
        public DbQueryOptions(bool ignoreQueryFilter = false, params string[]? includes)
        {
            IgnoreQueryFilter = ignoreQueryFilter;
            Includes = includes;
        }

        public bool IgnoreQueryFilter { get; }

        public string[]? Includes { get; }                   
    }
}
