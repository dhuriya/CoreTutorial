namespace CoreActionResult.Models
{
    public class ProductQueryParameters
    {
        public string SearchTerm { get; set; }
        public string Category { get; set; }
        public string SortBy { get; set; }
        public bool SortAscending { get; set; } = true; //Default is True
        public int PageNumber { get; set; } = 1; //Default Page Number
        public int PageSize { get; set; } = 3;
    }
}
