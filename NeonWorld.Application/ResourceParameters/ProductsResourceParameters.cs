namespace NeonWorld.BackendApi.ResourceParameters
{
    public class ProductsResourceParameters
    {
        const int maxPageSize = 20;
        public int mainCategory { get; set; }
        public string searchQuery { get; set; }
        public string Sort { get; set; }
        public string Order { get; set; }
        public int Page { get; set; } = 1;
        public decimal Min { get; set; }
        public decimal Max { get; set; }

        private int _pageSize = 10;
        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > maxPageSize) ? maxPageSize : value;
        }
    }
}
