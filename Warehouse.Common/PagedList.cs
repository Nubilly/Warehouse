namespace Warehouse.Common
{
    public class PagedList<TItem>
    {
        public List<TItem> Items { get; set; } = new List<TItem>();
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
    }
}