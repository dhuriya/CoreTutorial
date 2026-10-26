using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagementFile.API.Models
{
    public class StudentQueryParameters
    {
        // Search — name ya email mein match
        public string? Search { get; set; }
        // Filter — course exact match
        public string? Course { get; set; }
        // Filter — age range
        public int? MinAge { get; set; }
        public int? MaxAge { get; set; }
        // Sorting
        public string? SortBy { get; set; } = "id";   // default: id
        public string? SortOrder { get; set; } = "asc"; // "asc" ya "desc"
        // Pagination — defaults
        private int _page = 1;
        private int _pageSize = 10;
        private const int MaxPageSize = 100;
        public int Page
        {
            get => _page;
            set => _page = value < 1 ? 1 : value;  // minimum 1
        }
        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = value switch
            {
                < 1 => 10,
                > MaxPageSize => MaxPageSize,
                _ => value
            };
        }
    }
}