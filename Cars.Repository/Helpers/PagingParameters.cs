namespace Cars.Repository.Helpers
{
    public class PagingParameters : IPagingParameters
    {
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }
    }
}
