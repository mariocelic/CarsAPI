namespace Cars.Common
{
    public class FilteringParameters : IFilteringParameters
    {
        public string FilterString { get; set; }
        public string CurrentFilter { get; set; }
    }
}
