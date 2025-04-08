namespace OneBus.Domain.Commons
{
    public class DbQueryOptions
    {
        private DbQueryOptions(bool ignoreQueryFilter, params string[]? includes)
        {
            IgnoreQueryFilter = ignoreQueryFilter;
            Includes = includes;
        }

        public bool IgnoreQueryFilter { get; }

        public string[]? Includes { get; }               
        
        public static DbQueryOptions Create(bool ignoreQueryFilter, params string[]? includes)
        {
            return new DbQueryOptions(ignoreQueryFilter, includes);
        }

        /// <summary>
        /// Applies Ignore query filter to false
        /// </summary>
        /// <returns></returns>
        public static DbQueryOptions Default(params string[]? includes)
        {
            return new DbQueryOptions(ignoreQueryFilter: false, includes);
        }
    }
}
