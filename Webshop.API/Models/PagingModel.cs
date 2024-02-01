namespace Webshop.API.Models
{
    public struct PagingModel<T>
    {
        public IEnumerable<T>? Items { get; private set; }
        public int? Count { get; private set; }
        public string? ErrorMessage { get; private set; }

        public static PagingModel<T> Create(int page, int pageSize, IOrderedQueryable<T> query)
        {
            if (page < 0)
            {
                return new PagingModel<T> { ErrorMessage = "Pages must be 0 or bigger." };
            }

            if (pageSize < 0)
            {
                return new PagingModel<T> { ErrorMessage = "Page size must be 1 or bigger." };
            }

            var totalItems = query.Count();
            if (totalItems == 0)
            {
                return new PagingModel<T> { Count = 0, ErrorMessage = "No items found." };
            }

            if (page * pageSize >= totalItems)
            {
                return new PagingModel<T> { ErrorMessage = $"Page '{page}' not found." };
            }

            var items = query.Skip(page * pageSize).Take(pageSize).ToList();
            return new PagingModel<T>
            {
                Items = items,
                Count = totalItems
            };
        }
    }
}
