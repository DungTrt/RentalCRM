namespace RentalCRM.ViewModel
{
    public class TableSearchViewModel<T>
    {
        public string Keyword { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string SortType { get; set; }
        public string ColumnSort { get; set; }
        public T SearchOptions { get; set; }
    }
}
