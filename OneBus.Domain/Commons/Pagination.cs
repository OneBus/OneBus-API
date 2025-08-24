namespace OneBus.Domain.Commons
{
    public class Pagination<T>
    {
        /// <summary>
        /// Os dados da página atual.
        /// </summary>
        public IReadOnlyList<T> Items { get; private set; }

        /// <summary>
        /// A página atual (começando do 1, geralmente).
        /// </summary>
        public uint CurrentPage { get; private set; }

        /// <summary>
        /// Quantidade de itens por página.
        /// </summary>
        public uint PageSize { get; private set; }

        /// <summary>
        /// Total de itens no conjunto original (com filtros de página).
        /// </summary>
        public long TotalItems { get; private set; }

        /// <summary>
        /// Número total de páginas (calculado).
        /// </summary>
        public uint TotalPages { get; private set; }

        /// <summary>
        /// Se existe uma página anterior.
        /// </summary>
        public bool HasPreviousPage { get { return CurrentPage > 1; } }

        /// <summary>
        /// Se existe uma próxima página.
        /// </summary>
        public bool HasNextPage { get { return CurrentPage < TotalPages; } }

        public Pagination(IEnumerable<T> items, long totalItems, uint currentPage, uint pageSize)
        {
            Items = [.. items];
            TotalItems = totalItems;
            CurrentPage = currentPage;
            PageSize = pageSize;
            TotalPages = (uint)Math.Ceiling(totalItems / (double)pageSize);
        }
    }
}
