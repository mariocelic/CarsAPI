namespace Cars.Repository.Helpers
{
    public class FilteringParameters : IFilteringParameters
    {
        public string FilterString { get; set; }
        public string CurrentFilter { get; set; }
    }
}
