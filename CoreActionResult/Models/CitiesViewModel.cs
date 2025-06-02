namespace CoreActionResult.Models
{
    public class CitiesViewModel
    {
        public IEnumerable<int> SelectedCityIds { get; set; }
        public IEnumerable<City> Cities { get; set; }
    }
}
